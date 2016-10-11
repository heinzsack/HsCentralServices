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
		private static LruStorage _instance;
		private static readonly object ConcurrencyLock = new object();

		public static void Install(ulong capacity)
			{
			lock (ConcurrencyLock)
				{
				if (_instance != null)
					return;
				_instance = CsGlobal.Storage.Private.Handle($"{nameof(LruStorage)}", 
					() => new LruStorage(capacity));
				}
			}

		public static LruStorage Instance => _instance;

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
			ImageCapacity = (ulong)(capacity * 0.1);
			VideoCapacity = (capacity - ImageCapacity);
			LruDirectory = new DirectoryInfo(Path.Combine(logicalDiskWithMaximumFreeSpace.DeviceId + 
				"\\", "WpMedia", "LruStorage", "RingPlayer"));

			}

		[field: NonSerialized] private DirectoryInfo _imagesFoler;
		[field: NonSerialized] private DirectoryInfo _videosFolder;
		private ulong _imageCapacity;
		private ulong _videoCapacity;
		private DirectoryInfo _lruDirectory;
		[field: NonSerialized]
		private StoreForDownloadables _imageStore;
		[field: NonSerialized]
		private StoreForDownloadables _videoStore;

		private DirectoryInfo _downloadDirectory;


		public DirectoryInfo LruDirectory
			{
			get { return _lruDirectory; }
			set { SetProperty(ref _lruDirectory, value); }
			}
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

		private DirectoryInfo ImagesFolder
			=> _imagesFoler ?? (_imagesFoler = new DirectoryInfo(Path.Combine
				(LruDirectory.FullName, "1 - Images")));


		private DirectoryInfo VideosFolder
			=> _videosFolder ?? (_videosFolder = new DirectoryInfo(Path.Combine
				(LruDirectory.FullName, "2 - Videos")));


		public DirectoryInfo DownloadsFolder
			=> _downloadDirectory ?? (_downloadDirectory = new DirectoryInfo(Path.Combine
				(LruDirectory.FullName, "Z - Downloads")));


		public StoreForDownloadables Image => _imageStore ?? (_imageStore 
			= new StoreForDownloadables(ImagesFolder, ImageCapacity));
		public StoreForDownloadables Video => _videoStore ?? (_videoStore 
			= new StoreForDownloadables(VideosFolder, VideoCapacity));

		public DependencyDownloader GetFileDownloader(IDownloadAble[] images, 
			IDownloadAble[] videos, IContainDownloadInformations downloadInformations)
			{
			return new DependencyDownloader(images, videos, downloadInformations);
			}
		}
	}