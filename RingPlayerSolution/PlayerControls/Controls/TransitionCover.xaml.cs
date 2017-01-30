// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using PlayerControls.Interfaces.Transistions;






namespace PlayerControls.Controls
{
	/// <summary>Interaction logic for AnimationCover.xaml</summary>
	internal partial class TransitionCover : Border
	{
		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="RotationAngle" /> property.</summary>
		public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.Register("RotationAngle", typeof(double), typeof(TransitionCover), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((AnimationCover)o).RotationAngleDpChanged((double)args.OldValue, (double)args.NewValue),
			DefaultValue = default(double),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Transitions" /> property.</summary>
		public static readonly DependencyProperty TransitionsProperty = DependencyProperty.Register("Transitions", typeof(IList<ITransition>), typeof(TransitionCover), new FrameworkPropertyMetadata
		{
			//PropertyChangedCallback = (o, args) => ((AnimationCover)o).TransitionsDpChanged((IList<ITransition>)args.OldValue, (IList<ITransition>)args.NewValue),
			DefaultValue = default(IList<ITransition>),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		private Storyboard CurrentStoryboard { get; set; }


		#region EVENTS
		public event Action<TransitionCover> Completed;
		#endregion


		public TransitionCover()
		{
			InitializeComponent();
		}

		/// <summary>The transitions of which should be executed by this <see cref="TransitionCover" />.</summary>
		public IList<ITransition> Transitions
		{
			get { return (IList<ITransition>) GetValue(TransitionsProperty); }
			set { SetValue(TransitionsProperty, value); }
		}

		/// <summary>The rotation which will be applied to its content.</summary>
		public double RotationAngle
		{
			get { return (double) GetValue(RotationAngleProperty); }
			set { SetValue(RotationAngleProperty, value); }
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

		private void Storyboard_Completed(object sender, EventArgs e)
		{
			Completed?.Invoke(this);
		}
	}



}