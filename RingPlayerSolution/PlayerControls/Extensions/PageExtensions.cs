// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Themes.Controls.Containers;
using CsWpfBase.Utilitys;
using PlayerControls.Controls;
using PlayerControls.Interfaces;
using PlayerControls.Themes;


namespace PlayerControls.Extensions
{
	public static class PageExtensions
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

		public static Task<BitmapSource> GetRenderedImage(this IPage page, double width = 1920D, double height = 1080D)
		{
			var t = new Task<BitmapSource>(() =>
			{
				var pageViewer = new PageViewer {Page = page, Width = width, Height = height};

				pageViewer.Measure(pageViewer.DesiredSize);
				pageViewer.Arrange(new Rect(pageViewer.DesiredSize));
				pageViewer.UpdateLayout();

				var img = pageViewer.GetVisualChildsByCondition<Image>(i => true);
				pageViewer.MakeVideoVisible(TimeSpan.FromSeconds(5));
				foreach (var image in img)
				{
					BindingOperations.ClearBinding(image, Image.SourceProperty);
					image.Source = (image.DataContext as IImageVisual).IBitmapSource;
				}

				var bitmapSource = pageViewer.ConvertTo_Image();
				bitmapSource.Freeze();
				return bitmapSource;
			}, TaskCreationOptions.LongRunning);
			t.Start(StaTaskScheduler);
			return t;
		}

		public static void ShowDialog(this IPage page, string title = null)
		{
			new CsWindow
			{
				Title = title.IsNullOrEmpty()?"Page View": title,
				Content = new PageViewer
				{
					Page = page
				}
			}.ShowDialog();
		}

	public static void ShowDialog(this IDuratedPage[] duratedPages, string title = null)
		{
			new CsWindow()
				{
				Title = title.IsNullOrEmpty()?"Page View": title,
				Content = new RingPlayer() { Pages = duratedPages }
			}.ShowDialog();
		}

	}
}