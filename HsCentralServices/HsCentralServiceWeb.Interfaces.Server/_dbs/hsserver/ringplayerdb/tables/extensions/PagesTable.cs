using System;
using System.Collections.Generic;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;

namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.tables
	{
	partial class PagesTable
		{
		private StaTaskScheduler _staTaskScheduler;

		internal StaTaskScheduler StaTaskScheduler
			{
			get
				{
				if (_staTaskScheduler != null)
					return _staTaskScheduler;
				_staTaskScheduler = new StaTaskScheduler(1);
				return _staTaskScheduler;
				}
			}

		public Page[] LoadAndFind_via_Ids(List<Guid> visualGuids)
			{
			if ((visualGuids == null)
				|| (visualGuids.Count == 0))
				return new Page[0];
			List<String> visualGuidStringList = new List<string>();
			foreach (Guid guid in visualGuids)
				{
				visualGuidStringList.Add($"{guid}");
				}
			String whereClauseForScreenGroups = " where Id = '" 
				+ String.Join("' or Id = '", visualGuidStringList) + "'";
			return DownloadRows($"select {DefaultSqlSelector} from " +
					$"{NativeName} {whereClauseForScreenGroups}");
			}


		}
	}
