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
//<date>2017-02-05 16:40:02</date>



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
using RingPlayer24._dbs.hsserver.ringplayerdb.dataset;
using RingPlayer24._dbs.hsserver.ringplayerdb.tables;
using RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces;
using RingPlayer24._dbs.hsserver.ringplayerdb.rowpocos;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rows
{
	#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	
	///<summary>DataRow([<c>RingPlayerDb</c>].[<c>Texts</c>]): row model of <see cref="TextsTable"/>.</summary>
	[Serializable]
	[DebuggerDisplay("DataRow(RingPlayerDb.Texts): Id = '{Id}'")]
	[CsDbDataRow(Database = "RingPlayerDb", TableName = "Texts", Generated = "17.02.05 16:40:02", Hash = "19A9502B25BD815C9EBF73950F102ABB")]
	public partial class Text : CsDbTableRow, IText
	{
		#region statics
		private static Dictionary<string, System.Reflection.PropertyInfo> _nativeColumnName_To_Property;
		public static Dictionary<string, System.Reflection.PropertyInfo> NativeColumnName_To_Property
		{
			get
			{
				if (_nativeColumnName_To_Property != null)
					return _nativeColumnName_To_Property;
		
				var type = typeof(IText);
				_nativeColumnName_To_Property = new Dictionary<string, System.Reflection.PropertyInfo>
				{
					{ TextsTable.IdCol, type.GetProperty(nameof(Id)) },
					{ TextsTable.PageIdCol, type.GetProperty(nameof(PageId)) },
					{ TextsTable.TextColumnCol, type.GetProperty(nameof(TextColumn)) },
					{ TextsTable.SortOrderCol, type.GetProperty(nameof(SortOrder)) },
					{ TextsTable.MarginThicknessCol, type.GetProperty(nameof(MarginThickness)) },
					{ TextsTable.BorderThicknessCol, type.GetProperty(nameof(BorderThickness)) },
					{ TextsTable.BackgroundCol, type.GetProperty(nameof(Background)) },
					{ TextsTable.BorderColorCol, type.GetProperty(nameof(BorderColor)) },
					{ TextsTable.PaddingCol, type.GetProperty(nameof(Padding)) },
					{ TextsTable.RotationCol, type.GetProperty(nameof(Rotation)) },
					{ TextsTable.ForegroundCol, type.GetProperty(nameof(Foreground)) },
					{ TextsTable.FontFamilyCol, type.GetProperty(nameof(FontFamily)) },
					{ TextsTable.FontWeightCol, type.GetProperty(nameof(FontWeight)) },
					{ TextsTable.FontStyleCol, type.GetProperty(nameof(FontStyle)) },
					{ TextsTable.DiagnosticTextCol, type.GetProperty(nameof(DiagnosticText)) }
				};
		
				return _nativeColumnName_To_Property;
			}
		}
		#endregion
	
	
		public Text(DataRowBuilder builder) : base(builder){}
	
		
		///<summary>References the owning data context, this is equal to the database server. Use this to address databases on the same server.</summary>
		public new RingPlayer24._dbs.hsserver.HsServerContext DataContext => Table.DataContext;
	
		///<summary>References the owning dataset. Use this to address tables in the same database</summary>
		public new RingPlayerDb DataSet => Table.DataSet;
	
		///	<summary>Gets the owning table of type <see cref="TextsTable"/>.</summary>
		public new TextsTable Table => (TextsTable) base.Table;
	
	
	
	
		#region COLUMNS
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>')
		///</summary>
		[CsDbDataColumn(Default = "Guid.NewGuid()")]
		[CsDbNativeDataColumn(Table = "Texts", Name = "Id", Type = "uniqueidentifier", Default = "(newid())", IsNullable = "NO")]
		public Guid Id
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(TextsTable.IdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.IdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>PageId</c>] (Type = <c>uniqueidentifier</c>)
		///</summary>
		[CsDbDataColumn]
		[CsDbNativeDataColumn(Table = "Texts", Name = "PageId", Type = "uniqueidentifier", IsNullable = "NO")]
		public Guid PageId
		{
			[DebuggerStepThrough] get { return GetDbValue<Guid>(TextsTable.PageIdCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.PageIdCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>Text</c>] (Type = <c>nvarchar</c>, MaxLength = <c>2048</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 2048)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "Text", Type = "nvarchar", MaxLength = "2048", IsNullable = "NO")]
		public String TextColumn
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.TextColumnCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.TextColumnCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>SortOrder</c>] (Type = <c>int</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "SortOrder", Type = "int", Default = "((0))", IsNullable = "NO")]
		public Int32 SortOrder
		{
			[DebuggerStepThrough] get { return GetDbValue<Int32>(TextsTable.SortOrderCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.SortOrderCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>MarginThickness</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "MarginThickness", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String MarginThickness
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.MarginThicknessCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.MarginThicknessCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>BorderThickness</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "BorderThickness", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String BorderThickness
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.BorderThicknessCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.BorderThicknessCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>Background</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "Background", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String Background
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.BackgroundCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.BackgroundCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>BorderColor</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "BorderColor", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String BorderColor
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.BorderColorCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.BorderColorCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>Padding</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>256</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 256, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "Padding", Type = "nvarchar", MaxLength = "256", IsNullable = "YES")]
		public String Padding
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.PaddingCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.PaddingCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>Rotation</c>] (Type = <c>float</c>, Default = '<c>((0))</c>')
		///</summary>
		[CsDbDataColumn(Default = 0)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "Rotation", Type = "float", Default = "((0))", IsNullable = "NO")]
		public Double Rotation
		{
			[DebuggerStepThrough] get { return GetDbValue<Double>(TextsTable.RotationCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.RotationCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>Foreground</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "Foreground", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String Foreground
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.ForegroundCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.ForegroundCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>FontFamily</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "FontFamily", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String FontFamily
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.FontFamilyCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.FontFamilyCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>FontWeight</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "FontWeight", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String FontWeight
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.FontWeightCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.FontWeightCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>FontStyle</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>50</c>)
		///</summary>
		[CsDbDataColumn(MaxLength = 50, IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "FontStyle", Type = "nvarchar", MaxLength = "50", IsNullable = "YES")]
		public String FontStyle
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.FontStyleCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.FontStyleCol); }
		}
		///<summary>
		///		[<c>RingPlayerDb</c>].[<c>Texts</c>].[<c>DiagnosticText</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>)
		///</summary>
		[CsDbDataColumn(IsNullable = true)]
		[CsDbNativeDataColumn(Table = "Texts", Name = "DiagnosticText", Type = "nvarchar", MaxLength = "-1", IsNullable = "YES")]
		public String DiagnosticText
		{
			[DebuggerStepThrough] get { return GetDbValue<String>(TextsTable.DiagnosticTextCol); }
			[DebuggerStepThrough] set { SetDbValue(value, TextsTable.DiagnosticTextCol); }
		}
		
		#endregion
	
	
	
	
	
		///	<summary>Reloads the <see cref="Text"/> row by executing following command:<para/><c>$"SELECT * FROM Texts WHERE [Id] = '<see cref="Id"/>'</c></summary>
		public Text Reload()
		{
			Table.DataSet.Texts.LoadThenFind(Id);
			return this;
		}
		
		
		
		
		#region PROPERTIES<Many to One>
		private Page _page;
		public bool IsPageLoaded => (_page == null || _page.RowState != DataRowState.Detached) && Equals(_page?.Id, PageId);
		
		///	<summary>
		///		This field has cached Output.<para/>
		///		<c>SELECT * FROM Pages WHERE [Id] = '<paramref name="PageId"/>'</c><para/>[<c>Texts</c>].[<c>PageId</c>] &#62;&#62;&#62;&#62; [<c>Pages</c>].[<c>Id</c>]
		///	</summary>
		[CsDbResolvesRelation("FK_Texts_Visuals", PkTable = "Pages", PkColumn = "Id", FkTable = "Texts", FkColumn = "PageId")][DependsOn("PageId")]
		public Page Page
		{
			[DebuggerStepThrough]
			get 
			{
				if (IsPageLoaded)
					return _page;
				
				_page = Table.DataSet.Pages.FindOrLoad(PageId);
				return _page;
			}
			[DebuggerStepThrough]
			set 
			{
				if (value == null) throw new InvalidOperationException("The value cannot be null (FK: FK_Texts_Visuals)");
				if (value != null && value.Table.DataSet != Table.DataSet) throw new InvalidOperationException("The owning data set have to be equal.");
				if (value == _page) return;
		
				_page = value;
		
				if (value == null)
					SetDbValue(default(Guid), TextsTable.PageIdCol, "PageId");
				else
					SetDbValue(value.Id, TextsTable.PageIdCol, "PageId");
			}
		}
		#endregion
		
		
		
		
		
		#region PROPERTIES<One to Many>
		
		#endregion
		
		
		
		
		
		#region FUNC<Overrides>
		protected void Invalidate()
		{
			if (!IsPropertyChangedHandled)
				return;
		
			OnPropertyChanged("Id");
			OnPropertyChanged("PageId");
			OnPropertyChanged("TextColumn");
			OnPropertyChanged("SortOrder");
			OnPropertyChanged("MarginThickness");
			OnPropertyChanged("BorderThickness");
			OnPropertyChanged("Background");
			OnPropertyChanged("BorderColor");
			OnPropertyChanged("Padding");
			OnPropertyChanged("Rotation");
			OnPropertyChanged("Foreground");
			OnPropertyChanged("FontFamily");
			OnPropertyChanged("FontWeight");
			OnPropertyChanged("FontStyle");
			OnPropertyChanged("DiagnosticText");
		}
		///	<summary> Set all values which have default values inside the database to their defaults. This method is automatically invoked if you call <see cref="TextsTable.NewRow"/>. </summary>
		public override void ApplyDefaults()
		{
			Id = Guid.NewGuid();
				SortOrder = 0;
				Rotation = 0;
		}
		/// <summary>
		///     Loads the complete data bundle of the current row into a target data set.
		///     <para>A data bundle is defined as a set of all rows inside a database which are connected via relations.</para>
		///     <para>The currently selected row is the root of the bundle</para>
		/// </summary>
		public void Copy_BundledData_Into_DataSet(RingPlayerDb target)
		{
			base.Copy_BundledData_Into_DataSet(target);
		}
		
		
		/// <summary>
		///     Loads the complete data bundle of the current row into a new data set.
		///     <para>A data bundle is defined as a set of rows inside a database which are connected via relations.</para>
		///     <para>The currently selected row is the root of the bundle</para>
		/// </summary>
		public new RingPlayerDb Copy_BundledData_In_New_DataSet(bool cloneCompleteSchema = false)
		{
			return (RingPlayerDb) base.Copy_BundledData_In_New_DataSet(cloneCompleteSchema);
		}
		
		#endregion
		
		
		///	<summary> This method copy's each database field into the <paramref name="target"/> interface. </summary>
		public void Copy_To(IText target, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) target.Id = this.Id;
			target.PageId = this.PageId;
			target.TextColumn = this.TextColumn;
			target.SortOrder = this.SortOrder;
			target.MarginThickness = this.MarginThickness;
			target.BorderThickness = this.BorderThickness;
			target.Background = this.Background;
			target.BorderColor = this.BorderColor;
			target.Padding = this.Padding;
			target.Rotation = this.Rotation;
			target.Foreground = this.Foreground;
			target.FontFamily = this.FontFamily;
			target.FontWeight = this.FontWeight;
			target.FontStyle = this.FontStyle;
			target.DiagnosticText = this.DiagnosticText;
		}
		///	<summary> This method copy's each database field from the <paramref name="source"/> interface to this data row.</summary>
		public void Copy_From(IText source, bool includePrimaryKey = false)
		{
			if (includePrimaryKey) this.Id = source.Id;
			this.PageId = source.PageId;
			this.TextColumn = source.TextColumn;
			this.SortOrder = source.SortOrder;
			this.MarginThickness = source.MarginThickness;
			this.BorderThickness = source.BorderThickness;
			this.Background = source.Background;
			this.BorderColor = source.BorderColor;
			this.Padding = source.Padding;
			this.Rotation = source.Rotation;
			this.Foreground = source.Foreground;
			this.FontFamily = source.FontFamily;
			this.FontWeight = source.FontWeight;
			this.FontStyle = source.FontStyle;
			this.DiagnosticText = source.DiagnosticText;
		}
		///	<summary> 
		///		This method copy's each database field which is not in the <paramref name="excludedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_Ignore(IText source, params string[] excludedColumns)
		{
			if (!excludedColumns.Contains(TextsTable.IdCol)) this.Id = source.Id;
			if (!excludedColumns.Contains(TextsTable.PageIdCol)) this.PageId = source.PageId;
			if (!excludedColumns.Contains(TextsTable.TextColumnCol)) this.TextColumn = source.TextColumn;
			if (!excludedColumns.Contains(TextsTable.SortOrderCol)) this.SortOrder = source.SortOrder;
			if (!excludedColumns.Contains(TextsTable.MarginThicknessCol)) this.MarginThickness = source.MarginThickness;
			if (!excludedColumns.Contains(TextsTable.BorderThicknessCol)) this.BorderThickness = source.BorderThickness;
			if (!excludedColumns.Contains(TextsTable.BackgroundCol)) this.Background = source.Background;
			if (!excludedColumns.Contains(TextsTable.BorderColorCol)) this.BorderColor = source.BorderColor;
			if (!excludedColumns.Contains(TextsTable.PaddingCol)) this.Padding = source.Padding;
			if (!excludedColumns.Contains(TextsTable.RotationCol)) this.Rotation = source.Rotation;
			if (!excludedColumns.Contains(TextsTable.ForegroundCol)) this.Foreground = source.Foreground;
			if (!excludedColumns.Contains(TextsTable.FontFamilyCol)) this.FontFamily = source.FontFamily;
			if (!excludedColumns.Contains(TextsTable.FontWeightCol)) this.FontWeight = source.FontWeight;
			if (!excludedColumns.Contains(TextsTable.FontStyleCol)) this.FontStyle = source.FontStyle;
			if (!excludedColumns.Contains(TextsTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
		}
		///	<summary> 
		///		This method copy's each database field which is in the <paramref name="includedColumns"/> 
		///		from the <paramref name="source"/> interface to this data row.
		/// </summary>
		public void Copy_From_But_TakeOnly(IText source, params string[] includedColumns)
		{
			if (includedColumns.Contains(TextsTable.IdCol)) this.Id = source.Id;
			if (includedColumns.Contains(TextsTable.PageIdCol)) this.PageId = source.PageId;
			if (includedColumns.Contains(TextsTable.TextColumnCol)) this.TextColumn = source.TextColumn;
			if (includedColumns.Contains(TextsTable.SortOrderCol)) this.SortOrder = source.SortOrder;
			if (includedColumns.Contains(TextsTable.MarginThicknessCol)) this.MarginThickness = source.MarginThickness;
			if (includedColumns.Contains(TextsTable.BorderThicknessCol)) this.BorderThickness = source.BorderThickness;
			if (includedColumns.Contains(TextsTable.BackgroundCol)) this.Background = source.Background;
			if (includedColumns.Contains(TextsTable.BorderColorCol)) this.BorderColor = source.BorderColor;
			if (includedColumns.Contains(TextsTable.PaddingCol)) this.Padding = source.Padding;
			if (includedColumns.Contains(TextsTable.RotationCol)) this.Rotation = source.Rotation;
			if (includedColumns.Contains(TextsTable.ForegroundCol)) this.Foreground = source.Foreground;
			if (includedColumns.Contains(TextsTable.FontFamilyCol)) this.FontFamily = source.FontFamily;
			if (includedColumns.Contains(TextsTable.FontWeightCol)) this.FontWeight = source.FontWeight;
			if (includedColumns.Contains(TextsTable.FontStyleCol)) this.FontStyle = source.FontStyle;
			if (includedColumns.Contains(TextsTable.DiagnosticTextCol)) this.DiagnosticText = source.DiagnosticText;
		}
		
		///	<summary>Creates a new instance of type <see cref="Poco_Text" />.</summary>
		public Poco_Text AsPoco()
		{
			Poco_Text poco = new Poco_Text();
			Copy_To(poco, true);
			return poco;
		}
	}
}