using System.IO;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.tables
	{
	partial class ImagesTable
		{
		public event ImageFileRequestedDelegete FileRequested;
		public event ImageStreamRequestedDelegete StreamRequested;

		public virtual string OnFileRequested(Image image)
			{
			return FileRequested?.Invoke(image);
			}
		public virtual Stream OnStreamRequested(Image image)
			{
			if (StreamRequested == null && FileRequested == null)
				return null;

			if (StreamRequested != null)
				{
				return StreamRequested(image);
				}
			return File.Open(FileRequested?.Invoke(image), FileMode.Open);
			}
		}

	public delegate string ImageFileRequestedDelegete(Image image);
	public delegate Stream ImageStreamRequestedDelegete(Image image);
	}