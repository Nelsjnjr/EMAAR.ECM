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
        IFooterViewModel GetFooter();
        #endregion
    }
}
