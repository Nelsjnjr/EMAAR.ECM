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
        ///  ~/Views/Feature/ECM/
        /// </summary>
        public static string ViewPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.FeatureViewPath");
        /// <summary>
        ///  Getting Home page search icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Home/HomePageSearch
        /// </summary>
        public static string HomePageSearch { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.HomePageSearch");
        /// <summary>
        ///  Getting Home page Close icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Home/HomePageClose
        /// </summary>
        public static string HomePageClose { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.HomePageClose");
        /// <summary>
        ///  Getting Content page search icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Content/ContentPageSearch
        /// </summary>
        public static string ContentPageSearch { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.ContentPageSearch");
        /// <summary>
        ///  Getting Content page Close icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Content/ContentPageClose
        /// </summary>
        public static string ContentPageClose { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.ContentPageClose");
        /// <summary>
        ///  Getting Right Arrow icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Common/RightArrow
        /// </summary>
        public static string RightArrow { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.RightArrow");
        /// <summary>
        ///  Getting Srolldown icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Common/scrolldown
        /// </summary>
        public static string Scrolldown { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.Scrolldown");
        /// <summary>
        /// Getting Header item path /Site Content/Navigation/Header
        /// </summary>
        public static string NavigationHeaderPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.NavigationHeaderPath");
        /// <summary>
        /// Getting footer item path Site Content/Navigation/Footer
        /// </summary>
        public static string NavigationFooterPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.NavigationFooterPath");
        /// <summary>
        /// Getting Image location path "Content/Project/ECM/images/"
        /// </summary>
        public static string ImageLocatation { get; set; } = GetSetting("EMAAR.ECM.Foundation.Constants.ImageLocation");
    }
}