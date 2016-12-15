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






namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
{
	partial class Text : ITextVisual
	{
		#region Overrides/Interfaces
		[DependsOn(nameof(MarginThickness))]
		public Thickness IRelativePositioning => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int ISortOrder => SortOrder;

		[DependsOn(nameof(TextColumn))]
		public string IText => TextColumn;

		[DependsOn(nameof(FontFamily))]
		public string IFontFamily => FontFamily.IsNullOrEmpty() ? "Arial" : FontFamily;

		[DependsOn(nameof(FontWeight))]
		public FontWeight IFontWeight => Convert.FontWeight.Getter(FontWeight);

		[DependsOn(nameof(FontStyle))]
		public FontStyle IFontStyle => Convert.FontStyle.Getter(FontStyle);

		[DependsOn(nameof(Foreground))]
		public Color IForeground => Convert.Color.Getter(Foreground);

		[DependsOn(nameof(Background))]
		public Color IBackground => Convert.Color.Getter(Background);

		[DependsOn(nameof(BorderColor))]
		public Color IBorderColor => Convert.Color.Getter(BorderColor);

		[DependsOn(nameof(BorderThickness))]
		public Thickness IBorderThickness => Convert.Thickness.Getter(BorderThickness);

		[DependsOn(nameof(Rotation))]
		public double IRotation => Rotation;
		#endregion
	}
}