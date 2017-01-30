// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;






namespace PlayerControls.Interfaces.Transistions
{
	/// <summary>Describes how the value will changed over time.</summary>
	public enum TransitionTypes
	{
		/// <summary>y=kx+d. Where y equals the current valid value and x the current time.</summary>
		Linear,
		/// <summary>y=2^x.  Where y equals the current valid value and x the current time.</summary>
		Exponential,
		/// <summary>y=x³.  Where y equals the current valid value and x the current time.</summary>
		Cubic
	}
}