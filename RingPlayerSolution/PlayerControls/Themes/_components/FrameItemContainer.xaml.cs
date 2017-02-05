// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

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
			var converter = (PercentToContainerMetricConverter) BindingOperations.GetMultiBinding(control, MarginProperty)?.Converter;
			converter.Container = control.GetVisualParentByCondition<FrameworkElement>(t => true);
		}

		private void Storyboard_Completed(object sender, EventArgs e)
		{
			Completed?.Invoke(this);
		}
	}
}