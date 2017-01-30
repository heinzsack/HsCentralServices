// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using CsWpfBase.Global;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class Video : IFrameItemVideo
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

		[DependsOn(nameof(VideoId))]
		public string FrameItemVideoFilePath => CsGlobal.Remote.FileRepository.FindOrDownload(VideoId)?.LocalCachedFile?.FullName;
		#endregion
	}
}