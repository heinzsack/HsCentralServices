using System.IO;
using CsWpfBase.Utilitys.dataStore;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace RingPlayer24._sys.storage.LruStorages
{
	public class ImageStore : LruFileStore<Image>
	{
		public ImageStore(DirectoryInfo targetDirectory, ulong maximumCapacity) : base(targetDirectory, maximumCapacity)
		{
		}

		protected override string GetRelativeFilePath(Image img)
		{
			string s = img.FileIdentifier.ToString().ToUpper();
			return Path.Combine(s.Substring(0, 2), $"{s}.{img.Extension}");
		}
	}



}
