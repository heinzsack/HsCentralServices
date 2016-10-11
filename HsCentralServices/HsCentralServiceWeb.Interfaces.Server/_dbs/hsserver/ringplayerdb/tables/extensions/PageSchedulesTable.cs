using System.Linq;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.tables
	{
	partial class PageSchedulesTable
		{
		public PageSchedule[] Get_all_Ordered => Collection.OrderBy(ord => ord.StartTime).ToArray();
		}
	}
