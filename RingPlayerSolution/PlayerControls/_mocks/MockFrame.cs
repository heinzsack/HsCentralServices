// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using CsWpfBase.Ev.Objects;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls._mocks
{



	internal class MockFrame : Base, IFrame
	{



		public static IFrame GetSample()
		{
			var frame = new MockFrame {FrameItemBackground = Colors.White};
			frame.AddChild(MockText.GetSampleLeftBottom());
			frame.AddChild(MockText.GetSampleLeftTop());
			frame.AddChild(MockText.GetSampleRightTop());
			frame.AddChild(MockText.GetSampleRightBottom());
			frame.AddChild(MockImage.GetSampleMiddle());
			return frame;
		}

		private readonly ObservableCollection<IFrameItem> _frameChildren = new ObservableCollection<IFrameItem>();
		private readonly List<ITransition> _frameTransitions = new List<ITransition>();


		#region Overrides/Interfaces
		private Thickness _frameItemRelativePosition;
		private Color _frameItemBackground;
		private Color _frameItemBorderColor;
		private Thickness _frameItemBorderThickness;
		private double _frameItemRotation;
		private int _frameItemZIndex;
		private bool _frameHasFixedRatio;
		private double _frameRatioX;
		private double _frameRatioY;
		private Thickness _frameItemPadding;
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
		public Thickness FrameItemRelativePosition
		{
			get { return _frameItemRelativePosition; }
			set { SetProperty(ref _frameItemRelativePosition, value); }
		}
		/// <summary>The color of the background of the element.</summary>
		public Color FrameItemBackground
		{
			get { return _frameItemBackground; }
			set { SetProperty(ref _frameItemBackground, value); }
		}
		/// <summary>The color of the border of the element.</summary>
		public Color FrameItemBorderColor
		{
			get { return _frameItemBorderColor; }
			set { SetProperty(ref _frameItemBorderColor, value); }
		}
		/// <summary>The thickness of the border.</summary>
		public Thickness FrameItemBorderThickness
		{
			get { return _frameItemBorderThickness; }
			set { SetProperty(ref _frameItemBorderThickness, value); }
		}
		/// <summary>The padding of the border.</summary>
		public Thickness FrameItemPadding
		{
			get { return _frameItemPadding; }
			set { SetProperty(ref _frameItemPadding, value); }
		}
		/// <summary>The rotation of the element.</summary>
		public double FrameItemRotation
		{
			get { return _frameItemRotation; }
			set { SetProperty(ref _frameItemRotation, value); }
		}
		/// <summary>The z-index of the elemnt describes the layer on which this element sits.</summary>
		public int FrameItemZIndex
		{
			get { return _frameItemZIndex; }
			set { SetProperty(ref _frameItemZIndex, value); }
		}
		/// <summary>
		///     If true the two proeprties <see cref="IFrame.FrameRatioX" /> and <see cref="IFrame.FrameRatioY" /> will be used to determine
		///     an aspect ratio wich is used to resize the frame.
		/// </summary>
		public bool FrameHasFixedRatio
		{
			get { return _frameHasFixedRatio; }
			set { SetProperty(ref _frameHasFixedRatio, value); }
		}
		/// <summary>could be 16 when <see cref="IFrame.FrameRatioY" /> is 9 to make a 16:9 frame.</summary>
		public double FrameRatioX
		{
			get { return _frameRatioX; }
			set { SetProperty(ref _frameRatioX, value); }
		}
		/// <summary>could be 9 when <see cref="IFrame.FrameRatioX" /> is 16 to make a 16:9 frame.</summary>
		public double FrameRatioY
		{
			get { return _frameRatioY; }
			set { SetProperty(ref _frameRatioY, value); }
		}
		/// <summary>Could be any <see cref="IFrameItem" /> item.</summary>
		public IEnumerable<IFrameItem> FrameChildren => _frameChildren;
		/// <summary>Could be any <see cref="ITransition" /> item.</summary>
		public IEnumerable<ITransition> FrameTransitions => _frameTransitions;
		#endregion


		public void AddChild(IFrameItem child)
		{
			_frameChildren.Add(child);
		}
		public void RemoveChild(IFrameItem child)
		{
			_frameChildren.Remove(child);
		}

		public void AddTransitions(ITransition transistion)
		{
			_frameTransitions.Add(transistion);
		}

		/// <summary>
		///     Adds an <see cref="IFrameItemText" /> to the <see cref="IFrame.FrameChildren" /> collection and returns the added
		///     <see cref="IFrameItemText" />.
		/// </summary>
		public IFrameItemText EditorRequestedNewText()
		{
			var item = MockText.GetSampleLeftTop();
			AddChild(item);
			return item;
		}

		/// <summary>
		///     Adds an <see cref="IFrameItemImage" /> to the <see cref="IFrame.FrameChildren" /> collection and returns the added
		///     <see cref="IFrameItemImage" />.
		/// </summary>
		public IFrameItemImage EditorRequestedNewImage()
		{
			var item = MockImage.GetSampleMiddle();
			AddChild(item);
			return item;
		}

		/// <summary>
		///     Adds an <see cref="IFrameItemVideo" /> to the <see cref="IFrame.FrameChildren" /> collection and returns the added
		///     <see cref="IFrameItemVideo" />.
		/// </summary>
		public IFrameItemVideo EditorRequestedNewVideo()
		{
			throw new NotImplementedException();
		}

		/// <summary>Adds an <see cref="IFrame" /> to the <see cref="IFrame.FrameChildren" /> collection and returns the added
		///     <see cref="IFrame" />.</summary>
		public IFrame EditorRequestedNewFrame()
		{
			var frame = new MockFrame { FrameItemBackground = Colors.White, FrameItemRelativePosition = new Thickness(25,25,25,25)};
			AddChild(frame);
			return frame;
		}

		/// <summary>Removes the <paramref name="child" /> from the <see cref="IFrame.FrameChildren" />.</summary>
		public void EditorRequestedRemoveChild(IFrameItem child)
		{
			RemoveChild(child);
		}
	}
}