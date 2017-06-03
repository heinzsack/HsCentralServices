// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-01-28</creation-date>
// <modified>2017-05-05 17:54</modify-date>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls._sys.engines;
using PlayerControls._sys.pocos.presentation;






namespace PlayerControls.Themes
{
	/// <summary>Interaction logic for RingPlayer24.xaml</summary>
	public partial class FrameRingPresenter : UserControl
	{


		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="RingEngine" /> property.</summary>
		public static readonly DependencyProperty RingEngineProperty = DependencyProperty.Register("RingEngine", typeof(RingEngine<IFrameRingEntry>), typeof(FrameRingPresenter), new FrameworkPropertyMetadata
																																												{
																																													BindsTwoWayByDefault = true,
																																													//PropertyChangedCallback = (o, args) => ((ScheduledFramePresenter)o).RingEngineDpChanged((RingEngine<IScheduledFrame>)args.OldValue, (RingEngine<IScheduledFrame>)args.NewValue),
																																													DefaultValue = default(RingEngine<IFrameRingEntry>),
																																													DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																												});

		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Ring" /> property.</summary>
		public static readonly DependencyProperty RingProperty = DependencyProperty.Register("Ring", typeof(IFrameRing), typeof(FrameRingPresenter), new FrameworkPropertyMetadata
																																					{
																																						BindsTwoWayByDefault = true,
																																						PropertyChangedCallback = (o, args) => ((FrameRingPresenter) o).RingDpChanged((IFrameRing) args.OldValue, (IFrameRing) args.NewValue),
																																						DefaultValue = default(IFrameRing),
																																						DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																					});
		#endregion


		/// <summary>
		///     The amount of time before the <see cref="IFrameRingEntry" /> changes the videos of the next
		///     <see cref="IFrameRingEntry" /> will be started.
		/// </summary>
		private static readonly TimeSpan VideoStartOffset = TimeSpan.FromMilliseconds(1000);
		/// <summary>
		///     The amount of time before the <see cref="IFrameRingEntry" /> changes the current <see cref="IFrameRingEntry" /> will be
		///     faded out.
		/// </summary>
		private static readonly TimeSpan FadeOutOffset = TimeSpan.FromMilliseconds(350);

		/// <summary>Returns a prefilled <see cref="IFrameRingEntry" /> array.</summary>
		public static IRing<IFrameRingEntry> GetMock(DateTime startTime, TimeSpan duration)
		{
			return PocoFrameRing.Mock.Get(startTime, duration);
		}

		private bool? _activeBeforeInvisible;



		/// <summary>
		///     A timer which will tick about the time specified in the <see cref="VideoStartOffset" />, before the
		///     <see cref="IFrameRingEntry" /> changes. This helps to start videos before a <see cref="IFrameRingEntry" /> switch occurs.
		/// </summary>
		private DispatcherTimer VideoStartTimer { get; } = new DispatcherTimer();


		#region EVENTS
		/// <summary>
		///     Used whenever a <see cref="IFrameRingEntry" /> is added to the <see cref="RingEngine{TItem}.Buffer" /> and has a
		///     <see cref="IFrameRingEntry.RingEntryInterrupt" /> applied.
		/// </summary>
		public event Delegate0 InterruptFrameAvailable;
		#endregion



		public FrameRingPresenter()
		{
			VideoStartTimer.Tick += VideoStartTimer_Ticked;
			IsVisibleChanged += VisibleDpChanged;
			RingEngine = new RingEngine<IFrameRingEntry>();
			RingEngine.CurrentEntryChanged += NextRingElement;
			RingEngine.BufferedEntryAdded += BufferedEntryAdded;
			RingEngine.InterruptEntryAvailable += args =>
			{
				var resultArgs = new InterruptArgs(args.InterruptName);
				InterruptFrameAvailable?.Invoke(resultArgs);
				args.Result.RingEntryFrame = resultArgs.Result;
			};

			InitializeComponent();

			Loaded += OnLoaded;
		}


		/// <summary>The <see cref="IRing" /> which is meant to be played.</summary>
		public IFrameRing Ring
		{
			get => (IFrameRing) GetValue(RingProperty);
			set => SetValue(RingProperty, value);
		}

