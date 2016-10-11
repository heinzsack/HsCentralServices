// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-18</date>

using System.IO;
using CsWpfBase.Utilitys.dataStore;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace RingPlayer24._sys.storage.LruStorages
{
	public class VideoStore : LruFileStore<Video>
	{
		public VideoStore(DirectoryInfo targetDirectory, ulong maximumCapacity) : base(targetDirectory, maximumCapacity)
		{
		}


		#region Overrides/Interfaces
		protected override string GetRelativeFilePath(Video item)
		{
			string s = item.FileIdentifier.ToString().ToUpper();
			return Path.Combine(s.Substring(0, 2), $"{s}.{item.Extension}");
		}
		#endregion
	}
}