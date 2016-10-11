// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using System.Linq;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using PlayerControls.Interfaces;
using PlayerControls.Storage.Utils;






namespace PlayerControls.Storage
{
	[Serializable]
	public class LruStorage : Base
	{
		private static readonly object ConcurrencyLock = new object();

		public static LruStorage Instance { get; private set; }

		public static void Install(ulong capacity)
		{
			lock (ConcurrencyLock)
			{
				if (Instance != null)
					return;
				Instance = CsGlobal.Storage.Private.Handle($"{nameof(LruStorage)}",
										() => new LruStorage(capacity));
			}
		}

		private DirectoryInfo _downloadDirectory;
		private ulong _imageCapacity;

		[field: NonSerialized] private DirectoryInfo _imagesFoler;
		[field: NonSerialized] private StoreForDownloadables _imageStore;
		private DirectoryInfo _lruDirectory;
		private ulong _videoCapacity;
		[field: NonSerialized] private DirectoryInfo _videosFolder;
		[field: NonSerialized] private StoreForDownloadables _videoStore;
		private ulong ImageCapacity
		{
			get { return _imageCapacity; }
			set { SetProperty(ref _imageCapacity, value); }
		}

		private ulong VideoCapacity
		{
			get { return _videoCapacity; }
			set { SetProperty(ref _videoCapacity, value); }
		}

		private DirectoryInfo ImagesFolder => _imagesFoler ?? (_imagesFoler = new DirectoryInfo(Path.Combine(LruDirectory.FullName, "1 - Images")));
		private DirectoryInfo VideosFolder => _videosFolder ?? (_videosFolder = new DirectoryInfo(Path.Combine(LruDirectory.FullName, "2 - Videos")));

		private LruStorage(ulong capacity)
		{
			var logicalDiskWithMaximumFreeSpace = CsGlobal.Computer.DiskDrive
														.Devices.SelectMany(diskDrive => diskDrive.Partitions)
														.SelectMany(partition => partition.LogicalDisks)
														.MaxObject(logicalDisk => logicalDisk.FreeSpace);

			if (logicalDiskWithMaximumFreeSpace.FreeSpace < capacity)
			{
				throw new Exception(
					$"Dieser Computer verfügt nicht über\r\n" +
					$"genug freien Speicher. Schaffen Sie auf\r\n" +
					$"einer Ihrer Festplatten zumindest {capacity.ToByteSizeString()}.");
			}
			ImageCapacity = (ulong) (capacity*0.1);
			VideoCapacity = capacity - ImageCapacity;
			LruDirectory = new DirectoryInfo(Path.Combine(logicalDiskWithMaximumFreeSpace.DeviceId +
														"\\", "WpMedia", "LruStorage", "RingPlayer"));

		}


		public DirectoryInfo LruDirectory
		{
			get { return _lruDirectory; }
			set { SetProperty(ref _lruDirectory, value); }
		}


		public DirectoryInfo DownloadsFolder
			=> _downloadDirectory ?? (_downloadDirectory = new DirectoryInfo(Path.Combine
					(LruDirectory.FullName, "Z - Downloads")));


		public StoreForDownloadables Image => _imageStore ?? (_imageStore= new StoreForDownloadables(ImagesFolder, ImageCapacity));
		public StoreForDownloadables Video => _videoStore ?? (_videoStore= new StoreForDownloadables(VideosFolder, VideoCapacity));

		public DependencyDownloader GetFileDownloader(IDownloadAble[] images,IDownloadAble[] videos, IContainDownloadInformations downloadInformations)
		{
			return new DependencyDownloader(images, videos, downloadInformations);
		}
	}
}