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
//<date>2017-01-21 20:15:00</date>



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
using TestApplication._dbs.hsserver.centralservicedb.dataset;
using WebConfiguration=TestApplication._dbs.hsserver.centralservicedb.rows.WebConfiguration;
using IWebConfiguration=TestApplication._dbs.hsserver.centralservicedb.rowinterfaces.IWebConfiguration;
using TestApplication._dbs.hsserver;






namespace TestApplication._dbs.hsserver.centralservicedb.tables
{
	#pragma warning disable 657
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///	<summary>
	///		'[<c>HsServer</c>].[<c>#CentralServiceDb#</c>].[<c>WebConfigurations</c>]': A Table inside '[<c>HsServer</c>].[<c>#CentralServiceDb#</c>]' database with '<see cref="WebConfiguration"/>' as <see cref="DataRow"/>.<para/>
	///		
	///	</summary>
	[Serializable]
	[DebuggerDisplay("DataTable(CentralServiceDb.WebConfigurations): Rows[{Rows.Count}]")]
	[CsDbDataTable(Database = "CentralServiceDb", Name = "WebConfigurations", Generated = "17.01.21 20:15:00", Hash = "016D8F473E9E7018647F6BEBD3B3FAE0")]
	
	public partial class WebConfigurationsTable : CsDbTable<WebConfiguration>
	{
		#region CONSTANTS
		///<summary>The native table name (WebConfigurations).</summary>
		public const string NativeName = "WebConfigurations";
		///<summary>Holds native column name of <c>[CentralServiceDb].[WebConfigurations].[PropertyName]</c> column. Property = <see cref="WebConfiguration.PropertyName"/>.</summary>
		public const string PropertyNameCol = "PropertyName";
		///<summary>Holds native column name of <c>[CentralServiceDb].[WebConfigurations].[Value]</c> column. Property = <see cref="WebConfiguration.Value"/>.</summary>
		public const string ValueCol = "Value";
		///<summary>Holds native column name of <c>[CentralServiceDb].[WebConfigurations].[UpdateCount]</c> column. Property = <see cref="WebConfiguration.UpdateCount"/>.</summary>
		public const string UpdateCountCol = "UpdateCount";
		///<summary>Holds native column name of <c>[CentralServiceDb].[WebConfigurations].[LastUpdated]</c> column. Property = <see cref="WebConfiguration.LastUpdated"/>.</summary>
		public const string LastUpdatedCol = "LastUpdated";
	
		/// <summary> Contains attribute values for the columns</summary>
		public static class Cols
		{
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>PropertyName</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "PropertyName", Type = "nvarchar", MaxLength = "255", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute PropertyName = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "PropertyName", Type = "nvarchar", MaxLength = "255", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>Value</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "Value", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Value = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "Value", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>UpdateCount</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "UpdateCount", Type = "int", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute UpdateCount = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "UpdateCount", Type = "int", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>LastUpdated</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "LastUpdated", Type = "datetime2", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute LastUpdated = new CsDbNativeDataColumnAttribute {Table = "WebConfigurations", Name = "LastUpdated", Type = "datetime2", IsNullable = "NO"};
		}
		#endregion
	
	
	
	
	
	
	
		///<summary>Default constructor for save <see cref="DataTable"/> operations</summary>
		public WebConfigurationsTable()
		{
			TableName = NativeName;
		}
	
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new TestApplication._dbs.hsserver.HsServerContext DataContext => DataSet.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new CentralServiceDb DataSet => (CentralServiceDb) base.DataSet;
	
	
	
	
	
	
	
		#region FUNC<Overrides>
		
