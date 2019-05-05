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

               
                // Events - Get URL from Navigation URL field if available
                
                if ((CheckboxField)item.Fields["Is Events Page"] != null && 
                    !((CheckboxField)item.Fields["Is Events Page"]).Checked)
                {
                    if (SearchHelper.FormatGuid(item.TemplateID.ToString()).Equals(SearchHelper.FormatGuid(CommonConstants.EventsTemplateID))
                    && item.Fields["Navigation URL"] != null && !string.IsNullOrWhiteSpace(item.Fields["Navigation URL"].Value))
                    {
                        LinkField navigationUrl = item.Fields["Navigation URL"];
                        if (navigationUrl != null)
                        {
                            if (!string.IsNullOrEmpty(navigationUrl.Url))
                            {
                                return navigationUrl.Url;
                            }
                            else if (navigationUrl.TargetItem != null)
                            {
                                return SearchHelper.GetURL(navigationUrl.TargetItem);
                            }
                        }

                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    SearchHelper.GetURL(item);
                }
                // Downloads - Get URL from Download Link field if available
                if (SearchHelper.FormatGuid(item.TemplateID.ToString()).Equals(SearchHelper.FormatGuid(CommonConstants.DownloadItemTemplateID))
                    && item.Fields["Download Link"] != null && !string.IsNullOrWhiteSpace(item.Fields["Download Link"].Value))
                {
                    LinkField downloadLink = item.Fields["Download Link"];
                    if (downloadLink != null)
                    {
                        if (!string.IsNullOrEmpty(downloadLink.Url))
                        {
                            return downloadLink.Url;
                        }
                        else if (downloadLink.TargetItem != null)
                        {
                            return SearchHelper.GetURL(downloadLink.TargetItem);
                        }
                    }
                }
                // Video - Get Youtube URL
                if (SearchHelper.FormatGuid(item.TemplateID.ToString()).Equals(SearchHelper.FormatGuid(CommonConstants.VideoItemTemplateID)) && item.Fields["Video"]!=null)
                {
                    LinkField videoField = item.Fields["Video"];
                    if (videoField != null && !string.IsNullOrEmpty(videoField.Url))
                    {
                        string youtubeUrl = SearchHelper.GetYoutubeEmbedUrl(videoField.Url);
                        return youtubeUrl ?? null;                        
                    }
                }

                return SearchHelper.GetURL(item);

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