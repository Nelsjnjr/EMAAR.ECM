using System.Collections.Generic;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.RelatedContent;

namespace EMAAR.ECM.Feature.Banner.Interfaces
{
    /// <summary>
    /// Relatedcontent viewmodel to load Related content item from sitecore with additional fields
    /// </summary>
    public interface IRelatedContentViewModel
    {
        #region property
        IRelatedContentList RelatedContentList { get; set; }
        List<IRelatedContent> RelatedContent { get; set; }
        int ReletedContentCount { get; set; }
        #endregion
    }
}
