// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-04</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.Transistions;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class Page : IFrame
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

		[DependsOn(nameof(HasFixedRatio))]
		public bool FrameHasFixedRatio
		{
			get { return HasFixedRatio; }
			set { HasFixedRatio = value; }
		}

		[DependsOn(nameof(RatioX))]
		public double FrameRatioX
		{
			get { return RatioX; }
			set { RatioX = value; }
		}

		[DependsOn(nameof(RatioY))]
		public double FrameRatioY
		{
			get { return RatioY; }
			set { RatioY = value; }
		}

		public IEnumerable<IFrameItem> FrameChildren =>
			Images.OfType<IFrameItem>()
				.Concat(Videos)
				.Concat(Texts)
				.Concat(ChildPages);


		public IEnumerable<ITransition> FrameTransitions => DoubleTransitions;
		#endregion


		public new void Delete()
		{
			foreach (var childVisual in ChildPages.ToArray())
			{
				childVisual.Delete();
			}
			DataSet.AcceptChanges();
			base.Delete();
		}
	}
}