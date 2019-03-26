using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.Navigation.Interface
{ /// <summary>
  /// This  used to load header component
  /// </summary>
    public interface IHeaderViewModel
    {
        /// <summary>
        /// Getting Header Menu details from Sitecore
        /// </summary>
        IHeader Header { get; set; }
        /// <summary>
        /// Getting Logo details from Sitecore SiteRoot item
        /// </summary>
        ILogo Logos { get; set; }
        /// <summary>
        /// Getting Search Icon
        /// </summary>
        string SearchIcon { get; set; }
        /// <summary>
        /// Getting Close icon
        /// </summary>
        string CloseIcon { get; set; }
        /// <summary>
        /// Getting Header CSS Class name
        /// </summary>
        string HeaderCss { get; set; }
    }
}
