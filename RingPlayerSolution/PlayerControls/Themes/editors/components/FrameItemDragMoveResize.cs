// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CsWpfBase.env.extensions;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls.Themes._components;






namespace PlayerControls.Themes.editors.components
{
	internal class FrameItemDragMoveResize
	{
		private readonly Action<Thickness, Thickness> _callback;
		readonly Window _mouseAnker;
		private FrameItemContainer Target { get; }
		private Point StartPosition { get; }
		private Thickness AbsoluteStartMargin { get; }


		public static void Do(FrameItemContainer target, Action<Thickness, Thickness> callback = null)
		{
			// ReSharper disable once ObjectCreationAsStatement
			new FrameItemDragMoveResize(target, callback);
		}


		private FrameItemDragMoveResize(FrameItemContainer target, Action<Thickness, Thickness> callback = null)
		{
			_callback = callback;
			Target = target;
			_mouseAnker = Window.GetWindow(Target);
			StartPosition = Mouse.GetPosition(_mouseAnker);
			AbsoluteStartMargin = Target.Margin;
			RelativeStartMargin = ((IFrameItem)Target.DataContext).FrameItemRelativePosition;


			var position = Mouse.GetPosition(Target);
			var relRight = position.X / target.ActualWidth;
			var relLeft = 1 - relRight;
			var relBottom = position.Y / target.ActualHeight;
			var relTop = 1 - relBottom;

			var maxObject = new[]
			{
				new Tuple<double, double, MouseEventHandler, Cursor>(relLeft, (1-relLeft)*Target.ActualWidth, ResizeLeft, Cursors.SizeWE),
				new Tuple<double, double, MouseEventHandler, Cursor>(relTop, (1-relTop)*Target.ActualHeight,ResizeTop, Cursors.SizeNS),
				new Tuple<double, double, MouseEventHandler, Cursor>(relRight, (1-relRight)*Target.ActualWidth,ResizeRight, Cursors.SizeWE),
				new Tuple<double, double, MouseEventHandler, Cursor>(relBottom, (1-relBottom)*Target.ActualHeight,ResizeBottom, Cursors.SizeNS)
			}
			.Where(x => ((x.Item1 > 0.95 && x.Item2 < 10) || x.Item2<5))
			.MaxObject(x => x.Item1);
			if (maxObject == null)
				Target.PreviewMouseMove += Move;
			else
			{
				Target.PreviewMouseMove += maxObject.Item3;
				Mouse.OverrideCursor = maxObject.Item4;
			}


			Target.PreviewMouseLeftButtonUp += MouseLeftButtonUp;
			Target.LostMouseCapture += TargetOnLostMouseCapture;
			Target.CaptureMouse();
		}

		public Thickness RelativeStartMargin { get; }

		private void TargetOnLostMouseCapture(object sender, MouseEventArgs mouseEventArgs)
		{
			Target.PreviewMouseMove -= Move;
			Target.PreviewMouseMove -= ResizeLeft;
			Target.PreviewMouseMove -= ResizeTop;
			Target.PreviewMouseMove -= ResizeRight;
			Target.PreviewMouseMove -= ResizeBottom;
			Mouse.OverrideCursor = null;
		}

		private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Target.PreviewMouseLeftButtonUp -= MouseLeftButtonUp;
			Target.ReleaseMouseCapture();
			var frameItemRelativePosition = ((IFrameItem)Target.DataContext).FrameItemRelativePosition;

			_callback?.Invoke(RelativeStartMargin, frameItemRelativePosition);
			e.Handled = true;
		}

		private void Move(object sender, MouseEventArgs e)
		{
			if (!Target.IsMouseCaptureWithin)
				return;
			var vector = GetMove();
			Target.Margin = new Thickness(AbsoluteStartMargin.Left - vector.X, AbsoluteStartMargin.Top - vector.Y, AbsoluteStartMargin.Right + vector.X, AbsoluteStartMargin.Bottom + vector.Y);
			e.Handled = true;
		}

		private void ResizeTop(object sender, MouseEventArgs e)
		{
			if (!Target.IsMouseCaptureWithin)
				return;
			Target.Margin = new Thickness(AbsoluteStartMargin.Left, AbsoluteStartMargin.Top - GetMove().Y, AbsoluteStartMargin.Right, AbsoluteStartMargin.Bottom);
			e.Handled = true;
		}

		private void ResizeBottom(object sender, MouseEventArgs e)
		{
			if (!Target.IsMouseCaptureWithin)
				return;
			Target.Margin = new Thickness(AbsoluteStartMargin.Left, AbsoluteStartMargin.Top, AbsoluteStartMargin.Right, AbsoluteStartMargin.Bottom + GetMove().Y);
			e.Handled = true;
		}

		private void ResizeLeft(object sender, MouseEventArgs e)
		{
			if (!Target.IsMouseCaptureWithin)
				return;
			Target.Margin = new Thickness(AbsoluteStartMargin.Left - GetMove().X, AbsoluteStartMargin.Top, AbsoluteStartMargin.Right, AbsoluteStartMargin.Bottom);
			e.Handled = true;
		}

		private void ResizeRight(object sender, MouseEventArgs e)
		{
			if (!Target.IsMouseCaptureWithin)
				return;
			Target.Margin = new Thickness(AbsoluteStartMargin.Left, AbsoluteStartMargin.Top, AbsoluteStartMargin.Right + GetMove().X, AbsoluteStartMargin.Bottom);
			e.Handled = true;
		}

		private Vector GetMove()
		{
			return StartPosition - Mouse.GetPosition(_mouseAnker);
		}
	}
}