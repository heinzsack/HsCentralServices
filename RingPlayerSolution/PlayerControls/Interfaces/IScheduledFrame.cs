// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;






namespace PlayerControls.Interfaces
{
	/// <summary>Used when <see cref="IFrame" />s need to be presented in a circular way with absolute 24H timings.</summary>
	public interface IScheduledFrame
	{
		#region Abstract
		/// <summary>The <see cref="IFrame" /> which should be played at the according <see cref="FrameStartTime" />.</summary>
		IFrame Frame { get; }
		/// <summary>
		///     The <see cref="FrameStartTime" /> is interpreted as a clock time with 24H. The <see cref="Frame" /> will be displayed until
		///     the next <see cref="IScheduledFrame" /> is displayed.
		/// </summary>
		TimeSpan FrameStartTime { get; }
		#endregion
	}
}