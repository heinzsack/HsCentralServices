using System;
using System.Net;
using System.Web;






namespace HsCentralServiceWeb._sys._extensions
{
	public static class ObjectExtensions
	{
		public static void ThrowNotFound_If_Null<TObjectType>(this TObjectType obj, string message)
		{
			if (obj == null)
			throw new HttpException((int) HttpStatusCode.NotFound, message);
		}
	}
}