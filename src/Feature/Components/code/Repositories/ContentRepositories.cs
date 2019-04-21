using System;
using EMAAR.ECM.Feature.ContentComponents.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Amenity;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Faq;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using Glass.Mapper.Sc.Web.Mvc;

namespace EMAAR.ECM.Feature.ContentComponents.Repositories
{
    [Service(typeof(IContentRepositories))]
    public class ContentRepositories : IContentRepositories
    {
        #region property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly IAmenities _amenities;
        private readonly IGeneric_ContentPage _generic;
        private readonly IFaqs _faqs;

        #endregion
        #region construtor
        public ContentRepositories(Func<IMvcContext> mvcContext, IGeneric_ContentPage generic, IAmenities amenities, IFaqs faqs)
        {
            _generic = generic;
            _mvcContext = mvcContext;
            _amenities = amenities;
            _faqs = faqs;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting Content Page details
        /// </summary>
        /// <returns>Content page </returns>
        public IGeneric_ContentPage GetGenericContentPage()
        {
            IMvcContext mvcContext = _mvcContext();
            IGeneric_ContentPage generic = mvcContext.GetContextItem<IGeneric_ContentPage>();
            return generic ?? _generic;

        }
        /// <summary>
        /// Getting all amenities
        /// </summary>
        /// <returns>Amenities</returns>
        public IAmenities GetAmenities()
        {
            IMvcContext mvcContext = _mvcContext();
            IAmenities amenities = mvcContext.GetDataSourceItem<IAmenities>();
            return amenities ?? _amenities;
        }
        /// <summary>
        /// Getting all Faqs
        /// </summary>
        /// <returns>Faqs</returns>
        public IFaqs GetFaqs()
        {
            IMvcContext mvcContext = _mvcContext();
            IFaqs faqs = mvcContext.GetDataSourceItem<IFaqs>();
            return faqs ?? _faqs;
        }
        #endregion
    }
}