using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;

namespace EMAAR.ECM.Feature.Banner.Interfaces
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    public interface IBannerRepository
    {
        IImageText GetBannerVariants(out Alignment alignment);
    }
}
