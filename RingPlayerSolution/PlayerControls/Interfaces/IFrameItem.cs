// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;
using System.Windows.Media;
using PlayerControls.Interfaces.FrameItems;






namespace PlayerControls.Interfaces
{
	/// <summary>
	///     Contains all the properties which can be used for presenting a specific type of thing like an
	///     <see cref="IFrameItemImage" />.
	/// </summary>
	public interface IFrameItem
	{
		#region Abstract
		/// <summary>
		///     RelativePositioning is to base 100. Each value is the percentage of the distance to the outer box which could be an
		///     <see cref="IFrame" />. The percentage is then transformed into the <see cref="IFrame" /> metric.
		///     <example>
		///         if the container is in an aspect ratio of 16:9 and the margin is 0,0,0,0 then the resulting box is in aspect ratio 16:9
		///         or 1920x1080p.
		///         <para>
		///             if the container is in aspect ratio of 16:9 and size 1920:1080 and the margin equals 25,25,25,25 then the resulting
		///             box equals 960x540p and of an aspect ratio of 16:9
		///         </para>
		///     </example>
		/// </summary>
		Thickness FrameItemRelativePosition { get; }
		/// <summary>The color of the background of the element.</summary>
		Color FrameItemBackground { get; }
		/// <summary>The color of the border of the element.</summary>
		Color FrameItemBorderColor { get; }
		/// <summary>The thickness of the border.</summary>
		Thickness FrameItemBorderThickness { get; }
		/// <summary>The rotation of the element.</summary>
		double FrameItemRotation { get; }
		/// <summary>The z-index of the elemnt describes the layer on which this element sits.</summary>
		int FrameItemZIndex { get; }
		#endregion
	}
}