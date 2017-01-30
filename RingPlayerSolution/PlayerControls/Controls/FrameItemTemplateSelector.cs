// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;
using System.Windows.Controls;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;






namespace PlayerControls.Controls
{
	internal class FrameItemTemplateSelector : DataTemplateSelector
	{
		#region Overrides/Interfaces
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item == null)
				return null;
			var itemType = item.GetType();
			if (typeof(IFrame).IsAssignableFrom(itemType))
			{
				if (((IFrame) item).FrameHasFixedRatio)
					return FixedRatioFrameTemplate;
				return DynamicRatioFrameTemplate;
			}
			if (typeof(IFrameItemText).IsAssignableFrom(itemType))
				return FrameItemTextTemplate;
			if (typeof(IFrameItemImage).IsAssignableFrom(itemType))
				return FrameItemImageTemplate;
			if (typeof(IFrameItemVideo).IsAssignableFrom(itemType))
				return FrameItemVideoTemplate;

			return base.SelectTemplate(item, container);
		}
		#endregion


		public DataTemplate FixedRatioFrameTemplate { get; set; }
		public DataTemplate DynamicRatioFrameTemplate { get; set; }
		public DataTemplate FrameItemTextTemplate { get; set; }
		public DataTemplate FrameItemImageTemplate { get; set; }
		public DataTemplate FrameItemVideoTemplate { get; set; }
	}
}