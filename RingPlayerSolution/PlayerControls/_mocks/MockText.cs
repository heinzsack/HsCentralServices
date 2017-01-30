// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;
using System.Windows.Media;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace PlayerControls._mocks
{
	internal class MockText : IFrameItemText
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
		public Thickness FrameItemRelativePosition { get; set; } = new Thickness(0);
		/// <summary>The color of the background of the element.</summary>
		public Color FrameItemBackground { get; set; } = Colors.Transparent;
		/// <summary>The color of the border of the element.</summary>
		public Color FrameItemBorderColor { get; set; } = Colors.Transparent;
		/// <summary>The thickness of the border.</summary>
		public Thickness FrameItemBorderThickness { get; set; } = new Thickness(0);
		/// <summary>The rotation of the element.</summary>
		public double FrameItemRotation { get; set; } = 0;
		/// <summary>The z-index of the elemnt describes the layer on which this element sits.</summary>
		public int FrameItemZIndex { get; set; } = 10;
		/// <summary>The text which should be displayed.</summary>
		public string FrameItemText { get; set; } = "Text not set";
		/// <summary>The <see cref="Color" /> of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public Color FrameItemForeground { get; set; } = Colors.Black;
		/// <summary>The font family of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public string FrameItemFontFamily { get; set; } = "Arial";
		/// <summary>The <see cref="FontWeight" /> of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public FontWeight FrameItemFontWeight { get; set; } = FontWeights.Normal;
		/// <summary>The <see cref="FontStyle" /> of the <see cref="IFrameItemText.FrameItemText" />.</summary>
		public FontStyle FrameItemFontStyle { get; set; } = FontStyles.Normal;
		#endregion
	}



}