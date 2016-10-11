// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.transmission.clientIdentification;
using CsWpfBase.Utilitys;
using PlayerControls.Interfaces;






namespace PlayerControls.Storage.Utils
{
	public class DependencyDownloader
	{
		private readonly object _syncLock = new object();
		private bool _isCanceled = false;
		private List<WebClient> ActiveDownloads { get; set; } = new List<WebClient>();

		public DependencyDownloader(IDownloadAble[] image, IDownloadAble[] videos, IContainDownloadInformations downloadInformations)
		{
			MissingImages = image;
			MissingVideos = videos;
			DownloadInformations = downloadInformations;
		}

		public ProcessLock IsImageDownloading { get; } = new ProcessLock();
		public ProcessLock IsVideoDownloading { get; } = new ProcessLock();

		public IDownloadAble[] MissingImages { get; set; }
		public IDownloadAble[] MissingVideos { get; set; }
		public IContainDownloadInformations DownloadInformations { get; set; }

		public Task Start()
		{
			var t = new Task(() =>
			{
				DownloadImages();
				DownloadVideos();

				if (_isCanceled)
					throw new OperationCanceledException();
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

				foreach (var webClient in ActiveDownloads)
				{
					webClient.CancelAsync();
					webClient.Dispose();
				}
			}
		}



		private void DownloadImages()
		{
			if (MissingImages.Length == 0)
				return;
			using (IsImageDownloading.Activate())
			{
				foreach (var missingImage in MissingImages)
				{
					DownloadImage(missingImage);
					if (_isCanceled)
						return;
				}
			}
		}

		private void DownloadVideos()
		{
			if (MissingVideos.Length == 0)
				return;
			using (IsVideoDownloading.Activate())
			{
				foreach (var missingVideo in MissingVideos)
				{
					DownloadVideo(missingVideo);
					if (_isCanceled)
						return;
				}
			}
		}

		private void DownloadImage(IDownloadAble image)
		{
			DownloadFile(image, true);
		}

		private void DownloadVideo(IDownloadAble video)
		{
			DownloadFile(video, false);
		}

		private void DownloadFile(IDownloadAble element, bool image)
		{
			var tempFilePath = new FileInfo(Path.Combine(LruStorage.Instance.DownloadsFolder.FullName, $"{element.IFileIdentifier}.{element.IExtension}"));

			string url;
			StoreForDownloadables store;
			if (image)
			{
				store = LruStorage.Instance.Image;
				url = DownloadInformations.ImageDownloadUrl;
			}
			else
			{
				store = LruStorage.Instance.Video;
				url = DownloadInformations.VideoDownloadUrl;
			}
			var task = DownloadFile(url.Replace(DownloadInformations.ReplacementString, element.IFileIdentifier.ToString()), tempFilePath);

			if ((task != null) && (task.Status == TaskStatus.RanToCompletion))
				store.Add(element, tempFilePath);

			tempFilePath.DeleteFile_IfExists();

			if (task == null)
				throw new OperationCanceledException();
			if (task.Exception != null)
				throw task.Exception;
			if (task.Status != TaskStatus.RanToCompletion)
				throw new OperationCanceledException();
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