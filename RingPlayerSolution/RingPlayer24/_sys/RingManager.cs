// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using PlayerControls.Interfaces;
using RingPlayer24._dbs.hsserver.ringplayerdb.dataset;
using RingPlayer24._dbs.hsserver.ringplayerdb.rows;






namespace RingPlayer24._sys
{
	/// <summary>The <see cref="RingManager" /> updates loads and do all the stuff which is necessary to gather new rings and display them.</summary>
	[Serializable]
	public class RingManager : Base
	{
		private static RingManager _instance;
		private static readonly object SingletonLock = new object();

		/// <summary>Returns the singleton instance</summary>
		public static RingManager I
		{
			get
			{
				if (_instance != null)
					return _instance; //Advanced first check to improve performance (no lock needed).
				lock (SingletonLock)
				{
					if (_instance == null)
					{
						_instance = CsGlobal.Storage.Private.Handle(nameof(RingManager), () => new RingManager());
						_instance.Init();
					}
					return _instance;
				}
			}
		}

		[field: NonSerialized] private IPageSchedule[] _pageSchedules;
		[field: NonSerialized] private Ring _playingRing;
		private Guid? _playingRingId;

		private RingManager()
		{
		}

		///<summary>The ring which is currently playing.</summary>
		public Ring PlayingRing
		{
			get { return _playingRing; }
			set
			{
				if (!SetProperty(ref _playingRing, value)) return;
				_playingRingId = _playingRing?.Id;
				PageSchedules = _playingRing?.RingEntries.OrderBy(x => x.StartTime).OfType<IPageSchedule>().ToArray();
			}
		}

		///<summary>The page schedules for 24h which should be played.</summary>
		public IPageSchedule[] PageSchedules
		{
			get { return _pageSchedules; }
			private set { SetProperty(ref _pageSchedules, value); }
		}

		private void Init()
		{
			if (_playingRingId != null)
				PlayingRing = LoadRingFromFile(_playingRingId.Value);
			CsGlobal.Remote.EventHub.Connected += () =>
			{
				CsGlobal.Remote.EventHub.Subscribe<RingUpdateArgs>("RingUpdate", OnRingUpdate);
			};
		}

		/// <summary>Will be invoked by some remote application which calls the <see cref="CsGlobal.Remote" />.Event.Raise() method.</summary>
		/// <param name="eventData">data which will be passed by the invokator</param>
		private void OnRingUpdate(RingUpdateArgs eventData)
		{
			var asyncTask = new Task(() => { DoRingUpdateSync(eventData); }, TaskCreationOptions.LongRunning);
			asyncTask.Start(TaskScheduler.Default);
		}

		/// <summary>Do a complete ring update in the current active thread.</summary>
		/// <param name="args">The ring which should be downloaded.</param>
		private void DoRingUpdateSync(RingUpdateArgs args)
		{
			var ring = DownloadRing(args);
			DownloadRingDependencys(ring);
			Application.Current.Dispatcher.BeginInvoke(new Action(() => { PlayingRing = ring; }));
		}

		/// <summary>Downloads the ring file to the local disk.</summary>
		private Ring DownloadRing(RingUpdateArgs args)
		{
			var repoInfo = CsGlobal.Remote.FileRepository.FindOrDownload(args.RingFileId);
			if (repoInfo == null)
				throw new FileNotFoundException($"The ring file with the id [{args.RingFileId}] does not exist.");

			return LoadRingFromFile(repoInfo.LocalCachedFile);
		}

		/// <summary>Downloads all missing videos and images to the local disk.</summary>
		private void DownloadRingDependencys(Ring ring)
		{
			ring.DataSet.DownloadDependencys().Wait();
		}

		private Ring LoadRingFromFile(Guid fileId)
		{
			return LoadRingFromFile(CsGlobal.Remote.FileRepository.FindOrDownload(fileId).LocalCachedFile);
		}

		private Ring LoadRingFromFile(FileInfo file)
		{
			var nativeDataSet = file.LoadAs_Object_From_SerializedBinary<DataSet>();
			var db = new RingPlayerDb();
			db.LoadFrom_Native(nativeDataSet);
			db.SetHasBeenLoaded();
			return db.Rings[0];
		}
	}
}