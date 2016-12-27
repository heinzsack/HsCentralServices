// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-20</date>

using System;
using System.Linq;
using System.Net;
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
		private IPageSchedule[] _bindableSchedules;
		private RingMetaData _currentPlayingRing;


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
				var targetFilePath = Sys.Storage.CreatePlayingRingFilePath(value);
				var sourceFile = Sys.Storage.Ring.GetFile_And_SetUsed(value.Id);
				sourceFile.CopyTo(targetFilePath.FullName, true);

				//TODO HS Inserted Zero Propagation in both FileRequested callbacks

				_currentPlayingRing.DataSet.Images.FileRequested += image =>
				{
					var imagePath = Sys.Storage.Lru.Image.GetFile_And_SetUsed(image);
					return imagePath.FullName;
				};
				_currentPlayingRing.DataSet.Videos.FileRequested += video =>
				{
					var videoPath = Sys.Storage.Lru.Video.GetFile_And_SetUsed(video);
					return videoPath.FullName;
				};
				BindableSchedules = _currentPlayingRing.PageSchedules.OrderBy(x => x.StartTime).OfType<IPageSchedule>().ToArray();
				OnPropertyChanged();
				SendInstanceArgs();
			}
		}

		///<summary>Gets or sets the ActiveRingDownloader.</summary>
		public RingDownloader ActiveRingDownloader
		{
			get { return _activeRingDownloader; }
			private set { SetProperty(ref _activeRingDownloader, value); }
		}

		public event Action<RingMetaData> RingDownloadCompleted;

		public void LoadCurrentPlayingDataSetFromFile()
		{
			var playingRingFile = Sys.Storage.GetPlayingRingFilePath();
			if (playingRingFile == null || !playingRingFile.Exists)
				return;

			try
			{
				var dataSet = playingRingFile.LoadAs_Object_From_SerializedBinary<RingPlayerDb>();
				CurrentPlayingRing = dataSet.RingMetaDatas[0];
			}
			catch (Exception Excp)
			{
				throw new Exception($"Fehler bei LoadCurrentPlayingDataSetFromFile:\r\n{Excp}");
			}
		}

		public void SendInstanceArgs()
		{
			var state = PlayerStates.None;
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

			var activeRingDownloader = new RingDownloader(args);
			ActiveRingDownloader = activeRingDownloader;
			var downloadTask = ActiveRingDownloader.Start();
			downloadTask.ContinueWith(t =>
			{
				if (ActiveRingDownloader == activeRingDownloader)
					ActiveRingDownloader = null;
				SendInstanceArgs();
				if (t.IsFaulted)
				{
					var errorMsg = "";
					try
					{
						if (t.Exception?.MostInner() is WebException)
						{
							var exception = (WebException) t.Exception?.MostInner();
							errorMsg = exception.Response.GetResponseStream().SafeRead(exception.Response.ContentLength).ConvertTo_Utf8String();
						}
					}
					catch (Exception)
					{
						errorMsg = t.Exception?.MostInner()?.ToString();
					}


					Sys.ServerConnection.Management.Log(LogSeverity.FatalError, "Ringdownload FEHLGESCHLAGEN", $"Fehler beim herunterladen des Rings {args} :: " +
																												$"\r\n\r\n" +
																												$"FEHLER:" +
																												$"\r\n" +
																												$"{errorMsg}");

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

			ActiveRingDownloader.Stop();
			ActiveRingDownloader = null;
		}
	}
}