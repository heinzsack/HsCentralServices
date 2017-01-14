using System;
using System.Windows.Markup;
using PlayerControls.Interfaces;

namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	partial class RingEntry : IPageSchedule
		{
		[DependsOn(nameof(Page))]
		public IPage IPage => Page;

		[DependsOn(nameof(StartTime))]
		public TimeSpan IStartTime => StartTime.TimeOfDay;
		}
	}