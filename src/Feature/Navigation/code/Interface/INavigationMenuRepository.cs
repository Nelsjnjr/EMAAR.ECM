#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Interface
{
    /// <summary>
    /// Getting Navigation menus
    /// </summary>
    public interface INavigationMenuRepository
    {
        #region method
        /// <summary>
        /// Getting Header navigation menu along with logo details for the header
        /// </summary>
        /// <returns>Header details</returns>
        IHeaderViewModel GetHeader();
        /// <summary>
        /// Getting Footer navigation menu along with logo details/Contactinfo and LegalPages for the Footer 
        /// </summary>
        /// <returns>Footer details</returns>
        IFooter GetFooter();
        /// <summary>
        /// Getting left navigation menu from Sitecore content tree based on context item's parent with its childs
        /// Also displays only the items which has the options "Include in Left navigation" selected in sitecore
        /// </summary>
        /// <returns>Left navigation</returns>
        ILeftNavigation GetLeftNavigation();
        #endregion
    }
}
