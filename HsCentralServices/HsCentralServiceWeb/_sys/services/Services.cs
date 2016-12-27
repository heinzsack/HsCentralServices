using System;
using HsCentralServiceWeb._sys.services.dbproxy;
using HsCentralServiceWeb._sys.services.fileManagement;
using HsCentralServiceWeb._sys.services.ringdistribution;






namespace HsCentralServiceWeb._sys.services
{
	public class Services
	{
		private DbProxyService _dbProxyService;
		private RingDistribution _ringDistribution;
		private FileManagementService _fileManagementService;


		public RingDistribution RingDistribution => _ringDistribution ?? (_ringDistribution = new RingDistribution());
		public DbProxyService DbProxyService => _dbProxyService ?? (_dbProxyService = new DbProxyService());
		public FileManagementService FileRepo => _fileManagementService ?? (_fileManagementService = new FileManagementService());
	}
}