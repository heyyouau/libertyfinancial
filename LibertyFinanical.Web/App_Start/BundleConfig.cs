using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;


namespace LibertyFinancial.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

               bundles.Add(new ScriptBundle("~/jquery/foot")
                            .Include("~/Scripts/jquery-1.9.1.js")
                            .Include("~/Scripts/jquery.unobtrusive-ajax.js"));

             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bootstrap")
                            .Include("~/Scripts/bootstrap.js"));


            bundles.Add(new StyleBundle("~/content/css")
                            .Include("~/Content/bootstrap.css")
                            .Include("~/Content/Site.css"));
        }
    }
}