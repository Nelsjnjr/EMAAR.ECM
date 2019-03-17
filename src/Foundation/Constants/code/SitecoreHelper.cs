using System;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Foundation.DependencyInjection;

namespace EMAAR.ECM.Foundation.Constants
{
    /// <summary>
    /// This SitecoreHelper class used to retrieve common data from Sitecore
    /// </summary>
    [Service(typeof(ISitecoreHelper))]
    public class SitecoreHelper : ISitecoreHelper
    {
        private readonly Func<IMvcContext> _mvcContext;

        public SitecoreHelper(Func<IMvcContext> mvcContext, INavigationArrow navigationArrow)
        {
            _mvcContext = mvcContext;

        }
        /// <summary>
        /// Getting RightArrow image url from Sitecore based on Site
        /// </summary>
        public string RightArrow => _mvcContext()?.SitecoreService.GetItem<INavigationArrow>
            ($"{Sitecore.Context.Site.RootPath}/Settings/Navigation Arrow/RightArrow")?.Image?.Src ?? string.Empty;
    }

}
