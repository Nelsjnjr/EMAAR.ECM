#region namespace
using static Sitecore.Configuration.Settings;
#endregion
namespace EMAAR.ECM.Foundation.SitecoreExtensions.Settings
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
        public static string ViewPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.FeatureViewPath");
        /// <summary>
        ///  Getting Home page search icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Home/HomePageSearch
        /// </summary>
        public static string HomePageSearch { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.HomePageSearch");
        /// <summary>
        ///  Getting Home page Close icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Home/HomePageClose
        /// </summary>
        public static string HomePageClose { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.HomePageClose");
        /// <summary>
        ///  Getting Content page search icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Content/ContentPageSearch
        /// </summary>
        public static string ContentPageSearch { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.ContentPageSearch");
        /// <summary>
        ///  Getting Content page Close icon image url from Sitecore settings based on Site
        ///  /Site Settings/Site Specific Images/Content/ContentPageClose
        /// </summary>
        public static string ContentPageClose { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.ContentPageClose");
        /// <summary>
        /// Getting Header item path /Site Content/Navigation/Header
        /// </summary>
        public static string NavigationHeaderPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.NavigationHeaderPath");
        /// <summary>
        /// Getting footer item path Site Content/Navigation/Footer
        /// </summary>
        public static string NavigationFooterPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.NavigationFooterPath");
        /// <summary>
        /// Getting Image location path "Assets/Project/ECM/images/"
        /// </summary>
        public static string ImageLocatation { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.ImageLocation");
        /// <summary>
        /// Getting Image location path "~/Assets/Project/ECM/images/icon/"
        /// </summary>
        public static string IconRootPath { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.IconRootPath");

        /// <summary>
        /// Getting date format
        /// </summary>
        public static string DateFormat { get; set; } = GetSetting("EMAAR.ECM.Foundation.SitecoreExtensions.DateFormat");
    }
}