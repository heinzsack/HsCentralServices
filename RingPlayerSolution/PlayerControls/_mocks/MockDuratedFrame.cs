using System;
using System.Windows;
using PlayerControls.Interfaces;






namespace PlayerControls._mocks
{
	internal class MockDuratedFrame : IDuratedFrame
	{
		#region Overrides/Interfaces
		/// <summary>The <see cref="IFrame" /> which is meant to be played.</summary>
		public IFrame Frame { get; set; } = MockFrame.GetSample();
		/// <summary>The duration the <see cref="IDuratedFrame.Frame" /> should be presented.</summary>
		public Duration FrameDuration { get; set; } = new Duration(TimeSpan.FromSeconds(3));
		#endregion

		public static IDuratedFrame[] GetSamples(int count = 3)
		{
			var duratedFrames = new IDuratedFrame[count];
			for (var i = 0; i < duratedFrames.Length; i++)
				duratedFrames[i] = new MockDuratedFrame();
			return duratedFrames;
		}
	}

}