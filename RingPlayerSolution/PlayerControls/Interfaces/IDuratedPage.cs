using System;
using System.Windows;






namespace PlayerControls.Interfaces
	{
	public interface IDuratedPage
		{
		IPage IPage { get; }
		Duration IDuration { get; }
		}
	}