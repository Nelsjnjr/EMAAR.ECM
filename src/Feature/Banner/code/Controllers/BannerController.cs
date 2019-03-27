#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Community_Metrics;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Related_Content_Slides;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;
using static EMAAR.ECM.Foundation.Constants.Settings.SitecoreSettings;
#endregion
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
            return View($"{ViewPath}Banner/ImageText/ImageText.cshtml", imageText);
        }
        /// <summary>
        /// Getting all related component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>  
        /// <returns>Relatedcontent list</returns>
        public ActionResult RelatedContentSlides()
        {
            IRelated_Content_SlideList related_Content_SlideList = _bannerRepository.RelatedContentSlides();
            return View($"{ViewPath}Banner/RelatedContentSlides/RelatedContentSlide.cshtml", related_Content_SlideList);
        }
        /// <summary>
        ///  Getting all Hero Banner asigned in Sitecore 
        /// </summary>
        /// <returns>HeroBannerList</returns>
        public ActionResult GetCommunityMetrics()
        {
            ICommunity_MetricList community_MetricList  = _bannerRepository.GetCommunityMetrics();
            ViewBag.Scrolldown= _sitecoreHelper.Scrolldown;
            return View($"{ViewPath}Banner/CommunityMetrics/CommunityMetric.cshtml", community_MetricList);
        }
        #endregion
    }
}

