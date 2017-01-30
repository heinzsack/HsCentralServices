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
using PlayerControls.Interfaces.FrameItems;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class Image : IFrameItemImage
	{
		private static object ImageLock { get; } = new object();


		#region Overrides/Interfaces
		[DependsOn(nameof(MarginThickness))]
		public Thickness FrameItemRelativePosition => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int FrameItemZIndex => SortOrder;

		[DependsOn(nameof(ImageId))]
		public BitmapSource ImageBitmapSource
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
		public Color FrameItemBackground => Convert.Color.Getter(Background);

		[DependsOn(nameof(Background))]
		public Color FrameItemBorderColor => Convert.Color.Getter(BorderColor);

		[DependsOn(nameof(Background))]
		public Thickness FrameItemBorderThickness => Convert.Thickness.Getter(BorderThickness);

		[DependsOn(nameof(Rotation))]
		public double FrameItemRotation => Rotation;
		#endregion
	}
}