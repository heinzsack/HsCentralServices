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
//<date>2017-01-26 17:28:56</date>



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
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowinterfaces;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows
{
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///<summary>DataRow([<c>CentralServiceDb</c>].[<c>WebConfigurations</c>]): row model of <see cref="WebConfigurationsTable"/>.</summary>
	[Serializable]
	[DebuggerDisplay("DataRow(CentralServiceDb.WebConfigurations): PropertyName = '{PropertyName}'")]
	[CsDbDataRow(Database = "CentralServiceDb", TableName = "WebConfigurations", Generated = "17.01.26 17:28:56", Hash = "1C9DDB51505727AA802294E1B58D3E6F")]
	public partial class WebConfiguration : CsDbTableRow, IWebConfiguration
	{
		#region statics
		private static Dictionary<string, System.Reflection.PropertyInfo> _nativeColumnName_To_Property;
		public static Dictionary<string, System.Reflection.PropertyInfo> NativeColumnName_To_Property
		{
			get
			{
				if (_nativeColumnName_To_Property != null)
					return _nativeColumnName_To_Property;
		
				var type = typeof(IWebConfiguration);
				_nativeColumnName_To_Property = new Dictionary<string, System.Reflection.PropertyInfo>
				{
					{ WebConfigurationsTable.PropertyNameCol, type.GetProperty(nameof(PropertyName)) },
					{ WebConfigurationsTable.ValueCol, type.GetProperty(nameof(Value)) },
					{ WebConfigurationsTable.UpdateCountCol, type.GetProperty(nameof(UpdateCount)) },
					{ WebConfigurationsTable.LastUpdatedCol, type.GetProperty(nameof(LastUpdated)) }
				};
		
				return _nativeColumnName_To_Property;
			}
		}
		#endregion
	
	
		public WebConfiguration(DataRowBuilder builder) : base(builder){}
	
		
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new HsCentralServiceWeb._dbs.hsserver.HsServerContext DataContext => Table.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new CentralServiceDb DataSet => Table.DataSet;
	
		///	<summary>Gets the owning table of type <see cref="WebConfigurationsTable"/>.</summary>
		public new WebConfigurationsTable Table => (WebConfigurationsTable) base.Table;
	
	
	
	
		#region COLUMNS
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>PropertyName</c>] (Type = <c>nvarchar</c>, MaxLength = <c>255</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 255)]
		[CsDbNativeDataColumn(Table = "WebConfigurations", Name = "PropertyName", Type = "nvarchar", MaxLength = "255", IsNullable = "NO")]
		public String PropertyName
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(WebConfigurationsTable.PropertyNameCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebConfigurationsTable.PropertyNameCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>Value</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "WebConfigurations", Name = "Value", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES")]
		public String Value
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(WebConfigurationsTable.ValueCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebConfigurationsTable.ValueCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>UpdateCount</c>] (Type = <c>int</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "WebConfigurations", Name = "UpdateCount", Type = "int", IsNullable = "NO")]
		public Int32 UpdateCount
		{
			[DebuggerStepThrough] get { return GetDbValue<Int32>(WebConfigurationsTable.UpdateCountCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebConfigurationsTable.UpdateCountCol); }
		}
		///<summary>
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>LastUpdated</c>] (Type = <c>datetime2</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "WebConfigurations", Name = "LastUpdated", Type = "datetime2", IsNullable = "NO")]
		public DateTime LastUpdated
		{
			[DebuggerStepThrough] get { return GetDbValue<DateTime>(WebConfigurationsTable.LastUpdatedCol); }
			[DebuggerStepThrough] set { SetDbValue(value, WebConfigurationsTable.LastUpdatedCol); }
		}
		
		#endregion
	
	
	
	
	
		///	<summary>Reloads the <see cref="WebConfiguration"/> row by executing following command:<para/><c>$"SELECT * FROM WebConfigurations WHERE [PropertyName] = '<see cref="PropertyName"/>'</c></summary>
		public WebConfiguration Reload()
		{
			Table.DataSet.WebConfigurations.LoadThenFind(PropertyName);
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
		
			OnPropertyChanged("PropertyName");
			OnPropertyChanged("Value");
			OnPropertyChanged("UpdateCount");
			OnPropertyChanged("LastUpdated");
		}
		///	<summary> Set all values which have default values inside the database to their defaults. This method is automatically invoked if you call <see cref="WebConfigurationsTable.NewRow"/>. </summary>
		public override void ApplyDefaults()
		{
			
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
		public void Copy_To(IWebConfiguration target, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) target.PropertyName = this.PropertyName;
			target.Value = this.Value;
			target.UpdateCount = this.UpdateCount;
			target.LastUpdated = this.LastUpdated;
		}
		///	<summary> This method copy's each database field from the <paramref name="source"/> interface to this data row.</summary>
		public void Copy_From(IWebConfiguration source, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) this.PropertyName = source.PropertyName;
			this.Value = source.Value;
			this.UpdateCount = source.UpdateCount;
			this.LastUpdated = source.LastUpdated;
		}
		///	<summary> 
		///		This method copy's each database field which is not in the <paramref name="excludedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_Ignore(IWebConfiguration source, params string[] excludedColumns)
		{
			if (!excludedColumns.Contains(WebConfigurationsTable.PropertyNameCol)) this.PropertyName = source.PropertyName;
			if (!excludedColumns.Contains(WebConfigurationsTable.ValueCol)) this.Value = source.Value;
			if (!excludedColumns.Contains(WebConfigurationsTable.UpdateCountCol)) this.UpdateCount = source.UpdateCount;
			if (!excludedColumns.Contains(WebConfigurationsTable.LastUpdatedCol)) this.LastUpdated = source.LastUpdated;
		}
		///	<summary> 
		///		This method copy's each database field which is in the <paramref name="includedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_TakeOnly(IWebConfiguration source, params string[] includedColumns)
		{
			if (includedColumns.Contains(WebConfigurationsTable.PropertyNameCol)) this.PropertyName = source.PropertyName;
			if (includedColumns.Contains(WebConfigurationsTable.ValueCol)) this.Value = source.Value;
			if (includedColumns.Contains(WebConfigurationsTable.UpdateCountCol)) this.UpdateCount = source.UpdateCount;
			if (includedColumns.Contains(WebConfigurationsTable.LastUpdatedCol)) this.LastUpdated = source.LastUpdated;
		}
		
		///	<summary>Creates a new instance of type <see cref="Poco_WebConfiguration" />.</summary>
		public Poco_WebConfiguration AsPoco()
		{
			Poco_WebConfiguration poco = new Poco_WebConfiguration();
			Copy_To(poco, true);
			return poco;
		}
	}
}