		///	<summary><c>SELECT (DefaultSqlSelector) FROM [WebConfigurations]</c><para>The default selector is the * operator</para></summary>
		[DebuggerStepThrough] 
		public override void DownloadRows()
		{
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}]", false);
			HasBeenLoaded = true;
		}
		///	<summary><c>SELECT <paramref name="top"/> (DefaultSqlSelector) FROM [WebConfigurations]</c><para>The default selector is the * operator</para></summary>
		[DebuggerStepThrough] 
		public override void DownloadRows(int top)
		{
			DownloadRows($"SELECT TOP {top} {DefaultSqlSelector} FROM [{NativeName}]", false);
		}
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_FindOrLoad(object propertyName)
		{
			return propertyName==null ? null : FindOrLoad((String) propertyName);
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_LoadThenFind(object propertyName)
		{
			return propertyName==null ? null : LoadThenFind((String) propertyName);
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_Find(object propertyName)
		{
			return propertyName==null ? null : Find((String) propertyName);
		}
		
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_FindOrLoad(params object[] propertyNames)
		{
			return FindOrLoad_Each(propertyNames.OfType<String>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_LoadThenFind(params object[] propertyNames)
		{
			return LoadThenFind_Each(propertyNames.OfType<String>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_Find(params object[] propertyNames)
		{
			return Find_Each(propertyNames.OfType<String>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		#endregion
		
		
		
		
		#region FUNC<Primary Key>
		
		///	<summary>
		///		find an item in local data where PropertyName = '<paramref name="propertyName"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [WebConfigurations] WHERE [PropertyName] = '<paramref name="propertyName"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public WebConfiguration FindOrLoad(String propertyName)
		{
			if (propertyName == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind(propertyName);
		
			return Find(propertyName) ?? LoadThenFind(propertyName);
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [WebConfigurations] WHERE [PropertyName] = '<paramref name="propertyName"/>'</c> THEN find an item in local data where PropertyName = '<paramref name="propertyName"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		
		[DebuggerStepThrough] 
		public WebConfiguration LoadThenFind(String propertyName)
		{
			if (propertyName == null)
				return null;
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [PropertyName] = '{propertyName}'", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[PropertyNameCol] };
		
			return Rows.Find(propertyName) as WebConfiguration;
		}
		
		
		///	<summary>
		///		find an item in local data where PropertyName = '<paramref name="propertyName"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public WebConfiguration Find(String propertyName)
		{
			if (propertyName == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[PropertyNameCol] };
		
			return Rows.Find(propertyName) as WebConfiguration;
		}
		#endregion
		
		#region FUNC<Primary Key Many>
		///	<summary>
		///		find items in local data where PropertyName IN '<paramref name="propertyNames"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [WebConfigurations] WHERE [PropertyName] IN '<paramref name="propertyNames"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind_Each"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public WebConfiguration[] FindOrLoad_Each(params String[] propertyNames)
		{
			if (propertyNames == null || propertyNames.Length == 0)
				return new WebConfiguration[0];
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind_Each(propertyNames);
				
			var locallyFound = Find_Each(propertyNames);
			var loaded = LoadThenFind_Each(propertyNames.Except(locallyFound.Select(x=>x.PropertyName)).ToArray());
			return locallyFound.Union(loaded).ToArray();
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [WebConfigurations] WHERE [PropertyName] IN '<paramref name="propertyNames"/>'</c> THEN find items in local data where PropertyName IN '<paramref name="propertyNames"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		
		[DebuggerStepThrough] 
		public WebConfiguration[] LoadThenFind_Each(params String[] propertyNames)
		{
			if (propertyNames == null || propertyNames.Length == 0)
				return new WebConfiguration[0];
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [PropertyName] IN ('{propertyNames.Select(x=>x.ToString()).Join("', '")}')", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[PropertyNameCol] };
		
			return Find_Each(propertyNames);
		}
		
		
		///	<summary>
		///		find items in local data where PropertyName IN '<paramref name="propertyNames"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public WebConfiguration[] Find_Each(params String[] propertyNames)
		{
			if (propertyNames == null || propertyNames.Length == 0)
				return new WebConfiguration[0];
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[PropertyNameCol] };
				
			return Select(propertyNames.Select(key=>$"{PropertyNameCol} = '{key}'").Join(" OR "));
		}
		#endregion
		
		
		
		
		
		#region FUNC<Foreign Key>
		
		#endregion
		
		
		/// <summary>Creates a row then copy's the data from the <paramref name="item"/> and adds it to the row collection.</summary>
		public WebConfiguration AddAsNewRow(IWebConfiguration item)
		{
			var row = NewRow();
			row.Copy_From(item, true);
			Add(row);
			return row;
		}
	}
}