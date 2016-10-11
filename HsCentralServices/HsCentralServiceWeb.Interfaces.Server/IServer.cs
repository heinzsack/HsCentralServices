// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;






namespace HsCentralServiceWebInterfacesServer
{
	public interface IServer
	{
		#region Abstract
		/// <summary>Stores the <paramref name="obj" /> under the specified key into the current running server instance.</summary>
		/// <param name="key">A unique key for the <paramref name="obj" />.</param>
		/// <param name="obj">The obj which needs to be stored in RAM.</param>
		void Save(object key, object obj);

		/// <summary>Searches the currently stored instances for the specified key. If no such key is found null will be returned.</summary>
		/// <param name="key">The key of the requested object.</param>
		object Load(object key);

		/// <summary>Searches the currently stored instances for the specified key. If no such key is found null will be returned.</summary>
		/// <param name="key">The key of the requested object.</param>
		TCast Load<TCast>(object key);
		#endregion
	}
}