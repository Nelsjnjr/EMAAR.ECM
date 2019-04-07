#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.SEO.Interfaces;
using static EMAAR.ECM.Foundation.Constants.Settings.SitecoreSettings;
#endregion

namespace EMAAR.ECM.Feature.SEO.Controllers
{
    public class SeoController : Controller
    {
        #region Private property
        private readonly ISeoRepository _seoRepository;
        #endregion
        #region construtor    
        public SeoController(ISeoRepository seoRepository)
        {
            _seoRepository = seoRepository;
        }
        #endregion
        #region method
        /// <summary>
        /// Getting page metadata
        /// </summary>
        /// <returns>Metadata/OG/Twitter,Canonical and hreflang</returns>
        public ActionResult GetSeo()
        {
            return View($"{ViewPath}SEO/Seo.cshtml", _seoRepository.GetSeo());
        }
        #endregion
    }
}