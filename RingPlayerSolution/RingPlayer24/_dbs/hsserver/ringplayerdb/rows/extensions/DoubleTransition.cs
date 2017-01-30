// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Windows;
using System.Windows.Markup;
using PlayerControls.Interfaces.Transistions;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class DoubleTransition : IDoubleTransition
	{
		#region Overrides/Interfaces
		[DependsOn(nameof(BeginnTimeSeconds))]
		public TimeSpan TransitionBeginTime => TimeSpan.FromSeconds(BeginnTimeSeconds);

		[DependsOn(nameof(DurationSeconds))]
		public Duration TransitionDuration => TimeSpan.FromSeconds(DurationSeconds);

		[DependsOn(nameof(FromValue))]
		public double TransitionFromValue => FromValue;

		[DependsOn(nameof(ToValue))]
		public double TransitionToValue => ToValue;

		[DependsOn(nameof(TransitionType))]
		public TransitionTypes TransitionsType => Convert.Enum.Getter(TransitionType, TransitionTypes.Linear);

		[DependsOn(nameof(PropertyPath))]
		public string TransitionPropertyPath => PropertyPath;
		#endregion
	}
}