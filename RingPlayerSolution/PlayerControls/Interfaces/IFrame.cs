// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-06</date>

using System;
using System.Collections.Generic;
using PlayerControls.Interfaces.FrameItems;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls.Interfaces
{
	/// <summary>A <see cref="IFrame" /> describes a container which can be filled with multiple children and other <see cref="IFrame" />
	///     s.</summary>
	public interface IFrame : IFrameItem
	{
		#region Abstract
		/// <summary>
		///     If true the two proeprties <see cref="FrameRatioX" /> and <see cref="FrameRatioY" /> will be used to determine an aspect
		///     ratio wich is used to resize the frame.
		/// </summary>
		bool FrameHasFixedRatio { get; set; }

		/// <summary>could be 16 when <see cref="FrameRatioY" /> is 9 to make a 16:9 frame.</summary>
		double FrameRatioX { get; set; }

		/// <summary>could be 9 when <see cref="FrameRatioX" /> is 16 to make a 16:9 frame.</summary>
		double FrameRatioY { get; set; }

		/// <summary>Could be any <see cref="IFrameItem" /> item.</summary>
		IEnumerable<IFrameItem> FrameChildren { get; }

		/// <summary>Could be any <see cref="ITransition" /> item.</summary>
		IEnumerable<ITransition> FrameTransitions { get; }

		/// <summary>Adds an <see cref="IFrameItemText" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrameItemText" />.</summary>
		IFrameItemText EditorRequestedNewText();

		/// <summary>Adds an <see cref="IFrameItemImage" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrameItemImage" />.</summary>
		IFrameItemImage EditorRequestedNewImage();

		/// <summary>Adds an <see cref="IFrameItemVideo" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrameItemVideo" />.</summary>
		IFrameItemVideo EditorRequestedNewVideo();

		/// <summary>Adds an <see cref="IFrame" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrame" />.</summary>
		IFrame EditorRequestedNewFrame();

		/// <summary>Removes the <paramref name="child" /> from the <see cref="FrameChildren" />.</summary>
		void EditorRequestedRemoveChild(IFrameItem child);
		#endregion
	}
}