		/// <summary>The <see cref="RingEngine{TItem}" /> which is used to play the <see cref="Ring" />.</summary>
		public RingEngine<IFrameRingEntry> RingEngine
		{
			get => (RingEngine<IFrameRingEntry>) GetValue(RingEngineProperty);
			set => SetValue(RingEngineProperty, value);
		}


		#region DP Changed
		private void RingDpChanged(IFrameRing argsOldValue, IFrameRing argsNewValue)
		{
			RingEngine.Ring = argsNewValue;
		}

		private void VisibleDpChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			var newVal = args.NewValue as bool?;
			if (newVal == true && _activeBeforeInvisible != null)
			{
				RingEngine.Start(); // Restart engine if its gets visible again.
			}
			else if (newVal == false)
			{
				_activeBeforeInvisible = RingEngine.IsRunning; // store current state of engine
				RingEngine.Stop();
			}
		}
		#endregion


		/// <summary>When control is loaded start the <see cref="RingEngine" />.</summary>
		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			RingEngine.Start();
		}

		/// <summary>Occurs when a new <see cref="IFrameRingEntry" /> gets visible.</summary>
		private void NextRingElement(RingEngine<IFrameRingEntry>.CurrentEntryChangedArgs args)
		{
			DoOnLoaded(() =>
			{
				var presenter = Get_CurrentFramePresenter();
				if (presenter == null)
					return;

				presenter.StartTransitions(DateTime.Now - args.EntryStartTime);
				presenter.StartVideos(DateTime.Now - args.EntryStartTime.Subtract(VideoStartOffset));


				if (Ring.RingBufferSize <= 0) return;


				var da = new DoubleAnimation(0, FadeOutOffset, FillBehavior.HoldEnd);
				var sb = new Storyboard {Duration = FadeOutOffset, BeginTime = args.Duration - FadeOutOffset, AutoReverse = false, FillBehavior = FillBehavior.HoldEnd};
				sb.Children.Add(da);
				Storyboard.SetTarget(da, (FrameworkElement) presenter.Parent);
				Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
				sb.Begin();



				var interval = args.Duration - VideoStartOffset;
				VideoStartTimer.Interval = interval < TimeSpan.Zero ? TimeSpan.Zero : interval;
				VideoStartTimer.Start();
			});

		}

		private void BufferedEntryAdded(RingEngine<IFrameRingEntry>.NewBufferedElementArgs newBufferedElementArgs)
		{
			var presenter = ((ContentPresenter) BufferedItemsControl.ItemContainerGenerator.ContainerFromIndex(0)).VisualChild_By_Condition<FramePresenter>(a => true);
			presenter?.BufferVideos();
		}

		/// <summary>Occurs whenever a video of the next <see cref="IFrameRingEntry" /> should be started.</summary>
		private void VideoStartTimer_Ticked(object sender, EventArgs e)
		{
			VideoStartTimer.Stop();

			var nextFramePresenter = Get_NextFramePresenter();
			nextFramePresenter.StartVideos();
		}



		private void DoOnLoaded(Action action)
		{
			void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
			{
				Loaded -= OnLoaded;
				action();
			}

			if (!IsLoaded)
				Loaded += OnLoaded;
			else
				action();
		}


		/// <summary>Returns the <see cref="FramePresenter" /> for the current playing <see cref="IFrameRingEntry" /> inside the
		///     <see cref="RingEngine{TItem}.Buffer" />.</summary>
		private FramePresenter Get_CurrentFramePresenter()
		{
			return ((ContentPresenter) BufferedItemsControl.ItemContainerGenerator.ContainerFromIndex(RingEngine.Buffer.Count - 1)).VisualChild_By_Condition<FramePresenter>(a => true);
		}

		/// <summary>Returns the <see cref="FramePresenter" /> for the next playing <see cref="IFrameRingEntry" /> inside the
		///     <see cref="RingEngine{TItem}.Buffer" />
		///     .</summary>
		private FramePresenter Get_NextFramePresenter()
		{
			return ((ContentPresenter) BufferedItemsControl.ItemContainerGenerator.ContainerFromIndex(RingEngine.Buffer.Count - 2)).VisualChild_By_Condition<FramePresenter>(a => true);
		}



		public delegate void Delegate0(InterruptArgs args);

		public class InterruptArgs
		{
			internal InterruptArgs(string interruptName)
			{
				InterruptName = interruptName;
			}
			public string InterruptName { get;}
			public IFrame Result { get; set; }
		}

	}

}