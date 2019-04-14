using System.Collections.Generic;
using System.Web.Optimization;
using EMAAR.ECM.Foundation.SitecoreExtensions;
using Sitecore.Pipelines;

namespace EMAAR.ECM.Project.Website.Pipelines
{
    /// <summary>
    /// This class is used to bundle and minify the javacript to make only one HTTP request
    /// </summary>
    public class RegisterPlatformBundles
    {
        public virtual void Process(PipelineArgs args)
        {
            RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// Registering the javascripts to bundle and minify
        /// </summary>
        /// <param name="bundles">javascript bundle</param>
        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle(CommonConstants.JqueryBundleName).Include(CommonConstants.AllJqueryPaths));
            bundles.Add(new ScriptBundle(CommonConstants.JavascriptBundleName).Include(CommonConstants.AllSiteJavascriptsFilePaths));
            #if DEBUG
                //Developer can see individual javascripts
                BundleTable.EnableOptimizations = false;
            #else
                //Minified and Bundled Javascripts
                BundleTable.EnableOptimizations = true;
            #endif
        }

    }
   
}


