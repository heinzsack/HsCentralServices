using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;






namespace PlayerControls.Controls
	{
	public class RatioBorder : Border
		{
		#region DependencyProperty --- RatioX --- 

		public static readonly DependencyProperty RatioXProperty = DependencyProperty.Register(
			"RatioX", typeof(double), typeof(RatioBorder),
			new FrameworkPropertyMetadata(default(double))
				{
				DefaultValue = default(double),
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((RatioBorder) Sender)
					.RatioXChanged((double) Args.OldValue,
						(double) Args.NewValue),
				AffectsArrange = true
				});

		public double RatioX
			{
			get { return (double) GetValue(RatioXProperty); }
			set { SetValue(RatioXProperty, value); }
			}

		private void RatioXChanged(double OldValue,
			double NewValue)
			{
			}

		#endregion

		#region DependencyProperty --- RatioY --- 

		public static readonly DependencyProperty RatioYProperty = DependencyProperty.Register(
			"RatioY", typeof(double), typeof(RatioBorder),
			new FrameworkPropertyMetadata(default(double))
				{
				DefaultValue = default(double),
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((RatioBorder) Sender)
					.RatioYChanged((double) Args.OldValue,
						(double) Args.NewValue),
				AffectsArrange = true
				});

		public double RatioY
			{
			get { return (double) GetValue(RatioYProperty); }
			set { SetValue(RatioYProperty, value); }
			}

		private void RatioYChanged(double OldValue,
			double NewValue)
			{
			}

		#endregion

		protected override Size MeasureOverride(Size constraint)
			{
//ToDo by sac if is implemented after exception (Measure override only if required ??) 
			//if ((double.IsNaN(RatioX))
			//	|| (double.IsNaN(RatioY))
			//	|| (RatioX < 0.1)
			//	|| (RatioY <  0.1))
			//	{
			//	return constraint;
			//	}
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
//ToDo by sac if is implemented after exception (Measure override only if required ??)  
			//if ((double.IsNaN(RatioX))
			//	|| (double.IsNaN(RatioY))
			//	|| (RatioX < 0.1)
			//	|| (RatioY < 0.1))
			//	{
			//	return finalSize;
			//	}
			var targetWidth = finalSize.Height * RatioX/RatioY;
			var targetHeight = finalSize.Width * RatioY/RatioX;

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


			var finalRatio = finalSize.Width/finalSize.Height;
			var targetRatio = RatioX/RatioY;

			if (finalRatio > targetRatio)
				{
			return base.ArrangeOverride(new Size(finalSize.Height * (RatioX / RatioY), finalSize.Height));
				}
				return base.ArrangeOverride(new Size(finalSize.Width, finalSize.Width * (RatioY / RatioX)));
			}
		}
	}