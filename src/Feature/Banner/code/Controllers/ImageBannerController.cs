#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Hero;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Homepage_carousel;
using static EMAAR.ECM.Foundation.Constants.Settings.SitecoreSettings;
#endregion
namespace EMAAR.ECM.Feature.ImageBanner.Controllers
{
    /// <summary>
    /// This controller is used for loading ImageText component
    /// </summary>
    public class ImageBannerController : Controller
    {
        #region Private property
        private readonly IImageBannerRepository _bannerRepository;
        private readonly ISitecoreHelper _sitecoreHelper;
        #endregion

        #region construtor
        public ImageBannerController(IImageBannerRepository bannerRepository, ISitecoreHelper sitecoreHelper)
        {
            _bannerRepository = bannerRepository;
            _sitecoreHelper = sitecoreHelper;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting 2 variants of ImageText components(Left,Right )
        /// </summary>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>
        public ActionResult ImageText()
        {
            IImageText imageText = _bannerRepository.GetImageText();
            ViewBag.RightArrow = _sitecoreHelper.RightArrow;
            return View($"{ViewPath}Banner/ImageText/ImageText.cshtml", imageText);
        }
        /// <summary>
        /// Getting 2 variants of Parallax components(background image )
        /// </summary>
        /// <returns>Parallax</returns>
        public ActionResult Parallax()
        {
            IParallax parallax = _bannerRepository.GetParallax();
            ViewBag.RightArrow = _sitecoreHelper.RightArrow;
            return View($"{ViewPath}Banner/Parallax/Parallax.cshtml", parallax);
        }
        /// <summary>
        /// Getting all related component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>  
        /// <returns>Relatedcontent list</returns>
        public ActionResult HomePageCarousels()
        {
            IHomepage_Carousels homepage_CarouselList = _bannerRepository.HomePageCarousels();
            return View($"{ViewPath}Banner/HomePageCarousel/HomePageCarousel.cshtml", homepage_CarouselList);
        }
        /// <summary>
        ///  Getting all Hero Banner asigned in Sitecore 
        /// </summary>
        /// <returns>HeroBannerList</returns>
        public ActionResult GetHero()
        {
            IHero hero = _bannerRepository.GetHero();
            ViewBag.Scrolldown = _sitecoreHelper.Scrolldown;
            return View($"{ViewPath}Banner/Hero/Hero.cshtml", hero);
        }
        #endregion
    }
}

