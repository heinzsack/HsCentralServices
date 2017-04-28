// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-28</creation-date>
// <modified>2017-04-28 14:44</modify-date>

using System;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls.Interfaces.presentation
{
	/// <summary>A ring of <see cref="IFrameRingEntry" />'s.</summary>
	public interface IFrameRing : IRing<IFrameRingEntry>
	{
	}
}