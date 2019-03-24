using static Sitecore.Configuration.Settings;

namespace EMAAR.ECM.Feature.Map.Settings
{
    public static class SitecoreSettings
    {
        /// <summary>
        /// Physical location of the view path for the action method.
        /// </summary>
        public static string ViewPath { get; set; } = GetSetting("EMAAR.ECM.Feature.Map.ViewPath");
    }
}