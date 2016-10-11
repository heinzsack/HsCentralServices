using System.IO;
using CsWpfBase.Utilitys.dataStore;

namespace RingPlayer24._sys.storage.LruStorages
{
	public class RingStore : LruFileStore<int>
	{
		public string Extension { get; set; } = ".Ring24";
		public RingStore(DirectoryInfo targetDirectory, ulong maximumCapacity) : base(targetDirectory, maximumCapacity)
		{
		}

		protected override string GetRelativeFilePath(int item)
		{
			return $"{item}{Extension}";
		}
	}
}