// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-30</date>

using System;
using System.Linq;
using PlayerControls.Interfaces;






namespace PlayerControls._mocks
{
	internal class MockScheduledFrame : IScheduledFrame
	{

		public static IScheduledFrame[] GetSamples()
		{
			var scheduledFrames = new IScheduledFrame[(24 * 60)*6];
			for (var i = 0; i < scheduledFrames.Length; i++)
				scheduledFrames[i] = new MockScheduledFrame(TimeSpan.FromSeconds(i*10));
			return scheduledFrames;
		}

		public MockScheduledFrame(TimeSpan frameStartTime)
		{
			FrameStartTime = frameStartTime;
			Frame.FrameChildren.OfType<MockText>().First().FrameItemText = frameStartTime.ToString("g");
		}


		#region Overrides/Interfaces
		/// <summary>The <see cref="IFrame" /> which is meant to be played.</summary>
		public IFrame Frame { get; set; } = MockFrame.GetSample();

		/// <summary>
		///     The <see cref="IScheduledFrame.FrameStartTime" /> is interpreted as a clock time with 24H. The
		///     <see cref="IScheduledFrame.Frame" /> will be displayed until the next <see cref="IScheduledFrame" /> is displayed.
		/// </summary>
		public TimeSpan FrameStartTime { get; }
		#endregion
	}
}