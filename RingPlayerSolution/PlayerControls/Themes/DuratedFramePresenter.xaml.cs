// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-30</date>

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces;
using PlayerControls._mocks;






namespace PlayerControls.Themes
{
	/// <summary>Interaction logic for RingPlayer.xaml</summary>
	public partial class DuratedFramePresenter : UserControl, IDisposable
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="BufferedFrames" /> property.</summary>
		public static readonly DependencyProperty BufferedFramesProperty = DependencyProperty.Register("BufferedFrames", typeof(ObservableCollection<IDuratedFrame>), typeof(DuratedFramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			//PropertyChangedCallback = (o, args) => ((DuratedFramesPresenter)o).BufferedFramesDpChanged((ObservableCollection<IDuratedFrame>)args.OldValue, (ObservableCollection<IDuratedFrame>)args.NewValue),
			DefaultValue = default(ObservableCollection<IDuratedFrame>),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="IsRunning" /> property.</summary>
		public static readonly DependencyProperty IsRunningProperty = DependencyProperty.Register("IsRunning", typeof(bool), typeof(DuratedFramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			PropertyChangedCallback = (o, args) => ((DuratedFramePresenter) o).IsRunningDpChanged((bool) args.OldValue, (bool) args.NewValue),
			DefaultValue = true,
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="ItemsSource" /> property.</summary>
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IDuratedFrame[]), typeof(DuratedFramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			PropertyChangedCallback = (o, args) => ((DuratedFramePresenter) o).ItemsSourceDpChanged((IDuratedFrame[]) args.OldValue, (IDuratedFrame[]) args.NewValue),
			DefaultValue = default(IDuratedFrame[]),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		#region DP Changed
		private void IsRunningDpChanged(bool oldValue, bool newValue)
		{
			if (newValue)
				Start();
			else
				Stop();
		}

		private void ItemsSourceDpChanged(IDuratedFrame[] oldValue, IDuratedFrame[] newValue)
		{
			Stop();
			BufferedFrames.Clear();

			if (newValue == null || newValue.Length == 0)
				return;
			LoopIndex = -1; //cause GetNextRingElementToInsert increases by one

			Push();
			Push();
			Push();

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


		/// <summary>Returns a prefilled <see cref="IDuratedFrame" /> array.</summary>
		public static IDuratedFrame[] GetMock()
		{
			return MockDuratedFrame.GetSamples();
		}

		private bool? _activeBeforeInvisible;


		/// <summary>
		///     A timer which will tick about the time specified in the <see cref="VideoStartOffset" />, before the
		///     <see cref="FrameSwitchTimer" /> ticks. This helps to start videos before a frame switch occurs.
		/// </summary>
		DispatcherTimer VideoStartTimer { get; } = new DispatcherTimer();


		/// <summary>A timer which ticks after the current <see cref="IDuratedFrame" /> has played its duration.</summary>
		private DispatcherTimer FrameSwitchTimer { get; } = new DispatcherTimer();


		/// <summary>The loop index points to the element which was added at last.</summary>
		private int LoopIndex { get; set; }


		private IDuratedFrame CurrentFrame => BufferedFrames[BufferedFrames.Count - 1];

		public DuratedFramePresenter()
		{
			BufferedFrames = new ObservableCollection<IDuratedFrame>();
			IsVisibleChanged += VisibleDpChanged;


			FrameSwitchTimer.Tick += FrameSwitchTimer_Ticked;
			VideoStartTimer.Tick += VideoStartTimer_Ticked;

			InitializeComponent();
		}


		#region Overrides/Interfaces
		public void Dispose()
		{
			ItemsSource = null;
		}
		#endregion


		/// <summary>If true the <see cref="DuratedFramePresenter" /> is running.</summary>
		public bool IsRunning
		{
			get { return (bool) GetValue(IsRunningProperty); }
			set { SetValue(IsRunningProperty, value); }
		}

		/// <summary>The <see cref="IDuratedFrame" />s which are currently loaded into the UI.</summary>
		public ObservableCollection<IDuratedFrame> BufferedFrames
		{
			get { return (ObservableCollection<IDuratedFrame>) GetValue(BufferedFramesProperty); }
			set { SetValue(BufferedFramesProperty, value); }
		}

		/// <summary>A list of <see cref="IDuratedFrame" />s which will be played endless inside a loop.</summary>
		public IDuratedFrame[] ItemsSource
		{
			get { return (IDuratedFrame[]) GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		/// <summary>Starts the presenter by <see cref="BeginFrame" /> in a safe manner.</summary>
		private void Start()
		{
			if (!IsLoaded)
				Loaded += Start_OnLoaded;
			else
				BeginFrame();
		}

		private void Start_OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			Loaded -= Start_OnLoaded;
			BeginFrame();
		}

		private void Stop()
		{
			VideoStartTimer.Stop();
			FrameSwitchTimer.Stop();
		}

		private void FrameSwitchTimer_Ticked(object sender, EventArgs eventArgs)
		{
			Stop();
			if (!IsRunning)
				return;
			Push();
			Pop();
			BeginFrame();
		}


		private void VideoStartTimer_Ticked(object sender, EventArgs e)
		{
			VideoStartTimer.Stop();
			if (!IsRunning)
				return;

			Get_NextFramePresenter()?.StartVideos();
		}



		/// <summary>Plays the current active <see cref="IDuratedFrame" />, and set ups all timers for ending the
		///     <see cref="IDuratedFrame" />.</summary>
		private void BeginFrame()
		{
			if (!IsRunning)
				return;

			FrameSwitchTimer.Interval = CurrentFrame.FrameDuration.TimeSpan;

			if (FrameSwitchTimer.Interval <= TimeSpan.Zero)
				throw new InvalidDataException($"The {nameof(IDuratedFrame)} can not have a duration <= [{TimeSpan.Zero}]");

			VideoStartTimer.Interval = FrameSwitchTimer.Interval - (FrameSwitchTimer.Interval < VideoStartOffset ? TimeSpan.Zero : VideoStartOffset);

			VideoStartTimer.Start();
			FrameSwitchTimer.Start();

			var playingPresenter = Get_CurrentFramePresenter();
			playingPresenter?.StartTransitions();
			playingPresenter?.StartVideos();
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

		/// <summary>Returns the frame presenter for the current playing <see cref="IDuratedFrame" /> inside the
		///     <see cref="BufferedFrames" />.</summary>
		private FramePresenter Get_CurrentFramePresenter()
		{
			var container = (ContentPresenter) BufferedItemsControl.ItemContainerGenerator.ContainerFromIndex(BufferedFrames.Count - 1);
			return container?.GetVisualChildByCondition<FramePresenter>(a => true);
		}

		/// <summary>Returns the frame presenter for the next playing <see cref="IDuratedFrame" /> inside the <see cref="BufferedFrames" />.</summary>
		private FramePresenter Get_NextFramePresenter()
		{
			var container = (ContentPresenter) BufferedItemsControl.ItemContainerGenerator
																	.ContainerFromIndex(BufferedFrames.Count - 2);
			return container?.GetVisualChildByCondition<FramePresenter>(a => true);
		}
	}
}