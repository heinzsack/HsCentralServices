// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-20</date>

using System;
using System.Security.Cryptography;
using CsWpfBase.Db.tools.configurationTable;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Utilitys;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables
{
	partial class WebConfigurationsTable
	{
		private ServiceFileRepository _serviceFileManagementService;
		private RemoteLogConfiguration _remoteLog;
		private RingDistributionConfiguration _ringDistribution;
		private SmtpConfiguration _smtp;
		private ServiceDbAccess _serviceDbAccess;


		#region Abstract
		internal abstract class SubConfiguration
		{

			public SubConfiguration(WebConfigurationsTable parent, string context)
			{
				Parent = parent;
				Context = context;
			}

			public WebConfigurationsTable Parent { get; }
			public string Context { get; }
		}
		#endregion


		internal RemoteLogConfiguration RemoteLog => _remoteLog ?? (_remoteLog = new RemoteLogConfiguration(this));
		internal RingDistributionConfiguration RingDistribution => _ringDistribution ?? (_ringDistribution = new RingDistributionConfiguration(this));
		internal SmtpConfiguration Smtp => _smtp ?? (_smtp = new SmtpConfiguration(this));
		internal ServiceFileRepository FileRepository => _serviceFileManagementService ?? (_serviceFileManagementService = new ServiceFileRepository(this));
		internal ServiceDbAccess DbAccess => _serviceDbAccess ?? (_serviceDbAccess = new ServiceDbAccess(this));



		internal class RemoteLogConfiguration : SubConfiguration
		{

			public RemoteLogConfiguration(WebConfigurationsTable parent) : base(parent, nameof(RemoteLog))
			{
			}

			public int CurrentCount
			{
				get { return Parent.GetConfigurationValue(() => Parent.DataSet.RemoteLogs.DownloadRowsCount(), Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int TotalCount
			{
				get { return Parent.GetConfigurationValue(() => Parent.DataSet.RemoteLogs.DownloadRowsCount(), Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int MaximumCount
			{
				get { return Parent.GetConfigurationValue(2000, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int BatchDeleteCount
			{
				get { return Parent.GetConfigurationValue(100, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}



		internal class RingDistributionConfiguration : SubConfiguration
		{

			public RingDistributionConfiguration(WebConfigurationsTable parent) : base(parent, nameof(RingDistribution))
			{
			}

			public int MaxStoredRingsPerComputer
			{
				get { return Parent.GetConfigurationValue(20, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}



		internal class ServiceFileRepository : SubConfiguration
		{
			public ServiceFileRepository(WebConfigurationsTable parent) : base(parent, nameof(ServiceFileRepository))
			{
			}

			public string StorageDirectory
			{
				get { return Parent.GetConfigurationValue(@"\\speicher\AData2\HsCentralServiceWeb", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}


		internal class ServiceDbAccess : SubConfiguration
		{
			public ServiceDbAccess(WebConfigurationsTable parent) : base(parent, nameof(ServiceDbAccess))
			{
			}

			public string PrivateKey
			{
				get
				{
					var value = Parent.GetConfigurationValue("", Context);
					if (value.IsNullOrEmpty())
					{
						RSACryptoServiceProvider key = new RSACryptoServiceProvider(1024);
						PublicKey = key.ToXmlString(false);
						value = PrivateKey = key.ToXmlString(true);
					}
					return value;
				}
				set { Parent.SetConfigurationValue(value, Context); }
			}


			public string PublicKey
			{
				get
				{
					var value = Parent.GetConfigurationValue("", Context);
					if(value.IsNullOrEmpty())
					{
						RSACryptoServiceProvider key = new RSACryptoServiceProvider(1024);
						value = PublicKey = key.ToXmlString(false);
						PrivateKey = key.ToXmlString(true);
					}
					return value;
				}
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}



		internal class SmtpConfiguration : SubConfiguration, IContainMailConfiguration
		{

			public SmtpConfiguration(WebConfigurationsTable parent) : base(parent, nameof(Smtp))
			{
			}


			#region Overrides/Interfaces
			public string MailServer
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int MailServerPort
			{
				get { return Parent.GetConfigurationValue(25, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public bool MailServerEnableSsl
			{
				get { return Parent.GetConfigurationValue(false, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public string SenderMail
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public string MailServerUsername
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public string MailServerPassword
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int MailServerConnectionTimeout
			{
				get { return Parent.GetConfigurationValue(5000, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			#endregion
		}
	}
}