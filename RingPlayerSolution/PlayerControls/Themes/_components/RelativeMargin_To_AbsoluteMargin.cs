// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-02-05</creation-date>
// <modified>2017-04-26 20:43</modify-date>

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;






namespace PlayerControls.Themes._components
{
	/// <summary>
	///     Must be an <see cref="IMultiValueConverter" /> to ensure thaht automatic recalculations occure even if the window gets
	///     resized. Transforms relative margins into absolute margins and vice versa.
	/// </summary>
	// ReSharper disable once InconsistentNaming
	internal class RelativeMargin_To_AbsoluteMargin : DependencyObject, IMultiValueConverter
	{


		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Container" /> property.</summary>
		public static readonly DependencyProperty ContainerProperty = DependencyProperty.Register("Container", typeof(FrameworkElement), typeof(RelativeMargin_To_AbsoluteMargin), new FrameworkPropertyMetadata
																																													{
																																														//PropertyChangedCallback = (o, args) => ((PercentToContainerMetricConverter)o).ContainerDpChanged((FrameworkElement)args.OldValue, (FrameworkElement)args.NewValue),
																																														DefaultValue = default(FrameworkElement),
																																														DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																													});
		#endregion


		#region Overrides/Interfaces
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(values[0] is Thickness))
				return new Thickness(0);

			var percentageThickness = (Thickness) values[0];
			var containerWidth = (double) values[1];
			var containerHeight = (double) values[2];

			var leftMargin = containerWidth * (percentageThickness.Left / 100);
			var rightMargin = containerWidth * (percentageThickness.Right / 100);
			var topMargin = containerHeight * (percentageThickness.Top / 100);
			var bottomMargin = containerHeight * (percentageThickness.Bottom / 100);
			return new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			var val = (Thickness) value;
			var thickness = new Thickness(val.Left / Container.ActualWidth * 100, val.Top / Container.ActualHeight * 100, val.Right / Container.ActualWidth * 100, val.Bottom / Container.ActualHeight * 100);
			return new object[] {thickness, Binding.DoNothing, Binding.DoNothing};
		}
		#endregion


		/// <summary>Represents the Visual parent of the grid. This is needed for the realtive margins</summary>
		public FrameworkElement Container
		{
			get => (FrameworkElement) GetValue(ContainerProperty);
			set => SetValue(ContainerProperty, value);
		}
	}
}