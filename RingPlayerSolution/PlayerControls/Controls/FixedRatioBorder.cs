// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;






namespace PlayerControls.Controls
{
	internal class FixedRatioBorder : Border
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="RatioX" /> property.</summary>
		public static readonly DependencyProperty RatioXProperty = DependencyProperty.Register("RatioX", typeof(double), typeof(FixedRatioBorder), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((RatioBorder)o).RatioXDpChanged((double)args.OldValue, (double)args.NewValue),
			DefaultValue = default(double),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="RatioY" /> property.</summary>
		public static readonly DependencyProperty RatioYProperty = DependencyProperty.Register("RatioY", typeof(double), typeof(FixedRatioBorder), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((RatioBorder)o).RatioYDpChanged((double)args.OldValue, (double)args.NewValue),
			DefaultValue = default(double),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		#region Overrides/Interfaces
		protected override Size MeasureOverride(Size constraint)
		{

			var targetWidth = constraint.Height * RatioX / RatioY;
			var targetHeight = constraint.Width * RatioY / RatioX;

			if (targetWidth > constraint.Width)
			{
				var size = new Size(constraint.Width, targetHeight);
				return base.MeasureOverride(size);
			}
			else
			{
				var size = new Size(targetWidth, constraint.Height);
				return base.MeasureOverride(size);
			}
		}

		protected override Size ArrangeOverride(Size finalSize)
		{

			var targetWidth = finalSize.Height * RatioX / RatioY;
			var targetHeight = finalSize.Width * RatioY / RatioX;

			if (targetWidth > finalSize.Width)
			{
				var size = new Size(finalSize.Width, targetHeight);
				return base.ArrangeOverride(size);
			}
			else
			{
				var size = new Size(targetWidth, finalSize.Height);
				return base.ArrangeOverride(size);
			}
		}
		#endregion


		/// <summary>could be 16 when <see cref="RatioY" /> is 9 to make a 16:9 frame.</summary>
		public double RatioX
		{
			get { return (double) GetValue(RatioXProperty); }
			set { SetValue(RatioXProperty, value); }
		}

		/// <summary>could be 9 when <see cref="RatioX" /> is 16 to make a 16:9 frame.</summary>
		public double RatioY
		{
			get { return (double) GetValue(RatioYProperty); }
			set { SetValue(RatioYProperty, value); }
		}
	}
}