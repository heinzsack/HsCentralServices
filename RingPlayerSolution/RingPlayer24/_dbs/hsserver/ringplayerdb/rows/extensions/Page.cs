// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

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
		public Thickness FrameItemRelativePosition => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int FrameItemZIndex => SortOrder;

		[DependsOn(nameof(Background))]
		public Color FrameItemBackground => Convert.Color.Getter(Background);

		[DependsOn(nameof(BorderColor))]
		public Color FrameItemBorderColor => Convert.Color.Getter(BorderColor);

		[DependsOn(nameof(BorderThickness))]
		public Thickness FrameItemBorderThickness => Convert.Thickness.Getter(BorderThickness);

		[DependsOn(nameof(Rotation))]
		public double FrameItemRotation => Rotation;

		[DependsOn(nameof(HasFixedRatio))]
		public bool FrameHasFixedRatio => HasFixedRatio;

		[DependsOn(nameof(RatioX))]
		public double FrameRatioX => RatioX;

		[DependsOn(nameof(RatioY))]
		public double FrameRatioY => RatioY;

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