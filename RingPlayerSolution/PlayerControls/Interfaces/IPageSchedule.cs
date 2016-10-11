using System;






namespace PlayerControls.Interfaces
	{
	public interface IPageSchedule
		{
		IPage IPage { get; }
		TimeSpan IStartTime { get; }
		}
	}