#region namespace
using System;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.HeroBanner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.RelatedContent;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Foundation.DependencyInjection;
#endregion

namespace EMAAR.ECM.Foundation.Constants
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

        public SitecoreHelper(Func<IMvcContext> mvcContext, INavigationArrow navigationArrow)
        {
            _mvcContext = mvcContext;

        }
        #endregion
        #region property
        /// <summary>
        /// Getting RightArrow image url from Sitecore settings based on Site
        /// </summary>
        public string RightArrow => _mvcContext()?.SitecoreService.GetItem<INavigationArrow>
            ($"{Sitecore.Context.Site.RootPath}{CommonConstants.ArrowPath}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Scrolldown image url from Sitecore settings based on Site
        /// </summary>
        public string Scrolldown => _mvcContext()?.SitecoreService.GetItem<INavigationArrow>
            ($"{Sitecore.Context.Site.RootPath}{CommonConstants.ScrolldownPath}")?.Image?.Src ?? string.Empty;
        #endregion

    }

}
