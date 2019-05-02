#region namespace
using System;
using System.Web.Mvc;
using EMAAR.ECM.Feature.ContentComponents.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Amenity;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Faq;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Related_Pages;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using static EMAAR.ECM.Foundation.SitecoreExtensions.Settings.SitecoreSettings;
#endregion

namespace EMAAR.ECM.Feature.ContentComponents.Controllers
{
    public class ContentComponentsController : Controller
    {
        #region Private property
        private readonly IContentRepositories _contentRepositories;
        #endregion
        #region construtor
        public ContentComponentsController(IContentRepositories contentRepositories)
        {
          
            _contentRepositories = contentRepositories;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting Content Page details Discovery-->Al alka
        /// </summary>
        /// <returns>Content Page </returns>
        public ActionResult GetGenericContentPage()
        {
            IGeneric_ContentPage generic = _contentRepositories.GetGenericContentPage(out string date);
            if(!String.IsNullOrEmpty(date))
            {
                ViewBag.Date = date;
            }
            return View($"{ViewPath}ContentPage/ContentPage.cshtml", generic);
        }
        /// <summary>
        /// Getting all Ammenities selected for the page
        /// </summary>
        /// <returns>Amenities</returns>
        public ActionResult GetAmenities()
        {
            IAmenities amenities = _contentRepositories.GetAmenities();
            
            return View($"{ViewPath}ContentPage/Amenities/_Amenities.cshtml", amenities?.Page_Amenities??null);
        }
        /// <summary>
        /// Getting all Faqs selected for the page
        /// </summary>
        /// <returns>Faqs</returns>
        public ActionResult GetFaqs()
        {
            IFaqs faqs  = _contentRepositories.GetFaqs();
            return View($"{ViewPath}ContentPage/Faqs/_Faqs.cshtml", faqs?.Page_Faqs??null);
        }
        /// <summary>
        /// Getting all related pages asigned in Sitecore
        /// </summary>  
        /// <returns>Relatedpages</returns>
        public ActionResult RelatedPages()
        {
            IRelated_Pages related_Pages  = _contentRepositories.RelatedPages();
            return View($"{ViewPath}ContentPage/RelatedPages/_RelatedPages.cshtml", related_Pages);
        }
        #endregion
    }
}