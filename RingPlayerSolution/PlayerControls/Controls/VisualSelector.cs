using System;
using System.Windows;
using PlayerControls.Interfaces;






namespace PlayerControls.Controls
	{
	public class VisualSelector : System.Windows.Controls.DataTemplateSelector
		{
		public DataTemplate IVisualContainerWithFixedRatioTemplate { get; set; }
		public DataTemplate IVisualContainerTemplate { get; set; }
		public DataTemplate ITextVisualTemplate { get; set; }
		public DataTemplate IImageVisualTemplate { get; set; }
		public DataTemplate IVideoVisualTemplate { get; set; }



		public override DataTemplate SelectTemplate(object item, DependencyObject container)
			{
			if (item == null)
				return null;
			var itemType = item.GetType();
			if (typeof(IPage).IsAssignableFrom(itemType))
				{
				if (((IPage)item).IHasFixedRatio)
					return IVisualContainerWithFixedRatioTemplate;
				return IVisualContainerTemplate;
				}
			if (typeof(ITextVisual).IsAssignableFrom(itemType))
				return ITextVisualTemplate;
			if (typeof(IImageVisual).IsAssignableFrom(itemType))
				return IImageVisualTemplate;
			if (typeof(IVideoVisual).IsAssignableFrom(itemType))
				return IVideoVisualTemplate;

			return base.SelectTemplate(item, container);
			}
		}
	}