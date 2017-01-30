using System;
using System.Windows.Markup;
using PlayerControls.Interfaces;

namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class RingEntry : IScheduledFrame
		{
		[DependsOn(nameof(Page))]
		public IFrame Frame => Page;

		[DependsOn(nameof(StartTime))]
		public TimeSpan FrameStartTime => StartTime.TimeOfDay;
		}
	}