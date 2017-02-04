// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-04</date>

using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CsWpfBase.Global;
using PlayerControls.Interfaces.FrameItems;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class Image : IFrameItemImage
	{
		private static object ImageLock { get; } = new object();


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
		public Color FrameItemBackground
		{
			get { return Convert.Color.Getter(Background); }
			set { Convert.Color.Setter(s => Background = s, value); }
		}

		[DependsOn(nameof(Background))]
		public Color FrameItemBorderColor
		{
			get { return Convert.Color.Getter(BorderColor); }
			set { Convert.Color.Setter(s => BorderColor = s, value); }
		}

		[DependsOn(nameof(Background))]
		public Thickness FrameItemBorderThickness
		{
			get { return Convert.Thickness.Getter(BorderThickness); }
			set { Convert.Thickness.Setter(s => BorderThickness = s, value); }
		}

		[DependsOn(nameof(Rotation))]
		public double FrameItemRotation
		{
			get { return Rotation; }
			set { Rotation = value; }
		}
		#endregion
	}
}