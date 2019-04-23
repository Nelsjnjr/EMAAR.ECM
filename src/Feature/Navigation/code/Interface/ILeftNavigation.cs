#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Interface
{
    public interface ILeftNavigation
    {
        #region property
        /// <summary>
        /// Current Context item
        /// </summary>
        INavigable CurrentNavigationItem { get; set; }
        /// <summary>
        /// Parent item of the Context item based on the template(Mediacenter,Generic contentpage and contentpage)
        /// </summary>
        INavigable ParentNavigationItem { get; set; }
        #endregion

    }
}