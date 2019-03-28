#region namespace
using System;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Feature.Navigation.Settings;
using EMAAR.ECM.Foundation.Constants;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using Glass.Mapper.Sc.Web.Mvc;
using EMAAR.ECM.Foundation.DependencyInjection;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Repositories
{
    /// <summary>
    /// This class is used to provide navigation menu
    /// </summary>
    [Service(typeof(INavigationMenuRepository))]
    public class NavigationMenuRepository : INavigationMenuRepository
    {
        #region Property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly IHeaderViewModel _headerViewModel;
        private readonly IFooterViewModel _footerViewModel;
        private readonly ISitecoreHelper _sitecoreHelper;

        #endregion
        #region constructor
        public NavigationMenuRepository(Func<IMvcContext> mvcContext, IHeaderViewModel headerViewModel, IFooterViewModel footerViewModel, ISitecoreHelper sitecoreHelper)
        {
            _sitecoreHelper = sitecoreHelper;
            _headerViewModel = headerViewModel;
            _footerViewModel = footerViewModel;
            _mvcContext = mvcContext;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting Header navigation menu along with logo details for the header
        /// </summary>
        /// <returns>Header details</returns>
        public IHeaderViewModel GetHeader()
        {
            IMvcContext mvcContext = _mvcContext();
            //Checking the current item is the home item to display the Header based on this
            IHome contextItem = mvcContext.GetContextItem<IHome>();
            if (contextItem.TemplateId.ToString().Equals(SitecoreSettings.HomeTemplateID, StringComparison.InvariantCultureIgnoreCase))
            {
                _headerViewModel.SearchIcon = _sitecoreHelper.HomePageSearch;
                _headerViewModel.CloseIcon = _sitecoreHelper.HomePageClose;
                _headerViewModel.HeaderCss = CommonConstants.HomePageHeaderCss;
            }
            else
            {
                _headerViewModel.SearchIcon = _sitecoreHelper.ContentPageSearch;
                _headerViewModel.CloseIcon = _sitecoreHelper.ContentPageClose;
                _headerViewModel.HeaderCss = CommonConstants.ContentPageHeaderCss;
            }
            _headerViewModel.Header = mvcContext.GetDataSourceItem<IHeader>();
            _headerViewModel.Logos = GetLogo();
            return _headerViewModel;
        }
        /// <summary>
        /// Getting Footer navigation menu along with logo/legal pages and contact info details for the footer
        /// </summary>
        /// <returns>Footer details</returns>
        public IFooterViewModel GetFooter()
        {
            IMvcContext mvcContext = _mvcContext();
            _footerViewModel.Footer = mvcContext.GetDataSourceItem<IFooter>();
            _footerViewModel.Logos = GetLogo();
            return _footerViewModel;
        }
        #endregion
        #region private method
        /// <summary>
        /// Getting logo for the site from Site item
        /// </summary>
        /// <returns>Logo details(brand and site logo with urls)</returns>
        private ILogo GetLogo()
        {
            IMvcContext mvcContext = _mvcContext();
            //Getting Logo from Root Item of the site (eg DowntownDubai)
            return mvcContext.GetRootItem<ILogo>();
        }

        #endregion


    }
}