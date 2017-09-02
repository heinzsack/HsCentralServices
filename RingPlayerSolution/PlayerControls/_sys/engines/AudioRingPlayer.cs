// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-07-27</creation-date>
// <modified>2017-09-02 17:34</modify-date>

using System;
using System.Linq;
using CsWpfBase.env.extensions;
using CsWpfBase.env._base;
using PlayerControls.Interfaces.audio;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls._sys.engines
{
	/// <summary>Used to play audio.</summary>
	public class AudioRingPlayer : Base
	{
		private static AudioRingPlayer _instance;
		private static readonly object SingletonLock = new object();

		/// <summary>Returns the singleton instance</summary>
		internal static AudioRingPlayer I
		{
			get
			{
				if (_instance != null)
					return _instance; //Advanced first check to improve performance (no lock needed).
				lock (SingletonLock)
				{
					return _instance ?? (_instance = new AudioRingPlayer());
				}
			}
		}

		private AudioRingPlayer()
		{
			RingEngine = new RingEngine<IAudioRingEntry>();
			SmoothPlayer = new SmoothAudioPlayer(NewSoundFileNeeded);
			RingEngine.CurrentEntryChanged += PlayAudio;
			RingEngine.Start();
		}



		///<summary>The audio ring which is meant to be played.</summary>
		public RingEngine<IAudioRingEntry> RingEngine { get; set; }

		///<summary>The audio ring which is meant to be played.</summary>
		public IRing<IAudioRingEntry> AudioRing
		{
			get => RingEngine.Ring;
			set
			{
				if (RingEngine.Ring == value)
					return;

				var old = RingEngine.Ring;
				RingEngine.Ring = value;
				OnPropertyChanged();
				AudioRingChanged(old, value);
			}
		}
		private SmoothAudioPlayer SmoothPlayer { get; }

		private RingEngine<IAudioRingEntry>.CurrentEntryChangedArgs CurrentList { get; set; }

		private Uri NewSoundFileNeeded()
		{
			var random = CurrentList?.Entry?.AudioFiles?.PickRandom();
			return random != null ? new Uri(random) : null;
		}

		private void AudioRingChanged(IRing<IAudioRingEntry> oldRing, IRing<IAudioRingEntry> newRing)
		{
			if (newRing == null)
			{
				SmoothPlayer.Stop();
			}
		}

		private void PlayAudio(RingEngine<IAudioRingEntry>.CurrentEntryChangedArgs args)
		{
			CurrentList = args;
			if (args.Entry.AudioFiles?.Any() == true)
				SmoothPlayer.Start();
			else
				SmoothPlayer.Stop();
		}
	}
}