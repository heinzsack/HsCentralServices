// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CsWpfBase.Global;
using PlayerControls.Interfaces;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class Image : IImageVisual
	{
		private static object ImageLock { get; } = new object();


		#region Overrides/Interfaces
		[DependsOn(nameof(MarginThickness))]
		public Thickness IRelativePositioning => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int ISortOrder => SortOrder;

		[DependsOn(nameof(ImageId))]
		public BitmapSource IBitmapSource
		{
			get
			{
				lock (ImageLock)
				{
					try
					{
						var repoInfo = CsGlobal.Remote.FileRepository.FindOrDownload(ImageId);
						if (repoInfo == null)
							return null;

						var img = new BitmapImage(new Uri(repoInfo.LocalCachedFile.FullName, UriKind.RelativeOrAbsolute));
						img.Freeze();
						return img;
					}
					catch (Exception)
					{
						return null;
					}

				}
			}
		}

		[DependsOn(nameof(Background))]
		public Color IBackground => Convert.Color.Getter(Background);

		[DependsOn(nameof(Background))]
		public Color IBorderColor => Convert.Color.Getter(BorderColor);

		[DependsOn(nameof(Background))]
		public Thickness IBorderThickness => Convert.Thickness.Getter(BorderThickness);

		[DependsOn(nameof(Rotation))]
		public double IRotation => Rotation;
		#endregion
	}
}