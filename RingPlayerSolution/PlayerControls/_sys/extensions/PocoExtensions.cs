// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-28</creation-date>
// <modified>2017-04-28 16:21</modify-date>

using System;
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
			if (source is PocoFrameRing)
				return (PocoFrameRing) source;

			var poco = new PocoFrameRing();
			source.CopyTo(poco, nameof(IFrameRing.RingItems));
			poco.PocoRingItems = source.RingItems.Select(ToPoco).ToList();

			return poco;
		}

		/// <summary>
		///     Converts the <see cref="IFrameRingEntry" /> into a <see cref="PocoFrameRingEntry" /> which is serializeable to json or
		///     binary.
		/// </summary>
		/// <param name="source">The <see cref="IFrameRingEntry" /> to convert.</param>
		public static PocoFrameRingEntry ToPoco(this IFrameRingEntry source)
		{
			if (source is PocoFrameRingEntry)
				return (PocoFrameRingEntry) source;

			var poco = new PocoFrameRingEntry();
			source.CopyTo(poco, nameof(IFrameRingEntry.Frame));
			poco.Frame = source.Frame.ToPoco();
			return poco;
		}

		/// <summary>Converts the <see cref="IFrame" /> into a <see cref="PocoFrame" /> which is serializeable to json or binary.</summary>
		/// <param name="source">The <see cref="IFrame" /> to convert.</param>
		public static PocoFrame ToPoco(this IFrame source)
		{
			if (source is PocoFrame)
				return (PocoFrame) source;

			var poco = new PocoFrame();
			source.CopyTo(poco, nameof(IFrame.FrameChildren), nameof(IFrame.FrameTransitions));
			foreach (IFrameItem child in source.FrameChildren)
				poco.AddChild(child);
			return poco;
		}

		/// <summary>
		///     Converts the <see cref="IFrameText" /> into a new instance of <see cref="PocoFrameText" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameText ToPoco(this IFrameText source)
		{
			if (source is PocoFrameText)
				return (PocoFrameText) source;

			var poco = new PocoFrameText();
			source.CopyTo(poco);
			return poco;
		}

		/// <summary>
		///     Converts the <see cref="IFrameImage" /> into a new instance of <see cref="PocoFrameImage" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameImage ToPoco(this IFrameImage source)
		{
			if (source is PocoFrameImage)
				return (PocoFrameImage) source;

			var poco = new PocoFrameImage();
			source.CopyTo(poco, nameof(IFrameImage.FrameItemImage));
			return poco;
		}

		/// <summary>
		///     Converts the <see cref="IFrameVideo" /> into a new instance of <see cref="PocoFrameVideo" /> which is serializeable to
		///     json or binary.
		/// </summary>
		public static PocoFrameVideo ToPoco(this IFrameVideo source)
		{
			if (source is PocoFrameVideo)
				return (PocoFrameVideo) source;

			var poco = new PocoFrameVideo();
			source.CopyTo(poco, nameof(IFrameVideo.FrameItemVideoFilePath));
			return poco;
		}
	}
}