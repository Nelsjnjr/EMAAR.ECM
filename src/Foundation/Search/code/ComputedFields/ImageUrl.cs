using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;

namespace EMAAR.ECM.Foundation.Search.ComputedFields
{
    public class ImageUrl : IComputedIndexField
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
        /// Computed field for image url
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

                 ImageField imageField = item.Fields["Image"];
                    if (imageField != null && imageField.MediaItem != null)
                    {
                        MediaUrlOptions mediaUrlOption = new MediaUrlOptions();
                        mediaUrlOption.Language = item.Language;
                        string imageUrl = MediaManager.GetMediaUrl(imageField.MediaItem, mediaUrlOption);
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            imageUrl = imageUrl.Replace("/sitecore/shell", "");
                        }

                        return imageUrl;
                    }
                
            }

            catch (Exception ex)
            {
                string itemId = string.Empty;
                if (item != null)
                    itemId = item.ID.ToString();
                Sitecore.Diagnostics.Log.Error(this.GetType().Name + " - Item ID: " + itemId, ex,this);
             
            }

            return null;
        }

        #endregion

      
    }
}