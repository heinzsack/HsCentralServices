// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-02-06</creation-date>
// <modified>2017-05-05 14:40</modify-date>

using System;
using System.Windows;
using System.Windows.Controls;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls.Themes._components
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
				return FrameTemplate;
			if (typeof(IFrameText).IsAssignableFrom(itemType))
				return FrameItemTextTemplate;
			if (typeof(IFrameImage).IsAssignableFrom(itemType))
				return FrameItemImageTemplate;
			if (typeof(IFrameVideo).IsAssignableFrom(itemType))
				return FrameItemVideoTemplate;

			return base.SelectTemplate(item, container);
		}
		#endregion


		public DataTemplate FrameTemplate { get; set; }
		public DataTemplate FrameItemTextTemplate { get; set; }
		public DataTemplate FrameItemImageTemplate { get; set; }
		public DataTemplate FrameItemVideoTemplate { get; set; }
	}
}