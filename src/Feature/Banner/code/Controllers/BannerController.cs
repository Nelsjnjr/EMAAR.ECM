using System;
using System.Web.Mvc;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Parameters;
using Glass.Mapper.Sc.Web.Mvc;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;

namespace EMAAR.ECM.Feature.Banner.Controllers
{
    public class BannerController : Controller
    {
        private readonly IMvcContext _mvcContext;
        private readonly IImageText _imageText;
        public BannerController(IMvcContext mvcContext, IImageText imageText)
        {
            _imageText = imageText;
            _mvcContext = mvcContext;
        }
        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// </summary>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>
        public ActionResult Banners()
        {
            IImageText model = _mvcContext.GetDataSourceItem<IImageText>();
            if (model != null)
            {
                ViewBag.Variants = Alignment.Left;//Setting to default to Left ImageText component
                IParametersTemplate_ImageAlignment renderingParameter = _mvcContext.GetRenderingParameters<IParametersTemplate_ImageAlignment>();
                if (renderingParameter != null && renderingParameter.Image_Alignment != Guid.Empty)
                {
                    ISettings settings = _mvcContext.SitecoreService.GetItem<ISettings>(renderingParameter.Image_Alignment);
                    if (Enum.TryParse(settings.Key, out Alignment alignment))
                    {
                        ViewBag.Variants = alignment;
                    }
                }
            }
            return View(model ?? _imageText);
        }
    }
}

