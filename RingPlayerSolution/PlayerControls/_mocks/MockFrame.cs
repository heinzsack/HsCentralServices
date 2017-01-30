// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls._mocks
{



	internal class MockFrame : IFrame
	{



		public static IFrame GetSample()
		{
			var frame = new MockFrame() {FrameItemBackground = Colors.White};
			frame.AddChild(MockText.GetSampleLeftBottom());
			frame.AddChild(MockText.GetSampleLeftTop());
			frame.AddChild(MockText.GetSampleRightTop());
			frame.AddChild(MockText.GetSampleRightBottom());
			frame.AddChild(MockImage.GetSampleMiddle());
			return frame;
		}

		private readonly List<IFrameItem> _frameChildren = new List<IFrameItem>();
		private readonly List<ITransition> _frameTransitions = new List<ITransition>();


		#region Overrides/Interfaces
		/// <summary>
		///     RelativePositioning is to base 100. Each value is the percentage of the distance to the outer box which could be an
		///     <see cref="IFrame" />. The percentage is then transformed into the <see cref="IFrame" /> metric.
		///     <example>
		///         if the container is in an aspect ratio of 16:9 and the margin is 0,0,0,0 then the resulting box is in aspect ratio 16:9
		///         or 1920x1080p.
		///         <para>
		///             if the container is in aspect ratio of 16:9 and size 1920:1080 and the margin equals 25,25,25,25 then the resulting
		///             box equals 960x540p and of an aspect ratio of 16:9
		///         </para>
		///     </example>
		/// </summary>
		public Thickness FrameItemRelativePosition { get; set; }
		/// <summary>The color of the background of the element.</summary>
		public Color FrameItemBackground { get; set; }
		/// <summary>The color of the border of the element.</summary>
		public Color FrameItemBorderColor { get; set; }
		/// <summary>The thickness of the border.</summary>
		public Thickness FrameItemBorderThickness { get; set; }
		/// <summary>The rotation of the element.</summary>
		public double FrameItemRotation { get; set; }
		/// <summary>The z-index of the elemnt describes the layer on which this element sits.</summary>
		public int FrameItemZIndex { get; set; }
		/// <summary>
		///     If true the two proeprties <see cref="IFrame.FrameRatioX" /> and <see cref="IFrame.FrameRatioY" /> will be used to determine
		///     an aspect ratio wich is used to resize the frame.
		/// </summary>
		public bool FrameHasFixedRatio { get; set; }
		/// <summary>could be 16 when <see cref="IFrame.FrameRatioY" /> is 9 to make a 16:9 frame.</summary>
		public double FrameRatioX { get; set; }
		/// <summary>could be 9 when <see cref="IFrame.FrameRatioX" /> is 16 to make a 16:9 frame.</summary>
		public double FrameRatioY { get; set; }
		/// <summary>Could be any <see cref="IFrameItem" /> item.</summary>
		public IEnumerable<IFrameItem> FrameChildren => _frameChildren;
		/// <summary>Could be any <see cref="ITransition" /> item.</summary>
		public IEnumerable<ITransition> FrameTransitions => _frameTransitions;
		#endregion


		public void AddChild(IFrameItem child)
		{
			_frameChildren.Add(child);
		}

		public void AddTransitions(ITransition transistion)
		{
			_frameTransitions.Add(transistion);
		}
	}
}