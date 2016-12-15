using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PlayerControls.Controls
	{
	public class AreaTextBlock : Control
		{
		private TextBlock _textBlock;

		public AreaTextBlock()
			{
			_textBlock = new TextBlock();

			Viewbox vb = new Viewbox();
			vb.Child = _textBlock;

			_textBlock.SetBinding(TextBlock.FontWeightProperty, new Binding("FontWeight") {Source = this});
			_textBlock.SetBinding(TextBlock.TextProperty, new Binding("Text") { Source = this });

			AddVisualChild(_textBlock);
			AddLogicalChild(_textBlock);
			}

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
			"Text", typeof(string), typeof(AreaTextBlock), new PropertyMetadata(default(string)));

		public string Text
			{
			get { return (string) GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
			}

		public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(
			"FontWeight", typeof(FontWeight), typeof(AreaTextBlock), new PropertyMetadata(default(FontWeight)));

		public FontWeight FontWeight
			{
			get { return (FontWeight) GetValue(FontWeightProperty); }
			set { SetValue(FontWeightProperty, value); }
			}

		protected override Size ArrangeOverride(Size arrangeBounds)
			{
			return base.ArrangeOverride(arrangeBounds);
			}

		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
			{
			base.OnRenderSizeChanged(sizeInfo);
			}
		}
	}