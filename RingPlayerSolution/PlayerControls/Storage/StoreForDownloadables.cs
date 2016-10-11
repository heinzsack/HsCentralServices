// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using CsWpfBase.Utilitys.dataStore;
using PlayerControls.Interfaces;






namespace PlayerControls.Storage
{
	public class StoreForDownloadables : LruFileStore<IDownloadAble>
	{

		public StoreForDownloadables(DirectoryInfo targetDirectory, ulong maximumCapacity)
			: base(targetDirectory, maximumCapacity)
		{
		}


		#region Overrides/Interfaces
		protected override string GetRelativeFilePath(IDownloadAble item)
		{
			var fileGuid = item.IFileIdentifier.ToString().ToUpper();
			return Path.Combine(fileGuid.Substring(0, 2), $"{fileGuid}.{item.IExtension}");
		}
		#endregion
	}
}