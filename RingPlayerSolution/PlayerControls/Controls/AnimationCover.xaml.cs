using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls.Controls
	{
	/// <summary>
	/// Interaction logic for AnimationCover.xaml
	/// </summary>
	public partial class AnimationCover : Border
		{
		#region DependencyProperty --- Transitions --- 

		public static readonly DependencyProperty TransitionsProperty = DependencyProperty.Register(
			"Transitions", typeof(IList<ITransition>), typeof(AnimationCover),
			new FrameworkPropertyMetadata(default(IList<ITransition>))
				{
				DefaultValue = default(IList<ITransition>),
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((AnimationCover)Sender)
					.TransitionsChanged((IList<ITransition>)Args.OldValue,
						(IList<ITransition>)Args.NewValue)
				});

		public IList<ITransition> Transitions
			{
			get { return (IList<ITransition>)GetValue(TransitionsProperty); }
			set { SetValue(TransitionsProperty, value); }
			}

		private void TransitionsChanged(IList<ITransition> OldValue,
			IList<ITransition> NewValue)
			{
			}

		#endregion

		#region DependencyProperty --- RotationAngle --- 

		public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.Register(
			"RotationAngle", typeof(double), typeof(AnimationCover),
			new FrameworkPropertyMetadata(default(double))
				{
				DefaultValue = default(double),
				DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				PropertyChangedCallback = (Sender, Args) => ((AnimationCover) Sender)
					.RotationChanged((double) Args.OldValue,
						(double) Args.NewValue)
				});

		public double RotationAngle
			{
			get { return (double) GetValue(RotationAngleProperty); }
			set { SetValue(RotationAngleProperty, value); }
			}

		private void RotationChanged(double OldValue,
			double NewValue)
			{
			}

		#endregion



		public AnimationCover()
			{
			InitializeComponent();
			}

		public event Action<AnimationCover> Completed;

		private ThicknessAnimation CommonStartAnimation { get; set; }

		private Storyboard currentStoryboard { get; set; }

		public void LoadTransitions()
			{
			if (currentStoryboard != null)
				{
				currentStoryboard.Stop(this);
				currentStoryboard = null;
				}
			if (Transitions == null)
				return;
			currentStoryboard = new Storyboard();
			foreach (ITransition transition in Transitions)
				{
				if (transition is IDoubleTransition)
					{
					IDoubleTransition doubleTransition = (IDoubleTransition)transition;

					DoubleAnimation doubleAnimation = new DoubleAnimation(
						doubleTransition.IFrom, 
						doubleTransition.ITo, 
						doubleTransition.IDuration, 
						FillBehavior.HoldEnd)
						{
						BeginTime = doubleTransition.IBeginTime,
						};

					if (doubleTransition.ITransitionType == TransitionTypes.Cubic)
						doubleAnimation.EasingFunction = new CubicEase();
					else if (doubleTransition.ITransitionType == TransitionTypes.Exponential)
						doubleAnimation.EasingFunction = new ExponentialEase();

					Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(doubleTransition.IPropertyPath));
					
					currentStoryboard.Children.Add(doubleAnimation);
					}
				}
			currentStoryboard.Completed += Storyboard_Completed;
			}


		public void StartStoryBoard(TimeSpan? offset = null)
			{
			if (currentStoryboard == null)
				{
				LoadTransitions();
				}
			if (currentStoryboard != null)
				{
				currentStoryboard.Seek(offset??TimeSpan.Zero);
				currentStoryboard.Begin(this);
				}

			}

		private void Storyboard_Completed(object sender, EventArgs e)
			{
			Completed?.Invoke(this);
			}
		}


	
	}
