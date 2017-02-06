using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using PlayerControls.Interfaces;






namespace PlayerControls.Themes.editors.components
{
	internal class FrameItemsSortConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var view = CollectionViewSource.GetDefaultView(value);
			var liveShaping = (ICollectionViewLiveShaping)view;
			if (liveShaping.CanChangeLiveSorting)
			{
				liveShaping.LiveSortingProperties.Add(nameof(IFrameItem.FrameItemZIndex));
				liveShaping.IsLiveSorting = true;
			}
			view.SortDescriptions.Add(new SortDescription(nameof(IFrameItem.FrameItemZIndex), ListSortDirection.Ascending));
			return view;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}