using System;
using EMAAR.ECM.Feature.SEO.Interfaces;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Foundation.ECM.Base;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Web.Mvc;

namespace EMAAR.ECM.Feature.SEO.Repositories
{
    /// <summary>
    /// This is used to set SEO functionalities
    /// </summary>
    [Service(typeof(ISeoRepository))]
    public class SeoRepository : ISeoRepository
    {
        #region Property
        private readonly Func<IMvcContext> _mvcContext;
        #endregion
        #region constructor
        public SeoRepository(Func<IMvcContext> mvcContext)
        {
            _mvcContext = mvcContext;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting page metadata
        /// </summary>
        /// <returns>Metadata/OG/Twitter,Canonical and hreflang</returns>
        public I_PageBase GetSeo()
        {
            IMvcContext mvcContext = _mvcContext();
            return mvcContext.GetContextItem<I_PageBase>();
        }
        #endregion
    }
}