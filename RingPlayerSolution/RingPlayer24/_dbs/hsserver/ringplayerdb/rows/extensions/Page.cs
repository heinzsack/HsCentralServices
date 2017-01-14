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
	partial class Page : IPage
	{
		#region Overrides/Interfaces
		[DependsOn(nameof(MarginThickness))]
		public Thickness IRelativePositioning => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int ISortOrder => SortOrder;

		[DependsOn(nameof(Background))]
		public Color IBackground => Convert.Color.Getter(Background);

		[DependsOn(nameof(BorderColor))]
		public Color IBorderColor => Convert.Color.Getter(BorderColor);

		[DependsOn(nameof(BorderThickness))]
		public Thickness IBorderThickness => Convert.Thickness.Getter(BorderThickness);

		[DependsOn(nameof(Rotation))]
		public double IRotation => Rotation;

		[DependsOn(nameof(HasFixedRatio))]
		public bool IHasFixedRatio => HasFixedRatio;

		[DependsOn(nameof(RatioX))]
		public double IRatioX => RatioX;

		[DependsOn(nameof(RatioY))]
		public double IRatioY => RatioY;

		public IEnumerable<IBaseVisual> IChildren =>
			Images.OfType<IBaseVisual>()
				.Concat(Videos)
				.Concat(Texts)
				.Concat(ChildPages);


		public IEnumerable<ITransition> ITransitions => DoubleTransitions;
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