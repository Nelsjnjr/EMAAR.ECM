using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Amenity;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Faq;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;


namespace EMAAR.ECM.Feature.ContentComponents.Interfaces
{
    public interface IContentRepositories
    {
        #region method
        /// <summary>
        /// Getting Content Page details
        /// </summary>
        /// <returns></returns>
        IGeneric_ContentPage GetGenericContentPage();
        /// <summary>
        /// Getting all Amenities
        /// </summary>
        /// <returns>Amenities</returns>
        IAmenities GetAmenities();
        /// <summary>
        /// Getting all Faqs
        /// </summary>
        /// <returns>Faqs</returns>
        IFaqs GetFaqs();
        #endregion

    }
}
