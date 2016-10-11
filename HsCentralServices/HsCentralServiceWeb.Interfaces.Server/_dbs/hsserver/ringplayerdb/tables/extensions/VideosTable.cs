using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.tables
	{
	partial class VideosTable
		{
		public event VideoFileRequestedDelegete FileRequested;

		public virtual string OnFileRequested(Video video)
			{
			return FileRequested?.Invoke(video);
			}
		}

	public delegate string VideoFileRequestedDelegete(Video video);
	}