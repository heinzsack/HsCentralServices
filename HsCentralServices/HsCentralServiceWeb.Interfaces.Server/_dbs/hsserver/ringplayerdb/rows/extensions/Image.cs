using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
	{
	partial class Image : IImageVisual, IDownloadAble
		{
		private static object imageLock = new object();

		[DependsOn(nameof(MarginThickness))]
		public Thickness IRelativePositioning => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int ISortOrder => SortOrder;

		[DependsOn(nameof(FileIdentifier))]
		[DependsOn(nameof(Extension))]
		public BitmapSource IBitmapSource
			{
			get
				{
				lock (imageLock)
					{
					try
						{
						BitmapImage img;
						var stream = Table.OnStreamRequested(this);
						if (stream == null)
							return null;

						using (stream)
							{
							var sr = new MemoryStream();
							stream.CopyTo(sr);
							sr.Seek(0, SeekOrigin.Begin);
							img = new BitmapImage();
							img.BeginInit();
							img.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
							img.CacheOption = BitmapCacheOption.OnLoad;
							img.StreamSource = sr;
							img.EndInit();
							img.Freeze();
							sr.Close();
							stream.Close();
							}
						return img;
						}
					catch (Exception exc)
						{
						return null;
						}

					}
				}
			}

		[DependsOn(nameof(FileIdentifier))]
		public Guid IFileIdentifier => FileIdentifier;

		[DependsOn(nameof(Extension))]
		public string IExtension => Extension;

		[DependsOn(nameof(Background))]
		public Color IBackground => Convert.Color.Getter(Background);

		[DependsOn(nameof(Background))]
		public Color IBorderColor => Convert.Color.Getter(BorderColor);

		[DependsOn(nameof(Background))]
		public Thickness IBorderThickness => Convert.Thickness.Getter(BorderThickness);

		[DependsOn(nameof(System.Windows.Media.Imaging.Rotation))]
		public double IRotation => Rotation;
		}
	}
