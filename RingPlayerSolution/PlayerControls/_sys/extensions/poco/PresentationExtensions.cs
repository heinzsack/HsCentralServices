// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-07-27</creation-date>
// <modified>2017-07-27 11:45</modify-date>

using System;
using System.Collections.Generic;
using System.Linq;
using CsWpfBase.env.extensions;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls.Interfaces.ringEngine;
using PlayerControls._sys.pocos.presentation;
using PlayerControls._sys.pocos.presentation.frame;






namespace PlayerControls._sys.extensions.poco
{
	// ReSharper disable once InconsistentNaming
	public static class PresentationExtensions
	{
		/// <summary>Converts the <see cref="IFrameRing" /> into a <see cref="PocoFrameRing" /> which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IFrameRing" /> to convert.</param>
		public static PocoFrameRing ToPoco(this IFrameRing source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IEnumerable{IFrameRingEntry}" /> into a <see cref="PocoFrameRing" /> which is serializeable to
		///     json or binary.
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{IFrameRingEntry}" /> to convert.</param>
		/// <param name="startTime">
		///     The time where the <see cref="IFrameRingEntry.RingEntryStartTime" /> of value '
		///     <see cref="TimeSpan.Zero" />' is located at. If you have a <paramref name="startTime" /> at one o clock, the
		///     <see cref="IFrameRingEntry" /> with the <see cref="IRingEntry.RingEntryStartTime" /> of <see cref="TimeSpan.Zero" /> will
		///     begin at one o clock.
		/// </param>
		/// <param name="duration">The total length of the <see cref="IFrameRing" />.</param>
		public static PocoFrameRing ToPoco(this IEnumerable<IFrameRingEntry> source, DateTime startTime, TimeSpan duration)
		{
			return source.ToPoco(startTime, duration, new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IFrameRingEntry" /> into a <see cref="PocoFrameRingEntry" /> which is serializeable to json or
		///     binary.
		/// </summary>
		/// <param name="source">The <see cref="IFrameRingEntry" /> to convert.</param>
		public static PocoFrameRingEntry ToPoco(this IFrameRingEntry source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>Converts the <see cref="IFrame" /> into a <see cref="PocoFrame" /> which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IFrame" /> to convert.</param>
		public static PocoFrame ToPoco(this IFrame source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IFrameText" /> into a new instance of <see cref="PocoFrameText" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameText ToPoco(this IFrameText source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IFrameImage" /> into a new instance of <see cref="PocoFrameImage" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameImage ToPoco(this IFrameImage source)
		{
			return source.ToPoco(new ConversionContext());
		}

		/// <summary>
		///     Converts the <see cref="IFrameVideo" /> into a new instance of <see cref="PocoFrameVideo" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameVideo ToPoco(this IFrameVideo source)
		{
			return source.ToPoco(new ConversionContext());
		}



		private static PocoFrameRing ToPoco(this IFrameRing source, ConversionContext context)
		{
			if (source == null) return null;

			var poco = source as PocoFrameRing;
			if ((poco != null) || context.GetOrCreate(source, () => new PocoFrameRing(), out poco))
				return poco;

			source.CopyTo(poco, nameof(IFrameRing.RingItems));
			poco.PocoRingItems = source.RingItems.Select(entry => ToPoco(entry, context)).ToList();

			return poco;
		}

		private static PocoFrameRing ToPoco(this IEnumerable<IFrameRingEntry> source, DateTime startTime, TimeSpan duration, ConversionContext context)
		{
			if (source == null) return null;

			return new PocoFrameRing
			{
				PocoRingItems = source.Select(x => x.ToPoco(context)).ToList(),
				RingBufferSize = 3,
				RingStartTime = startTime,
				RingPeriod = duration,
			};
		}

		private static PocoFrameRingEntry ToPoco(this IFrameRingEntry source, ConversionContext context)
		{
			if (source == null) return null;

			var poco = source as PocoFrameRingEntry;
			if ((poco != null) || context.GetOrCreate(source, () => new PocoFrameRingEntry(), out poco))
				return poco;

			source.CopyTo(poco, nameof(IFrameRingEntry.RingEntryFrame));
			poco.RingEntryFrame = source.RingEntryFrame.ToPoco(context);
			return poco;
		}

		private static PocoFrame ToPoco(this IFrame source, ConversionContext context)
		{
			if (source == null) return null;

			var poco = source as PocoFrame;
			if ((poco != null) || context.GetOrCreate(source, () => new PocoFrame(), out poco))
				return poco;

			source.CopyTo(poco, nameof(IFrame.FrameChildren), nameof(IFrame.FrameTransitions));
			foreach (IFrameItem child in source.FrameChildren)
				if (child is IFrameText)
					poco.Texts.Add(child as PocoFrameText ?? ((IFrameText) child).ToPoco(context));
				else if (child is IFrameImage)
					poco.Images.Add(child as PocoFrameImage ?? ((IFrameImage) child).ToPoco(context));
				else if (child is IFrameVideo)
					poco.Videos.Add(child as PocoFrameVideo ?? ((IFrameVideo) child).ToPoco(context));
				else if (child is IFrame)
					poco.Frames.Add(child as PocoFrame ?? ((IFrame) child).ToPoco(context));
			return poco;
		}

		private static PocoFrameText ToPoco(this IFrameText source, ConversionContext context)
		{
			if (source == null) return null;

			var poco = source as PocoFrameText;
			if ((poco != null) || context.GetOrCreate(source, () => new PocoFrameText(), out poco))
				return poco;

			source.CopyTo(poco);
			return poco;
		}

		private static PocoFrameImage ToPoco(this IFrameImage source, ConversionContext context)
		{
			if (source == null) return null;

			var poco = source as PocoFrameImage;
			if ((poco != null) || context.GetOrCreate(source, () => new PocoFrameImage(), out poco))
				return poco;

			source.CopyTo(poco, nameof(IFrameImage.FrameItemImage));
			return poco;
		}

		private static PocoFrameVideo ToPoco(this IFrameVideo source, ConversionContext context)
		{
			if (source == null) return null;

			var poco = source as PocoFrameVideo;
			if ((poco != null) || context.GetOrCreate(source, () => new PocoFrameVideo(), out poco))
				return poco;


			source.CopyTo(poco, nameof(IFrameVideo.FrameItemVideoFilePath));
			return poco;
		}
	}
}