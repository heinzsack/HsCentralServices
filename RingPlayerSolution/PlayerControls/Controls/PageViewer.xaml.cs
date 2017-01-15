using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using PlayerControls.Interfaces;






namespace PlayerControls.Controls
	{
	/// <summary>
	/// Interaction logic for PageViewer.xaml
	/// </summary>
	public partial class PageViewer : UserControl
		{
		#region DependencyProperty --- Page --- 

		public static readonly DependencyProperty PageProperty = DependencyProperty.Register(
			"Page", typeof(IPage), typeof(PageViewer),
			new FrameworkPropertyMetadata(default(IPage))
				{
				DefaultValue = default(IPage),
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((PageViewer) Sender)
					.PageChanged((IPage) Args.OldValue,
						(IPage) Args.NewValue)
				});

		public IPage Page
			{
			get { return (IPage) GetValue(PageProperty); }
			set { SetValue(PageProperty, value); }
			}

		private void PageChanged(IPage OldValue,
			IPage NewValue)
			{
			}

		#endregion

		#region DependencyProperty --- IsTextBoundaryVisible --- 

		public static readonly DependencyProperty IsTextBoundaryVisibleProperty = DependencyProperty.Register(
			"IsTextBoundaryVisible", typeof(bool), typeof(PageViewer),
			new FrameworkPropertyMetadata(default(bool))
				{
				DefaultValue = default(bool),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((PageViewer)Sender)
					.IsTextBoundaryVisibleChanged((bool)Args.OldValue,
						(bool)Args.NewValue)
				});

		public bool IsTextBoundaryVisible
			{
			get { return (bool)GetValue(IsTextBoundaryVisibleProperty); }
			set { SetValue(IsTextBoundaryVisibleProperty, value); }
			}

		private void IsTextBoundaryVisibleChanged(bool OldValue,
			bool NewValue)
			{
			}

		#endregion

		#region DependencyProperty --- IsImageBoundaryVisible --- 

		public static readonly DependencyProperty IsImageBoundaryVisibleProperty = DependencyProperty.Register(
			"IsImageBoundaryVisible", typeof(bool), typeof(PageViewer),
			new FrameworkPropertyMetadata(default(bool))
				{
				DefaultValue = default(bool),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((PageViewer)Sender)
					.IsImageBoundaryVisibleChanged((bool)Args.OldValue,
						(bool)Args.NewValue)
				});

		public bool IsImageBoundaryVisible
			{
			get { return (bool)GetValue(IsImageBoundaryVisibleProperty); }
			set { SetValue(IsImageBoundaryVisibleProperty, value); }
			}

		private void IsImageBoundaryVisibleChanged(bool OldValue,
			bool NewValue)
			{
			}

		#endregion

		#region DependencyProperty --- IsVideoBoundaryVisible --- 

		public static readonly DependencyProperty IsVideoBoundaryVisibleProperty = DependencyProperty.Register(
			"IsVideoBoundaryVisible", typeof(bool), typeof(PageViewer),
			new FrameworkPropertyMetadata(default(bool))
				{
				DefaultValue = default(bool),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((PageViewer)Sender)
					.IsVideoBoundaryVisibleChanged((bool)Args.OldValue,
						(bool)Args.NewValue)
				});

		public bool IsVideoBoundaryVisible
			{
			get { return (bool)GetValue(IsVideoBoundaryVisibleProperty); }
			set { SetValue(IsVideoBoundaryVisibleProperty, value); }
			}

		private void IsVideoBoundaryVisibleChanged(bool OldValue,
			bool NewValue)
			{
			}

		#endregion

		#region DependencyProperty --- IsContainerBoundaryVisible --- 

		public static readonly DependencyProperty IsContainerBoundaryVisibleProperty = DependencyProperty.Register(
			"IsContainerBoundaryVisible", typeof(bool), typeof(PageViewer),
			new FrameworkPropertyMetadata(default(bool))
				{
				DefaultValue = default(bool),
				BindsTwoWayByDefault = true,
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((PageViewer)Sender)
					.IsDynamicBoundaryVisibleChanged((bool)Args.OldValue,
						(bool)Args.NewValue)
				});

		public bool IsContainerBoundaryVisible
			{
			get { return (bool)GetValue(IsContainerBoundaryVisibleProperty); }
			set { SetValue(IsContainerBoundaryVisibleProperty, value); }
			}

		private void IsDynamicBoundaryVisibleChanged(bool OldValue,
			bool NewValue)
			{
			}

		#endregion


		public PageViewer()
			{
			InitializeComponent();
			VisualSelector visualSelector = (VisualSelector)this.Resources[typeof(VisualSelector)];
			visualSelector.IVisualContainerTemplate = (DataTemplate)this.Resources[typeof(IPage)];
			visualSelector.IVisualContainerWithFixedRatioTemplate = (DataTemplate)this.Resources["IPageWithFixedRatio"];
			visualSelector.IVideoVisualTemplate = (DataTemplate)this.Resources[typeof(IVideoVisual)];
			visualSelector.ITextVisualTemplate = (DataTemplate)this.Resources[typeof(ITextVisual)];
			visualSelector.IImageVisualTemplate = (DataTemplate)this.Resources[typeof(IImageVisual)];
			}

		public void StartVideos(TimeSpan? position = null)
			{
			var start = DateTime.Now;
			foreach (var mediaElement in GetMediaElemente_FromPage())
				{
				if (position != null && position.Value > TimeSpan.FromMilliseconds(100))
					{
					mediaElement.MediaOpened += (sender, args) =>
						{
						mediaElement.Position = position.Value.Add(DateTime.Now - start);
						};
					}
				mediaElement.Play();
				}
			}

		public void MakeVideoVisible(TimeSpan position)
			{
			foreach (var mediaElement in GetMediaElemente_FromPage())
				{
				}
			}


		public void StartAnimations(TimeSpan? position = null)
			{
			foreach (var animationCover in GetAnimationCovers_FromPage())
				{
				animationCover.StartStoryBoard(position ?? TimeSpan.Zero);
				}
			}

		private MediaElement[] GetMediaElemente_FromPage()
			{
			List<MediaElement> mediaElements = RecursiveGetVisualChildByCondition(new List<MediaElement>(), PagePresenter, cover => true);
			if (mediaElements == null)
				return new MediaElement[0];
			return mediaElements.ToArray();
			}
		private AnimationCover[] GetAnimationCovers_FromPage()
			{

			List<AnimationCover> animationCovers = RecursiveGetVisualChildByCondition(new List<AnimationCover>(), PagePresenter, cover => true);
			if (animationCovers == null)
				return new AnimationCover[0];
			return animationCovers.ToArray();
			}
		private static List<T> RecursiveGetVisualChildByCondition<T>(List<T> list, DependencyObject container, Func<T, bool> condition) where T : FrameworkElement
			{
			if (container == null) return null;
			//Debug.WriteLine($"{container.GetType().Name} {typeof(T)}");
			T foundElement = null;
			if (container is FrameworkElement)
				(container as FrameworkElement).ApplyTemplate();
			if (container is ItemsControl)
				((ItemsControl)container).UpdateLayout();
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(container); i++)
				{
				DependencyObject dpO = VisualTreeHelper.GetChild(container, i);

				if (!(dpO is T))
					{
					RecursiveGetVisualChildByCondition(list, dpO, condition);
					continue;
					}

				T element = (T)dpO;
				if (!condition(element)) continue;

				list.Add((T)element);
				}

			return list;
			}

		private void MediaElement_OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
			{
			// throw new NotImplementedException();
			}
		}

	public class PercentToContainerMetricConverter : IMultiValueConverter
		{
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

			Thickness percentageThickness = (Thickness)values[0];
			double containerWidth = (double)values[1];
			double containerHeight = (double)values[2];


			double leftMargin = containerWidth * (percentageThickness.Left / 100);
			double rightMargin = containerWidth * (percentageThickness.Right / 100);
			double topMargin = containerHeight * (percentageThickness.Top / 100);
			double bottomMargin = containerHeight * (percentageThickness.Bottom / 100);
			return new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
			}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
			{
			throw new NotImplementedException();
			}
		}
	}
