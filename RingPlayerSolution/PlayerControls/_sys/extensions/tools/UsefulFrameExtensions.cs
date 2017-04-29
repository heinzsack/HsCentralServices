// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-29</creation-date>
// <modified>2017-04-29 11:09</modify-date>

using System;
using System.Collections.Generic;
using System.Linq;
using CsWpfBase.Ev.Objects;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.extensions.tools
{
	public static class UsefulFrameExtensions
	{
		/// <summary>
		///     Applies a <see cref="IFrameRing" /> around the <paramref name="duratedFrames" />. This helps presenting the
		///     <paramref name="duratedFrames" />.
		/// </summary>
		public static IFrameRing ToRing(this IEnumerable<IDuratedFrame> duratedFrames, DateTime startTime)
		{
			var relativeStartTime = TimeSpan.Zero;
			var resultList = new List<RingSimulation.Entry>();
			foreach (var duratedFrame in duratedFrames)
			{
				var entry = new RingSimulation.Entry
							{
								Frame = duratedFrame.Frame,
								RingEntryStartTime = relativeStartTime,
								RingEntryInterrupt = null,
							};
				resultList.Add(entry);
				relativeStartTime = relativeStartTime.Add(duratedFrame.FrameDuration.TimeSpan);
			}

			return new RingSimulation
					{
						RingItemsList = resultList,
						RingBufferSize = 3,
						RingPeriod = relativeStartTime,
						RingStartTime = startTime,
					};
		}

		/// <summary>Analyses the <paramref name="ring" />.</summary>
		public static FrameAnalysis Analyse(this IFrameRing ring)
		{
			FrameAnalysis analysis0 = null;
			foreach (var frameAnalysis in ring.RingItems.Select(x => x.Frame).Distinct().Select(x => x.Analyse()))
			{
				if (analysis0 == null)
				{
					analysis0 = frameAnalysis;
					continue;
				}
				analysis0.Add(frameAnalysis);
			}
			return analysis0;
		}

		/// <summary>Analyses the <paramref name="frame" />.</summary>
		public static FrameAnalysis Analyse(this IFrame frame)
		{
			var unprocessedFrames = new Queue<IFrame>();
			unprocessedFrames.Enqueue(frame);

			var frameAnalysis = new FrameAnalysis();

			while (unprocessedFrames.Count != 0)
			{
				var fr = unprocessedFrames.Dequeue();
				foreach (var child in fr.FrameChildren)
					if (child is IFrameText)
						frameAnalysis.Texts.Add((IFrameText) child);
					else if (child is IFrameImage)
						frameAnalysis.Images.Add((IFrameImage) child);
					else if (child is IFrameVideo)
						frameAnalysis.Videos.Add((IFrameVideo) child);
					else if (child is IFrame)
						unprocessedFrames.Enqueue((IFrame) child);
			}

			return frameAnalysis;
		}



		public class RingSimulation : Base, IFrameRing
		{
			private int _ringBufferSize;
			private List<Entry> _ringItemsList;
			private TimeSpan _ringPeriod;
			private DateTime _ringStartTime;


			#region Overrides/Interfaces
			/// <inheritdoc />
			public TimeSpan RingPeriod
			{
				get => _ringPeriod;
				set => SetProperty(ref _ringPeriod, value);
			}
			/// <inheritdoc />
			public DateTime RingStartTime
			{
				get => _ringStartTime;
				set => SetProperty(ref _ringStartTime, value);
			}
			/// <inheritdoc />
			public int RingBufferSize
			{
				get => _ringBufferSize;
				set => SetProperty(ref _ringBufferSize, value);
			}
			/// <inheritdoc />
			public IEnumerable<IFrameRingEntry> RingItems => RingItemsList;
			#endregion


			/// <summary>The <see cref="RingItems" /> wrapper.</summary>
			public List<Entry> RingItemsList
			{
				get => _ringItemsList ?? (_ringItemsList = new List<Entry>());
				set => SetProperty(ref _ringItemsList, value);
			}



			public class Entry : Base, IFrameRingEntry
			{
				private IFrame _frame;
				private string _ringEntryInterrupt;
				private TimeSpan _ringEntryStartTime;


				#region Overrides/Interfaces
				/// <inheritdoc />
				public TimeSpan RingEntryStartTime
				{
					get => _ringEntryStartTime;
					set => SetProperty(ref _ringEntryStartTime, value);
				}
				/// <inheritdoc />
				public IFrame Frame
				{
					get => _frame;
					set => SetProperty(ref _frame, value);
				}
				/// <inheritdoc />
				public string RingEntryInterrupt
				{
					get => _ringEntryInterrupt;
					set => SetProperty(ref _ringEntryInterrupt, value);
				}
				#endregion


			}
		}
	}



	/// <summary>Contains the analysis result.</summary>
	public class FrameAnalysis
	{
		/// <summary>All the <see cref="IFrameText" />.</summary>
		public HashSet<IFrameText> Texts { get; } = new HashSet<IFrameText>();
		/// <summary>All the <see cref="IFrameImage" />.</summary>
		public HashSet<IFrameImage> Images { get; } = new HashSet<IFrameImage>();
		/// <summary>All the <see cref="IFrameVideo" />.</summary>
		public HashSet<IFrameVideo> Videos { get; } = new HashSet<IFrameVideo>();

		public void Add(FrameAnalysis analysis)
		{
			Texts.UnionWith(analysis.Texts);
			Images.UnionWith(analysis.Images);
			Videos.UnionWith(analysis.Videos);
		}
	}
}