// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Windows;
using System.Windows.Media;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace PlayerControls._mocks
{
	internal class MockText : Base, IFrameItemText
	{
		public static IFrameItem GetSampleLeftTop()
		{
			return new MockText
			{
				FrameItemRelativePosition = new Thickness(2, 2, 52, 52),
				FrameItemText = "LINKS OBEN".AppendRandomText()
			};
		}

		public static IFrameItem GetSampleLeftBottom()
		{
			return new MockText
			{
				FrameItemRelativePosition = new Thickness(2, 52, 52, 2),
				FrameItemText = "LINKS UNTEN".AppendRandomText()
			};
		}

		public static IFrameItem GetSampleRightTop()
		{
			return new MockText
			{
				FrameItemRelativePosition = new Thickness(52, 2, 2, 52),
				FrameItemText = "RECHTS OBEN".AppendRandomText()
			};
		}

		public static IFrameItem GetSampleRightBottom()
		{
			return new MockText
			{
				FrameItemRelativePosition = new Thickness(52, 52, 2, 2),
				FrameItemText = "RECHTS UNTEN".AppendRandomText()
			};
		}

		private Color _frameItemBackground;
		private Color _frameItemBorderColor;
		private Thickness _frameItemBorderThickness;
		private Thickness _frameItemPadding;
		private Thickness _frameItemRelativePosition;
		private double _frameItemRotation;
		private int _frameItemZIndex;
		private string _frameItemText = "Text not set";
		private Color _frameItemForeground = Colors.Black;
		private string _frameItemFontFamily = "Arial";
		private FontWeight _frameItemFontWeight = FontWeights.Normal;
		private FontStyle _frameItemFontStyle = FontStyles.Normal;


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




		/// <summary>The text which should be displayed.</summary>
		public string FrameItemText
		{
			get { return _frameItemText; }
			set { SetProperty(ref _frameItemText, value); }
		}
		/// <summary>The <see cref="Color" /> of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public Color FrameItemForeground
		{
			get { return _frameItemForeground; }
			set { SetProperty(ref _frameItemForeground, value); }
		}
		/// <summary>The font family of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public string FrameItemFontFamily
		{
			get { return _frameItemFontFamily; }
			set { SetProperty(ref _frameItemFontFamily, value); }
		}
		/// <summary>The <see cref="FontWeight" /> of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public FontWeight FrameItemFontWeight
		{
			get { return _frameItemFontWeight; }
			set { SetProperty(ref _frameItemFontWeight, value); }
		}
		/// <summary>The <see cref="FontStyle" /> of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public FontStyle FrameItemFontStyle
		{
			get { return _frameItemFontStyle; }
			set { SetProperty(ref _frameItemFontStyle, value); }
		}
		#endregion
	}



}