// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 19:43</modify-date>

using System;
using System.IO;
using System.Linq;
using CsWpfBase.Ev.Objects;
using Newtonsoft.Json;
using PlayerControls.Interfaces.audio;






namespace PlayerControls._sys.pocos.audio
{



	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoAudioRingEntry : Base, IAudioRingEntry
	{
		private string[] _audioFiles;
		private bool _audioRandomize;
		private TimeSpan _ringEntryStartTime;


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("StartTime")]
		public TimeSpan RingEntryStartTime
		{
			get => _ringEntryStartTime;
			set => SetProperty(ref _ringEntryStartTime, value);
		}
		/// <inheritdoc />
		[JsonProperty("Files")]
		public string[] AudioFiles
		{
			get => _audioFiles;
			set => SetProperty(ref _audioFiles, value);
		}
		/// <inheritdoc />
		[JsonProperty("Randomize")]
		public bool AudioRandomize
		{
			get => _audioRandomize;
			set => SetProperty(ref _audioRandomize, value);
		}
		#endregion



		public static class Mock
		{
			public static IAudioRingEntry[] Get(TimeSpan duration)
			{
				var framesPerMinute = 6;
				var secondsPerFrame = 60 / framesPerMinute;

				var entries = new IAudioRingEntry[duration.Minutes * framesPerMinute];
				for (var i = 0; i < entries.Length; i++)
					entries[i] = new PocoAudioRingEntry
								{
									RingEntryStartTime = TimeSpan.FromSeconds(i * secondsPerFrame),
									AudioFiles = new DirectoryInfo(@"\\sack\_Musik\Musik von Chris\YouTube Music").GetFiles().Select(x => x.FullName).ToArray(),
								};
				return entries;
			}
		}
	}
}