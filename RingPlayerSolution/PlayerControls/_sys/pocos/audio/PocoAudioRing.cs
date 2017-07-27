// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 14:50</modify-date>

using System;
using System.Collections.Generic;
using CsWpfBase.env._base;
using Newtonsoft.Json;
using PlayerControls.Interfaces.audio;






namespace PlayerControls._sys.pocos.audio
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoAudioRing : Base, IAudioRing
	{
		private List<PocoAudioRingEntry> _pocoRingItems;
		/// <inheritdoc />
		private int _ringBufferSize;
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
		[JsonIgnore]
		public IEnumerable<IAudioRingEntry> RingItems => PocoRingItems;
		#endregion


		///<summary>Contains the list which is returned when accessing the <see cref="RingItems"/> property.</summary>
		[JsonProperty("Items")]
		public List<PocoAudioRingEntry> PocoRingItems
		{
			get => _pocoRingItems ?? (_pocoRingItems = new List<PocoAudioRingEntry>());
			set => SetProperty(ref _pocoRingItems, value);
		}

		public bool ShouldSerializePocoRingItems()
		{
			return _pocoRingItems != null && _pocoRingItems.Count != 0;
		}



		public static class Mock
		{
			public static PocoAudioRing Get(DateTime startTime, TimeSpan duration)
			{
				var pocoFrame = new PocoAudioRing
								{
									RingPeriod = duration,
									RingStartTime = startTime,
									RingBufferSize = 2,
									PocoRingItems = PocoAudioRingEntry.Mock.Get(duration)
								};
				return pocoFrame;
			}
		}
	}
}