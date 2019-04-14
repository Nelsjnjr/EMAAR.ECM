#region namespace
using System;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Feature.Navigation.Settings;
using EMAAR.ECM.Foundation.SitecoreExtensions;
using EMAAR.ECM.Foundation.SitecoreExtensions.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using Glass.Mapper.Sc.Web.Mvc;
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
        private readonly ISitecoreHelper _sitecoreHelper;

        #endregion
        #region constructor
        public NavigationMenuRepository(Func<IMvcContext> mvcContext, IHeaderViewModel headerViewModel, IFooter footer, ISitecoreHelper sitecoreHelper)
        {
            _sitecoreHelper = sitecoreHelper;
            _headerViewModel = headerViewModel;          
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
                _headerViewModel.IsHomePage = true;
            }
            else
            {
                _headerViewModel.SearchIcon = _sitecoreHelper.ContentPageSearch;
                _headerViewModel.CloseIcon = _sitecoreHelper.ContentPageClose;
                _headerViewModel.HeaderCss = CommonConstants.ContentPageHeaderCss;
                _headerViewModel.IsHomePage = false;
            }
            _headerViewModel.Header = _sitecoreHelper.NavigationHeader;

            return _headerViewModel;
        }
        /// <summary>
        /// Getting Footer navigation menu along with logo/legal pages and contact info details for the footer
        /// </summary>
        /// <returns>Footer details</returns>
        public IFooter GetFooter()
        {
            return _sitecoreHelper.NavigationFooter;
        }
        #endregion
      


    }
}