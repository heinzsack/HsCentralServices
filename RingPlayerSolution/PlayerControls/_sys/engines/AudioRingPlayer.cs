// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 20:33</modify-date>

using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Threading;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces.audio;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls._sys.engines
{
	/// <summary>Used to play audio.</summary>
	public class AudioRingPlayer : Base
	{
		private static AudioRingPlayer _instance;
		private static readonly object SingletonLock = new object();


		private static double FadeOutDecrement { get; } = 0.025;
		private static double FadeInIncrement { get; } = 0.025;
		private static TimeSpan FadeOutTime { get; } = TimeSpan.FromSeconds(4);
		private static TimeSpan FadeInTime { get; } = TimeSpan.FromSeconds(4);
		private static TimeSpan FadeOutDecrementInterval { get; } = new TimeSpan((long) (FadeOutTime.Ticks/ (1/FadeOutDecrement)));
		private static TimeSpan FadeInIncrementInterval { get; } = new TimeSpan((long) (FadeInTime.Ticks/ (1/FadeOutDecrement)));

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
		private MediaPlayer SoundPlayer1 { get; } = new MediaPlayer();
		private MediaPlayer SoundPlayer2 { get; } = new MediaPlayer();
		private DispatcherTimer FadeOutTimer { get; }
		private DispatcherTimer FadeInTimer { get; }
		private bool SoundPlayer1Active { get; set; }

		/// <summary>Contains the current inactive <see cref="MediaPlayer" />.</summary>
		private MediaPlayer FreeSoundPlayer
		{
			get
			{
				if (SoundPlayer1Active)
					return SoundPlayer2;
				return SoundPlayer1;
			}
		}
		/// <summary>Contains the current active <see cref="MediaPlayer" />.</summary>
		private MediaPlayer UsedSoundPlayer
		{
			get
			{
				if (SoundPlayer1Active)
					return SoundPlayer1;
				return SoundPlayer2;
			}
		}

		private AudioRingPlayer()
		{
			RingEngine = new RingEngine<IAudioRingEntry>();
			RingEngine.CurrentEntryChanged += PlayAudio;
			RingEngine.BufferedEntryAdded += BufferAudio;
			RingEngine.Start();


			SoundPlayer1.MediaFailed += SoundPlayer1OnMediaFailed;
			SoundPlayer2.MediaFailed += SoundPlayer1OnMediaFailed;
			SoundPlayer1.Volume = SoundPlayer2.Volume = 0;

			FadeOutTimer = new DispatcherTimer();
			FadeOutTimer.Tick += FadeOutTimerOnTick;
			FadeInTimer = new DispatcherTimer();
			FadeInTimer.Tick += FadeInTimerOnTick;
		}



		///<summary>The audio ring which is meant to be played.</summary>
		public RingEngine<IAudioRingEntry> RingEngine { get; }

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

		private void SoundPlayer1OnMediaFailed(object sender, ExceptionEventArgs exceptionEventArgs)
		{
			Debug.WriteLine(exceptionEventArgs.ErrorException.Message);
		}

		private void FadeOutTimerOnTick(object sender, EventArgs eventArgs)
		{
			FadeOutTimer.Stop();



			double volume;
			FadeOutTimer.Tag = volume = ((double)FadeOutTimer.Tag) - FadeOutDecrement;
			UsedSoundPlayer.Volume = volume<0 ? 0 : volume;

			if (volume > 0.0)
			{
				FadeOutTimer.Interval = FadeOutDecrementInterval;
				FadeOutTimer.Start();
			}
		}
		private void FadeInTimerOnTick(object sender, EventArgs e)
		{
			FadeInTimer.Stop();
			double volume;
			FadeInTimer.Tag = volume = ((double)FadeInTimer.Tag) + FadeInIncrement;

			UsedSoundPlayer.Volume = volume > 1 ? 1 : volume;

			if (volume < 1)
			{
				FadeInTimer.Interval = FadeInIncrementInterval;
				FadeInTimer.Start();
			}
		}

		/// <summary>Switches the <see cref="FreeSoundPlayer" /> with the <see cref="UsedSoundPlayer" />.</summary>
		private void SwitchSoundPlayer()
		{
			SoundPlayer1Active = !SoundPlayer1Active;
		}


		private void AudioRingChanged(IRing<IAudioRingEntry> oldRing, IRing<IAudioRingEntry> newRing)
		{
			if (newRing == null)
			{
				SoundPlayer1.Stop();
				SoundPlayer1.Close();

				SoundPlayer2.Stop();
				SoundPlayer2.Close();
			}
		}

		/// <summary>Starts the <see cref="UsedSoundPlayer" /> and stops the <see cref="FreeSoundPlayer" />.</summary>
		private void PlayAudio(RingEngine<IAudioRingEntry>.CurrentEntryChangedArgs args)
		{
			SwitchSoundPlayer();
			FreeSoundPlayer.Stop();
			FreeSoundPlayer.Close();

			UsedSoundPlayer.Play();
			
			FadeInTimer.Tag = UsedSoundPlayer.Volume = 0D;
			FadeInTimer.Start();

			var interval = args.Duration.Subtract(FadeOutTime);
			if (interval > TimeSpan.Zero)
			{
				FadeOutTimer.Tag = 1D;
				FadeOutTimer.Interval = interval;
				FadeOutTimer.Start();
			}

		}

		/// <summary>Starts buffering the audio.</summary>
		private void BufferAudio(RingEngine<IAudioRingEntry>.NewBufferedElementArgs args)
		{
			FreeSoundPlayer.Open(new Uri(args.Entry.AudioFiles.PickRandom(), UriKind.Absolute));
		}
	}
}