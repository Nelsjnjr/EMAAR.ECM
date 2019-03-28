#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Interface
{ /// <summary>
  /// This  used to load Footer component
  /// </summary>
    public interface IFooterViewModel
    {
        #region property
        /// <summary>
        /// Getting Footer Menu details from Sitecore
        /// </summary>
        IFooter Footer { get; set; }
        /// <summary>
        /// Getting Logo details from Sitecore SiteRoot item
        /// </summary>
        ILogo Logos { get; set; }
        #endregion

    }
}
