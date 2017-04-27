// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-01-26</creation-date>
// <modified>2017-04-26 21:06</modify-date>

using System;
using System.Collections;
using PlayerControls.Interfaces.presentation.Transistions;
using PlayerControls.Interfaces.presentation._base;






namespace PlayerControls.Interfaces.presentation.FrameItems
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
		IEnumerable FrameChildren { get; }

		/// <summary>Could be any <see cref="ITransition" /> item.</summary>
		IEnumerable FrameTransitions { get; }

		/// <summary>Adds an <see cref="IFrameText" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrameText" />.</summary>
		IFrameText EditorRequestedNewText();

		/// <summary>Adds an <see cref="IFrameImage" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrameImage" />.</summary>
		IFrameImage EditorRequestedNewImage();

		/// <summary>Adds an <see cref="IFrameVideo" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrameVideo" />.</summary>
		IFrameVideo EditorRequestedNewVideo();

		/// <summary>Adds an <see cref="IFrame" /> to the <see cref="FrameChildren" /> collection and returns the added
		///     <see cref="IFrame" />.</summary>
		IFrame EditorRequestedNewFrame();

		/// <summary>Removes the <paramref name="child" /> from the <see cref="FrameChildren" />.</summary>
		void EditorRequestedRemoveChild(IFrameItem child);
		#endregion


	}
}