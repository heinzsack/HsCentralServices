using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Controls;
using PlayerControls.Interfaces;






namespace PlayerControls.Themes
	{
	/// <summary>
	///     Interaction logic for RingPlayer24.xaml
	/// </summary>
	public partial class RingPlayer24 : UserControl
		{
		private static readonly TimeSpan PreStartVideoOffset = TimeSpan.FromMilliseconds(1000);

		#region DependencyProperty --- Pages --- 

		public static readonly DependencyProperty PagesProperty = DependencyProperty.Register(
			"Pages", typeof(IPageSchedule[]), typeof(RingPlayer24),
			new FrameworkPropertyMetadata(default(IPageSchedule[]))
				{
				DefaultValue = default(IPageSchedule[]),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((RingPlayer24) Sender)
					.ScheduledPagesChanged((IPageSchedule[]) Args.OldValue,
						(IPageSchedule[]) Args.NewValue)
				});

		public IPageSchedule[] Pages
			{
			get { return (IPageSchedule[]) GetValue(PagesProperty); }
			set { SetValue(PagesProperty, value); }
			}

		private void ScheduledPagesChanged(IPageSchedule[] OldValue,
			IPageSchedule[] NewValue)
			{
			Timer_EarlyVideoStarter.Stop();
			Timer_PageChanger.Stop();

			if (Pages == null || Pages.Length == 0)
				return;

			TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
			for (int i = 0; i < Pages.Length; i++)
				{
				if (Pages[i].IStartTime < timeOfDay)
					continue;
				if (Pages[i].IStartTime == timeOfDay)
					{
					nextElementToInsertIndex = i-1;
					break;
					}
				nextElementToInsertIndex = i - 1 -1;//cause GetNextRingElementToInsert increases by one
				break;
				}

			var oldPlayingPage = BufferedPages.LastOrDefault();
			var oldCount = BufferedPages.Count;
			for (int i = 0; i < oldCount-1; i++)
				{
				BufferedPages.RemoveAt(i);
				}


			BufferedPages.Insert(0, GetNextRingElementToInsert());
			BufferedPages.Insert(0, GetNextRingElementToInsert());
			BufferedPages.Insert(0, GetNextRingElementToInsert());



			Action startAction = () =>
			{
			if (oldPlayingPage != null)
				{
					Start_Videos_ForNextPage();
					RemoveCurrentPlayingPage();
				}
				else
					Start_Videos_ForCurrentPage();
				

				Start_Animations_ForCurrentPlayingPage();
				Start_Timers();

			};


			if (!IsLoaded)
				{
				Loaded += (sender, args) => startAction();
				}
			else
				{
				startAction();
				}
			}

		#endregion

		#region DependencyProperty --- BufferedPages --- 

		public static readonly DependencyProperty BufferedPagesProperty = DependencyProperty.Register(
			"BufferedPages", typeof(ObservableCollection<IPageSchedule>), typeof(RingPlayer24),
			new FrameworkPropertyMetadata(default(ObservableCollection<IPageSchedule>))
				{
				DefaultValue = default(ObservableCollection<IPageSchedule>),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((RingPlayer24) Sender)
					.BufferedScheduledPagesChanged((ObservableCollection<IPageSchedule>) Args.OldValue,
						(ObservableCollection<IPageSchedule>) Args.NewValue)
				});

		public ObservableCollection<IPageSchedule> BufferedPages
			{
			get { return (ObservableCollection<IPageSchedule>) GetValue(BufferedPagesProperty); }
			set { SetValue(BufferedPagesProperty, value); }
			}

		private void BufferedScheduledPagesChanged(ObservableCollection<IPageSchedule> OldValue,
			ObservableCollection<IPageSchedule> NewValue)
			{
			}

		#endregion


		DispatcherTimer Timer_PageChanger = new DispatcherTimer();
		DispatcherTimer Timer_EarlyVideoStarter = new DispatcherTimer();
		private int nextElementToInsertIndex = 0;


		public IPageSchedule PlayingPage => BufferedPages[BufferedPages.Count - 1];
		public IPageSchedule Page_Next => BufferedPages[BufferedPages.Count - 2];
		public IPageSchedule Page_NextNext => BufferedPages[BufferedPages.Count - 3];


		public RingPlayer24()
			{
			BufferedPages = new ObservableCollection<IPageSchedule>();
			Timer_PageChanger.Tick += Timer_PageChanger_Ticked;
			Timer_EarlyVideoStarter.Tick += Timer_EarlyVideoStarter_Ticked;
			InitializeComponent();

			}


		public void Timer_PageChanger_Ticked(object sender, EventArgs eventArgs)
			{
			ChangeToNextPage();
			}

		private void ChangeToNextPage()
			{
			Timer_PageChanger.Stop();

			RemoveCurrentPlayingPage();
			AddNextBufferedElement();

			Start_Animations_ForCurrentPlayingPage();
			Start_Timers();
			}

		private void Timer_EarlyVideoStarter_Ticked(object sender, EventArgs e)
			{
			Timer_EarlyVideoStarter.Stop();
			Start_Videos_ForNextPage();
			}
		private void Start_Videos_ForCurrentPage()
			{
			TimeSpan offset = DateTime.Now.TimeOfDay - PlayingPage.IStartTime.Subtract(PreStartVideoOffset);
			GetPageViewer_FromPlayingPage().StartVideos(offset < TimeSpan.Zero ? TimeSpan.Zero : offset);
			}
		private void Start_Videos_ForNextPage()
			{
			TimeSpan offset = DateTime.Now.TimeOfDay - Page_Next.IStartTime.Subtract(PreStartVideoOffset);
			GetPageViewer_FromNextPage().StartVideos(offset < TimeSpan.Zero ? TimeSpan.Zero : offset);
			}
		private void Start_Animations_ForCurrentPlayingPage()
			{
			TimeSpan offset = DateTime.Now.TimeOfDay - PlayingPage.IStartTime;
			GetPageViewer_FromPlayingPage().StartAnimations(offset<TimeSpan.Zero?TimeSpan.Zero : offset);
			}
		private PageViewer GetPageViewer_FromIndex(int index)
			{
			ContentPresenter container = (ContentPresenter)BufferedItemsControl.ItemContainerGenerator
				.ContainerFromIndex(index);
			return container.GetVisualChildByCondition<PageViewer>(a => true);
			}
		private PageViewer GetPageViewer_FromPlayingPage()
			{
			return GetPageViewer_FromIndex(BufferedPages.Count - 1);
			}
		private PageViewer GetPageViewer_FromNextPage()
			{
			ContentPresenter container = (ContentPresenter)BufferedItemsControl.ItemContainerGenerator
				.ContainerFromIndex(BufferedPages.Count - 2);
			return container.GetVisualChildByCondition<PageViewer>(a => true);
			}

		private void RemoveCurrentPlayingPage()
			{
			BufferedPages.RemoveAt(BufferedPages.Count - 1);
			}
		private void AddNextBufferedElement()
			{
			BufferedPages.Insert(0, GetNextRingElementToInsert());
			}
		

		/// <summary>
		/// Starts a timer which starts the next screens videos one second before screen change.
		/// </summary>
		private void Start_Timers()
			{
			//Timer_ScreenChanger.Interval = TimeSpan.FromSeconds((double)PlayingScreen.IPlayingSeconds);

			if (PlayingPage != Pages[Pages.Length - 1] && DateTime.Now.TimeOfDay >= Page_Next.IStartTime)//Solve problems with microssecond pages. CS.16.09.12
				{
				ChangeToNextPage();
				return;
				}

			if (PlayingPage != Pages[Pages.Length-1]) // Should solve problem with day change. CS.16.09.12
				Timer_PageChanger.Interval = Page_Next.IStartTime - DateTime.Now.TimeOfDay;
			else
				Timer_PageChanger.Interval = TimeSpan.FromDays(1).Subtract(DateTime.Now.TimeOfDay);



			if (Timer_PageChanger.Interval > PreStartVideoOffset)
				Timer_EarlyVideoStarter.Interval = Timer_PageChanger.Interval - PreStartVideoOffset;
			else
				Timer_EarlyVideoStarter.Interval = Timer_EarlyVideoStarter.Interval;


			//Debug.WriteLine($"Now = {DateTime.Now.TimeOfDay}, PageNext.Istart = {Page_Next.IStartTime}, " +
			//	$"EarlyVideoStart = {Timer_EarlyVideoStarter.Interval}");
			Timer_EarlyVideoStarter.Start();
			Timer_PageChanger.Start();
			}


		private IPageSchedule GetNextRingElementToInsert()
			{
			nextElementToInsertIndex++;
			return Pages[nextElementToInsertIndex % Pages.Length];
			}

		}

	}