// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-30</date>

using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces;
using PlayerControls._mocks;






namespace PlayerControls.Themes
{
	/// <summary>Interaction logic for RingPlayer24.xaml</summary>
	public partial class ScheduledFramePresenter : UserControl
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="BufferedFrames" /> property.</summary>
		public static readonly DependencyProperty BufferedFramesProperty = DependencyProperty.Register("BufferedFrames", typeof(ObservableCollection<IScheduledFrame>), typeof(ScheduledFramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			//PropertyChangedCallback = (o, args) => ((ScheduledFramePresenter)o).BufferedPagesDpChanged((ObservableCollection<IScheduledFrame>)args.OldValue, (ObservableCollection<IScheduledFrame>)args.NewValue),
			DefaultValue = default(ObservableCollection<IScheduledFrame>),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="IsRunning" /> property.</summary>
		public static readonly DependencyProperty IsRunningProperty = DependencyProperty.Register("IsRunning", typeof(bool), typeof(ScheduledFramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			PropertyChangedCallback = (o, args) => ((ScheduledFramePresenter) o).IsRunningDpChanged((bool) args.OldValue, (bool) args.NewValue),
			DefaultValue = true,
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="ItemsSource" /> property.</summary>
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IScheduledFrame[]), typeof(ScheduledFramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			PropertyChangedCallback = (o, args) => ((ScheduledFramePresenter) o).ItemsSourceDpChanged((IScheduledFrame[]) args.OldValue, (IScheduledFrame[]) args.NewValue),
			DefaultValue = default(IScheduledFrame[]),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		#region DP Changed
		private void IsRunningDpChanged(bool argsOldValue, bool argsNewValue)
		{
			if (argsNewValue)
				Start();
			else
				Stop();
		}

		private void ItemsSourceDpChanged(IScheduledFrame[] argsOldValue, IScheduledFrame[] argsNewValue)
		{
			Stop();
			if (ItemsSource == null || ItemsSource.Length == 0)
				return;


			var timeOfDay = DateTime.Now.TimeOfDay;
			for (var i = 0; i < ItemsSource.Length; i++)
			{
				if (ItemsSource[i].FrameStartTime < timeOfDay)
					continue;
				if (ItemsSource[i].FrameStartTime == timeOfDay)
				{
					LoopIndex = i - 1;
					break;
				}
				LoopIndex = i - 1 - 1; //cause GetNextRingElementToInsert increases by one
				break;
			}
			var oldCount = BufferedFrames.Count;
			for (var i = oldCount - 2; i >= 0; i--)
				BufferedFrames.RemoveAt(i);

			Push();
			Push();
			Push();

			if (oldCount != 0)
				Pop();
			if (IsRunning)
				Start();
		}

		private void VisibleDpChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			var newVal = args.NewValue as bool?;
			if (newVal == true && _activeBeforeInvisible != null)
				IsRunning = _activeBeforeInvisible.Value;
			else if (newVal == false)
			{
				_activeBeforeInvisible = IsRunning;
				IsRunning = false;
			}
		}
		#endregion


		/// <summary>The amount of time before the frame changes the videos of the next frame will be started.</summary>
		private static readonly TimeSpan VideoStartOffset = TimeSpan.FromMilliseconds(1000);
		private bool? _activeBeforeInvisible;


		/// <summary>
		///     A timer which will tick about the time specified in the <see cref="VideoStartOffset" />, before the
		///     <see cref="FrameSwitchTimer" /> ticks. This helps to start videos before a frame switch occurs.
		/// </summary>
		private DispatcherTimer VideoStartTimer { get; } = new DispatcherTimer();
		/// <summary>A timer which ticks when the current <see cref="IScheduledFrame" /> has played its desired time.</summary>
		private DispatcherTimer FrameSwitchTimer { get; } = new DispatcherTimer();
		/// <summary>The loop index points to the element which was added at last.</summary>
		private int LoopIndex { get; set; }

		private IScheduledFrame CurrentFrame => BufferedFrames[BufferedFrames.Count - 1];
		private IScheduledFrame NextFrame => BufferedFrames[BufferedFrames.Count - 2];


		public ScheduledFramePresenter()
		{
			BufferedFrames = new ObservableCollection<IScheduledFrame>();
			FrameSwitchTimer.Tick += FrameSwitchTimer_Ticked;
			VideoStartTimer.Tick += VideoStartTimer_Ticked;
			IsVisibleChanged += VisibleDpChanged;
			InitializeComponent();

		}

		/// <summary>The <see cref="IScheduledFrame" />s which are currently loaded into the UI.</summary>
		public ObservableCollection<IScheduledFrame> BufferedFrames
		{
			get { return (ObservableCollection<IScheduledFrame>) GetValue(BufferedFramesProperty); }
			set { SetValue(BufferedFramesProperty, value); }
		}

		/// <summary>A list of <see cref="IScheduledFrame" />s which will be played endless inside a absolute timed (24H) loop.</summary>
		public IScheduledFrame[] ItemsSource
		{
			get { return (IScheduledFrame[]) GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		/// <summary>True if the <see cref="ScheduledFramePresenter" /> is running</summary>
		public bool IsRunning
		{
			get { return (bool) GetValue(IsRunningProperty); }
			set { SetValue(IsRunningProperty, value); }
		}

		/// <summary>Starts the current visible <see cref="IScheduledFrame" /> in a safe manner.</summary>
		private void Start()
		{
			if (IsLoaded)
				BeginFrame();
			else
				Loaded += Start_OnLoaded;
		}

		private void Start_OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			Loaded -= Start_OnLoaded;
			BeginFrame();
		}

		/// <summary>Stops all running timers.</summary>
		private void Stop()
		{
			VideoStartTimer.Stop();
			FrameSwitchTimer.Stop();
		}

		/// <summary>Occurs whenever a frame switch is necessary.</summary>
		private void FrameSwitchTimer_Ticked(object sender, EventArgs eventArgs)
		{
			Stop();
			Push();
			Pop();
			BeginFrame();
		}

		/// <summary>Occurs whenever the video of the next frame should be started.</summary>
		private void VideoStartTimer_Ticked(object sender, EventArgs e)
		{
			VideoStartTimer.Stop();

			var offset = DateTime.Now.TimeOfDay - NextFrame.FrameStartTime.Subtract(VideoStartOffset);
			Get_NextFramePresenter().StartVideos(offset < TimeSpan.Zero ? TimeSpan.Zero : offset);
		}

		/// <summary>Starts evrything which has to do with the current visible Frame.</summary>
		private void BeginFrame()
		{
			if (!IsRunning)
				return;
			while (true)
			{
				if (CurrentFrame != ItemsSource[ItemsSource.Length - 1] && DateTime.Now.TimeOfDay >= NextFrame.FrameStartTime)
				{
					// Jump over already invalid pages.
					Push();
					Pop();
					continue;
				}

				if (CurrentFrame != ItemsSource[ItemsSource.Length - 1]) // Should solve problem with day change. CS.16.09.12
					FrameSwitchTimer.Interval = NextFrame.FrameStartTime - DateTime.Now.TimeOfDay;
				else
					FrameSwitchTimer.Interval = TimeSpan.FromDays(1).Subtract(DateTime.Now.TimeOfDay);

				VideoStartTimer.Interval = FrameSwitchTimer.Interval - (FrameSwitchTimer.Interval < VideoStartOffset ? TimeSpan.Zero : VideoStartOffset);


				VideoStartTimer.Start();
				FrameSwitchTimer.Start();

				var playingPresenter = Get_CurrentFramePresenter();
				var transitionOffset = DateTime.Now.TimeOfDay - CurrentFrame.FrameStartTime;
				playingPresenter?.StartTransitions(transitionOffset < TimeSpan.Zero ? TimeSpan.Zero : transitionOffset);

				var videoOffset = DateTime.Now.TimeOfDay - NextFrame.FrameStartTime.Subtract(VideoStartOffset);
				playingPresenter?.StartVideos(videoOffset < TimeSpan.Zero ? TimeSpan.Zero : videoOffset);
				break;
			}
		}

		/// <summary>Pushes the next <see cref="IDuratedFrame" /> from the <see cref="ItemsSource" /> and inserts it into the
		///     <see cref="BufferedFrames" />.</summary>
		private void Push()
		{
			BufferedFrames.Insert(0, ItemsSource[++LoopIndex % ItemsSource.Length]);
		}

		/// <summary>Pops the current playing <see cref="IDuratedFrame" /> from the <see cref="BufferedFrames" />.</summary>
		private void Pop()
		{
			BufferedFrames.RemoveAt(BufferedFrames.Count - 1);
		}

		/// <summary>Returns the frame presenter for the current playing <see cref="IScheduledFrame" /> inside the
		///     <see cref="BufferedFrames" />.</summary>
		private FramePresenter Get_CurrentFramePresenter()
		{
			return ((ContentPresenter) BufferedItemsControl.ItemContainerGenerator.ContainerFromIndex(BufferedFrames.Count - 1)).GetVisualChildByCondition<FramePresenter>(a => true);
		}

		/// <summary>Returns the frame presenter for the next playing <see cref="IScheduledFrame" /> inside the <see cref="BufferedFrames" />
		///     .</summary>
		private FramePresenter Get_NextFramePresenter()
		{
			return ((ContentPresenter) BufferedItemsControl.ItemContainerGenerator.ContainerFromIndex(BufferedFrames.Count - 2)).GetVisualChildByCondition<FramePresenter>(a => true);
		}

		/// <summary>Returns a prefilled <see cref="IScheduledFrame" /> array.</summary>
		public static IScheduledFrame[] GetMock()
		{
			return MockScheduledFrame.GetSamples();
		}
	}

}