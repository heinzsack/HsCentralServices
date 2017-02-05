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
//<date>2017-02-05 16:40:03</date>



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
using RepositoryFile=TestApplication._dbs.hsserver.centralservicedb.rows.RepositoryFile;
using IRepositoryFile=TestApplication._dbs.hsserver.centralservicedb.rowinterfaces.IRepositoryFile;
using TestApplication._dbs.hsserver;






namespace TestApplication._dbs.hsserver.centralservicedb.tables
{
	#pragma warning disable 657
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///	<summary>
	///		'[<c>HsServer</c>].[<c>#CentralServiceDb#</c>].[<c>RepositoryFiles</c>]': A Table inside '[<c>HsServer</c>].[<c>#CentralServiceDb#</c>]' database with '<see cref="RepositoryFile"/>' as <see cref="DataRow"/>.<para/>
	///		
	///	</summary>
	[Serializable]
	[DebuggerDisplay("DataTable(CentralServiceDb.RepositoryFiles): Rows[{Rows.Count}]")]
	[CsDbDataTable(Database = "CentralServiceDb", Name = "RepositoryFiles", Generated = "17.02.05 16:40:03", Hash = "A12063DA83EB4080AEF8433E52A21516")]
	
	public partial class RepositoryFilesTable : CsDbTable<RepositoryFile>
	{
		#region CONSTANTS
		///<summary>The native table name (RepositoryFiles).</summary>
		public const string NativeName = "RepositoryFiles";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Id]</c> column. Property = <see cref="RepositoryFile.Id"/>.</summary>
		public const string IdCol = "Id";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Hash]</c> column. Property = <see cref="RepositoryFile.Hash"/>.</summary>
		public const string HashCol = "Hash";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Path]</c> column. Property = <see cref="RepositoryFile.Path"/>.</summary>
		public const string PathCol = "Path";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[IsDownloadAble]</c> column. Property = <see cref="RepositoryFile.IsDownloadAble"/>.</summary>
		public const string IsDownloadAbleCol = "IsDownloadAble";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Name]</c> column. Property = <see cref="RepositoryFile.Name"/>.</summary>
		public const string NameCol = "Name";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Extension]</c> column. Property = <see cref="RepositoryFile.Extension"/>.</summary>
		public const string ExtensionCol = "Extension";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Description]</c> column. Property = <see cref="RepositoryFile.Description"/>.</summary>
		public const string DescriptionCol = "Description";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Author]</c> column. Property = <see cref="RepositoryFile.Author"/>.</summary>
		public const string AuthorCol = "Author";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[AuthorId]</c> column. Property = <see cref="RepositoryFile.AuthorId"/>.</summary>
		public const string AuthorIdCol = "AuthorId";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Length]</c> column. Property = <see cref="RepositoryFile.Length"/>.</summary>
		public const string LengthCol = "Length";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Created]</c> column. Property = <see cref="RepositoryFile.Created"/>.</summary>
		public const string CreatedCol = "Created";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[UploadDuration]</c> column. Property = <see cref="RepositoryFile.UploadDuration"/>.</summary>
		public const string UploadDurationCol = "UploadDuration";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Modified]</c> column. Property = <see cref="RepositoryFile.Modified"/>.</summary>
		public const string ModifiedCol = "Modified";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[Group]</c> column. Property = <see cref="RepositoryFile.Group"/>.</summary>
		public const string GroupCol = "Group";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[TimeToLive]</c> column. Property = <see cref="RepositoryFile.TimeToLive"/>.</summary>
		public const string TimeToLiveCol = "TimeToLive";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[AccessDate]</c> column. Property = <see cref="RepositoryFile.AccessDate"/>.</summary>
		public const string AccessDateCol = "AccessDate";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[AccessCount]</c> column. Property = <see cref="RepositoryFile.AccessCount"/>.</summary>
		public const string AccessCountCol = "AccessCount";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[LastAccessBy]</c> column. Property = <see cref="RepositoryFile.LastAccessBy"/>.</summary>
		public const string LastAccessByCol = "LastAccessBy";
		///<summary>Holds native column name of <c>[CentralServiceDb].[RepositoryFiles].[LastAccessById]</c> column. Property = <see cref="RepositoryFile.LastAccessById"/>.</summary>
		public const string LastAccessByIdCol = "LastAccessById";
	
		/// <summary> Contains attribute values for the columns</summary>
		public static class Cols
		{
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Id</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Id = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Hash</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Hash", Type = "char", MaxLength = "40", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Hash = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Hash", Type = "char", MaxLength = "40", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Path</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Path", Type = "nvarchar", MaxLength = "600", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Path = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Path", Type = "nvarchar", MaxLength = "600", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>IsDownloadAble</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "IsDownloadAble", Type = "bit", Default = "((1))", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute IsDownloadAble = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "IsDownloadAble", Type = "bit", Default = "((1))", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Name</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Name", Type = "nvarchar", MaxLength = "200", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Name = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Name", Type = "nvarchar", MaxLength = "200", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Extension</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Extension", Type = "nvarchar", MaxLength = "100", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Extension = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Extension", Type = "nvarchar", MaxLength = "100", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Description</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Description", Type = "nvarchar", MaxLength = "1000", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Description = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Description", Type = "nvarchar", MaxLength = "1000", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Author</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Author", Type = "nvarchar", MaxLength = "600", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Author = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Author", Type = "nvarchar", MaxLength = "600", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>AuthorId</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "AuthorId", Type = "uniqueidentifier", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute AuthorId = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "AuthorId", Type = "uniqueidentifier", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Length</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Length", Type = "int", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Length = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Length", Type = "int", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Created</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Created", Type = "datetime2", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Created = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Created", Type = "datetime2", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>UploadDuration</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "UploadDuration", Type = "float", IsNullable = "NO"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute UploadDuration = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "UploadDuration", Type = "float", IsNullable = "NO"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Modified</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Modified", Type = "datetime2", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Modified = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Modified", Type = "datetime2", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>Group</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Group", Type = "nvarchar", MaxLength = "200", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute Group = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "Group", Type = "nvarchar", MaxLength = "200", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>TimeToLive</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "TimeToLive", Type = "datetime2", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute TimeToLive = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "TimeToLive", Type = "datetime2", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>AccessDate</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "AccessDate", Type = "datetime2", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute AccessDate = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "AccessDate", Type = "datetime2", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>AccessCount</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "AccessCount", Type = "int", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute AccessCount = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "AccessCount", Type = "int", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>LastAccessBy</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "LastAccessBy", Type = "nvarchar", MaxLength = "600", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute LastAccessBy = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "LastAccessBy", Type = "nvarchar", MaxLength = "600", IsNullable = "YES"};
			/// <summary>
			///		Get the attribute from the column [<c>CentralServiceDb</c>].[<c>RepositoryFiles</c>].[<c>LastAccessById</c>]<para/>
			///		#Mode# = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "LastAccessById", Type = "uniqueidentifier", IsNullable = "YES"};
			/// </summary>
			public static CsDbNativeDataColumnAttribute LastAccessById = new CsDbNativeDataColumnAttribute {Table = "RepositoryFiles", Name = "LastAccessById", Type = "uniqueidentifier", IsNullable = "YES"};
		}
		#endregion
	
	
	
	
	
	
	
		///<summary>Default constructor for save <see cref="DataTable"/> operations</summary>
		public RepositoryFilesTable()
		{
			TableName = NativeName;
		}
	
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new TestApplication._dbs.hsserver.HsServerContext DataContext => DataSet.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new CentralServiceDb DataSet => (CentralServiceDb) base.DataSet;
	
	
	
	
	
	
	
		#region FUNC<Overrides>
		
		///	<summary><c>SELECT (DefaultSqlSelector) FROM [RepositoryFiles]</c><para>The default selector is the * operator</para></summary>
		[DebuggerStepThrough] 
		public override void DownloadRows()
		{
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}]", false);
			HasBeenLoaded = true;
		}
		///	<summary><c>SELECT <paramref name="top"/> (DefaultSqlSelector) FROM [RepositoryFiles]</c><para>The default selector is the * operator</para></summary>
		[DebuggerStepThrough] 
		public override void DownloadRows(int top)
		{
			DownloadRows($"SELECT TOP {top} {DefaultSqlSelector} FROM [{NativeName}]", false);
		}
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_FindOrLoad(object id)
		{
			return id==null ? null : FindOrLoad((Guid?) id);
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_LoadThenFind(object id)
		{
			return id==null ? null : LoadThenFind((Guid?) id);
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase Generic_Find(object id)
		{
			return id==null ? null : Find((Guid?) id);
		}
		
		
		
		///<summary>This method calls <see cref="FindOrLoad"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_FindOrLoad(params object[] ids)
		{
			return FindOrLoad_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="LoadThenFind"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_LoadThenFind(params object[] ids)
		{
			return LoadThenFind_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		///<summary>This method calls <see cref="Find"/>.</summary>
		[DebuggerStepThrough] 
		public override CsDbRowBase[] Generic_Find(params object[] ids)
		{
			return Find_Each(ids.OfType<Guid>().ToArray()).OfType<CsDbRowBase>().ToArray();
		}
		#endregion
		
		
		
		
		#region FUNC<Primary Key>
		
		///	<summary>
		///		find an item in local data where Id = '<paramref name="id"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RepositoryFiles] WHERE [Id] = '<paramref name="id"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public RepositoryFile FindOrLoad(Guid? id)
		{
			if (id == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind(id);
		
			return Find(id) ?? LoadThenFind(id);
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RepositoryFiles] WHERE [Id] = '<paramref name="id"/>'</c> THEN find an item in local data where Id = '<paramref name="id"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		
		[DebuggerStepThrough] 
		public RepositoryFile LoadThenFind(Guid? id)
		{
			if (id == null)
				return null;
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [Id] = '{id}'", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Rows.Find(id.Value) as RepositoryFile;
		}
		
		
		///	<summary>
		///		find an item in local data where Id = '<paramref name="id"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public RepositoryFile Find(Guid? id)
		{
			if (id == null)
				return null;
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Rows.Find(id.Value) as RepositoryFile;
		}
		#endregion
		
		#region FUNC<Primary Key Many>
		///	<summary>
		///		find items in local data where Id IN '<paramref name="ids"/>'. If nothing is found QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RepositoryFiles] WHERE [Id] IN '<paramref name="ids"/>'</c>.<para/>
		///		If no primary key is set execute <see cref="LoadThenFind_Each"/> instead.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public RepositoryFile[] FindOrLoad_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RepositoryFile[0];
		
			if (PrimaryKey.Length == 0)
				return LoadThenFind_Each(ids);
				
			var locallyFound = Find_Each(ids);
			var loaded = LoadThenFind_Each(ids.Except(locallyFound.Select(x=>x.Id)).ToArray());
			return locallyFound.Union(loaded).ToArray();
		}
		
		
		///<summary>
		///		QUERY WITH <c>SELECT {DefaultSqlSelector} FROM [RepositoryFiles] WHERE [Id] IN '<paramref name="ids"/>'</c> THEN find items in local data where Id IN '<paramref name="ids"/>'.<para/>
		///		IMPORTENT: Sets primary key if not set already.<para/>
		///</summary>
		
		[DebuggerStepThrough] 
		public RepositoryFile[] LoadThenFind_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RepositoryFile[0];
		
			DownloadRows($"SELECT {DefaultSqlSelector} FROM [{NativeName}] WHERE [Id] IN ('{ids.Select(x=>x.ToString()).Join("', '")}')", false);
			
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
		
			return Find_Each(ids);
		}
		
		
		///	<summary>
		///		find items in local data where Id IN '<paramref name="ids"/>'. IMPORTENT: Sets primary key if not set already.<para/>
		///	</summary>
		
		[DebuggerStepThrough] 
		public RepositoryFile[] Find_Each(params Guid[] ids)
		{
			if (ids == null || ids.Length == 0)
				return new RepositoryFile[0];
		
			if (PrimaryKey.Length == 0)
				PrimaryKey = new[] { Columns[IdCol] };
				
			return Select(ids.Select(key=>$"{IdCol} = '{key}'").Join(" OR "));
		}
		#endregion
		
		
		
		
		
		#region FUNC<Foreign Key>
		
		#endregion
		
		
		/// <summary>Creates a row then copy's the data from the <paramref name="item"/> and adds it to the row collection.</summary>
		public RepositoryFile AddAsNewRow(IRepositoryFile item)
		{
			var row = NewRow();
			row.Copy_From(item, true);
			Add(row);
			return row;
		}
	}
}