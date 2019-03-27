#region namespace
using System;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Community_Metrics;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Related_Content_Slides;
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
        private readonly IRelated_Content_SlideList _related_Content_SlideList ;
        private readonly ICommunity_MetricList _community_MetricList;

        #endregion
        #region construtor
        public BannerRepository(Func<IMvcContext> mvcContext, IImageText imageText, IRelated_Content_SlideList related_Content_SlideList , ICommunity_MetricList community_MetricList )
        {
            _imageText = imageText;
            _mvcContext = mvcContext;
            _related_Content_SlideList = related_Content_SlideList;
            _community_MetricList = community_MetricList;
        
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
        /// <returns>Related content Slides details</returns>
        public IRelated_Content_SlideList RelatedContentSlides()
        {
            IMvcContext mvcContext = _mvcContext();
            IRelated_Content_SlideList relatedContentList = mvcContext.GetDataSourceItem<IRelated_Content_SlideList>();          
            return relatedContentList ?? _related_Content_SlideList;
        }
        /// <summary>
        /// Getting all CommunityMetric component asigned in Sitecore on field (Hero Community Metrics)
        /// </summary>
        /// <returns>HeroBannerList</returns>
        public ICommunity_MetricList GetCommunityMetrics()
        {           
            IMvcContext mvcContext = _mvcContext();
            ICommunity_MetricList heroBannerList = mvcContext.GetDataSourceItem<ICommunity_MetricList>();           
            return heroBannerList ?? _community_MetricList;
        }
        #endregion
        #region private method
 
        #endregion

    }
}