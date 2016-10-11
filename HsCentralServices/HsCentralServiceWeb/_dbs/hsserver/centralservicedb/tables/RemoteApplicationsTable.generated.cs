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
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset;
using RemoteApplication=HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows.RemoteApplication;
using IRemoteApplication=HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowinterfaces.IRemoteApplication;
using HsCentralServiceWeb._dbs.hsserver;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables
{
	#pragma warning disable 657
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///	<summary>
	///		'[<c>HsServer</c>].[<c>#CentralServiceDb#</c>].[<c>RemoteApplications</c>]': A Table inside '[<c>HsServer</c>].[<c>#CentralServiceDb#</c>]' database with '<see cref="RemoteApplication"/>' as <see cref="DataRow"/>.<para/>
	///		[<c>RemoteApplications</c>].[<c>Id</c>] &#60;&#60;&#60;&#60; [<c>RemoteInstances</c>].[<c>RemoteApplicationId</c>]
	///	</summary>
	[Serializable]
	[DebuggerStepThrough]
	[DebuggerDisplay("DataTable(CentralServiceDb.RemoteApplications): Rows[{Rows.Count}]")]
	[CsDbDataTable(Database = "CentralServiceDb", Name = "RemoteApplications", Generated = "16.10.11 17:43:34", Hash = "D43ACF02AC5AE0C7CCE54DD663163177")]
	[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
	public partial class RemoteApplicationsTable : CsDbTable<RemoteApplication>
	{
		#region CONSTANTS
		///<summary>The native table name (RemoteApplications).</summary>
		public const string NativeName = "RemoteApplications";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RemoteApplications].[Id]</c> column. Property = <see cref="RemoteApplication.Id"/>.</summary>
		public const string IdCol = "Id";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RemoteApplications].[Name]</c> column. Property = <see cref="RemoteApplication.Name"/>.</summary>
		public const string NameCol = "Name";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RemoteApplications].[Product]</c> column. Property = <see cref="RemoteApplication.Product"/>.</summary>
		public const string ProductCol = "Product";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RemoteApplications].[ProductTitle]</c> column. Property = <see cref="RemoteApplication.ProductTitle"/>.</summary>
		public const string ProductTitleCol = "ProductTitle";
	
		/// <summary> Contains attribute values for the columns</summary>
		public static class Cols
		{
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RemoteApplications</c>].[<c>Id</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Id = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RemoteApplications</c>].[<c>Name</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "Name", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Name = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "Name", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RemoteApplications</c>].[<c>Product</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "Product", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Product = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "Product", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RemoteApplications</c>].[<c>ProductTitle</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "ProductTitle", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute ProductTitle = new CsDbNativeDataColumnAttribute {Table = "RemoteApplications", Name = "ProductTitle", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES"};
		}
		#endregion
	
	
	
	
	
	
	
		///<summary>Default constructor for save <see cref="DataTable"/> operations</summary>
		public RemoteApplicationsTable()
		{
			TableName = NativeName;
		}
	
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new HsCentralServiceWeb._dbs.hsserver.HsServerContext DataContext => DataSet.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new CentralServiceDb DataSet => (CentralServiceDb) base.DataSet;
	
	
	
	
	
	
	
		#region FUNC<Overrides>
		
		///	<summary><c>SELECT (DefaultSqlSelector) FROM [RemoteApplications]</c><para>The default selector is the * operator</para></summary>
		public override void DownloadRows()
		{
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}]", false);
			HasBeenLoaded = true;
		}
		///	<summary><c>SELECT <paramref name="top"/> (DefaultSqlSelector) FROM [RemoteApplications]</c><para>The default selector is the * operator</para></summary>
		public override void DownloadRows(int top)
		{
			DownloadRows($"SELECT TOP {top} {DefaultSqlSelector} FROM [{NativeName}]", false);
		}
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		public override CsDbRowBase Generic_FindOrLoad(object id)
		{
			return id==null ? null : FindOrLoad((Guid?) id);
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		public override CsDbRowBase Generic_LoadThenFind(object id)
		{
			return id==null ? null : LoadThenFind((Guid?) id);
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		public override CsDbRowBase Generic_Find(object id)
		{
			return id==null ? null : Find((Guid?) id);
		}
		
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		public override CsDbRowBase[] Generic_FindOrLoad(params object[] ids)
		{
			return FindOrLoad_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		public override CsDbRowBase[] Generic_LoadThenFind(params object[] ids)
		{
			return LoadThenFind_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		public override CsDbRowBase[] Generic_Find(params object[] ids)
		{
			return Find_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		#endregion
		
		
		
		
		#region FUNC<Primary Key>
		
		///	<summary>
		///		find an item in local data where Id = '<paramref name="id"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RemoteApplications] WHERE [Id] = '<paramref name="id"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
		public RemoteApplication FindOrLoad(Guid? id)
		{
			if (id == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind(id);
		
			return Find(id) ?? LoadThenFind(id);
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RemoteApplications] WHERE [Id] = '<paramref name="id"/>'</c> THEN find an item in local data where Id = '<paramref name="id"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
		public RemoteApplication LoadThenFind(Guid? id)
		{
			if (id == null)
				return null;
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [Id] = '{id}'", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Rows.Find(id.Value) as RemoteApplication;
		}
		
		
		///	<summary>
		///		find an item in local data where Id = '<paramref name="id"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
		public RemoteApplication Find(Guid? id)
		{
			if (id == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Rows.Find(id.Value) as RemoteApplication;
		}
		#endregion
		
		#region FUNC<Primary Key Many>
		///	<summary>
		///		find items in local data where Id IN '<paramref name="ids"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RemoteApplications] WHERE [Id] IN '<paramref name="ids"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind_Each"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
		public RemoteApplication[] FindOrLoad_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RemoteApplication[0];
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind_Each(ids);
				
			var locallyFound = Find_Each(ids);
			var loaded = LoadThenFind_Each(ids.Except(locallyFound.Select(x=>x.Id)).ToArray());
			return locallyFound.Union(loaded).ToArray();
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RemoteApplications] WHERE [Id] IN '<paramref name="ids"/>'</c> THEN find items in local data where Id IN '<paramref name="ids"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
		public RemoteApplication[] LoadThenFind_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RemoteApplication[0];
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [Id] IN ('{ids.Select(x=>x.ToString()).Join("', '")}')", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Find_Each(ids);
		}
		
		
		///	<summary>
		///		find items in local data where Id IN '<paramref name="ids"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		[CsDbResolvesRelation("FK__RemoteIns__Remot__1AD3FDA4", PkTable = "RemoteApplications", PkColumn = "Id", FkTable = "RemoteInstances", FkColumn = "RemoteApplicationId")]
		public RemoteApplication[] Find_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RemoteApplication[0];
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
				
			return Select(ids.Select(key=>$"{IdCol} = '{key}'").Join(" OR "));
		}
		#endregion
		
		
		
		
		
		#region FUNC<Foreign Key>
		
		#endregion
		
		
		/// <summary>Creates a row then copy's the data from the <paramref name="item"/> and adds it to the row collection.</summary>
		public RemoteApplication AddAsNewRow(IRemoteApplication item)
		{
			var row = NewRow();
			row.Copy_From(item, true);
			Add(row);
			return row;
		}
	}
}