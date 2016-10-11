using System;
using System.Collections.ObjectModel;
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
	/// Interaction logic for RingPlayer.xaml
	/// </summary>
	public partial class RingPlayer : UserControl, IDisposable
		{
		private static readonly TimeSpan PreStartVideoOffset = TimeSpan.FromMilliseconds(1000);
		DispatcherTimer Timer_PageChanger = new DispatcherTimer();
		DispatcherTimer Timer_EarlyVideoStarter = new DispatcherTimer();
		private int nextElementToInsertIndex = 0;


		#region DependencyProperty --- BufferedPages --- 

		public static readonly DependencyProperty BufferedPagesProperty = DependencyProperty.Register(
			"BufferedPages", typeof(ObservableCollection<IDuratedPage>), typeof(RingPlayer),
			new FrameworkPropertyMetadata(default(ObservableCollection<IDuratedPage>))
				{
				DefaultValue = default(ObservableCollection<IDuratedPage>),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((RingPlayer) Sender)
					.BufferedPagesChanged((ObservableCollection<IDuratedPage>) Args.OldValue,
						(ObservableCollection<IDuratedPage>) Args.NewValue)
				});

		public ObservableCollection<IDuratedPage> BufferedPages
			{
			get { return (ObservableCollection<IDuratedPage>) GetValue(BufferedPagesProperty); }
			set { SetValue(BufferedPagesProperty, value); }
			}

		private void BufferedPagesChanged(ObservableCollection<IDuratedPage> OldValue,
			ObservableCollection<IDuratedPage> NewValue)
			{
			}

		#endregion


		#region DependencyProperty --- Pages --- 

		public static readonly DependencyProperty PagesProperty = DependencyProperty.Register(
			"Pages", typeof(IDuratedPage[]), typeof(RingPlayer),
			new FrameworkPropertyMetadata(default(IDuratedPage[]))
				{
				DefaultValue = default(IDuratedPage[]),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((RingPlayer) Sender)
					.PagesChanged((IDuratedPage[]) Args.OldValue,
						(IDuratedPage[]) Args.NewValue)
				});

		public IDuratedPage[] Pages
			{
			get { return (IDuratedPage[]) GetValue(PagesProperty); }
			set { SetValue(PagesProperty, value); }
			}

		private void PagesChanged(IDuratedPage[] OldValue,
			IDuratedPage[] NewValue)
			{
			Timer_EarlyVideoStarter.Stop();
			Timer_PageChanger.Stop();
			BufferedPages.Clear();

			if (Pages == null || Pages.Length == 0)
				return;
			nextElementToInsertIndex = -1;//cause GetNextRingElementToInsert increases by one

			BufferedPages.Insert(0, GetNextElementToInsert());
			BufferedPages.Insert(0, GetNextElementToInsert());
			BufferedPages.Insert(0, GetNextElementToInsert());

			Action startAction = () =>
			{
				Start_Videos_ForCurrentPage();
				Start_Animations_ForCurrentPlayingScreen();
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

		public RingPlayer()
			{
			BufferedPages = new ObservableCollection<IDuratedPage>();
			Timer_PageChanger.Tick += Timer_ScreenChanger_Ticked;
			Timer_EarlyVideoStarter.Tick += Timer_EarlyVideoStarter_Ticked;
			InitializeComponent();
			}


		public IDuratedPage PlayingPage => BufferedPages[BufferedPages.Count - 1];
		public IDuratedPage Page_Next => BufferedPages[BufferedPages.Count - 2];
		public IDuratedPage Page_NextNext => BufferedPages[BufferedPages.Count - 3];


		public void Timer_ScreenChanger_Ticked(object sender, EventArgs eventArgs)
			{
			Timer_PageChanger.Stop();

			RemoveCurrentPlayingScreen();
			AddNextBufferedElement();

			Start_Animations_ForCurrentPlayingScreen();
			Start_Timers();
			}

		private void Timer_EarlyVideoStarter_Ticked(object sender, EventArgs e)
			{
			Timer_EarlyVideoStarter.Stop();
			Start_Videos_ForNextPage();
			}
		private void Start_Videos_ForCurrentPage()
			{
			GetPageViewer_FromPlayingPage()?.StartVideos();
			}
		private void Start_Videos_ForNextPage()
			{
			GetPageViewer_FromNextPage()?.StartVideos();
			}
		private void Start_Animations_ForCurrentPlayingScreen()
			{
			GetPageViewer_FromPlayingPage()?.StartAnimations();
			}
		private PageViewer GetPageViewer_FromPlayingPage()
			{
			ContentPresenter container = (ContentPresenter)BufferedItemsControl.ItemContainerGenerator
				.ContainerFromIndex(BufferedPages.Count - 1);
			return container?.GetVisualChildByCondition<PageViewer>(a => true);
			}
		private PageViewer GetPageViewer_FromNextPage()
			{
			ContentPresenter container = (ContentPresenter)BufferedItemsControl.ItemContainerGenerator
				.ContainerFromIndex(BufferedPages.Count - 2);
			return container?.GetVisualChildByCondition<PageViewer>(a => true);
			}

		private void RemoveCurrentPlayingScreen()
			{
			BufferedPages.RemoveAt(BufferedPages.Count - 1);
			}

		private void AddNextBufferedElement()
			{
			BufferedPages.Insert(0, GetNextElementToInsert());
			}

		/// <summary>
		/// Starts a timer which starts the next screens videos one second before screen change.
		/// </summary>
		private void Start_Timers()
			{
			//Timer_ScreenChanger.Interval = TimeSpan.FromSeconds((double)PlayingScreen.IPlayingSeconds);


			Timer_PageChanger.Interval = Page_Next.IDuration.TimeSpan;
			Timer_EarlyVideoStarter.Interval = Timer_PageChanger.Interval - PreStartVideoOffset;
			Timer_EarlyVideoStarter.Start();
			Timer_PageChanger.Start();
			}

		private IDuratedPage GetNextElementToInsert()
			{
			nextElementToInsertIndex++;
			return Pages[nextElementToInsertIndex % Pages.Length];
			}

		public void Dispose()
			{
			Pages = null;
			}
		}
	}
