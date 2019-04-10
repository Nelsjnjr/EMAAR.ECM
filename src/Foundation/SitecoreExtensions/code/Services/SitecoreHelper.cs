#region namespace
using System;
using EMAAR.ECM.Foundation.SitecoreExtensions.Interfaces;
using EMAAR.ECM.Foundation.SitecoreExtensions.Settings;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Web.Mvc;
#endregion

namespace EMAAR.ECM.Foundation.SitecoreExtensions
{
    /// <summary>
    /// This SitecoreHelper class used to retrieve common data from Sitecore
    /// </summary>
    [Service(typeof(ISitecoreHelper))]
    public class SitecoreHelper : ISitecoreHelper
    {
        #region variable
        private readonly Func<IMvcContext> _mvcContext;
        #endregion
        #region constructor

        public SitecoreHelper(Func<IMvcContext> mvcContext)
        {
            _mvcContext = mvcContext;

        }
        #endregion
        #region property
        /// <summary>
        /// Getting RightArrow image url from Sitecore settings based on Site
        /// </summary>
        public string RightArrow => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.RightArrow}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Scrolldown image url from Sitecore settings based on Site
        /// </summary>
        public string Scrolldown => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.Scrolldown}")?.Image?.Src ?? string.Empty;
        /// <summary>
        ///  Getting Home page search icon image url from Sitecore settings based on Site
        /// </summary>
        public string HomePageSearch => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.HomePageSearch}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Home page Close icon image url from Sitecore settings based on Site
        /// </summary>
        public string HomePageClose => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.HomePageClose}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Content page search icon image url from Sitecore settings based on Site
        /// </summary>
        public string ContentPageSearch => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.ContentPageSearch}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Content page Close icon image url from Sitecore settings based on Site
        /// </summary>
        public string ContentPageClose => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.ContentPageClose}")?.Image?.Src ?? string.Empty;
      
        /// <summary>
        /// Getting Header Navigation details
        /// </summary>
        public IHeader NavigationHeader => _mvcContext()?.SitecoreService.GetItem<IHeader>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.NavigationHeaderPath}");
        /// <summary>
        /// Getting footer navigation details
        /// </summary>
        public IFooter NavigationFooter => _mvcContext()?.SitecoreService.GetItem<IFooter>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.NavigationFooterPath}");
       
        #endregion


    }

}
