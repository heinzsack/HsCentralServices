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

		protected override string GetRelativeFilePath(IDownloadAble item)
			{
			var fileGuid = item.IFileIdentifier.ToString().ToUpper();
			return Path.Combine(fileGuid.Substring(0, 2), $"{fileGuid}.{item.IExtension}");
			}
		}
	}
