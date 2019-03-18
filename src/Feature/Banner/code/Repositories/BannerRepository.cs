using System;
using System.Collections.Generic;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Banner;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.RelatedContent;
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
        #region property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly IImageText _imageText;
        private readonly IRelatedContentViewModel _relatedContentViewModel;

        #endregion
        #region construtor
        public BannerRepository(Func<IMvcContext> mvcContext, IImageText imageText, IRelatedContentViewModel relatedContentViewModel)
        {
            _imageText = imageText;
            _mvcContext = mvcContext;
            _relatedContentViewModel = relatedContentViewModel;

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
            IImageText model = mvcContext.GetDataSourceItem<IImageText>();
            if (model != null)
            {
                IParametersTemplate_ImageAlignment renderingParameter = mvcContext?.GetRenderingParameters<IParametersTemplate_ImageAlignment>();
                if (renderingParameter != null && renderingParameter.Image_Alignment != Guid.Empty)
                {
                    ISettings settings = mvcContext.SitecoreService.GetItem<ISettings>(renderingParameter.Image_Alignment);
                    Enum.TryParse(settings.Key, out alignment);
                }
            }
            return model ?? _imageText;
        }

        /// <summary>
        /// Getting all related component asigned in Sitecore with the Background CSS (eg:explore)
        /// </summary>
        /// <returns>Related content details</returns>
        public IRelatedContentViewModel GetRelatedContent()
        {
            IMvcContext mvcContext = _mvcContext();
            IRelatedContentList model = mvcContext.GetDataSourceItem<IRelatedContentList>();
            IRelatedContentViewModel relatedContentViewModel = null;
            if (model != null)
            {
                relatedContentViewModel = MapRelatedContent(model);

            }
            return relatedContentViewModel ?? _relatedContentViewModel;
        }
        #endregion
        #region private method
        /// <summary>
        /// Mapping the view model for RelatedContent
        /// </summary>
        /// <param name="model">Passing RelatedContentList to map to RelatedContentViewModel</param>
        /// <returns>RelatedContentViewModel</returns>
        private IRelatedContentViewModel MapRelatedContent(IRelatedContentList model)
        {
            int count = 0;
            List<IRelatedContent> reletedContents = new List<IRelatedContent>();
            IMvcContext mvcContext = _mvcContext(); 
            //Getting all related content from Multilist
            foreach (Guid item in model.RelatedContents)
            {
                count++;
                reletedContents.Add(mvcContext.SitecoreService.GetItem<IRelatedContent>(item));
            }
            _relatedContentViewModel.RelatedContentList = model;
            _relatedContentViewModel.RelatedContent = reletedContents;
            _relatedContentViewModel.ReletedContentCount = count;
            return _relatedContentViewModel;
        }
        #endregion

    }
}