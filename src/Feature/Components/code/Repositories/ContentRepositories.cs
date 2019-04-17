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

        private readonly IGeneric_ContentPage _generic ;

        #endregion
        #region construtor
        public ContentRepositories(Func<IMvcContext> mvcContext, IGeneric_ContentPage generic)
        {
            _generic = generic;
            _mvcContext = mvcContext;
        }
        #endregion
        #region method
        public IGeneric_ContentPage GetContentPage()
        {
            IMvcContext mvcContext = _mvcContext();
            IGeneric_ContentPage generic = mvcContext.GetContextItem<IGeneric_ContentPage>();
            return generic ?? _generic;

        }
        #endregion
    }
}