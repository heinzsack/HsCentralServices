// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 18:31</modify-date>

using System;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls._sys.exceptions;






namespace PlayerControls._sys.extensions
{
	public static class RingExtensions
	{
		/// <summary>Calculates the last time the <see cref="IRing" /> was restarted.</summary>
		/// <param name="ring">The target <see cref="IRing" />.</param>
		/// <param name="time">The reference time. Could be datetime now.</param>
		public static DateTime Find_LastRingStart<TItem>(this IRing<TItem> ring, DateTime? time = null) where TItem : IRingEntry
		{
			if (ring == null)
				throw RingEngineException_InvalidArgument.NullOrEmpty(nameof(ring));

			RingEngineException_InvalidRing.ThrowIfInvalid(ring);

			if (time == null)
				time = DateTime.Now;


			//Contains the ticks which are past since the last ring start.
			var ticksSinceLastStart = (time.Value - ring.RingStartTime).Ticks % ring.RingPeriod.Ticks;
			var ringStart = new DateTime(time.Value.Ticks - ticksSinceLastStart);
			return ringStart;
		}

		/// <summary>Finds the index of the <see cref="IRingEntry" /> which should be played at the specified <paramref name="time" />.</summary>
		/// <param name="ring">The target <see cref="IRing" /></param>
		/// <param name="time">
		///     The time where you want to gather the playing <see cref="IRingEntry" />. If <paramref name="time" /> equals null
		///     <see cref="DateTime.Now" /> will be used.
		/// </param>
		public static RingEntrySpecification<TItem> Find_Item_At_Time<TItem>(this IRing<TItem> ring, DateTime? time = null) where TItem : IRingEntry
		{
			if (ring == null)
				throw RingEngineException_InvalidArgument.NullOrEmpty(nameof(ring));

			RingEngineException_InvalidRing.ThrowIfInvalid(ring);

			if (time == null)
				time = DateTime.Now;

			var ringStart = ring.Find_LastRingStart(time);

			// The current position in the ring in ticks
			var searchedTickInRing = (time.Value - ringStart).Ticks;

			for (var i = 0; i < ring.RingItems.Length; i++)
			{
				var item = ring.RingItems[i];
				if (item.RingEntryStartTime.Ticks < searchedTickInRing)
					continue;

				int itemIndex;
				if (i == 0)
					itemIndex = ring.RingItems.Length - 1;
				else
					itemIndex = i - 1;

				return new RingEntrySpecification<TItem>(ringStart, ring.RingItems[itemIndex], itemIndex);
			}
			return new RingEntrySpecification<TItem>(ringStart, ring.RingItems[0], 0);
		}

		/// <summary>
		///     Finds the time when the <see cref="IRingEntry" /> with the specified <paramref name="index" /> will be played next time after
		///     the speciefied <paramref name="time" />.
		/// </summary>
		/// <param name="ring">The ring</param>
		/// <param name="index">The index of the <see cref="IRingEntry" /> inside the <paramref name="ring" />.</param>
		/// <param name="time">The time after which the time is searched.</param>
		public static DateTime Find_Time_At_NextPlay<TItem>(this IRing<TItem> ring, int index, DateTime? time = null) where TItem : IRingEntry
		{
			if (ring == null)
				throw RingEngineException_InvalidArgument.NullOrEmpty(nameof(ring));
			if (index < 0)
				throw RingEngineException_InvalidArgument.SmallerThenZero(nameof(index), index);
			if (index >= ring.RingItems.Length)
				throw RingEngineException_InvalidArgument.OutOfRange(nameof(index), index, ring.RingItems.Length - 1);

			RingEngineException_InvalidRing.ThrowIfInvalid(ring);

			if (time == null)
				time = DateTime.Now;

			var ringStart = ring.Find_LastRingStart(time);
			var item = ring.RingItems[index];



			var result = ringStart.Add(item.RingEntryStartTime);

			if (result >= time) // if the resulting value is in the future return
				return result;

			//Otherwise take next ring start and then add start time.
			return ringStart.Add(ring.RingPeriod).Add(item.RingEntryStartTime);
		}


		/// <summary>Decrease the specified <paramref name="index" /> by the <paramref name="value" /> keeping <see cref="IRing" /> metrics.</summary>
		internal static int DecreaseIndexBy<TItem>(this IRing<TItem> ring, int index, int value) where TItem : IRingEntry
		{
			if (value < 0)
				throw RingEngineException_InvalidArgument.SmallerThenZero(nameof(value), value);
			if (index < 0)
				throw RingEngineException_InvalidArgument.SmallerThenZero(nameof(index), index);
			if (ring == null)
				throw RingEngineException_InvalidArgument.NullOrEmpty(nameof(ring));
			if (index >= ring.RingItems.Length)
				throw RingEngineException_InvalidArgument.OutOfRange(nameof(index), index, ring.RingItems.Length - 1);

			if (value == 0)
				return index;

			value = value % ring.RingItems.Length; // if the number is greater then the ring itself.

			var result = index - value;
			if (result >= 0)
				return result;

			//result is smaller then 0
			result = ring.RingItems.Length + result; // if it is minus 1 take the last element and so on.
			return result;
		}

		/// <summary>Increases the specified <paramref name="index" /> by the <paramref name="value" /> keeping <see cref="IRing" /> metrics.</summary>
		internal static int IncreaseIndexBy<TItem>(this IRing<TItem> ring, int index, int value) where TItem : IRingEntry
		{
			if (value < 0)
				throw RingEngineException_InvalidArgument.SmallerThenZero(nameof(value), value);
			if (index < 0)
				throw RingEngineException_InvalidArgument.SmallerThenZero(nameof(index), index);
			if (ring == null)
				throw RingEngineException_InvalidArgument.NullOrEmpty(nameof(ring));
			if (index >= ring.RingItems.Length)
				throw RingEngineException_InvalidArgument.OutOfRange(nameof(index), index, ring.RingItems.Length - 1);

			RingEngineException_InvalidRing.ThrowIfInvalid(ring);

			if (value == 0)
				return index;

			value = value % ring.RingItems.Length; // if the number is greater then the ring itself.

			var result = index + value;
			if (result < ring.RingItems.Length)
				return result;

			//result is greather then the ring length
			result = result - ring.RingItems.Length; // if it is exactly the length take the first element and so on.
			return result;
		}
	}



}