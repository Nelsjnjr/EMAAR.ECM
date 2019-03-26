﻿using System;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Feature.Navigation.Settings;
using EMAAR.ECM.Foundation.Constants;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Foundation.DependencyInjection;

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
        public NavigationMenuRepository(Func<IMvcContext> mvcContext, IHeaderViewModel headerViewModel, ISitecoreHelper sitecoreHelper)
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
            IGlassBase contextItem = mvcContext.GetContextItem<IGlassBase>();
            if (contextItem.TemplateId.ToString().Equals(SitecoreSettings.HomeTemplateID, StringComparison.InvariantCultureIgnoreCase))
            {
                _headerViewModel.SearchIcon = _sitecoreHelper.HomePageSearch;
                _headerViewModel.CloseIcon = _sitecoreHelper.HomePageClose;
                _headerViewModel.HomeCss = CommonConstants.HomePageHeaderCss;
            }
            else
            {
                _headerViewModel.SearchIcon = _sitecoreHelper.ContentPageSearch;
                _headerViewModel.CloseIcon = _sitecoreHelper.ContentPageClose;
                _headerViewModel.HomeCss = CommonConstants.ContentPageHeaderCss;
            }
            _headerViewModel.Header = mvcContext.GetDataSourceItem<IHeader>();
            _headerViewModel.Logos = GetLogo();
            return _headerViewModel;
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