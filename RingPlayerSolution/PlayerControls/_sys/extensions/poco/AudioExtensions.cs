// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-29</creation-date>
// <modified>2017-04-29 10:56</modify-date>

using System;
using System.Collections.Generic;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces.audio;
using PlayerControls._sys.pocos.audio;






namespace PlayerControls._sys.extensions.poco
{
	public static class AudioExtensions
	{
		/// <summary>Converts the <see cref="IAudioRing" /> into a <see cref="PocoAudioRing" /> which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IAudioRing" /> to convert.</param>
		public static PocoAudioRing ToPoco(this IAudioRing source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IAudioRingEntry" /> into a <see cref="PocoAudioRingEntry" /> which is serializeable to json or
		///     binary.
		/// </summary>
		/// <param name="source">The <see cref="IAudioRingEntry" /> to convert.</param>
		public static PocoAudioRingEntry ToPoco(this IAudioRingEntry source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IEnumerable{IAudioRingEntry}" /> into a <see cref="PocoAudioRing" /> which is serializeable to
		///     json or binary.
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{IAudioRingEntry}" /> to convert.</param>
		/// <param name="startTime">
		///     The time where the <see cref="IAudioRingEntry.RingEntryStartTime" /> of value '
		///     <see cref="TimeSpan.Zero" />' is located at. If you have a <paramref name="startTime" /> at one o clock, the
		///     <see cref="IAudioRingEntry" /> with the <see cref="IAudioRingEntry.RingEntryStartTime" /> of <see cref="TimeSpan.Zero" />
		///     will begin at one o clock.
		/// </param>
		/// <param name="duration">The total length of the <see cref="IAudioRing" />.</param>
		public static PocoAudioRing ToPoco(this IEnumerable<IAudioRingEntry> source, DateTime startTime, TimeSpan duration)
		{
			return source.ToPoco(startTime, duration, new ConversionContext());
		}

		private static PocoAudioRing ToPoco(this IAudioRing source, ConversionContext context)
		{
			var poco = source as PocoAudioRing;
			if (poco != null || context.GetOrCreate(source, () => new PocoAudioRing(), out poco))
				return poco;



			source.CopyTo(poco, nameof(IAudioRing.RingItems));
			poco.PocoRingItems = source.RingItems.Select(entry => ToPoco(entry, context)).ToList();

			return poco;
		}

		private static PocoAudioRingEntry ToPoco(this IAudioRingEntry source, ConversionContext context)
		{
			var poco = source as PocoAudioRingEntry;
			if (poco != null || context.GetOrCreate(source, () => new PocoAudioRingEntry(), out poco))
				return poco;


			source.CopyTo(poco, nameof(IAudioRingEntry.AudioFiles), nameof(IAudioRingEntry.AudioIds));
			poco.AudioGuidList = source.AudioIds.ToList();
			return poco;
		}

		private static PocoAudioRing ToPoco(this IEnumerable<IAudioRingEntry> source, DateTime startTime, TimeSpan duration, ConversionContext context)
		{
			return new PocoAudioRing
					{
						RingStartTime = startTime,
						RingPeriod = duration,
						RingBufferSize = 1,
						PocoRingItems = source.Select(x => x.ToPoco(context)).ToList()
					};
		}



	}

}