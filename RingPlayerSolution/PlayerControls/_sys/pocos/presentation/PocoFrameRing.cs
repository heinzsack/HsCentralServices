// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-27 16:37</modify-date>

using System;
using CsWpfBase.Ev.Objects;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameRing : Base, IRing<IFrameRingEntry>
	{
		/// <inheritdoc />
		private int _ringBufferSize;
		/// <inheritdoc />
		private IFrameRingEntry[] _ringItems;
		/// <inheritdoc />
		private TimeSpan _ringPeriod;
		/// <inheritdoc />
		private DateTime _ringStartTime;


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("Period")]
		public TimeSpan RingPeriod
		{
			get => _ringPeriod;
			set => SetProperty(ref _ringPeriod, value);
		}
		/// <inheritdoc />
		[JsonProperty("StartTime")]
		public DateTime RingStartTime
		{
			get => _ringStartTime;
			set => SetProperty(ref _ringStartTime, value);
		}
		/// <inheritdoc />
		[JsonProperty("BufferSize")]
		public int RingBufferSize
		{
			get => _ringBufferSize;
			set => SetProperty(ref _ringBufferSize, value);
		}
		/// <inheritdoc />
		[JsonProperty("Items")]
		public IFrameRingEntry[] RingItems
		{
			get => _ringItems;
			set => SetProperty(ref _ringItems, value);
		}
		#endregion



		public static class Mock
		{
			public static PocoFrameRing Get(DateTime startTime, TimeSpan duration)
			{
				var pocoFrame = new PocoFrameRing
								{
									RingPeriod = duration,
									RingStartTime = startTime,
									RingBufferSize = 2,
									RingItems = PocoFrameRingEntry.Mock.Get(duration)
								};
				return pocoFrame;
			}
		}
	}
}