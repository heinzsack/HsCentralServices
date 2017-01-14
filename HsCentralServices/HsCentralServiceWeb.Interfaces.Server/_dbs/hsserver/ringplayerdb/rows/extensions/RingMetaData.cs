// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Linq;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;






//using DbEntitiesPlayer.dbserver3.CustomClasses;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows
{
	partial class RingMetaData
	{
		private ScheduledPageGroup[] _scheduledPageGroups;

		public ScheduledPageGroup[] ScheduledPageGroups
		{
			get
			{
				if (_scheduledPageGroups != null)
					return _scheduledPageGroups;

				_scheduledPageGroups = PageSchedules.GroupBy(x => x.PageGroupScheduleId).Select(x =>
				{
					var orderedPageSchedules = x.OrderBy(x2 => x2.StartTime).ToArray();
					return new ScheduledPageGroup()
					{
						PageGroupScheduleId = x.Key,
						StartTime = orderedPageSchedules.First().StartTime,
						PageSchedules = orderedPageSchedules,
						Pages = orderedPageSchedules.Select(x2 => x2.Page).Distinct().OrderBy(x2 => x2.SortOrder).ToArray(),
					};
				}).OrderBy(x => x.StartTime).ToArray();

				if (ScheduledPageGroups.Length != 0)
				{
					for (var i = 0; i < _scheduledPageGroups.Length - 1; i++)
					{
						_scheduledPageGroups[i].Duration = _scheduledPageGroups[i + 1].StartTime.TimeOfDay -
															_scheduledPageGroups[i].StartTime.TimeOfDay;
					}
					_scheduledPageGroups[_scheduledPageGroups.Length - 1].Duration = DateTime.Now.EndOfDay().TimeOfDay -
																					_scheduledPageGroups[_scheduledPageGroups.Length - 1].StartTime.TimeOfDay;
				}
				return _scheduledPageGroups;
			}
		}



		public class ScheduledPageGroup : Base
		{
			private TimeSpan _duration;
			private Guid _pageGroupScheduleId;
			private Page[] _pages;
			private PageSchedule[] _pageSchedules;

			private Guid _slotId;
			private DateTime _startTime;

			///<summary>Gets or sets the PageGroupScheduleId.</summary>
			public Guid PageGroupScheduleId
			{
				get { return _pageGroupScheduleId; }
				set { SetProperty(ref _pageGroupScheduleId, value); }
			}

			///<summary>Gets or sets the StartTime.</summary>
			public DateTime StartTime
			{
				get { return _startTime; }
				set { SetProperty(ref _startTime, value); }
			}

			///<summary>Gets or sets the Duration.</summary>
			public TimeSpan Duration
			{
				get { return _duration; }
				set { SetProperty(ref _duration, value); }
			}

			public Guid SlotId
			{
				get { return _slotId; }
				set { SetProperty(ref _slotId, value); }
			}


			///<summary>Gets or sets the PageSchedules.</summary>
			public PageSchedule[] PageSchedules
			{
				get { return _pageSchedules; }
				set { SetProperty(ref _pageSchedules, value); }
			}

			///<summary>Gets or sets the Pages.</summary>
			public Page[] Pages
			{
				get { return _pages; }
				set { SetProperty(ref _pages, value); }
			}

			public string PlayTimeStartString
			{
				get
				{
					var startTimeString = StartTime.TimeOfDay.ToString(@"hh\:mm\:ss");
					return $"{startTimeString}";
				}
			}

			public int NumberOfLogicalPages
			{
				get { return Pages.Where(whe => whe.ParentPageId == null).Count(); }
			}
		}
	}
}