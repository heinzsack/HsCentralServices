// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 15:42</modify-date>

using System;
using PlayerControls._sys.engines;






namespace PlayerControls.Interfaces.ringEngine
{
	/// <summary>Represents one item inside the <see cref="IRing{TItem}.RingItems" /> collection inside an <see cref="IRing" />.</summary>
	public interface IRingEntry
	{


		#region Abstract
		/// <summary>The start time of the <see cref="IRingEntry" /> inside a <see cref="IRing" />.</summary>
		TimeSpan RingEntryStartTime { get; }
		/// <summary>If not null this will produce a interrupt while buffering inside the <see cref="RingEngine{TItem}"/>.</summary>
		string RingEntryInterrupt { get; }
		#endregion


	}
}