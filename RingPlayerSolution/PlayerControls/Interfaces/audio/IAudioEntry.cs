// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 19:03</modify-date>

using System;
using System.IO;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls.Interfaces.audio
{
	/// <summary>Used as the base interface for playing audio from a <see cref="IRing" />.</summary>
	public interface IAudioRingEntry : IRingEntry
	{


		#region Abstract
		/// <summary>The audio files which are meant to be played.</summary>
		string[] AudioFiles { get; }
		/// <summary>If true the audio files will be randomized.</summary>
		bool AudioRandomize { get; }
		#endregion


	}
}