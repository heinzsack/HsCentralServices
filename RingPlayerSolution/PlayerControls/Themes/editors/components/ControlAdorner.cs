// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using JetBrains.Annotations;






namespace PlayerControls.Themes.editors.components
{
	/// <summary>A control adorner which can be filled with a control.</summary>
	[ContentProperty(nameof(Child))]
	internal class ControlAdorner : Adorner
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Child" /> property.</summary>
		public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(FrameworkElement), typeof(ControlAdorner), new FrameworkPropertyMetadata
		{
			PropertyChangedCallback = (o, args) => ((ControlAdorner) o).ChildDpChanged((FrameworkElement) args.OldValue, (FrameworkElement) args.NewValue),
			DefaultValue = default(FrameworkElement),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		#region DP Changed
		private void ChildDpChanged(FrameworkElement argsOldValue, FrameworkElement argsNewValue)
		{
			if (argsOldValue != null)
				RemoveVisualChild(argsOldValue);
			if (argsNewValue != null)
				AddVisualChild(argsNewValue);
		}
		#endregion

		public ControlAdorner([NotNull] UIElement adornedElement) : base(adornedElement)
		{
		}


		#region Overrides/Interfaces
		protected override int VisualChildrenCount => Child == null ? 0 : 1;

		protected override Visual GetVisualChild(int index)
		{
			if (index != 0)
				throw new ArgumentOutOfRangeException();
			return Child;
		}

		protected override Size MeasureOverride(Size constraint)
		{
			Child?.Measure(constraint);
			return base.MeasureOverride(constraint);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			Child?.Arrange(new Rect(new Point(0, 0), finalSize));
			return base.ArrangeOverride(finalSize);
		}
		#endregion


		/// <summary>The child control of this adorner.</summary>
		public FrameworkElement Child
		{
			get { return (FrameworkElement) GetValue(ChildProperty); }
			set { SetValue(ChildProperty, value); }
		}
	}
}