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
//<date>2017-01-21 20:15:01</date>



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
using TestApplication._dbs.hsserver.centralservicedb.tables;
using TestApplication._dbs.hsserver.centralservicedb.rowinterfaces;
using TestApplication._dbs.hsserver.centralservicedb.rowpocos;






namespace TestApplication._dbs.hsserver.centralservicedb.rows
{
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///<summary>DataRow([<c>CentralServiceDb</c>].[<c>WebUsers</c>]): row model of <see cref="WebUsersTable"/>.</summary>
	[Serializable]
	[DebuggerDisplay("DataRow(CentralServiceDb.WebUsers): Id = '{Id}'")]
	[CsDbDataRow(Database = "CentralServiceDb", TableName = "WebUsers", Generated = "17.01.21 20:15:01", Hash = "1A5710CE8D1E3D1EDA9357702344B0BB")]
	public partial class WebUser : CsDbTableRow, IWebUser
	{
		#region statics
		private static Dictionary<string, System.Reflection.PropertyInfo> _nativeColumnName_To_Property;
		public static Dictionary<string, System.Reflection.PropertyInfo> NativeColumnName_To_Property
		{
			get
			{
				if (_nativeColumnName_To_Property != null)
					return _nativeColumnName_To_Property;
		
				var type = typeof(IWebUser);
				_nativeColumnName_To_Property = new Dictionary<string, System.Reflection.PropertyInfo>
				{
					{ WebUsersTable.IdCol, type.GetProperty(nameof(Id)) },
					{ WebUsersTable.NameCol, type.GetProperty(nameof(Name)) },
					{ WebUsersTable.DescriptionCol, type.GetProperty(nameof(Description)) },
					{ WebUsersTable.UserNameCol, type.GetProperty(nameof(UserName)) },
					{ WebUsersTable.PasswordMd5Col, type.GetProperty(nameof(PasswordMd5)) }
				};
		
				return _nativeColumnName_To_Property;
			}
		}
		#endregion
	
	
		public WebUser(DataRowBuilder builder) : base(builder){}
	
		
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new TestApplication._dbs.hsserver.HsServerContext DataContext => Table.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new CentralServiceDb DataSet => Table.DataSet;
	
