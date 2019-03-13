using System.Web.Mvc;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using Glass.Mapper.Sc.Web.Mvc;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;

namespace EMAAR.ECM.Feature.Banner.Controllers
{
    /// <summary>
    /// This controller is used for loading ImageText component
    /// </summary>
    public class BannerController : Controller
    {     
        private readonly IBannerRepository _bannerRepository;
        public BannerController( IBannerRepository bannerRepository)
        {  
            _bannerRepository = bannerRepository;
        }
        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// </summary>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>
        public ActionResult Banners()
        {
            IImageText imageText = _bannerRepository.GetBannerVariants(out Alignment alignment);
            ViewBag.Variants = alignment;
            return View(imageText);
        }
    }
}

