using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.tables
	{
	partial class PageGroupsTable
		{
		public PageGroup[] Load_All()
			{
			HasBeenLoaded = true;
			return DownloadRows($"select {DefaultSqlSelector} from {NativeName}");
			}
		}
	}
