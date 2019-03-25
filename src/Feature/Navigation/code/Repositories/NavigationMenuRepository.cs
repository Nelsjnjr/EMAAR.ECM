using System;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Feature.Navigation.Settings;
using EMAAR.ECM.Foundation.ORM.Models;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
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
        private readonly IHeader _header;
        #endregion
        #region constructor
        public NavigationMenuRepository(Func<IMvcContext> mvcContext, IHeader header)
        {
            _header = header;
            _mvcContext = mvcContext;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting Header navigation menu along with logo details for the header
        /// </summary>
        /// <param name="logo">Brand logo,Site logo with urls</param>
        /// <returns>Header details</returns>
        public IHeader GetHeader(out ILogo logo,out bool isHomePage)
        {
            isHomePage = false;
               logo = GetLogo();
            IMvcContext mvcContext = _mvcContext();
            //Checking the current item is the home item to display the Header based on this
            IGlassBase contextItem = mvcContext.GetContextItem<IGlassBase>();
            if(contextItem.TemplateId.ToString().Equals(SitecoreSettings.HomeTemplateID, StringComparison.InvariantCultureIgnoreCase))
            {
                isHomePage = true;
            }
            IHeader header = mvcContext.GetDataSourceItem<IHeader>();
            return header ?? _header;
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