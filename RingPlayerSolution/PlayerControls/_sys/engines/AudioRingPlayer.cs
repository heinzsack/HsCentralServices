// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-07-27</creation-date>
// <modified>2017-07-27 11:44</modify-date>

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
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

		private static TimeSpan FadeOutTime { get; } = TimeSpan.FromSeconds(5);
		private static TimeSpan FadeInTime { get; } = TimeSpan.FromSeconds(5);

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
			RingEngine.CurrentEntryChanged += PlayAudio;
			RingEngine.BufferedEntryAdded += BufferAudio;
			RingEngine.Start();

			SoundPlayer1.MediaFailed += SoundPlayer1OnMediaFailed;
			SoundPlayer2.MediaFailed += SoundPlayer1OnMediaFailed;
			SoundPlayer1.Volume = SoundPlayer2.Volume = 0;
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
		private MediaPlayer SoundPlayer1 { get; } = new MediaPlayer();
		private MediaPlayer SoundPlayer2 { get; } = new MediaPlayer();
		private FadeTimer FadeOutTimer { get; set; }
		private FadeTimer FadeInTimer { get; set; }
		private bool _bufferTargetPlayer { get; set; }
		private bool _soundPlayer { get; set; }

		/// <summary>Contains the current inactive <see cref="MediaPlayer" />.</summary>
		private MediaPlayer BufferTargetPlayer
		{
			get
			{
				if (_bufferTargetPlayer)
					return SoundPlayer1;
				return SoundPlayer2;
			}
		}
		/// <summary>Contains the current active <see cref="MediaPlayer" />.</summary>
		private MediaPlayer SoundPlayer
		{
			get
			{
				if (_soundPlayer)
					return SoundPlayer1;
				return SoundPlayer2;
			}
		}

		private void SoundPlayer1OnMediaFailed(object sender, ExceptionEventArgs exceptionEventArgs)
		{
			Debug.WriteLine(exceptionEventArgs.ErrorException.Message);
		}


		/// <summary>Switches the <see cref="BufferTargetPlayer" /> with the <see cref="SoundPlayer" />.</summary>
		private void SwitchTargetBufferPlayer()
		{
			_bufferTargetPlayer = !_bufferTargetPlayer;
		}

		/// <summary>Switches the <see cref="BufferTargetPlayer" /> with the <see cref="SoundPlayer" />.</summary>
		private void SwitchSoundPlayer()
		{
			_soundPlayer = !_soundPlayer;
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

		/// <summary>Starts the <see cref="SoundPlayer" /> and stops the <see cref="BufferTargetPlayer" />.</summary>
		private void PlayAudio(RingEngine<IAudioRingEntry>.CurrentEntryChangedArgs args)
		{
			try
			{
				if (SoundPlayer.Source == null)
					return;

				SoundPlayer.Play();
				if (args.Duration < TimeSpan.FromSeconds(3))
				{
					SoundPlayer.Volume = 1;
					return;
				}

				SoundPlayer.Volume = 0;

				var now = DateTime.Now;
				var fadeInEnd = now.Add(FadeInTime);
				var fadeOutStart = now.Add(args.Duration).Subtract(FadeOutTime);

				var difference = fadeOutStart - fadeInEnd;

				if (difference < TimeSpan.FromSeconds(1))
				{
					var halfDuration = new TimeSpan(args.Duration.Ticks / 2);
					fadeInEnd = now.Add(halfDuration.Subtract(TimeSpan.FromSeconds(0.5)));
					fadeOutStart = now.Add(halfDuration.Add(TimeSpan.FromSeconds(0.5)));
				}

				FadeInTimer = new FadeTimer(SoundPlayer, 1, now, fadeInEnd - now);
				if (fadeOutStart > now)
					FadeOutTimer = new FadeTimer(SoundPlayer, 0, fadeOutStart, now.Add(args.Duration) - fadeOutStart);

			}
			finally
			{
				SwitchSoundPlayer();
			}


		}

		/// <summary>Starts buffering the audio.</summary>
		private void BufferAudio(RingEngine<IAudioRingEntry>.NewBufferedElementArgs args)
		{
			try
			{
				var audioFiles = args.Entry.AudioFiles as string[] ?? args.Entry.AudioFiles.ToArray();
				if (audioFiles.Length == 0)
				{
					BufferTargetPlayer.Close();
					return;
				}
				BufferTargetPlayer.Open(new Uri(audioFiles.PickRandom(), UriKind.Absolute));
			}
			finally
			{
				SwitchTargetBufferPlayer();
			}
		}



		private class FadeTimer : IDisposable
		{
			private static TimeSpan MinTimeBetweenSteps { get; } = TimeSpan.FromMilliseconds(60);
			private readonly TimeSpan _duration;
			private readonly DateTime _startTime;
			private readonly double _targetValue;

			public FadeTimer(MediaPlayer player, double targetValue, DateTime startTime, TimeSpan duration)
			{
				Player = player;
				_targetValue = targetValue;
				_startTime = startTime;
				_duration = duration;

				var now = DateTime.Now;


				if (startTime.Add(duration) < now)
				{
					player.Volume = targetValue;
					return;
				}

				if (_duration < MinTimeBetweenSteps)
				{
					player.Volume = targetValue;
					return;
				}

				Timer = new DispatcherTimer();
				Timer.Tick += TimerOnTick;


				if (startTime - now < TimeSpan.Zero)
				{
					TimerOnTick(null, null);
				}
				else
				{
					Timer.Interval = startTime - now;
					Timer.Start();
				}

			}


			#region Overrides/Interfaces
			/// <inheritdoc />
			public void Dispose()
			{
				Timer = null;
				Player = null;
			}
			#endregion


			private MediaPlayer Player { get; set; }
			private DispatcherTimer Timer { get; set; }


			private int RemainingSteps { get; set; }
			private double StepIncrement { get; set; }

			private void TimerOnTick(object sender, EventArgs eventArgs)
			{
				Timer.Stop();
				CoerceParameters();

				Player.Volume += StepIncrement;

				if (RemainingSteps == 0)
				{
					Dispose();
					return;
				}
				Timer.Interval = MinTimeBetweenSteps;
				Timer.Start();
			}


			private void CoerceParameters()
			{
				TimeSpan remainingTime = _startTime.Add(_duration) - DateTime.Now;
				double remainingVolume = _targetValue - Player.Volume;

				RemainingSteps = (int) (remainingTime.Ticks / MinTimeBetweenSteps.Ticks);
				if (RemainingSteps < 0)
					RemainingSteps = 0;

				StepIncrement = remainingVolume / (RemainingSteps == 0 ? 1 : RemainingSteps);
				if (StepIncrement == 0)
					RemainingSteps = 0;
			}
		}
	}
}