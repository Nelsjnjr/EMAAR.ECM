using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Page_Types;
using static Sitecore.Configuration.Settings;

namespace EMAAR.ECM.Feature.Navigation.Settings
{
    public static class SitecoreSettings
    {
        /// <summary>
        /// Physical location of the view path for the action method.
        /// </summary>
        public static string ViewPath { get; set; } = GetSetting("EMAAR.ECM.Feature.Navigation.ViewPath");
        /// <summary>
        /// Home Template ID
        /// </summary>
        public static string HomeTemplateID { get; set; } =  IHomeConstants.TemplateIdString;

    }
}