		///	<summary>Gets the owning table of type <see cref="WebUsersTable"/>.</summary>
		public new WebUsersTable Table => (WebUsersTable) base.Table;
	
	
	
	
		#region COLUMNS
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>')
		///</summary>
		[CsDbDataColumn(Default = "Guid.NewGuid()")]
		[CsDbNativeDataColumn(Table = "WebUsers", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO")]
		public Guid Id
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(WebUsersTable.IdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebUsersTable.IdCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>Name</c>] (Type = <c>nvarchar</c>, MaxLength = <c>255</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 255)]
		[CsDbNativeDataColumn(Table = "WebUsers", Name = "Name", Type = "nvarchar", MaxLength = "255", IsNullable = "NO")]
		public String Name
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(WebUsersTable.NameCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebUsersTable.NameCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>Description</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>500</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 500, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "WebUsers", Name = "Description", Type = "nvarchar", MaxLength = "500", IsNullable = "YES")]
		public String Description
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(WebUsersTable.DescriptionCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebUsersTable.DescriptionCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>UserName</c>] (Type = <c>nvarchar</c>, MaxLength = <c>255</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 255)]
		[CsDbNativeDataColumn(Table = "WebUsers", Name = "UserName", Type = "nvarchar", MaxLength = "255", IsNullable = "NO")]
		public String UserName
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(WebUsersTable.UserNameCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebUsersTable.UserNameCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>PasswordMd5</c>] (Type = <c>binary</c>, MaxLength = <c>16</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 16)]
		[CsDbNativeDataColumn(Table = "WebUsers", Name = "PasswordMd5", Type = "binary", MaxLength = "16", IsNullable = "NO")]
		public Byte[] PasswordMd5
		{
			[DebuggerStepThrough] get { return GetDbValue<Byte[]>(WebUsersTable.PasswordMd5Col); }
			[DebuggerStepThrough] set { SetDbValue(value, WebUsersTable.PasswordMd5Col); }
		}
		
		#endregion
	
	
	
	
	
		///	<summary>Reloads the <see cref="WebUser"/> row by executing following command:<para/><c>$"SELECT * FROM WebUsers WHERE [Id] = '<see cref="Id"/>'</c></summary>
		public WebUser Reload()
		{
			Table.DataSet.WebUsers.LoadThenFind(Id);
			return this;
		}
		
		
		
		
		#region PROPERTIES<Many to One>
		
		
		
		
		#endregion
		
		
		
		
		
		#region PROPERTIES<One to Many>
		
		#endregion
		
		
		
		
		
		#region FUNC<Overrides>
		protected void Invalidate()
		{
			if (!IsPropertyChangedHandled)
				return;
		
			OnPropertyChanged("Id");
			OnPropertyChanged("Name");
			OnPropertyChanged("Description");
			OnPropertyChanged("UserName");
			OnPropertyChanged("PasswordMd5");
		}
		///	<summary> Set all values which have default values inside the database to their defaults. This method is automatically invoked if you call <see cref="WebUsersTable.NewRow"/>. </summary>
		public override void ApplyDefaults()
		{
			Id = Guid.NewGuid();
		}
		/// <summary>
		///     Loads the complete data bundle of the current row into a target data set.
		///     <para>A data bundle is defined as a set of all rows inside a database which are connected via relations.</para>
		///     <para>The currently selected row is the root of the bundle</para>
		/// </summary>
		public void Copy_BundledData_Into_DataSet(CentralServiceDb target)
		{
			base.Copy_BundledData_Into_DataSet(target);
		}
		
		
		/// <summary>
		///     Loads the complete data bundle of the current row into a new data set.
		///     <para>A data bundle is defined as a set of rows inside a database which are connected via relations.</para>
		///     <para>The currently selected row is the root of the bundle</para>
		/// </summary>
		public new CentralServiceDb Copy_BundledData_In_New_DataSet(bool cloneCompleteSchema = false)
		{
			return (CentralServiceDb) base.Copy_BundledData_In_New_DataSet(cloneCompleteSchema);
		}
		
		#endregion
		
		
		///	<summary> This method copy's each database field into the <paramref name="target"/> interface. </summary>
		public void Copy_To(IWebUser target, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) target.Id = this.Id;
			target.Name = this.Name;
			target.Description = this.Description;
			target.UserName = this.UserName;
			target.PasswordMd5 = this.PasswordMd5;
		}
		///	<summary> This method copy's each database field from the <paramref name="source"/> interface to this data row.</summary>
		public void Copy_From(IWebUser source, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) this.Id = source.Id;
			this.Name = source.Name;
			this.Description = source.Description;
			this.UserName = source.UserName;
			this.PasswordMd5 = source.PasswordMd5;
		}
		///	<summary> 
		///		This method copy's each database field which is not in the <paramref name="excludedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_Ignore(IWebUser source, params string[] excludedColumns)
		{
			if (!excludedColumns.Contains(WebUsersTable.IdCol)) this.Id = source.Id;
			if (!excludedColumns.Contains(WebUsersTable.NameCol)) this.Name = source.Name;
			if (!excludedColumns.Contains(WebUsersTable.DescriptionCol)) this.Description = source.Description;
			if (!excludedColumns.Contains(WebUsersTable.UserNameCol)) this.UserName = source.UserName;
			if (!excludedColumns.Contains(WebUsersTable.PasswordMd5Col)) this.PasswordMd5 = source.PasswordMd5;
		}
		///	<summary> 
		///		This method copy's each database field which is in the <paramref name="includedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_TakeOnly(IWebUser source, params string[] includedColumns)
		{
			if (includedColumns.Contains(WebUsersTable.IdCol)) this.Id = source.Id;
			if (includedColumns.Contains(WebUsersTable.NameCol)) this.Name = source.Name;
			if (includedColumns.Contains(WebUsersTable.DescriptionCol)) this.Description = source.Description;
			if (includedColumns.Contains(WebUsersTable.UserNameCol)) this.UserName = source.UserName;
			if (includedColumns.Contains(WebUsersTable.PasswordMd5Col)) this.PasswordMd5 = source.PasswordMd5;
		}
		
		///	<summary>Creates a new instance of type <see cref="Poco_WebUser" />.</summary>
		public Poco_WebUser AsPoco()
		{
			Poco_WebUser poco = new Poco_WebUser();
			Copy_To(poco, true);
			return poco;
		}
	}
}