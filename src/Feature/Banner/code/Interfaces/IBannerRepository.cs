using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;

namespace EMAAR.ECM.Feature.Banner.Interfaces
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    public interface IBannerRepository
    {
        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// <param name="alignment">Variant</param>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>
        IImageText GetBannerVariants(out Alignment alignment);
    }
}
