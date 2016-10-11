using System;
using System.Web.Mvc;
using System.Web.Routing;
using JetBrains.Annotations;






namespace HsCentralServiceWeb._sys._extensions._razorExtensions
{
	public static class CsMvcBaseHtmlAjaxExtension
	{
		public static HtmlAjaxExtensions Cs(this AjaxHelper helper) => new HtmlAjaxExtensions(helper);
	}



	public class HtmlAjaxExtensions : HelperBase
	{
		public HtmlAjaxExtensions(AjaxHelper helper) : base(helper)
		{
		}

		public CsAjaxForm Form([AspMvcAction] string action, [AspMvcController] string controller = null, object routeValues = null, bool autoOpen = true)
		{
			return new CsAjaxForm(Ajax, action, controller, routeValues == null ? null : HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues), autoOpen);
		}
	}
	public class CsAjaxForm : HelperBase, IDisposable
	{
		private readonly bool _autoOpen;
		private readonly TagBuilder _ajaxForm;
		private readonly TagBuilder _clearDiv;
		private readonly TagBuilder _container;
		private readonly TagBuilder _loadingDiv;
		private bool _isEnded;
		private bool _isStarted;

		public CsAjaxForm(AjaxHelper helper, [AspMvcAction] string action, [AspMvcController] string controller, RouteValueDictionary routeValueDictionary = null, bool autoOpen = true) : base(helper)
		{
			Id = GetUniqueId();
			LoadingId = GetUniqueId();

			_autoOpen = autoOpen;
			_container = new TagBuilder("div");
			_container.MergeAttribute("style", "position:relative;");

			_ajaxForm = new TagBuilder("form");
			_ajaxForm.GenerateId(Id);
			_ajaxForm.AddCssClass("cs-ajax");
			_ajaxForm.MergeAttribute("action", Url.Action(action, controller, routeValueDictionary));
			_ajaxForm.MergeAttribute("data-ajax", "true");
			_ajaxForm.MergeAttribute("data-ajax-loading", $"#{LoadingId}");
			_ajaxForm.MergeAttribute("data-ajax-loading-duration", $"200");
			_ajaxForm.MergeAttribute("data-ajax-method", $"Post");
			_ajaxForm.MergeAttribute("data-ajax-mode", $"replace");
			_ajaxForm.MergeAttribute("data-ajax-success", $"$.validator.unobtrusive.parse($('#{Id}'));");
			_ajaxForm.MergeAttribute("data-ajax-update", $"#{Id}");
			_ajaxForm.MergeAttribute("method", $"post");

			_loadingDiv = new TagBuilder("div");
			_loadingDiv.GenerateId(LoadingId);
			_loadingDiv.AddCssClass("cs-ajax-overlay");

			_clearDiv = new TagBuilder("div");
			_clearDiv.AddCssClass("clearfix");



			if(_autoOpen)
				Begin();



		}


		#region Overrides/Interfaces
		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			End();
		}
		#endregion


		public string LoadingId { get; }
		public string Id { get; }

		public CsAjaxForm Begin()
		{
			if(IsAjax || _isStarted)
				return this;
			_isStarted = true;
			Write(_container.ToString(TagRenderMode.StartTag));
			Write(_ajaxForm.ToString(TagRenderMode.StartTag));
			return this;
		}

		private void End()
		{
			if(IsAjax || _isEnded)
				return;
			_isEnded = true;
			Write(_ajaxForm.ToString(TagRenderMode.EndTag));
			Write(_loadingDiv.ToString());
			Write(_clearDiv.ToString());
			Write(_container.ToString(TagRenderMode.EndTag));
		}
	}
}