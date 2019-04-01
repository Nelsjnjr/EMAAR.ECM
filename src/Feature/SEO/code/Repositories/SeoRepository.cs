using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMAAR.ECM.Feature.SEO.Interfaces;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using Glass.Mapper.Sc.Web.Mvc;

namespace EMAAR.ECM.Feature.SEO.Repositories
{
    public class SeoRepository : ISeoRepository
    {
        #region Property
        private readonly Func<IMvcContext> _mvcContext;

        private readonly ISitecoreHelper _sitecoreHelper;

        #endregion
        #region constructor
        public SeoRepository(Func<IMvcContext> mvcContext, ISitecoreHelper sitecoreHelper)
        {
            _sitecoreHelper = sitecoreHelper;

            _mvcContext = mvcContext;
        }
        #endregion
        public ISiteRoot GetSEO()
        {
            IMvcContext mvcContext = _mvcContext();
            return mvcContext.GetRootItem<ISiteRoot>();
        }
    }
}