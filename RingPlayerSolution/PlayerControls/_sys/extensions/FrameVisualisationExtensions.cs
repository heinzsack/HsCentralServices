// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 16:07</modify-date>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Utilitys;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls.Themes;
using PlayerControls.Themes.editors;
using PlayerControls.Themes.windows;
using PlayerControls._sys.extensions.tools;






namespace PlayerControls._sys.extensions
{
	public static class FrameVisualisationExtensions
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

		/// <summary>Renders the associated <see cref="frame" /> into an image. You can specify <paramref name="width" /> and
		///     <paramref name="height" />.</summary>
		/// <param name="frame">The frame which needs to be converted into an image.</param>
		/// <param name="width">The width of the rendered image.</param>
		/// <param name="height">The height of the rendered image.</param>
		public static Task<BitmapSource> ConvertTo_RenderedImage(this IFrame frame, double width = 1920D, double height = 1080D)
		{
			var t = new Task<BitmapSource>(() =>
			{
				var frameViewer = new FramePresenter {Item = frame, Width = width, Height = height};

				frameViewer.Measure(frameViewer.DesiredSize);
				frameViewer.Arrange(new Rect(frameViewer.DesiredSize));
				frameViewer.UpdateLayout();

				var img = frameViewer.VisualChilds_By_Condition<Image>(i => true);
				//TODO frameViewer.MakeVideoVisible(TimeSpan.FromSeconds(5));
				foreach (var image in img)
				{
					BindingOperations.ClearBinding(image, Image.SourceProperty);
					image.Source = ((IFrameImage) image.DataContext).FrameItemImage;
				}

				var bitmapSource = frameViewer.ConvertTo_Image();
				bitmapSource.Freeze();
				return bitmapSource;
			}, TaskCreationOptions.LongRunning);
			t.Start(StaTaskScheduler);
			return t;
		}

		/// <summary>Shows the <paramref name="frame" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		public static void ShowDialog(this IFrame frame, string title = null, bool isDiagnostic = false)
		{
			new FramePresenterWindow(title ?? $"Unknown {nameof(IFrame)}", frame, isDiagnostic).ShowDialog();
		}

		/// <summary>Shows the <paramref name="frame" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="frame">The <see cref="IFrame" /> which will be presented</param>
		/// <param name="title">The title of the <paramref name="frame" />.</param>
		public static void ShowEditorDialog(this IFrame frame, string title = null)
		{
			new FrameEditor {Item = frame}.ShowDialog(title);
		}

		/// <summary>Shows the <paramref name="duratedFrames" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="duratedFrames">The durated frames.</param>
		/// <param name="title">The title of the <see cref="Window" />.</param>
		public static void ShowDialog(this IEnumerable<IDuratedFrame> duratedFrames, string title = null)
		{
			new RingFramePresenterWindow(title.IsNullOrEmpty() ? "Page View" : title, duratedFrames.ToRing(DateTime.Now)).ShowDialog();
		}

		/// <summary>Shows the <paramref name="ring" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="ring">The <see cref="IFrameRing"/>.</param>
		/// <param name="title">The title of the <see cref="Window" />.</param>
		public static void ShowDialog(this IFrameRing ring, string title = null)
		{
			new RingFramePresenterWindow(title.IsNullOrEmpty() ? "Page View" : title, ring).ShowDialog();
		}


	}



}