using System.Collections.Generic;
using System.Web.Optimization;
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
            Bundle scriptBundle = new ScriptBundle("~/bundles/jquery")
                .Include("~/js/modernizr.js")
                        .Include("~/js/jquery.js")
                        .Include("~/js/vendor/bootstrap.js")
                        .Include("~/js/vendor/swiper.js")
                        .Include("~/js/app.js")
                        .Include("~/js/main.js");

            scriptBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(scriptBundle);
            BundleTable.EnableOptimizations = true;
        }

    }
    public sealed class AsIsBundleOrderer : IBundleOrderer
    {

        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)

        {

            return files;

        }

    }
}


