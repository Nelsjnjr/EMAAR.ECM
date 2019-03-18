using System.Web.Mvc;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;

namespace EMAAR.ECM.Feature.Banner.Controllers
{
    /// <summary>
    /// This controller is used for loading ImageText component
    /// </summary>
    public class BannerController : Controller
    {
        #region Private property
        private readonly IBannerRepository _bannerRepository;
        private readonly ISitecoreHelper _sitecoreHelper;
        #endregion

        #region construtor
        public BannerController(IBannerRepository bannerRepository, ISitecoreHelper sitecoreHelper)
        {
            _bannerRepository = bannerRepository;
            _sitecoreHelper = sitecoreHelper;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// </summary>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>
        public ActionResult ImageText()
        {
            IImageText imageText = _bannerRepository.GetBannerVariants(out Alignment alignment);
            ViewBag.Variants = alignment;
            ViewBag.RightArrow = _sitecoreHelper.RightArrow;
            return View("~/Views/Banner/ImageText/ImageText.cshtml", imageText);
        }
        /// <summary>
        /// Getting all related component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>  
        /// <returns>Relatedcontent list</returns>
        public ActionResult RelatedContent()
        {
            IRelatedContentViewModel relatedContentList = _bannerRepository.GetRelatedContent();
            return View("~/Views/Banner/RelatedContent/RelatedContent.cshtml", relatedContentList);
        }
        #endregion
    }
}

