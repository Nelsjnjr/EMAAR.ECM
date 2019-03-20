using static Sitecore.Configuration.Settings;
namespace EMAAR.ECM.Feature.Banner.Settings
{
    /// <summary>
    /// This class provides the common setting for Banner projects
    /// </summary>
    public static class SitecoreSettings
    {
        /// <summary>
        /// Physical location of the view path for the action method.
        /// </summary>
        public static string ViewPath { get; set; } = GetSetting("EMAAR.ECM.Feature.Banner.ViewPath");
    }
}