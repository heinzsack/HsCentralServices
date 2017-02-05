// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class Text : IFrameItemText
	{
		#region Overrides/Interfaces

		[DependsOn(nameof(MarginThickness))]
		public Thickness FrameItemRelativePosition
		{
			get { return Convert.Thickness.Getter(MarginThickness); }
			set { Convert.Thickness.Setter(s => MarginThickness = s, value); }
		}

		[DependsOn(nameof(SortOrder))]
		public int FrameItemZIndex
		{
			get { return SortOrder; }
			set { SortOrder = value; }
		}

		[DependsOn(nameof(Background))]
		public Color FrameItemBackground
		{
			get { return Convert.Color.Getter(Background); }
			set { Convert.Color.Setter(s => Background = s, value); }
		}

		[DependsOn(nameof(BorderColor))]
		public Color FrameItemBorderColor
		{
			get { return Convert.Color.Getter(BorderColor); }
			set { Convert.Color.Setter(s => BorderColor = s, value); }
		}

		[DependsOn(nameof(BorderThickness))]
		public Thickness FrameItemBorderThickness
		{
			get { return Convert.Thickness.Getter(BorderThickness); }
			set { Convert.Thickness.Setter(s => BorderThickness = s, value); }
		}

		[DependsOn(nameof(Padding))]
		public Thickness FrameItemPadding
		{
			get { return Convert.Thickness.Getter(Padding); }
			set { Convert.Thickness.Setter(s => Padding = s, value); }
		}

		[DependsOn(nameof(Rotation))]
		public double FrameItemRotation
		{
			get { return Rotation; }
			set { Rotation = value; }
		}









		[DependsOn(nameof(TextColumn))]
		public string FrameItemText
		{
			get { return TextColumn; }
			set { TextColumn = value; }
		}

		[DependsOn(nameof(FontFamily))]
		public string FrameItemFontFamily
		{
			get { return FontFamily.IsNullOrEmpty() ? "Arial" : FontFamily; }
			set { FontFamily = value; }
		}

		[DependsOn(nameof(FontWeight))]
		public FontWeight FrameItemFontWeight
		{
			get { return Convert.FontWeight.Getter(FontWeight); }
			set { Convert.FontWeight.Setter(s => FontWeight = s, value); }
		}

		[DependsOn(nameof(FontStyle))]
		public FontStyle FrameItemFontStyle
		{
			get { return Convert.FontStyle.Getter(FontStyle); }
			set { Convert.FontStyle.Setter(s => FontStyle = s, value); }
		}

		[DependsOn(nameof(Foreground))]
		public Color FrameItemForeground
		{
			get { return Convert.Color.Getter(Foreground); }
			set { Convert.Color.Setter(s => Foreground = s, value); }
		}
		#endregion
	}
}