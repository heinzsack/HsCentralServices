using System;






namespace PlayerControls.Interfaces.Transistions
	{
	public interface IDoubleTransition : ITransition
		{
		double IFrom { get; }
		double ITo { get; }
		String IPropertyPath { get; }
		TransitionTypes ITransitionType { get; }
		}
	}