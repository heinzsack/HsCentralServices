// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 13:40</modify-date>

using System;
using System.Runtime.Serialization;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls._sys.engines;






// ReSharper disable InconsistentNaming

namespace PlayerControls._sys.exceptions
{
	/// <summary>Occurs whenever there are problems withing the <see cref="RingEngine{TItem}" />.</summary>
	public sealed class RingEngineException_InvalidRing : RingEngineException
	{
		public static void ThrowIfInvalid<TType>(IRing<TType> ring) where TType : IRingEntry
		{
			var now = DateTime.Now;
			if (ring.RingStartTime > now)
				throw new RingEngineException_InvalidRing($"The start time of the {nameof(IRing)}[{ring.RingStartTime:dd.MM.yy HH:mm:ss.fffff}] must be smaller then the actual date {now:dd.MM.yy HH:mm:ss.fffff}.");
			if (ring.RingPeriod.Ticks <= 0)
				throw new RingEngineException_InvalidRing($"The {nameof(IRing.RingPeriod)} of the {nameof(IRing)}[{ring.RingPeriod.Ticks} Ticks] must be greater then [0].");
			if (ring.RingBufferSize < 0)
				throw new RingEngineException_InvalidRing($"The {nameof(IRing.RingBufferSize)} of the {nameof(IRing)}[{ring.RingBufferSize}] must be greater then [-1].");
			if (ring.RingBufferSize > 10)
				throw new RingEngineException_InvalidRing($"The {nameof(IRing.RingBufferSize)} of the {nameof(IRing)}[{ring.RingBufferSize}] must be smaller or equal to [10].");
		}

		private RingEngineException_InvalidRing(string description) : base(description)
		{
		}


		private RingEngineException_InvalidRing(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}