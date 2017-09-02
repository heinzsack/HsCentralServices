// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-05-03 17:07</modify-date>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PlayerControls.Interfaces.audio;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls._sys.engines;
using PlayerControls._sys.extensions.tools;
using PlayerControls._sys.pocos.audio;






namespace PlayerControls._sys.extensions
{
	public static class AudioExtensions
	{
		/// <summary>
		///     Generates a <see cref="PocoAudioRing" /> which fills all audio gaps between videos with the specified audio
		///     <paramref name="ids" />.
		/// </summary>
		/// <param name="ring">The ring from which the audio should be generated.</param>
		/// <param name="ids">The audio ids</param>
		public static PocoAudioRing CreateGapFillingAudioRing(this IRing<IFrameRingEntry> ring, IEnumerable<Guid> ids)
		{
			var audioIds = ids as List<Guid> ?? ids.ToList();
			var frameAnalyses = new Dictionary<IFrameRingEntry, FrameAnalysis>();
			var audioRing = new PocoAudioRing
							{
								RingBufferSize = 1,
								RingPeriod = ring.RingPeriod,
								RingStartTime = ring.RingStartTime
							};


			var foo = ring.RingItems as IFrameRingEntry[] ?? ring.RingItems.ToArray();
			var audioStarted = (foo[foo.Length-1].RingEntryFrame?.Analyse().Videos.Count??0) == 0;
			foreach (var entry in ring.RingItems)
			{
				FrameAnalysis analysis;

				if (!frameAnalyses.TryGetValue(entry, out analysis))
				{
					analysis = entry.RingEntryFrame?.Analyse();
					frameAnalyses.Add(entry, analysis);
				}
				if ((analysis?.Videos.Count??0) != 0)
				{
					// Video will start
					if (!audioStarted)
						continue;
					audioRing.PocoRingItems.Add(new PocoAudioRingEntry { AudioGuidList = null, RingEntryStartTime = entry.RingEntryStartTime });
					audioStarted = false;
				}
				else
				{
					// Video will stop
					if (audioStarted)
						continue;

					audioRing.PocoRingItems.Add(new PocoAudioRingEntry
												{
													RingEntryStartTime = entry.RingEntryStartTime,
													AudioGuidList = audioIds,
												});
					audioStarted = true;
				}
			}

			return audioRing;
		}

		/// <summary>Plays the <paramref name="ring" /> to the sound card.</summary>
		public static void Play(this IRing<IAudioRingEntry> ring)
		{
			AudioRingPlayer.I.AudioRing = ring;
		}
	}
}
