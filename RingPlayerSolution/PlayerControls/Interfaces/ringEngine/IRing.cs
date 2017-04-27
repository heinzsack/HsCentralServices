// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 15:44</modify-date>

using System;
using PlayerControls._sys.engines;






namespace PlayerControls.Interfaces.ringEngine
{
	/// <summary>
	///     A structure which has a <see cref="RingStartTime" /> a <see cref="RingPeriod" /> and <see cref="IRing{TItem}.RingItems" />
	///     which can be used with the <see cref="RingEngine{TItem}" /> to allow a always looping playing structure.
	/// </summary>
	public interface IRing
	{


		#region Abstract
		/// <summary>
		///     The total length of the <see cref="IRing" />. After the length is exceeded (<see cref="RingStartTime" /> +
		///     <see cref="RingPeriod" />) the <see cref="IRing" /> will start from the beginning.
		/// </summary>
		TimeSpan RingPeriod { get; }
		/// <summary>
		///     The <see cref="RingStartTime" /> of the <see cref="IRing" /> describes when the ring is meant to be started. All the
		///     <see cref="IRing{TItem}.RingItems" /> and its
		///     <see cref="IRingEntry.RingEntryStartTime" /> will be based on the <see cref="RingStartTime" />. The
		///     <see cref="RingStartTime" /> can be interpreted as offset.
		/// </summary>
		DateTime RingStartTime { get; }
		/// <summary>The amount of buffered items. This might be useful to avoid flickering in the application.</summary>
		int RingBufferSize { get; }
		#endregion


	}



	public interface IRing<out TItem> : IRing where TItem : IRingEntry
	{


		#region Abstract
		/// <summary>The <see cref="RingItems" /> inside the ring which are meant to be played.</summary>
		TItem[] RingItems { get; }
		#endregion


	}


}