using System;
using System.Windows;
using System.Windows.Markup;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
	{
	partial class DoubleTransition : RingPlayerControls.Interfaces.Transistions.IDoubleTransition
		{
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
		}
	}
