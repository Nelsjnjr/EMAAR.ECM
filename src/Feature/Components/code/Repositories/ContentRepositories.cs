using System;
using EMAAR.ECM.Feature.ContentComponents.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using Glass.Mapper.Sc.Web.Mvc;

namespace EMAAR.ECM.Feature.ContentComponents.Repositories
{
    [Service(typeof(IContentRepositories))]
    public class ContentRepositories : IContentRepositories
    {
        #region property
        private readonly Func<IMvcContext> _mvcContext;

        private readonly IGeneric _generic ;

        #endregion
        #region construtor
        public ContentRepositories(Func<IMvcContext> mvcContext, IGeneric generic)
        {
            _generic = generic;
            _mvcContext = mvcContext;
        }
        #endregion
        #region method
        public IGeneric GetContentPage()
        {
            IMvcContext mvcContext = _mvcContext();
            IGeneric generic = mvcContext.GetContextItem<IGeneric>();
            return generic ?? _generic;

        }
        #endregion
    }
}