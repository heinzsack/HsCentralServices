// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 19:35</modify-date>

using System;
using PlayerControls.Interfaces.audio;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls._sys.engines;






namespace PlayerControls._sys.extensions
{
	public static class AudioExtensions
	{
		public static void Play(this IRing<IAudioRingEntry> ring)
		{
			AudioRingPlayer.I.AudioRing = ring;
		}
	}
}