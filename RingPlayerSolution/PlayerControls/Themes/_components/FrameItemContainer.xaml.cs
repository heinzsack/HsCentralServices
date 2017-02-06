// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-06</date>

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using CsWpfBase.Ev.Public.Extensions;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls.Themes._components
{
	/// <summary>Interaction logic for IFrameItemContainer.xaml</summary>
	public partial class FrameItemContainer : Border
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="HasFixedRatio" /> property.</summary>
		public static readonly DependencyProperty HasFixedRatioProperty = DependencyProperty.Register("HasFixedRatio", typeof(bool), typeof(FrameItemContainer), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((FrameItemContainer)o).HasFixedRatioDpChanged((bool)args.OldValue, (bool)args.NewValue),
			DefaultValue = default(bool),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
			AffectsRender = true,
			AffectsMeasure = true,
			AffectsArrange = true,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="RatioX" /> property.</summary>
		public static readonly DependencyProperty RatioXProperty = DependencyProperty.Register("RatioX", typeof(double), typeof(FrameItemContainer), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((FrameItemContainer)o).RatioXDpChanged((double)args.OldValue, (double)args.NewValue),
			DefaultValue = default(double),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
			AffectsRender = true,
			AffectsMeasure = true,
			AffectsArrange = true,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="RatioY" /> property.</summary>
		public static readonly DependencyProperty RatioYProperty = DependencyProperty.Register("RatioY", typeof(double), typeof(FrameItemContainer), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((FrameItemContainer)o).RatioYDpChanged((double)args.OldValue, (double)args.NewValue),
			DefaultValue = default(double),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
			AffectsRender = true,
			AffectsMeasure = true,
			AffectsArrange = true,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Transitions" /> property.</summary>
		public static readonly DependencyProperty TransitionsProperty = DependencyProperty.Register("Transitions", typeof(IList<ITransition>), typeof(FrameItemContainer), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			//PropertyChangedCallback = (o, args) => ((FrameItemContainer)o).TransitionsDpChanged((IList<ITransition>)args.OldValue, (IList<ITransition>)args.NewValue),
			DefaultValue = default(IList<ITransition>),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		private Storyboard CurrentStoryboard { get; set; }


		#region EVENTS
		public event Action<FrameItemContainer> Completed;
		#endregion


		public FrameItemContainer()
		{
			InitializeComponent();
		}


		#region Overrides/Interfaces
		protected override Size MeasureOverride(Size constraint)
		{
			if (!HasFixedRatio || RatioX == 0 || RatioY == 0)
				return base.MeasureOverride(constraint);


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
			if(!HasFixedRatio || RatioX == 0 || RatioY == 0)
				return base.ArrangeOverride(finalSize);


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


		/// <summary>If true the border will preserve the ratio</summary>
		public bool HasFixedRatio
		{
			get { return (bool) GetValue(HasFixedRatioProperty); }
			set { SetValue(HasFixedRatioProperty, value); }
		}

		/// <summary>The ratio in x direction</summary>
		public double RatioX
		{
			get { return (double) GetValue(RatioXProperty); }
			set { SetValue(RatioXProperty, value); }
		}

		/// <summary>The ratio in y direction</summary>
		public double RatioY
		{
			get { return (double) GetValue(RatioYProperty); }
			set { SetValue(RatioYProperty, value); }
		}

		/// <summary>Transitions which needs to be applied to the border.</summary>
		public IList<ITransition> Transitions
		{
			get { return (IList<ITransition>) GetValue(TransitionsProperty); }
			set { SetValue(TransitionsProperty, value); }
		}

		/// <summary>Loads the transitions</summary>
		public void Load()
		{
			if (CurrentStoryboard != null)
			{
				CurrentStoryboard.Stop(this);
				CurrentStoryboard = null;
			}
			if (Transitions == null)
				return;


			CurrentStoryboard = Transitions.ConvertTo_Storyboard();
			CurrentStoryboard.Completed += Storyboard_Completed;
		}


		public void Start(TimeSpan? offset = null)
		{
			if (CurrentStoryboard == null)
				Load();
			if (CurrentStoryboard != null)
			{
				CurrentStoryboard.Seek(offset ?? TimeSpan.Zero);
				CurrentStoryboard.Begin(this);
			}

		}

		private void SetConverterContainer(object sender, EventArgs eventArgs)
		{
			var control = (FrameItemContainer) sender;
			var converter = (RelativeMargin_To_AbsoluteMargin) BindingOperations.GetMultiBinding(control, MarginProperty)?.Converter;
			converter.Container = control.VisualParent_By_Condition<FrameworkElement>(t => true);
		}

		private void Storyboard_Completed(object sender, EventArgs e)
		{
			Completed?.Invoke(this);
		}
	}
}