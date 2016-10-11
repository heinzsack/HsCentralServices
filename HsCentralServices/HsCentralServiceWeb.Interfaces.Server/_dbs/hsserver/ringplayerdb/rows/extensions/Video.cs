using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
	{
	partial class Video : IVideoVisual, IDownloadAble
		{
		[DependsOn(nameof(MarginThickness))]
		public Thickness IRelativePositioning => Convert.Thickness.Getter(MarginThickness);

		[DependsOn(nameof(SortOrder))]
		public int ISortOrder => SortOrder;

		[DependsOn(nameof(FileIdentifier))]
		public string IFileName => Table.OnFileRequested(this);

		[DependsOn(nameof(FileIdentifier))]
		public Guid IFileIdentifier => FileIdentifier;

		[DependsOn(nameof(Extension))]
		public string IExtension => Extension;

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
