// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-28</creation-date>
// <modified>2017-04-29 09:40</modify-date>

using System;
using System.Collections.Generic;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls._sys.pocos.presentation;






namespace PlayerControls._sys.extensions
{
	public static class PocoExtensions
	{
		/// <summary>Converts the <see cref="IFrameRing" /> into a <see cref="PocoFrameRing" /> which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IFrameRing" /> to convert.</param>
		public static PocoFrameRing ToPoco(this IFrameRing source)
		{
			return source.ToPoco(new Context());
		}

		/// <summary>
		///     Converts the <see cref="IEnumerable{IFrameRingEntry}" /> into a <see cref="PocoFrameRing" /> which is serializeable to
		///     json or binary.
		/// </summary>
		/// <param name="source">The <see cref="IEnumerable{IFrameRingEntry}" /> to convert.</param>
		/// <param name="startTime">
		///     The time where the <see cref="IFrameRingEntry.RingEntryStartTime" /> of value '
		///     <see cref="TimeSpan.Zero" />' is started at.
		/// </param>
		/// <param name="duration">The total length of the ring.</param>
		public static PocoFrameRing ToPoco(this IEnumerable<IFrameRingEntry> source, DateTime startTime, TimeSpan duration)
		{
			return source.ToPoco(startTime, duration, new Context());
		}

		/// <summary>
		///     Converts the <see cref="IFrameRingEntry" /> into a <see cref="PocoFrameRingEntry" /> which is serializeable to json or
		///     binary.
		/// </summary>
		/// <param name="source">The <see cref="IFrameRingEntry" /> to convert.</param>
		public static PocoFrameRingEntry ToPoco(this IFrameRingEntry source)
		{
			return source.ToPoco(new Context());
		}

		/// <summary>Converts the <see cref="IFrame" /> into a <see cref="PocoFrame" /> which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IFrame" /> to convert.</param>
		public static PocoFrame ToPoco(this IFrame source)
		{
			return source.ToPoco(new Context());
		}

		/// <summary>
		///     Converts the <see cref="IFrameText" /> into a new instance of <see cref="PocoFrameText" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameText ToPoco(this IFrameText source)
		{
			return source.ToPoco(new Context());
		}

		/// <summary>
		///     Converts the <see cref="IFrameImage" /> into a new instance of <see cref="PocoFrameImage" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameImage ToPoco(this IFrameImage source)
		{
			return source.ToPoco(new Context());
		}

		/// <summary>
		///     Converts the <see cref="IFrameVideo" /> into a new instance of <see cref="PocoFrameVideo" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameVideo ToPoco(this IFrameVideo source)
		{
			return source.ToPoco(new Context());
		}


		private static PocoFrameRing ToPoco(this IFrameRing source, Context context)
		{
			if (source is PocoFrameRing)
				return (PocoFrameRing) source;

			var poco = context.GetOrCreate(source, () => new PocoFrameRing());
			source.CopyTo(poco, nameof(IFrameRing.RingItems));
			poco.PocoRingItems = source.RingItems.Select(entry => ToPoco(entry, context)).ToList();

			return poco;
		}

		private static PocoFrameRing ToPoco(this IEnumerable<IFrameRingEntry> source, DateTime startTime, TimeSpan duration, Context context)
		{
			return new PocoFrameRing
					{
						PocoRingItems = source.Select(x => x.ToPoco(context)).ToList(),
						RingBufferSize = 3,
						RingStartTime = startTime,
						RingPeriod = duration,
					};
		}

		private static PocoFrameRingEntry ToPoco(this IFrameRingEntry source, Context context)
		{
			if (source is PocoFrameRingEntry)
				return (PocoFrameRingEntry) source;

			var poco = context.GetOrCreate(source, () => new PocoFrameRingEntry());
			source.CopyTo(poco, nameof(IFrameRingEntry.Frame));
			poco.Frame = source.Frame.ToPoco(context);
			return poco;
		}

		private static PocoFrame ToPoco(this IFrame source, Context context)
		{
			if (source is PocoFrame)
				return (PocoFrame) source;

			var poco = context.GetOrCreate(source, () => new PocoFrame());
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

		private static PocoFrameText ToPoco(this IFrameText source, Context context)
		{
			if (source is PocoFrameText)
				return (PocoFrameText) source;

			var poco = context.GetOrCreate(source, () => new PocoFrameText());
			source.CopyTo(poco);
			return poco;
		}

		private static PocoFrameImage ToPoco(this IFrameImage source, Context context)
		{
			if (source is PocoFrameImage)
				return (PocoFrameImage) source;

			var poco = context.GetOrCreate(source, () => new PocoFrameImage());
			source.CopyTo(poco, nameof(IFrameImage.FrameItemImage));
			return poco;
		}

		private static PocoFrameVideo ToPoco(this IFrameVideo source, Context context)
		{
			if (source is PocoFrameVideo)
				return (PocoFrameVideo) source;


			var poco = context.GetOrCreate(source, () => new PocoFrameVideo());
			source.CopyTo(poco, nameof(IFrameVideo.FrameItemVideoFilePath));
			return poco;
		}



		private class Context
		{
			private Dictionary<object, object> ConvertedObjects { get; } = new Dictionary<object, object>();

			public TType GetOrCreate<TType>(object o, Func<TType> createFunc)
			{
				object val;
				if (ConvertedObjects.TryGetValue(o, out val))
					return (TType) val;

				var t = createFunc();
				ConvertedObjects.Add(o, t);
				return t;
			}
		}
	}
}