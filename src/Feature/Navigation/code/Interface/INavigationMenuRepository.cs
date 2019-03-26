using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

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
        /// <param name="logo">Brand logo,Site logo with urls</param>
        /// <returns>Header details</returns>
        IHeaderViewModel GetHeader();
        #endregion
    }
}
