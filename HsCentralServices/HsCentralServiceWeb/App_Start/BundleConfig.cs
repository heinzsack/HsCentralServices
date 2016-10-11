using System.Web;
using System.Web.Optimization;

namespace HsCentralServiceWeb
	{
	public class BundleConfig
		{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/defaultScripts").Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.*", "~/Scripts/bootstrap.*", "~/Scripts/own/NotificationScripts.js"));
			bundles.Add(new StyleBundle("~/bundles/defaultCss").Include("~/Content/bootstrap.*", "~/Content/own/GlyphIcons.css", "~/Content/own/Site.css"));
			}
		}
	}
