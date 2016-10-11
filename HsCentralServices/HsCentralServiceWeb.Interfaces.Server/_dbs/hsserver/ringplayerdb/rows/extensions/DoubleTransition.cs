// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Windows;
using System.Windows.Markup;
using PlayerControls.Interfaces.Transistions;






namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
{
	partial class DoubleTransition : IDoubleTransition
	{
		#region Overrides/Interfaces
		[DependsOn(nameof(BeginnTimeSeconds))]
		public TimeSpan IBeginTime => TimeSpan.FromSeconds(BeginnTimeSeconds);

		[DependsOn(nameof(DurationSeconds))]
		public Duration IDuration => TimeSpan.FromSeconds(DurationSeconds);

		[DependsOn(nameof(FromValue))]
		public double IFrom => FromValue;

		[DependsOn(nameof(ToValue))]
		public double ITo => ToValue;

		[DependsOn(nameof(TransitionType))]
		public TransitionTypes ITransitionType => Convert.Enum.Getter(TransitionType, TransitionTypes.Linear);

		[DependsOn(nameof(PropertyPath))]
		public string IPropertyPath => PropertyPath;
		#endregion
	}
}