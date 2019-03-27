using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using static Sitecore.Configuration.Settings;

namespace EMAAR.ECM.Feature.Navigation.Settings
{
    public static class SitecoreSettings
    {
        /// <summary>
        /// Home Template ID
        /// </summary>
        public static string HomeTemplateID { get; set; } =  IHomeConstants.TemplateIdString;      

    }
}