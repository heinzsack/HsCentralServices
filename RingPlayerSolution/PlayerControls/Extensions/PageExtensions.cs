using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Utilitys;
using PlayerControls.Controls;
using PlayerControls.Interfaces;

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
				var pageViewer = new PageViewer() { Page = page, Width = width, Height = height };

				pageViewer.Measure(pageViewer.DesiredSize);
				pageViewer.Arrange(new Rect(pageViewer.DesiredSize));
				pageViewer.UpdateLayout();

				List<System.Windows.Controls.Image> img = pageViewer.GetVisualChildsByCondition<System.Windows.Controls.Image>(i => true);
				pageViewer.MakeVideoVisiblie(TimeSpan.FromSeconds(5));
				foreach (var image in img)
					{
					BindingOperations.ClearBinding(image, System.Windows.Controls.Image.SourceProperty);
					image.Source = (image.DataContext as IImageVisual).IBitmapSource;
					}

				var bitmapSource = pageViewer.ConvertTo_Image();
				bitmapSource.Freeze();
				return bitmapSource;
			}, TaskCreationOptions.LongRunning);
			t.Start(StaTaskScheduler);
			return t;
			}
		}
	}
