using System;
using EMAAR.ECM.Foundation.Search.Helpers;
using EMAAR.ECM.Foundation.SitecoreExtensions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Framework.Helper;

namespace EMAAR.ECM.Foundation.Search.ComputedFields
{
    public class ThumbnailUrl : IComputedIndexField
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
        /// Computed field for thumbnailimage url
        /// </summary>
        /// <param name="indexable">IIndexable</param>
        /// <returns>object.</returns>    
        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = null;
            int width = 0;
            int height = 0;
            try
            {
                item = indexable as SitecoreIndexableItem;
                if (item == null)
                {
                    return null;
                }
                string formattedTemplateId = SearchHelper.FormatGuid(item.TemplateID.ToString());
            
                if (formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.NewsTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.ImageItemTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoItemTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.DownloadItemTemplateID)))
                {

                    ImageField imageField = item.Fields["Image"];
                    if (SearchHelper.FormatGuid(item.TemplateID.ToString()).Equals(SearchHelper.FormatGuid(CommonConstants.NewsTemplateID)))
                    {
                        width = 237;
                        height = 257;
                        imageField = item.Fields["Banner"];
                    }
                    else if (SearchHelper.FormatGuid(item.TemplateID.ToString()).Equals(SearchHelper.FormatGuid(CommonConstants.DownloadItemTemplateID)))
                    {
                        width = 237;
                        height = 328;
                    }
                    else
                    {
                        width = 236;
                        height = 148;
                    }                                   
                    return AdvancedImageHelper.GetImageFieldUrl(imageField, width,height).Replace("/sitecore/shell", "") ;
                }
            }

            catch (Exception ex)
            {
                string itemId = string.Empty;
                if (item != null)
                {
                    itemId = item.ID.ToString();
                }

                Sitecore.Diagnostics.Log.Error(GetType().Name + " - Item ID: " + itemId, ex, this);

            }

            return null;
        }

        #endregion

  
    }
}