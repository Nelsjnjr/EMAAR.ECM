using EMAAR.ECM.Foundation.ErrorHandling.Helpers;
using EMAAR.ECM.Foundation.ErrorHandling.Interfaces;
using Sitecore.Configuration;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Net;
using System.Web;

namespace EMAAR.ECM.Foundation.ErrorHandling.Pipelines.ErrorRedirect
{
    public class SetErrorStatusCode : HttpRequestBase
    {
        private ILogManager logWrapper;

        public SetErrorStatusCode()
        {
            this.logWrapper = new LogManager();
        }

        protected override void Execute(HttpRequestArgs args)
        {
            // retain 500 response if previously set
            if (HttpContext.Current.Request.Url.AbsolutePath.ToLower().Equals("/error"))
            {
                logWrapper.Warn("Error occured: " + args.Context.Request.RawUrl + ", current status: " + HttpContext.Current.Response.StatusCode, null);
                HttpContext.Current.Response.TrySkipIisCustomErrors = true;
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                HttpContext.Current.Response.StatusDescription = "Error";
                return;
            }
            

            // return if request does not end with value set in ItemNotFoundUrl, i.e. successful page
            if (!args.Context.Request.Url.LocalPath.EndsWith(Settings.ItemNotFoundUrl, StringComparison.InvariantCultureIgnoreCase))
                return;

            logWrapper.Warn("Page Not Found: " + args.Context.Request.RawUrl + ", current status: " + HttpContext.Current.Response.StatusCode,null);
            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
            HttpContext.Current.Response.StatusDescription = "Page not found";
        }
    }
}