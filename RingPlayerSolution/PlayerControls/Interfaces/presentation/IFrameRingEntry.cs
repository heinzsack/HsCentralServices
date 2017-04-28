// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 18:10</modify-date>

using System;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls.Themes;






namespace PlayerControls.Interfaces.presentation
{
	/// <summary>Used when <see cref="IFrame" />s need to be presented in a circular way with timings.</summary>
	public interface IFrameRingEntry : IRingEntry
	{


		#region Abstract
		/// <summary>The <see cref="IFrame" /> which should be played at the according <see cref="IRingEntry.RingEntryStartTime" />.</summary>
		IFrame Frame { get; }
		/// <summary>If not null this will produce a interrupt on the <see cref="FrameRingPresenter"/> which have to provide a <see cref="IFrame" />.</summary>
		string RingEntryInterrupt { get; }
		#endregion


	}
}