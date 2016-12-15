// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Controls;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.Transistions;






namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
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
		#endregion


		public IEnumerable<ITransition> ITransitions => DoubleTransitions.OfType<IDoubleTransition>();

		public Task<BitmapSource> GetRenderedImage(double width = 1920D, double height = 1080D)
		{
			var t = new Task<BitmapSource>(() =>
			{
				var pageViewer = new PageViewer() {Page = this, Width = width, Height = height};

				pageViewer.Measure(pageViewer.DesiredSize);
				pageViewer.Arrange(new Rect(pageViewer.DesiredSize));
				pageViewer.UpdateLayout();

				List<System.Windows.Controls.Image> img = pageViewer.GetVisualChildsByCondition<System.Windows.Controls.Image>(i => true);
				pageViewer.MakeVideoVisiblie(TimeSpan.FromSeconds(5));
				foreach (var image in img)
				{
					BindingOperations.ClearBinding(image, System.Windows.Controls.Image.SourceProperty);
					image.Source = (image.DataContext as IImageVisual).IBitmapSource;
				}

				var bitmapSource = pageViewer.ConvertTo_Image();
				bitmapSource.Freeze();
				return bitmapSource;
			}, TaskCreationOptions.LongRunning);
			t.Start(Table.StaTaskScheduler);
			return t;
		}

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