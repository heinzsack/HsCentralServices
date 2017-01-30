// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Themes.Controls.Containers;
using CsWpfBase.Utilitys;
using PlayerControls.Controls.windows;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;
using PlayerControls.Themes;






namespace PlayerControls.Extensions
{
	public static class FrameExtensions
	{
		private static StaTaskScheduler _staTaskScheduler;

		private static StaTaskScheduler StaTaskScheduler
		{
			get
			{
				if (_staTaskScheduler != null)
					return _staTaskScheduler;
				_staTaskScheduler = new StaTaskScheduler(1);
				return _staTaskScheduler;
			}
		}

		public static Task<BitmapSource> GetRenderedImage(this IFrame frame, double width = 1920D, double height = 1080D)
		{
			var t = new Task<BitmapSource>(() =>
			{
				var frameViewer = new FramePresenter {Item = frame, Width = width, Height = height};

				frameViewer.Measure(frameViewer.DesiredSize);
				frameViewer.Arrange(new Rect(frameViewer.DesiredSize));
				frameViewer.UpdateLayout();

				var img = frameViewer.GetVisualChildsByCondition<Image>(i => true);
				//TODO frameViewer.MakeVideoVisible(TimeSpan.FromSeconds(5));
				foreach (var image in img)
				{
					BindingOperations.ClearBinding(image, Image.SourceProperty);
					image.Source = ((IFrameItemImage) image.DataContext).ImageBitmapSource;
				}

				var bitmapSource = frameViewer.ConvertTo_Image();
				bitmapSource.Freeze();
				return bitmapSource;
			}, TaskCreationOptions.LongRunning);
			t.Start(StaTaskScheduler);
			return t;
		}

		/// <summary>Shows the <paramref name="frame" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="frame">The <see cref="IFrame" /> which will be presented</param>
		/// <param name="title">The title of the <paramref name="frame" />.</param>
		/// <param name="isDiagnostic">if true diagnostic elements will be presented</param>
		public static void ShowDialog(this IFrame frame, string title = null, bool isDiagnostic = false)
		{
			new FramePresenterWindow(title ?? $"Unknown {nameof(IFrame)}", frame, isDiagnostic).ShowDialog();
		}

		/// <summary>Shows the <paramref name="duratedFrames" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="duratedFrames">The durated frames.</param>
		/// <param name="title">The title of the <see cref="Window" />.</param>
		public static void ShowDialog(this IDuratedFrame[] duratedFrames, string title = null)
		{
			new DuratedFramesPresenterWindow(title.IsNullOrEmpty() ? "Page View" : title, duratedFrames).ShowDialog();
		}

		/// <summary>Shows the <paramref name="scheduledFrames" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="scheduledFrames">The scheduled frames.</param>
		/// <param name="title">The title of the <see cref="Window" />.</param>
		public static void ShowDialog(this IScheduledFrame[] scheduledFrames, string title = null)
		{
			new ScheduledFramesPresenterWindow(title.IsNullOrEmpty() ? "Page View" : title, scheduledFrames).ShowDialog();
		}
	}
}