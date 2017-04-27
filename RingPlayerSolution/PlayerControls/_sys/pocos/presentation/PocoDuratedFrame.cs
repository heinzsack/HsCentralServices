using System;
using System.Windows;
using CsWpfBase.Ev.Objects;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoDuratedFrame : Base, IDuratedFrame
	{
		/// <inheritdoc />
		[JsonProperty("Frame")] private PocoFrame _frame;
		/// <inheritdoc />
		private Duration _frameDuration;


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonIgnore]
		public IFrame Frame
		{
			get => _frame;
			set => SetProperty(ref _frame, (PocoFrame) value);
		}
		/// <inheritdoc />
		[JsonProperty("Duration")]
		public Duration FrameDuration
		{
			get => _frameDuration;
			set => SetProperty(ref _frameDuration, value);
		}
		#endregion


		public static class Mock
		{
			public static IDuratedFrame[] Get(int count = 100)
			{
				var duratedFrames = new IDuratedFrame[count];
				for (var i = 0; i < duratedFrames.Length; i++)
					duratedFrames[i] = new PocoDuratedFrame(){FrameDuration = TimeSpan.FromSeconds(10)};
				return duratedFrames;
			}
		}
	}
}