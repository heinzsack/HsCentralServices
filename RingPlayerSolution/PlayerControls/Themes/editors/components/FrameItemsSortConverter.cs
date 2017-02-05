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
			var collectionView = CollectionViewSource.GetDefaultView(value);
			collectionView.SortDescriptions.Add(new SortDescription(nameof(IFrameItem.FrameItemZIndex), ListSortDirection.Ascending));
			return collectionView;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}