// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.IO;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using RingPlayer24._dbs.hsserver.ringplayerdb.rows;
using RingPlayer24._sys.storage.LruStorages;






namespace RingPlayer24._sys.storage
{
	public class Storage
	{
		private DirectoryInfo _downloadDirectory;
		private DirectoryInfo _playingRingDirectory;
		private RingStore _ring;
		private DirectoryInfo RootDirectory { get; }

		public Storage()
		{
			RootDirectory = CsGlobal.Storage.HiddenDataDirectory.Combine("WpMedia", "RingPlayer24");
		}

		public DirectoryInfo DownloadDirectory => _downloadDirectory ?? (_downloadDirectory = RootDirectory.Combine("downloading"));
		public DirectoryInfo PlayingRingDirectory => _playingRingDirectory ?? (_playingRingDirectory = RootDirectory.Combine("#Playing"));
		public RingStore Ring => _ring ?? (_ring = new RingStore(RootDirectory.Combine("#Archive"), 209715200)); // 200 MB


		public FileInfo GetPlayingRingFilePath()
		{
			if (!PlayingRingDirectory.Exists)
				return null;
			return PlayingRingDirectory.GetFiles($"*{Ring.Extension}").FirstOrDefault();
		}

		public FileInfo CreatePlayingRingFilePath(Ring ring)
		{
			return new FileInfo(Path.Combine(PlayingRingDirectory.FullName, $"{ring.Id}{Ring.Extension}"));
		}
	}
}