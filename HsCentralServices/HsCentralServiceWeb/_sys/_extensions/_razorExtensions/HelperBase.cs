using System;
using System.Threading;
using System.Web.Mvc;






namespace HsCentralServiceWeb._sys._extensions._razorExtensions
{
	public abstract class HelperBase
	{
		protected HelperBase(AjaxHelper helper)
		{
			_ajax = helper;
		}

		protected HelperBase(HtmlHelper helper)
		{
			_html = helper;
		}

		protected AjaxHelper Ajax => _ajax ?? (_ajax = new AjaxHelper(Html.ViewContext, Html.ViewDataContainer, Html.RouteCollection));
		protected UrlHelper Url => _url ?? (_url = _ajax == null ? new UrlHelper(_html.ViewContext.RequestContext, _html.RouteCollection) : new UrlHelper(_ajax.ViewContext.RequestContext, _ajax.RouteCollection));
		protected HtmlHelper Html => _html ?? (_html = new HtmlHelper(Ajax.ViewContext, Ajax.ViewDataContainer, Ajax.RouteCollection));

		protected bool IsAjax => Ajax.ViewContext.HttpContext.Request.IsAjaxRequest();

		protected void Write(string s)
		{
			Ajax.ViewContext.Writer.Write(s);
		}
		private static int _lastId;
		public string GetUniqueId()
		{
			int increment = Interlocked.Increment(ref _lastId);
			return "UID" + increment;
		}
		private HtmlHelper _html;
		private UrlHelper _url;
		private AjaxHelper _ajax;
	}
}