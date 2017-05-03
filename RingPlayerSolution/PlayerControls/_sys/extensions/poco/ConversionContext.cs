// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-29</creation-date>
// <modified>2017-04-29 14:18</modify-date>

using System;
using System.Collections.Generic;






namespace PlayerControls._sys.extensions.poco
{
	/// <summary>Ensures that for each instance only one new instance is created.</summary>
	internal class ConversionContext
	{
		private Dictionary<object, object> ConvertedObjects { get; } = new Dictionary<object, object>();

		public bool GetOrCreate<TType>(object o, Func<TType> createFunc, out TType result)
		{
			object val;
			if (ConvertedObjects.TryGetValue(o, out val))
			{
				result = (TType) val;
				return true;
			}

			result = createFunc();
			ConvertedObjects.Add(o, result);
			return false;
		}
	}
}