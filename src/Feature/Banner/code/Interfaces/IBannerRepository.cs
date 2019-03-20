﻿#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.HeroBanner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.RelatedContent;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;
#endregion
namespace EMAAR.ECM.Feature.Banner.Interfaces
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    public interface IBannerRepository
    {
        #region method
        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// <param name="alignment">Variant</param>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>
        IImageText GetBannerVariants(out Alignment alignment);
        /// <summary>
        /// Getting all related component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>
        /// <returns>Related content details</returns>
        IRelatedContentList GetRelatedContent();
        /// <summary>
        /// Getting all HeroBanner component asigned in Sitecore on field (Hero Community Metrics)
        /// </summary>
        /// <returns>HeroBannerList</returns>
        IHeroBannerList GetHeroBanner();
        #endregion
    }
}
