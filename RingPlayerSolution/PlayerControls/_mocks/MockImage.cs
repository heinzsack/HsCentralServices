// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using CsWpfBase.Global.os.functions.knownfolders;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace PlayerControls._mocks
{
	internal class MockImage : Base, IFrameItemImage
	{
		private static readonly object ConcurrencyLock = new object();

		public static IFrameItem GetSampleMiddle()
		{
			return new MockImage
			{
				FrameItemRelativePosition = new Thickness(15, 15, 15, 15),
			};
		}

		private Color _frameItemBackground;
		private Color _frameItemBorderColor;
		private Thickness _frameItemBorderThickness;
		private Thickness _frameItemPadding;
		private Thickness _frameItemRelativePosition;
		private double _frameItemRotation;
		private int _frameItemZIndex;


		#region Overrides/Interfaces
		/// <summary>
		///     RelativePositioning is to base 100. Each value is the percentage of the distance to the outer box which could be an
		///     <see cref="IFrame" />. The percentage is then transformed into the <see cref="IFrame" /> metric.
		///     <example>
		///         if the container is in an aspect ratio of 16:9 and the margin is 0,0,0,0 then the resulting box is in aspect ratio 16:9
		///         or 1920x1080p.
		///         <para>
		///             if the container is in aspect ratio of 16:9 and size 1920:1080 and the margin equals 25,25,25,25 then the resulting
		///             box equals 960x540p and of an aspect ratio of 16:9
		///         </para>
		///     </example>
		/// </summary>
		public Thickness FrameItemRelativePosition
		{
			get { return _frameItemRelativePosition; }
			set { SetProperty(ref _frameItemRelativePosition, value); }
		}
		/// <summary>The color of the background of the element.</summary>
		public Color FrameItemBackground
		{
			get { return _frameItemBackground; }
			set { SetProperty(ref _frameItemBackground, value); }
		}
		/// <summary>The color of the border of the element.</summary>
		public Color FrameItemBorderColor
		{
			get { return _frameItemBorderColor; }
			set { SetProperty(ref _frameItemBorderColor, value); }
		}
		/// <summary>The thickness of the border.</summary>
		public Thickness FrameItemBorderThickness
		{
			get { return _frameItemBorderThickness; }
			set { SetProperty(ref _frameItemBorderThickness, value); }
		}
		/// <summary>The padding of the border.</summary>
		public Thickness FrameItemPadding
		{
			get { return _frameItemPadding; }
			set { SetProperty(ref _frameItemPadding, value); }
		}
		/// <summary>The rotation of the element.</summary>
		public double FrameItemRotation
		{
			get { return _frameItemRotation; }
			set { SetProperty(ref _frameItemRotation, value); }
		}
		/// <summary>The z-index of the elemnt describes the layer on which this element sits.</summary>
		public int FrameItemZIndex
		{
			get { return _frameItemZIndex; }
			set { SetProperty(ref _frameItemZIndex, value); }
		}
		/// <summary>The source which is used for the image. This will be accessed by an async binding. TAKE CARE OF SYNCHRONIZATION.</summary>
		public BitmapSource ImageBitmapSource
		{
			get
			{
				lock (ConcurrencyLock)
				{
					var img = new DirectoryInfo(CsGlobal.Os.Functions.KnownFolder.GetPath(KnownFolder.Pictures)).GetFiles("*.jpg").PickRandom().LoadAs_Image();
					img.Freeze();
					return img;
				}
			}
		}
		#endregion
	}
}