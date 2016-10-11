using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management.args;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.dataset;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;
using PlayerControls.Interfaces;
using RingPlayer24._sys.services.ringPlayerService.ringDownloader;

namespace RingPlayer24._sys.services.ringPlayerService
	{
	public class RingPlayerService : Base
		{
		private RingDownloader _activeRingDownloader;
		private RingMetaData _currentPlayingRing;
		private IPageSchedule[] _bindableSchedules;


		public IPageSchedule[] BindableSchedules
			{
			get { return _bindableSchedules; }
			set { SetProperty(ref _bindableSchedules, value); }
			}
		///<summary>Gets the current playing ring.</summary>
		public RingMetaData CurrentPlayingRing
			{
			get { return _currentPlayingRing; }
			set
				{
				if (_currentPlayingRing == value)
					return;
				Sys.Storage.PlayingRingDirectory.Create_If_NotExists();
				Sys.Storage.PlayingRingDirectory.GetFiles().ForEach(fi => fi.Delete());
				if (value == null)
					{
					_currentPlayingRing = null;
					OnPropertyChanged();
					SendInstanceArgs();
					return;
					}
				_currentPlayingRing = value;
				_currentPlayingRing.DataSet.SetHasBeenLoaded();
				FileInfo targetFilePath = Sys.Storage.CreatePlayingRingFilePath(value);
				FileInfo sourceFile = Sys.Storage.Ring.GetFile_And_SetUsed(value.Id);
				sourceFile.CopyTo(targetFilePath.FullName, true);

//TODO HS Inserted Zero Propagation in both FileRequested callbacks

				_currentPlayingRing.DataSet.Images.FileRequested += image =>
					{
					FileInfo imagePath = Sys.Storage.Lru.Image.GetFile_And_SetUsed(image);
					return imagePath.FullName;
					};
				_currentPlayingRing.DataSet.Videos.FileRequested += video =>
					{
					FileInfo videoPath = Sys.Storage.Lru.Video.GetFile_And_SetUsed(video);
					return videoPath.FullName;
					};
				BindableSchedules = _currentPlayingRing.PageSchedules.OrderBy(x => x.StartTime).OfType<IPageSchedule>().ToArray();
				OnPropertyChanged();
				SendInstanceArgs();
				}
			}

		public void LoadCurrentPlayingDataSetFromFile()
			{
			FileInfo playingRingFile = Sys.Storage.GetPlayingRingFilePath();
			if (playingRingFile == null || !playingRingFile.Exists)
				return;

			try
				{
				RingPlayerDb dataSet = playingRingFile.LoadAs_Object_From_SerializedBinary<RingPlayerDb>();
				CurrentPlayingRing = dataSet.RingMetaDatas[0];
				}
			catch (Exception)
				{

				}
			}

		///<summary>Gets or sets the ActiveRingDownloader.</summary>
		public RingDownloader ActiveRingDownloader
			{
			get { return _activeRingDownloader; }
			private set { SetProperty(ref _activeRingDownloader, value); }
			}

		public event Action<RingMetaData> RingDownloadCompleted;

		public void SendInstanceArgs()
			{
			PlayerStates state = PlayerStates.None;
			if (CurrentPlayingRing != null)
				state = PlayerStates.Playing;

			if (ActiveRingDownloader != null)
				{
				if (ActiveRingDownloader.IsRingDownloading.Active)
					state = state | PlayerStates.DownloadingRing;
				if (ActiveRingDownloader.IsFileDownloading.Active)
					state = state | PlayerStates.DownloadingFiles;
				if (ActiveRingDownloader.IsRingValidating.Active)
					state = state | PlayerStates.RingValidation;
				}

			Sys.ServerConnection.RingDistribution.UpdatePlayerData(new PlayerDataArgs()
				{
				PlayingRingId = CurrentPlayingRing?.Id,
				DownloadingRingId = ActiveRingDownloader?.Arguments.RingId ?? 0,
				State = state,
				});
			}

		public void DownloadRing(NewRingAvailableArgs args)
			{
			CancleRingDownload();

			RingDownloader activeRingDownloader = new RingDownloader(args);
			ActiveRingDownloader = activeRingDownloader;
			Task<RingMetaData> downloadTask = ActiveRingDownloader.Start();
			downloadTask.ContinueWith(t =>
				{
				if (ActiveRingDownloader == activeRingDownloader)
					ActiveRingDownloader = null;
				SendInstanceArgs();
				if (t.IsFaulted)
					{
					Sys.ServerConnection.Management.Log(LogSeverity.FatalError,
						$"Fehler beim herunterladen des Rings von {Environment.MachineName}",
						$"RingId = {args.RingId}, DownloadUrl = {args.DownloadUrl}\r\n" +
						$"ImageUrl = {args.ImageDownloadUrl}, VideoUrl = {args.VideoDownloadUrl}\r\n" +
						t.Exception?.MostInner()?.ToString());

					if (t.Exception?.MostInner() is OperationCanceledException)
						return; //canceled
						return; //TODO implement logic if failed restart or anything
					}
				RingDownloadCompleted?.Invoke(t.Result);
				}, TaskScheduler.FromCurrentSynchronizationContext());
			}

		public void CancleRingDownload()
			{
			if (ActiveRingDownloader == null)
				return;
			Sys.ServerConnection.Management.Log(LogSeverity.FatalError,
						$"in CancleRingDownload {Environment.MachineName}",
						$"ein alter Downloader war aktiv");

			ActiveRingDownloader.Stop();
			ActiveRingDownloader = null;
			}
		}
	}