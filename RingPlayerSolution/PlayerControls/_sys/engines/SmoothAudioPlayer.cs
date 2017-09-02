// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-08-13</creation-date>
// <modified>2017-09-02 15:56</modify-date>

using System;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using CsWpfBase.csglobal;
using CsWpfBase.env.extensions;
using CsWpfBase.env._base;






namespace PlayerControls._sys.engines
{
	public class SmoothAudioPlayer : Base
	{
		private TimeSpan _fadeDuration = TimeSpan.FromSeconds(10);
		private TimeSpan _fadeOverlap = TimeSpan.FromSeconds(5);
		private bool _isRunning;

		private bool _isStarting;
		private Func<Uri> _newSoundFileNeeded;

		public SmoothAudioPlayer(Func<Uri> newSoundFileNeeded)
		{
			_newSoundFileNeeded = newSoundFileNeeded;

			SoundPlayer1.MediaFailed += OnMediaFailed;
			SoundPlayer2.MediaFailed += OnMediaFailed;
			SoundPlayer1.Volume = SoundPlayer2.Volume = 0;

			SoundPlayer1.MediaOpened += OnMediaOpened;
			SoundPlayer2.MediaOpened += OnMediaOpened;
		}

		///<summary>True if start was called.</summary>
		private bool IsStarting
		{
			get => _isStarting;
			set => SetProperty(ref _isStarting, value);
		}
		/// <summary>If true the <see cref="SmoothAudioPlayer" /> is currently playing.</summary>
		public bool IsRunning
		{
			get => _isRunning;
			private set => SetProperty(ref _isRunning, value);
		}

		///<summary>The duration the audio is faded in or out.</summary>
		public TimeSpan FadeDuration
		{
			get => _fadeDuration;
			set => SetProperty(ref _fadeDuration, value);
		}

		///<summary>The time the fading is overlapped.</summary>
		public TimeSpan FadeOverlap
		{
			get => _fadeOverlap;
			set => SetProperty(ref _fadeOverlap, value);
		}
		private DispatcherTimer StartNextTimer { get; set; }



		private MediaPlayer SoundPlayer1 { get; } = new MediaPlayer();
		private MediaPlayer SoundPlayer2 { get; } = new MediaPlayer();


		public void Start()
		{
			if (IsRunning)
				return;
			IsRunning = true;
			IsStarting = true;
			
			SoundPlayer1.Open(_newSoundFileNeeded());
			SoundPlayer2.Open(_newSoundFileNeeded());
		}

		public void Stop()
		{
			if (!IsRunning)
				return;
			IsRunning = false;
			StartNextTimer?.Stop();

			SoundPlayer1.CancleFadings();
			SoundPlayer2.CancleFadings();
			SoundPlayer1.Close();
			SoundPlayer2.Close();
		}


		private void OnMediaFailed(object sender, ExceptionEventArgs exceptionEventArgs)
		{
			CsGlobal.Log.Error($"{nameof(SmoothAudioPlayer)} failed to load media", exceptionEventArgs.ErrorException);
		}

		private void OnMediaOpened(object sender, EventArgs eventArgs)
		{
			if (!IsRunning)
				return;

			((MediaPlayer) sender).Volume = 0;

			if (IsStarting)
			{
				if (!ReferenceEquals(sender, SoundPlayer1))
					return;
				IsStarting = false;
				StartPlayer(SoundPlayer1);
				return;
			}
		}

		private void StartPlayer(MediaPlayer player)
		{
			player.Play();
			player.FadeAudio(0, 0.5, FadeDuration); //Fade in
			player.FadeAudio(0.5, 0, FadeDuration, player.NaturalDuration.TimeSpan.Subtract(FadeDuration)).ContinueWith(t =>
			{
				player.Close();
				if (!IsRunning)
					return;

				player.Open(_newSoundFileNeeded()); //Buffer next
			}, TaskScheduler.FromCurrentSynchronizationContext());

			StartNextTimer = new DispatcherTimer
			{
				Interval = player.NaturalDuration.TimeSpan.Subtract(player.Position).Subtract(FadeOverlap)
			};

			StartNextTimer.Tick += (o, args) =>
			{
				StartNextTimer.Stop();

				if (!IsRunning)
					return;

				StartPlayer(ReferenceEquals(player, SoundPlayer1) ? SoundPlayer2 : SoundPlayer1);
			};
			StartNextTimer.Start();
		}

	}
}