// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-05-03 16:58</modify-date>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using Newtonsoft.Json;
using PlayerControls.Interfaces.audio;






namespace PlayerControls._sys.pocos.audio
{



	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoAudioRingEntry : Base, IAudioRingEntry
	{
		private List<Guid> _audioFilesList;
		private string _ringEntryInterrupt;
		private TimeSpan _ringEntryStartTime;


		#region EVENTS
		/// <summary>Occurs whenever a audio file is requested through the <see cref="PocoAudioRingEntry" />.</summary>
		public static event Delegate0 AudioFileRequested;
		#endregion


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("StartTime")]
		public TimeSpan RingEntryStartTime
		{
			get => _ringEntryStartTime;
			set => SetProperty(ref _ringEntryStartTime, value);
		}
		/// <inheritdoc />
		[JsonProperty("Interrupt")]
		public string RingEntryInterrupt
		{
			get => _ringEntryInterrupt;
			set => SetProperty(ref _ringEntryInterrupt, value);
		}
		/// <inheritdoc />
		public IEnumerable<string> AudioFiles => AudioIds?.Select(x =>
		{
			var args = new AudioRequestedArgs(this, x);
			AudioFileRequested?.Invoke(args);
			return args.Result;
		}).Where(x => x != null).Select(x => x.FullName);

		/// <inheritdoc />
		[JsonIgnore]
		public IEnumerable<Guid> AudioIds => AudioGuidList;
		#endregion


		/// <summary>Contains the list which is returned when accessing the <see cref="AudioFiles" /> property.</summary>
		[JsonProperty("Ids")]
		public List<Guid> AudioGuidList
		{
			get => _audioFilesList ?? (_audioFilesList = new List<Guid>());
			set => SetProperty(ref _audioFilesList, value);
		}

		public bool ShouldSerializeAudioGuidList()
		{
			return _audioFilesList != null && _audioFilesList.Count != 0;
		}



		public delegate void Delegate0(AudioRequestedArgs args);



		public class AudioRequestedArgs
		{
			public AudioRequestedArgs(PocoAudioRingEntry entry, Guid id)
			{
				Entry = entry;
				Id = id;
			}

			public PocoAudioRingEntry Entry { get; }
			public Guid Id { get; }
			public FileInfo Result { get; set; }
		}



		public static class Mock
		{
			public static void HandleEvent()
			{
				AudioFileRequested += args =>
				{
					if (args.Id == Guid.Empty)
						args.Result = new DirectoryInfo(@"\\sack\_Musik\Musik von Chris\YouTube Music").GetFiles().PickRandom();
				};
			}

			public static List<PocoAudioRingEntry> Get(TimeSpan duration)
			{
				var framesPerMinute = 15;
				var secondsPerFrame = 60 / framesPerMinute;

				var entries = new List<PocoAudioRingEntry>();
				for (var i = 0; i < duration.Minutes * framesPerMinute; i++)
					entries.Add(new PocoAudioRingEntry
								{
									RingEntryStartTime = TimeSpan.FromSeconds(i * secondsPerFrame),
									AudioGuidList = new List<Guid>{Guid.Empty},
								});
				return entries;
			}
		}
	}
}