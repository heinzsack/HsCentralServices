// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using CsWpfBase.Ev.Public.Extensions;
using JetBrains.Annotations;
using PlayerControls.Controls;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.FrameItems;
using PlayerControls._mocks;






namespace PlayerControls.Themes
{
	/// <summary>Interaction logic for PageViewer.xaml</summary>
	public partial class FramePresenter : UserControl
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="IsDiagnostic" /> property.</summary>
		public static readonly DependencyProperty IsDiagnosticProperty = DependencyProperty.Register("IsDiagnostic", typeof(bool), typeof(FramePresenter), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			//PropertyChangedCallback = (o, args) => ((FramePresenter)o).IsDiagnosticDpChanged((bool)args.OldValue, (bool)args.NewValue),
			DefaultValue = default(bool),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Item" /> property.</summary>
		public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(IFrame), typeof(FramePresenter), new FrameworkPropertyMetadata
		{
			PropertyChangedCallback = (o, args) => ((FramePresenter) o).ItemDpChanged((IFrame) args.OldValue, (IFrame) args.NewValue),
			DefaultValue = default(IFrame),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		#region DP Changed
		private void ItemDpChanged(IFrame oldValue, IFrame newValue)
		{
			_videosStarted = false;
			_animationsStarted = false;
		}
		#endregion


		/// <summary>Returns a prefilled IFrame.</summary>
		public static IFrame GetMock()
		{
			return MockFrame.GetSample();
		}


		//private static List<T> RecursiveGetVisualChildByCondition<T>(List<T> list, DependencyObject container, Func<T, bool> condition) where T : FrameworkElement
		//{
		//	if (container == null) return null;
		//	//Debug.WriteLine($"{container.GetType().Name} {typeof(T)}");
		//	T foundElement = null;
		//	if (container is FrameworkElement)
		//		(container as FrameworkElement).ApplyTemplate();
		//	if (container is ItemsControl)
		//		((ItemsControl) container).UpdateLayout();
		//	for (var i = 0; i < VisualTreeHelper.GetChildrenCount(container); i++)
		//	{
		//		var dpO = VisualTreeHelper.GetChild(container, i);

		//		if (!(dpO is T))
		//		{
		//			RecursiveGetVisualChildByCondition(list, dpO, condition);
		//			continue;
		//		}

		//		var element = (T) dpO;
		//		if (!condition(element)) continue;

		//		list.Add((T) element);
		//	}

		//	return list;
		//}

		private bool _animationsStarted;
		private bool _videosStarted;


		public FramePresenter()
		{
			InitializeComponent();
			var selector = (FrameItemTemplateSelector) Resources[typeof(FrameItemTemplateSelector)];
			selector.DynamicRatioFrameTemplate = (DataTemplate) Resources[typeof(IFrame)];
			selector.FixedRatioFrameTemplate = (DataTemplate) Resources[nameof(selector.FixedRatioFrameTemplate)];
			selector.FrameItemVideoTemplate = (DataTemplate) Resources[typeof(IFrameItemVideo)];
			selector.FrameItemTextTemplate = (DataTemplate) Resources[typeof(IFrameItemText)];
			selector.FrameItemImageTemplate = (DataTemplate) Resources[typeof(IFrameItemImage)];
		}


		/// <summary>The <see cref="IFrame" /> which should be displayed by the <see cref="FramePresenter" />.</summary>
		public IFrame Item
		{
			get { return (IFrame) GetValue(ItemProperty); }
			set { SetValue(ItemProperty, value); }
		}

		/// <summary>If true a special diagnostic representation of the single elements will be applied.</summary>
		public bool IsDiagnostic
		{
			get { return (bool) GetValue(IsDiagnosticProperty); }
			set { SetValue(IsDiagnosticProperty, value); }
		}


		/// <summary>
		///     Starts the videos of this page at a specific <paramref name="position" />. This method can safly be called multiple times.
		///     Only the first call will take effect.
		/// </summary>
		/// <param name="position">The position where the video should start.</param>
		public void StartVideos(TimeSpan? position = null)
		{
			if (_videosStarted)
				return;
			_videosStarted = true;

			var start = DateTime.Now;
			foreach (var mediaElement in GetMediaElemente_FromPage())
			{
				if (position != null && position.Value > TimeSpan.FromMilliseconds(100))
				{
					mediaElement.MediaOpened += (sender, args) => { mediaElement.Position = position.Value.Add(DateTime.Now - start); };
				}
				mediaElement.Play();
			}
		}

		/// <summary>
		///     Starts the transitions of this page at a specific <paramref name="position" />. This method can safly be called multiple
		///     times. Only the first call will take effect.
		/// </summary>
		/// <param name="position">The position where the transistions should start.</param>
		public void StartTransitions(TimeSpan? position = null)
		{
			if (_animationsStarted)
				return;
			_animationsStarted = true;

			foreach (var animationCover in GetTransistionCovers_FromPage())
			{
				animationCover.Start(position ?? TimeSpan.Zero);
			}
		}


		private MediaElement[] GetMediaElemente_FromPage()
		{
			var mediaElements = PagePresenter.GetVisualChildsByCondition<MediaElement>(cover => true);
			if (mediaElements == null)
				return new MediaElement[0];
			return mediaElements.ToArray();
		}

		private TransitionCover[] GetTransistionCovers_FromPage()
		{

			var animationCovers = PagePresenter.GetVisualChildsByCondition<TransitionCover>(cover => true);
			if (animationCovers == null)
				return new TransitionCover[0];
			return animationCovers.ToArray();
		}

		private void MediaElement_OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
		{
			// throw new NotImplementedException();
		}
	}




	public class PercentToContainerMetricConverter : IMultiValueConverter
	{
		#region Overrides/Interfaces
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values.Length != 3)
				return new Thickness(0);
			if (!(values[0] is Thickness))
				return new Thickness(0);
			if (!(values[1] is double))
				return new Thickness(0);
			if (!(values[2] is double))
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
			throw new NotImplementedException();
		}
		#endregion
	}
}