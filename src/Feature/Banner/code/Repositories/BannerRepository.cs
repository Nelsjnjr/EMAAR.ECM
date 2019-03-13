using System;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Parameters;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Foundation.DependencyInjection;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;

namespace EMAAR.ECM.Feature.Banner.Repositories
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    [Service(typeof(IBannerRepository))]
    public class BannerRepository : IBannerRepository
    {
        private readonly IMvcContext _mvcContext;
        private readonly IImageText _imageText;
        public BannerRepository(IMvcContext mvcContext, IImageText imageText)
        {
            _imageText = imageText;
            _mvcContext = mvcContext;
        }
        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// <param name="alignment">Variant</param>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>

        public IImageText GetBannerVariants(out Alignment alignment)
        {
            alignment = Alignment.Left;//Assigning default varaiant to left unless if nothing selected in sitecore
            IImageText model = _mvcContext.GetDataSourceItem<IImageText>();
            if (model != null)
            {
                IParametersTemplate_ImageAlignment renderingParameter = _mvcContext.GetRenderingParameters<IParametersTemplate_ImageAlignment>();
                if (renderingParameter != null && renderingParameter.Image_Alignment != Guid.Empty)
                {
                    ISettings settings = _mvcContext.SitecoreService.GetItem<ISettings>(renderingParameter.Image_Alignment);
                    Enum.TryParse(settings.Key, out alignment);
                }
            }
            return model ?? _imageText;
        }
    }
}