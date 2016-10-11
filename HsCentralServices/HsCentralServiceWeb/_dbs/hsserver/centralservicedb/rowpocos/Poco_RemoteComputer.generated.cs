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
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowinterfaces;
using Poco_RemoteComputer=HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos.Poco_RemoteComputer;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos
{
	public partial class Poco_RemoteComputer : IRemoteComputer, INotifyPropertyChanged
	{
		private Guid _id;
		private String _name;
		private String _osName;
		private String _osRegisteredUser;
		private String _osCountryCode;
		private String _osCodeSet;
		private String _osProductType;
		private String _manufacturer;
		private String _model;
		private String _family;
		private String _skuNumber;
		private String _biosName;
		private String _biosVersion;
		private String _mainboardManufacturer;
		private String _mainboardProduct;
	
	
	
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>Id</c>] (Type = <c>uniqueidentifier</c>, Default = '<c>(newid())</c>') 
		///</summary>
		public Guid Id 
		{
			get { return _id; }
			set { SetProperty(ref _id, value, nameof(Id)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>Name</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String Name 
		{
			get { return _name; }
			set { SetProperty(ref _name, value, nameof(Name)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>OsName</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String OsName 
		{
			get { return _osName; }
			set { SetProperty(ref _osName, value, nameof(OsName)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>OsRegisteredUser</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String OsRegisteredUser 
		{
			get { return _osRegisteredUser; }
			set { SetProperty(ref _osRegisteredUser, value, nameof(OsRegisteredUser)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>OsCountryCode</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String OsCountryCode 
		{
			get { return _osCountryCode; }
			set { SetProperty(ref _osCountryCode, value, nameof(OsCountryCode)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>OsCodeSet</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String OsCodeSet 
		{
			get { return _osCodeSet; }
			set { SetProperty(ref _osCodeSet, value, nameof(OsCodeSet)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>OsProductType</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String OsProductType 
		{
			get { return _osProductType; }
			set { SetProperty(ref _osProductType, value, nameof(OsProductType)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>Manufacturer</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String Manufacturer 
		{
			get { return _manufacturer; }
			set { SetProperty(ref _manufacturer, value, nameof(Manufacturer)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>Model</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String Model 
		{
			get { return _model; }
			set { SetProperty(ref _model, value, nameof(Model)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>Family</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String Family 
		{
			get { return _family; }
			set { SetProperty(ref _family, value, nameof(Family)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>SkuNumber</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String SkuNumber 
		{
			get { return _skuNumber; }
			set { SetProperty(ref _skuNumber, value, nameof(SkuNumber)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>BiosName</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String BiosName 
		{
			get { return _biosName; }
			set { SetProperty(ref _biosName, value, nameof(BiosName)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>BiosVersion</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String BiosVersion 
		{
			get { return _biosVersion; }
			set { SetProperty(ref _biosVersion, value, nameof(BiosVersion)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>MainboardManufacturer</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String MainboardManufacturer 
		{
			get { return _mainboardManufacturer; }
			set { SetProperty(ref _mainboardManufacturer, value, nameof(MainboardManufacturer)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>RemoteComputers</c>].[<c>MainboardProduct</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String MainboardProduct 
		{
			get { return _mainboardProduct; }
			set { SetProperty(ref _mainboardProduct, value, nameof(MainboardProduct)); }
		}
		
	
	
	
	
	
	
	#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		///     Implementation of the <see cref="INotifyPropertyChanged" /> interface. Checks whether the backing field
		///     already provides this reference or value. If backing field provides the same value, no notification is sent, if you
		///     want to force a notification use <see cref="OnPropertyChanged" />
		/// </summary>
		/// <typeparam name="T">the generic controller, used to provide intellisense feature.</typeparam>
		/// <param name="backingField">The backing field where the property stores the reference</param>
		/// <param name="value">The new value.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		protected virtual bool SetProperty<T>(ref T backingField, T value, string propertyName)
		{
			if (Equals(backingField, value))
				return false;
	
			backingField = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		/// <summary>Sends a notification to <see cref="PropertyChanged" /> subscriber.</summary>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler onPropertyChanged = PropertyChanged;
			if (onPropertyChanged != null)
			{
				onPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	#endregion
	}
}