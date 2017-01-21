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
//<date>2017-01-21 20:14:59</date>



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
using Poco_WebConfiguration=HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos.Poco_WebConfiguration;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowpocos
{
	public partial class Poco_WebConfiguration : IWebConfiguration, INotifyPropertyChanged
	{
		private String _propertyName;
		private String _value;
		private Int32 _updateCount;
		private DateTime _lastUpdated;
	
	
	
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>PropertyName</c>] (Type = <c>nvarchar</c>, MaxLength = <c>255</c>) 
		///</summary>
		public String PropertyName 
		{
			get { return _propertyName; }
			set { SetProperty(ref _propertyName, value, nameof(PropertyName)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>Value</c>] (Type = <c>nvarchar</c>, <c>NULLABLE</c>, MaxLength = <c>-1</c>) 
		///</summary>
		public String Value 
		{
			get { return _value; }
			set { SetProperty(ref _value, value, nameof(Value)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>UpdateCount</c>] (Type = <c>int</c>) 
		///</summary>
		public Int32 UpdateCount 
		{
			get { return _updateCount; }
			set { SetProperty(ref _updateCount, value, nameof(UpdateCount)); }
		}
		///<summary> 
		///		[<c>CentralServiceDb</c>].[<c>WebConfigurations</c>].[<c>LastUpdated</c>] (Type = <c>datetime2</c>) 
		///</summary>
		public DateTime LastUpdated 
		{
			get { return _lastUpdated; }
			set { SetProperty(ref _lastUpdated, value, nameof(LastUpdated)); }
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