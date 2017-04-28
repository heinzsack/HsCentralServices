// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 14:50</modify-date>

using System;
using System.Collections.Generic;
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
		private List<string> _audioFilesList;
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
		[JsonIgnore]
		public IEnumerable<string> AudioFiles => _audioFilesList;
		/// <inheritdoc />
		[JsonProperty("Randomize")]
		public bool AudioRandomize
		{
			get => _audioRandomize;
			set => SetProperty(ref _audioRandomize, value);
		}
		#endregion


		///<summary>Contains the list which is returned when accessing the <see cref="AudioFiles"/> property.</summary>
		[JsonProperty("Files")]
		public List<string> AudioFilesList
		{
			get => _audioFilesList ?? (_audioFilesList = new List<string>());
			set => SetProperty(ref _audioFilesList, value);
		}

		public bool ShouldSerializeAudioFilesList()
		{
			return _audioFilesList != null && _audioFilesList.Count != 0;
		}



		public static class Mock
		{
			public static List<PocoAudioRingEntry> Get(TimeSpan duration)
			{
				var framesPerMinute = 6;
				var secondsPerFrame = 60 / framesPerMinute;

				var entries = new List<PocoAudioRingEntry>();
				for (var i = 0; i < duration.Minutes * framesPerMinute; i++)
					entries.Add(new PocoAudioRingEntry
								{
									RingEntryStartTime = TimeSpan.FromSeconds(i * secondsPerFrame),
									AudioFilesList = new DirectoryInfo(@"\\sack\_Musik\Musik von Chris\YouTube Music").GetFiles().Select(x => x.FullName).ToList(),
								});
				return entries;
			}
		}
	}
}