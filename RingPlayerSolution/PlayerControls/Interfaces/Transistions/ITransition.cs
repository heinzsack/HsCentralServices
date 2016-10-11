using System;
using System.Windows;






namespace PlayerControls.Interfaces.Transistions
	{
	public interface ITransition
		{
		TimeSpan IBeginTime { get; }
		Duration IDuration { get; }
		}
	}