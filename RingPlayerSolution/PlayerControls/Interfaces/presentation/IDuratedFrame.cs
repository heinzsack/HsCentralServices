// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls.Interfaces.presentation
{
	/// <summary>Used when <see cref="IFrame" />s need to be presented in a circular way with relative timings.</summary>
	[Obsolete("Das interface IDuratedFrame ist obsolet. Stattdessen sollten nur noch Ringe verwendet werden.")]
	public interface IDuratedFrame
	{
		#region Abstract
		/// <summary>The <see cref="IFrame"/> which is meant to be played.</summary>
		IFrame Frame { get; }
		/// <summary>The duration the <see cref="Frame" /> should be presented.</summary>
		Duration FrameDuration { get; }
		#endregion
	}
}