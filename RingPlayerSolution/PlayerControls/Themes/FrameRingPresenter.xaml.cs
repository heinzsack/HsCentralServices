﻿// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-01-28</creation-date>
// <modified>2017-04-27 19:08</modify-date>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces.presentation;
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
		public static readonly DependencyProperty RingProperty = DependencyProperty.Register("Ring", typeof(IRing<IFrameRingEntry>), typeof(FrameRingPresenter), new FrameworkPropertyMetadata
																																								{
																																									BindsTwoWayByDefault = true,
																																									//PropertyChangedCallback = (o, args) => ((ScheduledFramePresenter)o).RingDpChanged((IRing<IScheduledFrame>)args.OldValue, (IRing<IScheduledFrame>)args.NewValue),
																																									DefaultValue = default(IRing<IFrameRingEntry>),
																																									DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																								});
		#endregion


		/// <summary>The amount of time before the frame changes the videos of the next frame will be started.</summary>
		private static readonly TimeSpan VideoStartOffset = TimeSpan.FromMilliseconds(1000);

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
			RingEngine.BufferedEntryAdded += BufferElementAdded;
			SetBinding(RingProperty, new Binding($"{nameof(RingEngine)}.{nameof(RingEngine.Ring)}") {Source = this, Mode = BindingMode.TwoWay});

			InitializeComponent();

			Loaded += OnLoaded;
		}

		/// <summary>The <see cref="IRing" /> which is meant to be played.</summary>
		public IRing<IFrameRingEntry> Ring
		{
			get => (IRing<IFrameRingEntry>) GetValue(RingProperty);
			set => SetValue(RingProperty, value);
		}

		/// <summary>The <see cref="RingEngine{TItem}" /> which is used to play the <see cref="Ring" />.</summary>
		public RingEngine<IFrameRingEntry> RingEngine
		{
			get => (RingEngine<IFrameRingEntry>) GetValue(RingEngineProperty);
			set => SetValue(RingEngineProperty, value);
		}


		#region DP Changed
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

		/// <summary>Occurs whenever a new <see cref="IFrameRingEntry" /> is added to the <see cref="RingEngine{TItem}.Buffer" />.</summary>
		private void BufferElementAdded(RingEngine<IFrameRingEntry>.NewBufferedElementArgs args)
		{
			if (args.Entry.RingEntryInterrupt.IsNullOrEmpty())
				return;

			InterruptFrameAvailable?.Invoke(args.Entry.RingEntryInterrupt, args.Entry);
		}

		/// <summary>Occurs when a new <see cref="IFrameRingEntry" /> gets visible.</summary>
		private void NextRingElement(RingEngine<IFrameRingEntry>.CurrentEntryChangedArgs args)
		{
			var presenter = Get_CurrentFramePresenter();
			presenter.StartTransitions(DateTime.Now - args.EntryStartTime);
			presenter.StartVideos(DateTime.Now - args.EntryStartTime.Subtract(VideoStartOffset));



			if (Ring.RingBufferSize > 0)
			{
				var interval = args.Duration - VideoStartOffset;
				VideoStartTimer.Interval = interval < TimeSpan.Zero ? TimeSpan.Zero : interval;
				VideoStartTimer.Start();
			}
		}

		/// <summary>Occurs whenever a video of the next <see cref="IFrameRingEntry" /> should be started.</summary>
		private void VideoStartTimer_Ticked(object sender, EventArgs e)
		{
			VideoStartTimer.Stop();

			var nextFramePresenter = Get_NextFramePresenter();
			nextFramePresenter.StartVideos();
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



		public delegate void Delegate0(string interruptName, IFrameRingEntry frame);
	}

}