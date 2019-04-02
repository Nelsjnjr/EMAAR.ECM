using System.Web.Optimization;
using EMAAR.ECM.Foundation.Constants;
using Sitecore;
using Sitecore.Pipelines;

namespace EMAAR.ECM.Project.Website.App_Start
{
    public class RegisterPlatformBundles
    {
        [UsedImplicitly]
        public virtual void Process(PipelineArgs args)
        {
            RegisterBundles(BundleTable.Bundles);
          
        }

        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/js/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/vendor").IncludeDirectory("~/js/vendor/", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/main").Include("~/js/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/js/app.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/js/modernizr.js"));
          
            BundleTable.EnableOptimizations = true;

        }

    }
}


