// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;






namespace PlayerControls.Interfaces.Transistions
{
	/// <summary>Contains extension methods for the transitions.</summary>
	public static class TransitionExtensions
	{
		/// <summary>Returns a list of converted <see cref="Timeline" /> objects which can be added to a <see cref="Storyboard" />.</summary>
		public static Storyboard ConvertTo_Storyboard(this IEnumerable<ITransition> doubleTransition)
		{
			var storyboard = new Storyboard();

			foreach (var timelineObject in doubleTransition.ConvertTo_TimelineObjects())
			{
				storyboard.Children.Add(timelineObject);
			}

			return storyboard;
		}

		/// <summary>Returns a list of converted <see cref="Timeline" /> objects which can be added to a <see cref="Storyboard" />.</summary>
		public static IEnumerable<Timeline> ConvertTo_TimelineObjects(this IEnumerable<ITransition> doubleTransition)
		{
			foreach (var transition in doubleTransition)
			{
				if (transition is IDoubleTransition)
					yield return ((IDoubleTransition) transition).ConvertTo_DoubleAnimation();
			}
		}

		/// <summary>
		///     Returns the presentation of the <paramref name="doubleTransition" /> by converting it to an instance of
		///     <see cref="DoubleAnimation" /> which can be added to a <see cref="Storyboard" />.
		/// </summary>
		public static DoubleAnimation ConvertTo_DoubleAnimation(this IDoubleTransition doubleTransition)
		{
			var doubleAnimation = new DoubleAnimation(
				doubleTransition.TransitionFromValue,
				doubleTransition.TransitionToValue,
				doubleTransition.TransitionDuration,
				FillBehavior.HoldEnd)
			{
				BeginTime = doubleTransition.TransitionBeginTime,
			};

			if (doubleTransition.TransitionsType == TransitionTypes.Cubic)
				doubleAnimation.EasingFunction = new CubicEase();
			else if (doubleTransition.TransitionsType == TransitionTypes.Exponential)
				doubleAnimation.EasingFunction = new ExponentialEase();

			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(doubleTransition.TransitionPropertyPath));
			return doubleAnimation;
		}
	}
}