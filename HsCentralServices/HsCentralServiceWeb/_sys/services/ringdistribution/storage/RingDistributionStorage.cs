// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using System;
using System.IO;
using System.Web;






// ReSharper disable InconsistentNaming

namespace HsCentralServiceWeb._sys.services.ringdistribution.storage
{
	public class RingDistributionStorage
	{
		private DirectoryInfo _directory;
		private RingDistributionStoragePaths _paths;
		private RingDistributionStorageEntitys _ring;

		public DirectoryInfo Directory => _directory ?? (_directory = new DirectoryInfo(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/"), "RingDistribution")));
		public RingDistributionStoragePaths Paths => _paths ?? (_paths = new RingDistributionStoragePaths());
		public RingDistributionStorageEntitys Ring => _ring ?? (_ring = new RingDistributionStorageEntitys());
	}



}