// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;






namespace PlayerControls.Interfaces.Transistions
{
	/// <summary>Used for transitions like the <see cref="IDoubleTransition" />.</summary>
	public interface ITransition
	{
		#region Abstract
		/// <summary>The time when the animation should fire after the <see cref="IFrame"/> is visible.</summary>
		TimeSpan TransitionBeginTime { get; }
		/// <summary>The <see cref="Duration"/> of the animation.</summary>
		Duration TransitionDuration { get; }
		#endregion
	}
}