// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 13:06</modify-date>

using System;
using System.Runtime.Serialization;
using PlayerControls._sys.engines;






// ReSharper disable InconsistentNaming





namespace PlayerControls._sys.exceptions
{
	/// <summary>Occurs whenever there are problems withing the <see cref="RingEngine{TItem}" />.</summary>
	public sealed class RingEngineException_InvalidArgument : RingEngineException
	{
		public static RingEngineException_InvalidArgument NullOrEmpty(string argument)
		{
			throw new RingEngineException_InvalidArgument($"The passed argument '{argument}' is null or empty.");
		}
		public static RingEngineException_InvalidArgument SmallerThenZero(string argument, int value)
		{
			throw new RingEngineException_InvalidArgument($"The passed argument '{argument}'[{value}] is smaller then zero.");
		}
		public static RingEngineException_InvalidArgument OutOfRange(string argument, int value, int maximum)
		{
			throw new RingEngineException_InvalidArgument($"The passed argument '{argument}'[{value}] greater then allowed value [{maximum}].");
		}

		public RingEngineException_InvalidArgument(string description) : base(description)
		{
		}


		private RingEngineException_InvalidArgument(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}