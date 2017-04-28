// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 15:12</modify-date>

using System;
using System.Collections.Generic;
using CsWpfBase.Ev.Objects;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameRing : Base, IFrameRing
	{
		private List<PocoFrameRingEntry> _pocoRingItems;
		/// <inheritdoc />
		private int _ringBufferSize;
		/// <inheritdoc />
		private TimeSpan _ringPeriod;
		/// <inheritdoc />
		private DateTime _ringStartTime;


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("StartTime", Order = 0)]
		public DateTime RingStartTime
		{
			get => _ringStartTime;
			set => SetProperty(ref _ringStartTime, value);
		}
		/// <inheritdoc />
		[JsonProperty("Period", Order = 1)]
		public TimeSpan RingPeriod
		{
			get => _ringPeriod;
			set => SetProperty(ref _ringPeriod, value);
		}
		/// <inheritdoc />
		[JsonProperty("BufferSize", Order = 2)]
		public int RingBufferSize
		{
			get => _ringBufferSize;
			set => SetProperty(ref _ringBufferSize, value);
		}
		/// <inheritdoc />
		[JsonIgnore]
		public IEnumerable<IFrameRingEntry> RingItems => PocoRingItems;
		#endregion


		///<summary></summary>
		[JsonProperty("Items", Order = 3)]
		public List<PocoFrameRingEntry> PocoRingItems
		{
			get => _pocoRingItems;
			set => SetProperty(ref _pocoRingItems, value);
		}



		public static class Mock
		{
			public static PocoFrameRing Get(DateTime startTime, TimeSpan duration)
			{
				var pocoFrame = new PocoFrameRing
								{
									RingPeriod = duration,
									RingStartTime = startTime,
									RingBufferSize = 2,
									PocoRingItems = PocoFrameRingEntry.Mock.Get(duration)
								};
				return pocoFrame;
			}
		}
	}
}