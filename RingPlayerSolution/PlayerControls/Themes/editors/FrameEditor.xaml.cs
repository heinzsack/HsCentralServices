// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-04</date>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Themes.Controls.Containers;
using CsWpfBase.Themes.Controls.glyphicon;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace PlayerControls.Themes.editors
{
	/// <summary>Interaction logic for FrameEditor.xaml</summary>
	public partial class FrameEditor : ItemControl<IFrame>
	{
		public FrameEditor()
		{
			InitializeComponent();
		}

		private void FramePreview_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var element = (FrameworkElement) sender;
			var clickedElement = element.InputHitTest(e.GetPosition(element)) as FrameworkElement;




			var frameItem = clickedElement.DataContext as IFrameItem;
			if (frameItem == null)
				frameItem = clickedElement.GetVisualParentByCondition<FrameworkElement>(t => t.DataContext as IFrameItem != null)?.DataContext as IFrameItem;

			TreeView.Select(frameItem);
		}



		private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
		{
			var element = (FrameworkElement) sender;
			var mouseOverElement = element.InputHitTest(e.GetPosition(element)) as FrameworkElement;

			var frameItem = mouseOverElement.DataContext as IFrameItem;

			while (frameItem == null)
			{
				mouseOverElement = (FrameworkElement) mouseOverElement.Parent;
				frameItem = mouseOverElement.DataContext as IFrameItem;
			}

			while (frameItem == ((FrameworkElement) mouseOverElement.Parent)?.DataContext)
			{
				mouseOverElement = (FrameworkElement) mouseOverElement.Parent;
			}

			if (FocusAdorner._currentAdorner?.AdornedElement == mouseOverElement)
				return;

			new FocusAdorner(mouseOverElement);
		}



		private class FocusAdorner : Adorner
		{
			public static Adorner _currentAdorner = null;
			private static AdornerLayer _currentLayer = null;

			private FrameworkElement _child;
			private GlyphIcons? _icon;
			protected override int VisualChildrenCount => _child == null?0:1;

			protected override Visual GetVisualChild(int index)
			{
				if(index != 0) throw new ArgumentOutOfRangeException();
				return _child;
			}
			public FrameworkElement Child
			{
				get { return _child; }
				set
				{
					if(_child != null)
					{
						RemoveVisualChild(_child);
					}
					_child = value;
					if(_child != null)
					{
						AddVisualChild(_child);
					}
				}
			}
			public GlyphIcons? Icon
			{
				get { return _icon; }
				set
				{
					_icon = value;
					if (_icon == null)
					{
						Child = null;
						return;
					}
					Child = new Border()
					{
						Background = Brushes.White,
						MaxWidth = 100,
						MaxHeight = 100,
						Padding = new Thickness(10),
						CornerRadius = new CornerRadius(5),
						BorderThickness = new Thickness(1),
						BorderBrush = new SolidColorBrush(Colors.Black),
						Child = new Viewbox()
						{
							Child = new GlyphIcon()
							{
								Icon = _icon,
							}
						}
					};
				}
			}

			protected override Size MeasureOverride(Size constraint)
			{
				_child?.Measure(constraint);
				return base.MeasureOverride(constraint);
			}

			protected override Size ArrangeOverride(Size finalSize)
			{
				_child?.Arrange(new Rect(new Point(0, 0), finalSize));
				return base.ArrangeOverride(finalSize);
			}

			public FocusAdorner(FrameworkElement adornedElement) : base(adornedElement)
			{
				_currentLayer?.Remove(_currentAdorner);
				_currentLayer = AdornerLayer.GetAdornerLayer(adornedElement);
				if (_currentLayer == null)
					return;
				_currentAdorner = this;
				_currentLayer.Add(_currentAdorner);
				IsHitTestVisible = false;

				if (adornedElement.DataContext as IFrameItemText != null)
					Icon = GlyphIcons.H_Font;
				else if (adornedElement.DataContext as IFrameItemImage != null)
					Icon = GlyphIcons.E_Image;
				else if (adornedElement.DataContext as IFrameItemVideo != null)
					Icon = GlyphIcons.E_Youtube;
				else if (adornedElement.DataContext as IFrame != null)
					Icon = GlyphIcons.G_Vector_Path_All;
			}


			#region Overrides/Interfaces
			protected override void OnRender(DrawingContext drawingContext)
			{
				base.OnRender(drawingContext);

				var fre = (FrameworkElement) AdornedElement;

				drawingContext.DrawRectangle(null, new Pen(new SolidColorBrush(Color.FromArgb(200,255,0,0)), 3), new Rect(-2.5, -2.5, fre.ActualWidth + 5, fre.ActualHeight + 5));
			}
			#endregion
		}
	}
}