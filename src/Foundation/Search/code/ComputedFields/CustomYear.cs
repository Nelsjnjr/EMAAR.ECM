using EMAAR.ECM.Foundation.SitecoreExtensions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Linq;
using System.Collections;
using EMAAR.ECM.Foundation.Search.Helpers;

namespace EMAAR.ECM.Foundation.Search.ComputedFields
{
    public class CustomYear : IComputedIndexField
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
        /// Computed field for year
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

                string formattedTemplateId = SearchHelper.FormatGuid(item.TemplateID.ToString());

                if (formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.ImageAlbumPageTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.ImageItemTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoAlbumPageTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoItemTemplateID)))
                {
                    string query = item.Paths.FullPath + "/ancestor-or-self::*[@@templateid='" + CommonConstants.YearFolderTemplateID + "']";
                    Item yearFolder = item.Database.SelectSingleItem(query);
                    if (yearFolder != null && yearFolder.Fields["Year"] != null)
                    {
                        return Convert.ToInt32(yearFolder.Fields["Year"].Value);
                    }
                }
                else if (formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.NewsTemplateID)) ||
                    formattedTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.EventsTemplateID)))
                {
                    if (item.Fields["Date"] != null && !string.IsNullOrEmpty(item.Fields["Date"].Value))
                    {
                        DateField dt = item.Fields["Date"];
                        return dt.DateTime.Year;

                    }
                    else
                    {

                        string query = item.Paths.FullPath + "/ancestor-or-self::*[@@templateid='" + CommonConstants.YearFolderTemplateID + "']";
                        Item yearFolder = item.Database.SelectSingleItem(query);
                        if (yearFolder != null && yearFolder.Fields["Year"] != null)
                        {
                            return Convert.ToInt32(yearFolder.Fields["Year"].Value);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                string itemId = string.Empty;
                if (item != null)
                    itemId = item.ID.ToString();
                Sitecore.Diagnostics.Log.Error(this.GetType().Name + " - Item ID: " + itemId, ex, this);

            }

            return System.DateTime.Today.Year;
        }

        #endregion

      
    }
}