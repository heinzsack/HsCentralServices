using System.IO;
using System.Linq;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;
using PlayerControls.Storage;
using RingPlayer24._sys.storage.LruStorages;

namespace RingPlayer24._sys.storage
{
	public class Storage
	{
		private RingStore _ring;
		private DirectoryInfo _playingRingDirectory;

	public Storage()
		{
		LruStorage.Install(20*1024*1024*(ulong)1024);
		}

		public DirectoryInfo PlayingRingDirectory => 
			_playingRingDirectory ?? (_playingRingDirectory = new DirectoryInfo
			(Path.Combine(Lru.LruDirectory.FullName, "#Playing")));


		public LruStorage Lru => LruStorage.Instance;
		public RingStore Ring => _ring ?? (_ring = new RingStore(new DirectoryInfo
			(Path.Combine(Lru.LruDirectory.FullName, "0 - Ringe")), 52428800)); // 50 MB
		

		public FileInfo GetPlayingRingFilePath()
			{
			if (!PlayingRingDirectory.Exists)
				return null;
			return PlayingRingDirectory.GetFiles($"*{Ring.Extension}").FirstOrDefault();
		}
		public FileInfo CreatePlayingRingFilePath(RingMetaData ring)
		{
			return new FileInfo(Path.Combine(PlayingRingDirectory.FullName, $"{ring.Id}{Ring.Extension}"));
		}
	}
}
