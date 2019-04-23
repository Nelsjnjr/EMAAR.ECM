#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Mediacenter;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Settings
{
    public static class SitecoreSettings
    {
        #region Constants
        /// <summary>
        /// Home Template ID
        /// </summary>
        public const string HomeTemplateID  =  IHomeConstants.TemplateIdString;
        /// <summary>
        /// Navigable Template ID
        /// </summary>
        public const string NavigableTemplateID = INavigableConstants.TemplateIdString;
        /// <summary>
        /// Content Page template ID
        /// </summary>
        public const string GenericContentRootPageTemplateID = IGenericContentRootPageConstants.TemplateIdString;
        /// <summary>
        /// Generic ContentPage Template ID
        /// 
        /// </summary>
        public const string GenericContentPageTemplateID  = IGeneric_ContentPageConstants.TemplateIdString;
        /// <summary>
        /// Mediacenter Template ID
        /// </summary>
        public const string MediaCenterTemplateID  = IMediacenterConstants.TemplateIdString;
        #endregion
    }
}