// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.remote.clientIdentification;
using CsWpfBase.Global.remote.clientSide.fileRepository.components;
using CsWpfBase.Utilitys;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.ringValidationArgs;
using RingPlayer24._dbs.hsserver.ringplayerdb.dataset;
using RingPlayer24._dbs.hsserver.ringplayerdb.rows;






namespace RingPlayer24._sys.services.ringPlayerService.ringDownloader
{
	public class RingDownloader
	{
		private readonly object _syncLock = new object();
		private bool _isCanceled = false;
		private List<WebClient> ActiveDownloads { get; set; } = new List<WebClient>();
		private Ring CurrentRing { get; set; }
		private FileDownloadTask FileDownload { get; set; }

		public RingDownloader(NewRingAvailableArgs arguments)
		{
			Arguments = arguments;
		}

		public ProcessLock IsFileDownloading { get; } = new ProcessLock();
		public ProcessLock IsRingDownloading { get; } = new ProcessLock();
		public ProcessLock IsRingValidating { get; } = new ProcessLock();

		public NewRingAvailableArgs Arguments { get; set; }

		public Task<Ring> Start()
		{
			var t = new Task<Ring>(() =>
			{
				DownloadRing();
				DownloadMissingFiles();
				ApproveNewRing();

				if (_isCanceled)
					throw new OperationCanceledException();

				return CurrentRing;
			}, TaskCreationOptions.LongRunning);
			t.Start(TaskScheduler.Default);
			return t;
		}

		public void Stop()
		{
			lock (_syncLock)
			{
				if (_isCanceled)
					return;

				_isCanceled = true;
				foreach (var activeDownload in ActiveDownloads)
				{
					activeDownload.CancelAsync();
				}
				FileDownload?.Cancle();
			}
		}

		private void DownloadRing()
		{
			using (IsRingDownloading.Activate())
			{
				Sys.Services.RingPlayerService.SendInstanceArgs();
				var tempFilePath = new FileInfo(Path.Combine(Sys.Storage.DownloadDirectory.FullName, Arguments.RingId + ".dataset"));
				var task = DownloadFile(Arguments.DownloadUrl, tempFilePath);
				if (task != null && task.Status == TaskStatus.RanToCompletion)
					Sys.Storage.Ring.Add(Arguments.RingId, tempFilePath);

				tempFilePath.Delete();

				if (task == null)
					throw new OperationCanceledException();
				if (task.Exception != null)
					throw task.Exception;
				if (task.Status != TaskStatus.RanToCompletion)
					throw new OperationCanceledException();

				CurrentRing = Sys.Storage.Ring.GetFile_And_SetUsed(Arguments.RingId).LoadAs_Object_From_SerializedBinary<RingPlayerDb>().Rings[0];
			}
		}

		private void DownloadMissingFiles()
		{
			using (IsFileDownloading.Activate())
			{
				Sys.Services.RingPlayerService.SendInstanceArgs();
				FileDownload = CurrentRing.DataSet.DownloadDependencys();
				if (FileDownload == null)
					return;

				FileDownload.Wait();
			}
		}


		private void ApproveNewRing()
		{
			if (_isCanceled)
				return;
			using (IsRingValidating.Activate())
			{
				Sys.Services.RingPlayerService.SendInstanceArgs();
				var resultArgs =
					Sys.ServerConnection.RingDistribution.RingValidation(new RingValidationArgs {RingId = Arguments.RingId})?.Result;
				if (resultArgs == null || !resultArgs.Valid)
					throw new InvalidOperationException("the ring is invalid and should not be played");
			}
		}

		private Task DownloadFile(string website, FileInfo targetFile)
		{
			Task task;
			WebClient wc;
			lock (_syncLock)
			{
				if (_isCanceled)
					return null;
				targetFile.CreateDirectory_IfNotExists();
				targetFile.DeleteFile_IfExists();
				wc = new WebClient();
				CsClientIdentification.Transmission.Set(wc);
				ActiveDownloads.Add(wc);
				task = wc.DownloadFileTaskAsync(website, targetFile.FullName);
			}
			try
			{
				Task.WaitAll(task);
			}
			catch (Exception exc)
			{

			}
			lock (_syncLock)
			{
				ActiveDownloads.Remove(wc);
			}
			return task;

		}
	}
}