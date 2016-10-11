using CsWpfBase.Ev.Public.Extensions;
using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
	{
	partial class Text : ITextVisual
		{
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

		[DependsOn(nameof(FontWeight))]
		public FontStyle IFontStyle => Convert.FontStyle.Getter(FontWeight);

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





		
		}
	}
