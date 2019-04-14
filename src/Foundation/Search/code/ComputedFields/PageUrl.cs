using EMAAR.ECM.Foundation.SitecoreExtensions;
using EMAAR.ECM.Foundation.Search.Helpers;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Web;
using System;

namespace EMAAR.ECM.Foundation.Search.ComputedFields
{
    public class PageUrl : IComputedIndexField
    {

        #region Properties
        public string FieldName
        {
            get; set;
        }

        public string ReturnType
        {
            get; set;
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Computed field for page url
        /// </summary>
        /// <param name="indexable">IIndexable</param>
        /// <returns>object.</returns>    
        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = null;

            try
            {
                item = indexable as SitecoreIndexableItem;
                if (item == null)
                {
                    return null;
                }

                if (SearchHelper.FormatGuid(item.TemplateID.ToString()).Equals(SearchHelper.FormatGuid(CommonConstants.VideoItemTemplateID)) && item.Fields["Video"]!=null)
                {
                    LinkField videoField = item.Fields["Video"];
                    if (videoField != null && !string.IsNullOrEmpty(videoField.Url))
                    {
                        string youtubeUrl = SearchHelper.GetYoutubeEmbedUrl(videoField.Url);
                        return youtubeUrl ?? null;                        
                    }
                }

                UrlOptions urlOption = new UrlOptions();
                urlOption.Language = item.Language;

                string link = LinkManager.GetItemUrl(item, urlOption);
                SiteInfo siteInfo = SearchHelper.GetSiteInfo(item);
                string currentSiteStartItemPath = siteInfo.RootPath + siteInfo.StartItem;
                if (!string.IsNullOrWhiteSpace(link))
                {
                    if (link.Contains("/content/"))
                    {
                        return link.Replace("/shell", string.Empty).Replace(currentSiteStartItemPath, string.Empty);
                    }
                    else
                    {
                        currentSiteStartItemPath = currentSiteStartItemPath.Replace("/content", string.Empty);
                        return link.Replace("/shell", string.Empty).Replace(currentSiteStartItemPath, string.Empty);
                    }
                    
                }
                return link;

            }



            catch (Exception ex)
            {
                string itemId = string.Empty;
                if (item != null)
                    itemId = item.ID.ToString();
                Sitecore.Diagnostics.Log.Error(this.GetType().Name + " - Item ID: " + itemId, ex, this);

            }

            return null;
        }

        #endregion

      
    }
}