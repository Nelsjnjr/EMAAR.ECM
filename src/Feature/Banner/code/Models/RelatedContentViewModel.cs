using System.Collections.Generic;
using EMAAR.ECM.Feature.Banner.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.RelatedContent;
using Sitecore.Foundation.DependencyInjection;

namespace EMAAR.ECM.Feature.Banner.Models
{
    /// <summary>
    /// Relatedcontent viewmodel to load Related content item from sitecore with additional fields
    /// </summary>
    [Service(typeof(IRelatedContentViewModel))]
    public class RelatedContentViewModel: IRelatedContentViewModel
    {
        #region property
        public IRelatedContentList RelatedContentList { get; set; }
        public List<IRelatedContent> RelatedContent { get; set; }
        public int ReletedContentCount { get; set; }
        #endregion

    }
}