// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 18:30</modify-date>

using System;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls._sys.extensions
{
	/// <summary>Contains ring specifications.</summary>
	public class RingEntrySpecification<TItem> where TItem : IRingEntry
	{
		public RingEntrySpecification(DateTime ringStart, TItem item, int index)
		{
			Entry = item;
			Index = index;
			RingStart = ringStart;
			Start = RingStart.Add(Entry.RingEntryStartTime);
		}

		/// <summary>The <see cref="IRingEntry" /> itself all other properties are related to.</summary>
		public TItem Entry { get; }
		/// <summary>The index of the <see cref="Entry" /> inside the <see cref="IRing" />.</summary>
		public int Index { get; }
		/// <summary>Contains the time when the <see cref="IRing" /> cycle has started from the beginning. This is always in the past.</summary>
		public DateTime RingStart { get; }
		/// <summary>Contains the time when the <see cref="Entry" /> was started.</summary>
		public DateTime Start { get; }
	}
}