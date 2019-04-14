using Newtonsoft.Json;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace EMAAR.ECM.Foundation.Search.Models
{
    /// <summary>
    /// ListingSearchResultItem class definition
    /// </summary>
    [Serializable]
    public class ListingSearchResultItem : SearchResultItem
    {
        [JsonProperty]
        [IndexField("title")]
        public string title { get; set; }

        [JsonProperty]
        [IndexField("description")]
        public string description { get; set; }

        [JsonProperty]
        [IndexField("date")]
        public string date { get; set; }

        [JsonProperty]
        [IndexField("pageurl")]
        public string pageUrl { get; set; }

        [JsonProperty]
        [IndexField("imageurl")]
        public string imageUrl { get; set; }

        [JsonProperty]
        [IndexField("imagealttext")]
        public string imageAlttext { get; set; }

        [JsonProperty]
        [IndexField("externalurl")]
        public string externalURL { get; set; }

        [JsonProperty]
        [IndexField("showplayicon")]
        public bool showPlayIcon { get; set; }


        [IndexField("Value")]
        public string value { get; set; }

        [JsonProperty]
        [IndexField("_indexname")]
        public string IndexName { get; set; }

        
        [IndexField("images_sm")]
        public List<string> images { get; set; }

        [IndexField("videos_sm")]
        public List<string> videos { get; set; }

    }
}