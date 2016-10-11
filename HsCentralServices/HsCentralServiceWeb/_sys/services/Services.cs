using System;
using HsCentralServiceWeb._sys.services.dbproxy;
using HsCentralServiceWeb._sys.services.ringdistribution;






namespace HsCentralServiceWeb._sys.services
{
	public class Services
	{
		private DbProxy _dbProxy;
		private RingDistribution _ringDistribution;


		public RingDistribution RingDistribution => _ringDistribution ?? (_ringDistribution = new RingDistribution());
		public DbProxy DbProxy => _dbProxy ?? (_dbProxy = new DbProxy());
	}
}