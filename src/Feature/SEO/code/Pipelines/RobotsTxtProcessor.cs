using System.Web;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Foundation.ECM.Content_Types;
using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;

namespace EMAAR.ECM.Feature.SEO.Pipelines
{
    /// <summary>
    /// This class is used to generate robots.txt file dynamically based on the site 
    /// </summary>
    public class RobotsTxtProcessor : HttpRequestProcessor
    {
        /// <summary>
        /// Generating the robots.txt file when robots.txt file is accessed from browser url
        /// </summary>
        /// <param name="args"></param>
        public override void Process(HttpRequestArgs args)
        {
            HttpContext context = HttpContext.Current;

            if (context == null)
            {
                return;
            }
            string requestUrl = context.Request.Url.ToString();
            if (string.IsNullOrEmpty(requestUrl) || !requestUrl.ToLower().EndsWith("robots.txt"))
            {
                return;
            }
            Item SiteRoot = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath);
            string robotsTxtContent = SiteRoot.Fields[I_RobotsConstants.Robots_File_ContentFieldName].Value;
            context.Response.ContentType = "text/plain";
            context.Response.Write(robotsTxtContent);
            context.Response.End();
        }
    }

}
