#region namespace
using System;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.HeroBanner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.RelatedContent;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Parameters;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Foundation.DependencyInjection;
using static EMAAR.ECM.Foundation.Constants.CommonConstants;
#endregion
namespace EMAAR.ECM.Feature.Banner.Repositories
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    [Service(typeof(IBannerRepository))]
    public class BannerRepository : IBannerRepository
    {
        #region property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly IImageText _imageText;
        private readonly IRelatedContentList _relatedContentList;
        private readonly IHeroBannerList _heroBannerList;

        #endregion
        #region construtor
        public BannerRepository(Func<IMvcContext> mvcContext, IImageText imageText, IRelatedContentList relatedContentList, IHeroBannerList heroBannerList)
        {
            _imageText = imageText;
            _mvcContext = mvcContext;
            _relatedContentList = relatedContentList;
            _heroBannerList = heroBannerList;
        
        }
        #endregion
        #region public method

        /// <summary>
        /// Getting 3 variants of ImageText components(Left,Right and Background)
        /// <param name="alignment">Variant(Left/Right/Background)</param>
        /// <returns>ImageText component variation based on parameter selected from Sitecore</returns>

        public IImageText GetBannerVariants(out Alignment alignment)
        {
            IMvcContext mvcContext = _mvcContext();
            alignment = Alignment.Left;//Assigning default varaiant to left unless if nothing selected in sitecore
            IImageText imageText = mvcContext.GetDataSourceItem<IImageText>();
            if (imageText != null)
            {
                IParametersTemplate_ImageAlignment renderingParameter = mvcContext?.GetRenderingParameters<IParametersTemplate_ImageAlignment>();
                if (renderingParameter?.Image_Alignment!=null)
                {                    
                    Enum.TryParse(renderingParameter.Image_Alignment.Key, out alignment);
                }
            }
            return imageText ?? _imageText;
        }

        /// <summary>
        /// Getting all related component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>
        /// <returns>Related content details</returns>
        public IRelatedContentList GetRelatedContent()
        {
            IMvcContext mvcContext = _mvcContext();
            IRelatedContentList relatedContentList = mvcContext.GetDataSourceItem<IRelatedContentList>();          
            return relatedContentList ?? _relatedContentList;
        }
        /// <summary>
        /// Getting all HeroBanner component asigned in Sitecore on field (Hero Community Metrics)
        /// </summary>
        /// <returns>HeroBannerList</returns>
        public IHeroBannerList GetHeroBanner()
        {           
            IMvcContext mvcContext = _mvcContext();
            IHeroBannerList heroBannerList = mvcContext.GetDataSourceItem<IHeroBannerList>();           
            return heroBannerList ?? _heroBannerList;
        }
        #endregion
        #region private method
 
        #endregion

    }
}