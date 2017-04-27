// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using PlayerControls.Interfaces.presentation._base;






namespace PlayerControls.Interfaces.presentation.Transistions
{
	/// <summary>Used for animating properties of type double.</summary>
	public interface IDoubleTransition : ITransition
	{
		#region Abstract
		/// <summary>The starting value of this animation.</summary>
		double TransitionFromValue { get; }
		/// <summary>The target value after the animation completes.</summary>
		double TransitionToValue { get; }
		/// <summary>
		///     The path to the property which should be animated. The property type should be numeric like (int, int64, double,
		///     float,...)
		/// </summary>
		string TransitionPropertyPath { get; }
		/// <summary>The type of the transition look at <see cref="TransitionTypes" /> for further informations.</summary>
		TransitionTypes TransitionsType { get; }
		#endregion
	}



}