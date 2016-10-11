//********************************************************************
//
//                 AUTOGENERATED CONTENT DO NOT MODIFY
//                      PRODUCED BY CsWpfBase.Db
//
//********************************************************************
//
//
//Copyright (c) 2014 - 2016 All rights reserved Christian Sack
//<author>Christian Sack</author>
//<email>service.christian@sack.at</email>
//<website>christian.sack.at</website>
//<date>2016-10-11 17:43:34</date>



using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Db.attributes;
using CsWpfBase.Db.attributes.columnAttributes;
using CsWpfBase.Db.models;
using CsWpfBase.Db.models.helper;
using CsWpfBase.Db.models.bases;
using CsWpfBase.Db.router;
using System.IO;
using System.Text;
using System.ComponentModel;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.views;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;
using HsCentralServiceWeb._dbs.hsserver;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset
{
	
	
	
	/// <summary>'[<c>HsServerContext</c>].[<c>CentralServiceDb</c>]': a dataset/database inside context [<c>HsServerContext</c>] providing the tables and views inside database [<c>CentralServiceDb</c>].</summary>
	[Serializable] [DebuggerStepThrough]
	[DebuggerDisplay("DB[CentralServiceDb]: Tables[{Tables.Count}]")]
	[CsDbDataSet(Name = "CentralServiceDb", Generated = "16.10.11 17:43:34", Hash = "2D2EFF031C440EA2E94B450F05ADE858")]
	public partial class CentralServiceDb : CsDbDataSet
	{
	
	
	#region StaticDefinitions: Table names, Relations, schema description,...
	
		private static DataSet _schemaSet;
		private static CsDbRelation[] _csDbRelations;
		private static Dictionary<Type, CsDbRelation[]> _csDbRelationsPerTableType;
	
	
		/// <summary>The database name for the the database 'CentralServiceDb' </summary>
		public const string NativeName = "CentralServiceDb";
	
	
		///	<summary>Gets a list of the native names of all tables inside the database.</summary>
		public static string[] StaticTableNames = new string[]{"RemoteComputers", "RemoteApplications", "WebUsers", "RemoteUsers", "WebLogs", "RemoteInstances", "RemoteLogs", "WebConfigurations", "sysdiagrams", "RemoteRingPlayerManagements"};
	
	
		///	<summary>Gets a list of the native relations of all tables inside the data set. With this set of relations you can use reflection to dynamically get linked rows.</summary>
		public static CsDbRelation[] StaticCsDbRelations
		{
			get
			{
				if (_csDbRelations != null)
					return _csDbRelations;
				_csDbRelations = new[]{new CsDbRelation(typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteComputersTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteComputer), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteUsersTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteUser), "RemoteComputers", "Id", "RemoteUsers", "RemoteComputerId", typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteComputer).GetProperty("Id"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteUser).GetProperty("RemoteComputerId"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteUser).GetProperty("RemoteComputer"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteComputer).GetProperty("RemoteUsers")),
					new CsDbRelation(typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteApplicationsTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteApplication), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteInstancesTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance), "RemoteApplications", "Id", "RemoteInstances", "RemoteApplicationId", typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteApplication).GetProperty("Id"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("RemoteApplicationId"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("RemoteApplication"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteApplication).GetProperty("RemoteInstances")),
					new CsDbRelation(typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteUsersTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteUser), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteInstancesTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance), "RemoteUsers", "Id", "RemoteInstances", "RemoteUserId", typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteUser).GetProperty("Id"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("RemoteUserId"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("RemoteUser"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteUser).GetProperty("RemoteInstances")),
					new CsDbRelation(typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteInstancesTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteLogsTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteLog), "RemoteInstances", "Id", "RemoteLogs", "RemoteInstanceId", typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("Id"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteLog).GetProperty("RemoteInstanceId"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteLog).GetProperty("RemoteInstance"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("RemoteLogs")),
					new CsDbRelation(typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteInstancesTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables.RemoteRingPlayerManagementsTable), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteRingPlayerManagement), "RemoteInstances", "Id", "RemoteRingPlayerManagements", "RemoteInstanceId", typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("Id"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteRingPlayerManagement).GetProperty("RemoteInstanceId"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteRingPlayerManagement).GetProperty("RemoteInstance"), typeof(HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteInstance).GetProperty("RemoteRingPlayerManagements")),			};
				return _csDbRelations;
			}
		}
		
		///	<summary>Gets a list of the native relations of all tables inside the data set. With this set of relations you can use reflection to dynamically get linked rows. Use table type as key.</summary>
		public static Dictionary<Type, CsDbRelation[]> StaticCsDbRelationsPerTableType
		{
			get
			{
				if (_csDbRelationsPerTableType != null)
					return _csDbRelationsPerTableType;
	
					
				var dict = new Dictionary<Type, List<CsDbRelation>>();
				foreach (var relation in StaticCsDbRelations)
				{
					List<CsDbRelation> pkrelations;
					if (!dict.TryGetValue(relation.PkTableType, out pkrelations))
					{
						pkrelations = new List<CsDbRelation>();
						dict.Add(relation.PkTableType, pkrelations);
					}
					if (!pkrelations.Contains(relation))
						pkrelations.Add(relation);
	
	
					List<CsDbRelation> fkrelations;
					if (!dict.TryGetValue(relation.FkTableType, out fkrelations))
					{
						fkrelations = new List<CsDbRelation>();
						dict.Add(relation.FkTableType, fkrelations);
					}
					if (!fkrelations.Contains(relation))
						fkrelations.Add(relation);
				}
				return _csDbRelationsPerTableType = dict.ToDictionary(x => x.Key, x => x.Value.ToArray());
			}
		}
	
	
	
	
		///	<summary>Gets a list of the native relations of all tables inside the data set. With this set of relations you can use reflection to dynamically get linked rows.</summary>
		public override CsDbRelation[] CsDbRelations => StaticCsDbRelations;
	
		///	<summary>Gets a list of the native relations of all tables inside the data set. With this set of relations you can use reflection to dynamically get linked rows.</summary>
		public override Dictionary<Type, CsDbRelation[]> CsDbRelationsPerTableType => StaticCsDbRelationsPerTableType;
		
		///	<summary>Gets a list of the native names of all tables inside the database.</summary>
		public override string[] TableNames => StaticTableNames;
	
	
	
		/// <summary> Used as a database template for the schema.</summary>
		public override DataSet SchemaSet
		{
			get
			{
				if (_schemaSet != null)
					return _schemaSet;
	
				_schemaSet = DbProxy.ExecuteDataSetCommand(TableNames.Select(tableName => $"SELECT TOP(0) * FROM [{tableName}]").Join(";"));
				for (int i = 0; i < TableNames.Length; i++)
				{
					string tableName = TableNames[i];
					_schemaSet.Tables[i].TableName = tableName;
				}
				return _schemaSet;
			}
		}
	#endregion
	
	
	#region WPF Extension
		///<summary>Use this to propagate an instance of the data set trough the logical tree of an WPF control.</summary>
		public static readonly DependencyProperty InstanceProperty = DependencyProperty.RegisterAttached("Instance", typeof (CentralServiceDb), typeof (CentralServiceDb), new FrameworkPropertyMetadata(default(CentralServiceDb), FrameworkPropertyMetadataOptions.Inherits));
		///<summary>Use this to propagate an instance of the data set trough the logical tree of an WPF control.</summary>
		public static void SetInstance(DependencyObject element, CentralServiceDb value)
		{
			element.SetValue(InstanceProperty, value);
		}
		///<summary>Use this to get the propagated instance from a control inside the logical tree. You have to set the property anywhere in upstream to get it with this method.</summary>
		public static CentralServiceDb GetInstance(DependencyObject element)
		{
			return (CentralServiceDb) element.GetValue(InstanceProperty);
		}
	#endregion
	
	
		public CentralServiceDb()
		{
			DataSetName = "CentralServiceDb";
		}
	
		///<summary>Gets the owning data context for this data set. The owning context is the relative addressing method for other databases on the same server.</summary>
		public new HsCentralServiceWeb._dbs.hsserver.HsServerContext DataContext
		{
			get { return (HsCentralServiceWeb._dbs.hsserver.HsServerContext) base.DataContext; }
			internal set { base.DataContext = value; }
		}
	
		///<summary>Gets the native name of the owning data context or the native name of the database server associated with this.</summary>
		public override string DataContextName => DataContext?.Name ?? "HsServerContext";
	
	
	#region Tables
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>RemoteApplications</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public RemoteApplicationsTable RemoteApplications => GetTable<RemoteApplicationsTable>("RemoteApplications");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>RemoteComputers</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public RemoteComputersTable RemoteComputers => GetTable<RemoteComputersTable>("RemoteComputers");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>RemoteInstances</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public RemoteInstancesTable RemoteInstances => GetTable<RemoteInstancesTable>("RemoteInstances");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>RemoteLogs</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public RemoteLogsTable RemoteLogs => GetTable<RemoteLogsTable>("RemoteLogs");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>RemoteRingPlayerManagements</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public RemoteRingPlayerManagementsTable RemoteRingPlayerManagements => GetTable<RemoteRingPlayerManagementsTable>("RemoteRingPlayerManagements");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>RemoteUsers</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public RemoteUsersTable RemoteUsers => GetTable<RemoteUsersTable>("RemoteUsers");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>sysdiagrams</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public SysdiagramsTable Sysdiagrams => GetTable<SysdiagramsTable>("sysdiagrams");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>WebConfigurations</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public WebConfigurationsTable WebConfigurations => GetTable<WebConfigurationsTable>("WebConfigurations");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>WebLogs</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public WebLogsTable WebLogs => GetTable<WebLogsTable>("WebLogs");
	
		///<summary>Get or Create DataTable([<c>CentralServiceDb</c>].[<c>WebUsers</c>]) => If table does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public WebUsersTable WebUsers => GetTable<WebUsersTable>("WebUsers");
	#endregion
	
	
	
	
	#region Views
		///<summary>Get or create view of type DataTable([<c>CentralServiceDb</c>].[<c>ShowInstancenSituation</c>]) => If view does not exist in <see cref="Tables"/> collection, it will be created and inserted automatically.</summary>
		public ShowInstancenSituationView ShowInstancenSituation => GetTable<ShowInstancenSituationView>("ShowInstancenSituation");
	#endregion
	
		private bool _constraintsLoaded = false;
	
		///<summary>First it loads the schema then the relations and after that it enforces the constraint's.</summary>
		public override void LoadConstraints()
		{
			if (_constraintsLoaded)
				return;
	
			LoadSchema();
	
			AddRelation("FK__RemoteUse__Remot__18EBB532", RemoteComputers.Columns[RemoteComputersTable.IdCol], RemoteUsers.Columns[RemoteUsersTable.RemoteComputerIdCol], Rule.Cascade, Rule.Cascade);
			AddRelation("FK__RemoteIns__Remot__1AD3FDA4", RemoteApplications.Columns[RemoteApplicationsTable.IdCol], RemoteInstances.Columns[RemoteInstancesTable.RemoteApplicationIdCol], Rule.Cascade, Rule.Cascade);
			AddRelation("FK__RemoteIns__Remot__19DFD96B", RemoteUsers.Columns[RemoteUsersTable.IdCol], RemoteInstances.Columns[RemoteInstancesTable.RemoteUserIdCol], Rule.Cascade, Rule.Cascade);
			AddRelation("FK__RemoteLog__Remot__1BC821DD", RemoteInstances.Columns[RemoteInstancesTable.IdCol], RemoteLogs.Columns[RemoteLogsTable.RemoteInstanceIdCol], Rule.Cascade, Rule.Cascade);
			AddRelation("FK_RemoteRingPlayerInstanceArgs_RemoteInstances", RemoteInstances.Columns[RemoteInstancesTable.IdCol], RemoteRingPlayerManagements.Columns[RemoteRingPlayerManagementsTable.RemoteInstanceIdCol], Rule.Cascade, Rule.Cascade);
			
			_constraintsLoaded = true;
		}
		///<summary>Saves the tables in an order which is good for creating new items.</summary>
		public override CsDbDataSet SaveAnabolic(object tag = null)
		{
			CentralServiceDb targetSet = new CentralServiceDb();
	
			if(Tables.Contains("RemoteApplications")) AddAnabolicChanges(targetSet, RemoteApplications);
			if(Tables.Contains("RemoteComputers")) AddAnabolicChanges(targetSet, RemoteComputers);
			if(Tables.Contains("sysdiagrams")) AddAnabolicChanges(targetSet, Sysdiagrams);
			if(Tables.Contains("WebConfigurations")) AddAnabolicChanges(targetSet, WebConfigurations);
			if(Tables.Contains("WebLogs")) AddAnabolicChanges(targetSet, WebLogs);
			if(Tables.Contains("WebUsers")) AddAnabolicChanges(targetSet, WebUsers);
			if(Tables.Contains("RemoteUsers")) AddAnabolicChanges(targetSet, RemoteUsers);
			if(Tables.Contains("RemoteInstances")) AddAnabolicChanges(targetSet, RemoteInstances);
			if(Tables.Contains("RemoteLogs")) AddAnabolicChanges(targetSet, RemoteLogs);
			if(Tables.Contains("RemoteRingPlayerManagements")) AddAnabolicChanges(targetSet, RemoteRingPlayerManagements);
			
			if (targetSet.Tables.Count != 0)
				DbProxy.SaveChanges(targetSet.CloneTo_Native(), tag);
	
			return targetSet;
		}
		///<summary>Saves the tables in an order which is good for deleting items.</summary>
		public override CsDbDataSet SaveKatabolic(object tag = null)
		{
			CentralServiceDb targetSet = new CentralServiceDb();
	
			if(Tables.Contains("RemoteLogs")) AddKatabolicChanges(targetSet, RemoteLogs);
			if(Tables.Contains("RemoteRingPlayerManagements")) AddKatabolicChanges(targetSet, RemoteRingPlayerManagements);
			if(Tables.Contains("RemoteInstances")) AddKatabolicChanges(targetSet, RemoteInstances);
			if(Tables.Contains("RemoteUsers")) AddKatabolicChanges(targetSet, RemoteUsers);
			if(Tables.Contains("RemoteApplications")) AddKatabolicChanges(targetSet, RemoteApplications);
			if(Tables.Contains("RemoteComputers")) AddKatabolicChanges(targetSet, RemoteComputers);
			if(Tables.Contains("sysdiagrams")) AddKatabolicChanges(targetSet, Sysdiagrams);
			if(Tables.Contains("WebConfigurations")) AddKatabolicChanges(targetSet, WebConfigurations);
			if(Tables.Contains("WebLogs")) AddKatabolicChanges(targetSet, WebLogs);
			if(Tables.Contains("WebUsers")) AddKatabolicChanges(targetSet, WebUsers);
			
			if (targetSet.Tables.Count != 0)
				DbProxy.SaveChanges(targetSet.CloneTo_Native(), tag);
				
			return targetSet;
		}
		///<summary>Get the right table by its table name</summary>
		public override CsDbTable GetTableByName(string nativeName)
		{
			switch (nativeName)
			{
				case "RemoteComputers":
					return RemoteComputers;
				case "RemoteApplications":
					return RemoteApplications;
				case "WebUsers":
					return WebUsers;
				case "RemoteUsers":
					return RemoteUsers;
				case "WebLogs":
					return WebLogs;
				case "RemoteInstances":
					return RemoteInstances;
				case "RemoteLogs":
					return RemoteLogs;
				case "WebConfigurations":
					return WebConfigurations;
				case "sysdiagrams":
					return Sysdiagrams;
				case "RemoteRingPlayerManagements":
					return RemoteRingPlayerManagements;
				case "ShowInstancenSituation":
					return ShowInstancenSituation;
				default:
					throw new Exception($"Table with native name [{nativeName}] not found.");
			}
		}
		///<summary>Get the right table by its type</summary>
		public override CsDbTable GetTableByType<TType>()
		{
			switch (typeof(TType).Name)
			{
				case "RemoteComputersTable":
					return RemoteComputers;
				case "RemoteApplicationsTable":
					return RemoteApplications;
				case "WebUsersTable":
					return WebUsers;
				case "RemoteUsersTable":
					return RemoteUsers;
				case "WebLogsTable":
					return WebLogs;
				case "RemoteInstancesTable":
					return RemoteInstances;
				case "RemoteLogsTable":
					return RemoteLogs;
				case "WebConfigurationsTable":
					return WebConfigurations;
				case "SysdiagramsTable":
					return Sysdiagrams;
				case "RemoteRingPlayerManagementsTable":
					return RemoteRingPlayerManagements;
				case "ShowInstancenSituationView":
					return ShowInstancenSituation;
				default:
					throw new Exception($"Table with type [{typeof(TType).Name}] not found.");
			}
		}
	}
	
}