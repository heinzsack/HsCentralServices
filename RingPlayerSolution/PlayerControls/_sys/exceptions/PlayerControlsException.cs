﻿// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 12:45</modify-date>

using System;
using System.Runtime.Serialization;






namespace PlayerControls._sys.exceptions
{
	/// <summary>Occurs whenever there are problems withing the <see cref="PlayerControls" />.</summary>
	public class PlayerControlsException : Exception
	{
		public PlayerControlsException()
		{
		}

		public PlayerControlsException(string message) : base(message)
		{
		}

		public PlayerControlsException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected PlayerControlsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}



}