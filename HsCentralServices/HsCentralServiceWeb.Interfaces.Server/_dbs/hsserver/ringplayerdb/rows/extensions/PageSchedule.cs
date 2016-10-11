using System;
using System.Windows.Markup;
using PlayerControls.Interfaces;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
	{
	partial class PageSchedule : IPageSchedule
		{
		[DependsOn(nameof(Page))]
		public IPage IPage => Page;

		[DependsOn(nameof(StartTime))]
		public TimeSpan IStartTime => StartTime.TimeOfDay;
		}
	}