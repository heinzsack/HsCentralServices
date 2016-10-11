using System;
using System.Windows.Markup;
using IPage = RingPlayerControls.Interfaces.IPage;

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