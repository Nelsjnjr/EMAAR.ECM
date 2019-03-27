#region namespace
using static Sitecore.Configuration.Settings;
#endregion
namespace EMAAR.ECM.Foundation.Constants.Settings
{
    /// <summary>
    /// This class provides the common setting for Banner projects
    /// </summary>
    public static class SitecoreSettings
    {
        /// <summary>
        ///  Getting Root View location for controller to load view
        ///  Physical location of the view path for the action method
        /// </summary>
        public static string ViewPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.ViewPath");
        /// <summary>
        ///  Getting Home page search icon image url from Sitecore settings based on Site
        /// </summary>
        public static string HomePageSearch { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.HomePageSearch");
        /// <summary>
        ///  Getting Home page Close icon image url from Sitecore settings based on Site
        /// </summary>
        public static string HomePageClose { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.HomePageClose");
        /// <summary>
        ///  Getting Content page search icon image url from Sitecore settings based on Site
        /// </summary>
        public static string ContentPageSearch { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.ContentPageSearch");
        /// <summary>
        ///  Getting Content page Close icon image url from Sitecore settings based on Site
        /// </summary>
        public static string ContentPageClose { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.ContentPageClose");
        /// <summary>
        ///  Getting Right Arrow icon image url from Sitecore settings based on Site
        /// </summary>
        public static string RightArrow { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.RightArrow");
        /// <summary>
        ///  Getting Srolldown icon image url from Sitecore settings based on Site
        /// </summary>
        public static string Scrolldown { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.Scrolldown");

    }
}