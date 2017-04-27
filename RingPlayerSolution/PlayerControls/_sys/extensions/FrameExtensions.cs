// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 18:30</modify-date>

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Utilitys;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls.Themes;
using PlayerControls.Themes.editors;
using PlayerControls.Themes.windows;
using PlayerControls._sys.pocos.presentation;






namespace PlayerControls._sys.extensions
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
					image.Source = ((IFrameImage) image.DataContext).ImageBitmapSource;
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
		public static void ShowDialog(this IDuratedFrame[] duratedFrames, string title = null)
		{
			new DuratedFramesPresenterWindow(title.IsNullOrEmpty() ? "Page View" : title, duratedFrames).ShowDialog();
		}

		/// <summary>Shows the <paramref name="scheduledFrames" /> in a new <see cref="Window" /> (ShowDialog blocks further program code).</summary>
		/// <param name="scheduledFrames">The scheduled frames.</param>
		/// <param name="title">The title of the <see cref="Window" />.</param>
		public static void ShowDialog(this IRing<IFrameRingEntry> scheduledFrames, string title = null)
		{
			new RingFramePresenterWindow(title.IsNullOrEmpty() ? "Page View" : title, scheduledFrames).ShowDialog();
		}




		/// <summary>Converts the frame into a poco frame which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IFrame" /> to convert.</param>
		public static PocoFrame ToPoco(this IFrame source)
		{
			if (source is PocoFrame)
				return (PocoFrame) source;

			var pocoFrame = new PocoFrame();
			source.CopyTo(pocoFrame, nameof(IFrame.FrameChildren), nameof(IFrame.FrameTransitions));
			foreach (IFrameItem child in source.FrameChildren)
				pocoFrame.AddChild(child);
			return pocoFrame;
		}

		/// <summary>
		///     Converts the <see cref="IFrameText" /> into a new instance of <see cref="PocoFrameText" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameText ToPoco(this IFrameText source)
		{
			if (source is PocoFrameText)
				return (PocoFrameText) source;

			var target = new PocoFrameText();
			source.CopyTo(target);
			return target;
		}

		/// <summary>
		///     Converts the <see cref="IFrameImage" /> into a new instance of <see cref="PocoFrameImage" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameImage ToPoco(this IFrameImage source)
		{
			if (source is PocoFrameImage)
				return (PocoFrameImage) source;

			var target = new PocoFrameImage();
			source.CopyTo(target);
			return target;
		}

		/// <summary>
		///     Converts the <see cref="IFrameVideo" /> into a new instance of <see cref="PocoFrameVideo" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameVideo ToPoco(this IFrameVideo source)
		{
			if (source is PocoFrameVideo)
				return (PocoFrameVideo) source;

			var target = new PocoFrameVideo();
			source.CopyTo(target);
			return target;
		}
	}
}