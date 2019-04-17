using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
namespace EMAAR.ECM.Feature.ContentComponents.Settings
{
    public static class SitecoreSettings
    {
        /// <summary>
        /// SiteRoot Template ID
        /// </summary>
        public static string SiteRootTemplateID { get; set; } = ISiteRootConstants.TemplateIdString;
        /// <summary>
        /// Generic Template ID
        /// </summary>
        public static string GenericTemplateID { get; set; } = IGenericConstants.TemplateIdString;
        /// <summary>
        /// CSS Field Name from Siteroot template
        /// </summary>
        public static string SiteRootCSSFieldName { get; set; } = ISiteRootConstants.CSSFileFieldName;

    }
}