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
						PageGroup = orderedPageSchedules.First().Page.PageGroup,
						SlotId = orderedPageSchedules.First().SlotId,
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





















		private string _sourceFileName;
		private DateTime _sourceCreationDateTime;
// setting from outside because the Data DataBase is not referended here
		public String SourceFileName
			{
			get { return _sourceFileName; }
			set { _sourceFileName = value; }
			}

		public DateTime SourceCreationDateTime
			{
			get { return _sourceCreationDateTime; }
			set { _sourceCreationDateTime = value; }
			}

		public int NumberOfBeitraege { get; set; }
		public int NumberOfSeiten { get; set; }


		//[DependsOn(nameof(StatusNumber))]
		//public RingMetaDataStates Status
		//	{
		//	get { return EnumWrapper.Get(StatusNumber, RingMetaDataStates.Unknown); }
		//	set { EnumWrapper.Set(() => StatusNumber = (int) value); }
		//	}
		}

	public enum RingMetaDataStates
		{
		Unknown = 0,
		Created,
		Pending,
		Transfered,
		Playing,
		Deleted
		}
	public class ScheduledPageGroup : Base
		{
		private TimeSpan _duration;
		private PageGroup _pageGroup;
		private Guid _pageGroupScheduleId;
		private Page[] _pages;
		private PageSchedule[] _pageSchedules;
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

		private Guid _slotId;

		public Guid SlotId
			{
			get { return _slotId; }
			set { SetProperty(ref _slotId, value); }
			}


		///<summary>Gets or sets the PageGroup.</summary>
		public PageGroup PageGroup
			{
			get { return _pageGroup; }
			set { SetProperty(ref _pageGroup, value); }
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

		public String PlayTimeStartString
			{
			get
				{
				String startTimeString = StartTime.TimeOfDay.ToString(@"hh\:mm\:ss");
				return $"{startTimeString}";
				}
			}

		public String PlayDurationString
			{
			get
				{
				if (PageGroup.DurationInSeconds < 60)
					{
					String secondsString = TimeSpan.FromSeconds((double)PageGroup.DurationInSeconds).ToString("ss");
					return $"{secondsString} Sekunden";
					}
				if (PageGroup.DurationInSeconds < 3600)
					{
					String minutenString = TimeSpan.FromSeconds((double)PageGroup.DurationInSeconds).ToString(@"mm\:ss");
					return $"{minutenString} Minuten";
					}
				String hourString = TimeSpan.FromSeconds((double)PageGroup.DurationInSeconds).ToString(@"h\:mm\:ss");
				return $"{hourString} Stunden";
				}
			}
		}
	
	}
