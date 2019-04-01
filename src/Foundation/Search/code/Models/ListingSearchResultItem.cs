using Newtonsoft.Json;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace EMAAR.ECM.Foundation.Search.Models
{
    /// <summary>
    /// ListingSearchResultItem class definition
    /// </summary>
    public class ListingSearchResultItem : SearchResultItem
    {
        [JsonProperty]
        [IndexField("Title")]
        public string title { get; set; }

        [JsonProperty]
        [IndexField("description")]
        public string description { get; set; }

        [JsonProperty]
        [IndexField("date")]
        public string date { get; set; }

        [JsonProperty]
        [IndexField("PageURL")]
        public string pageUrl { get; set; }

        [JsonProperty]
        [IndexField("imageurl")]
        public string imageUrl { get; set; }

        [JsonProperty]
        [IndexField("ImageAltText")]
        public string imageAlttext { get; set; }

        [JsonProperty]
        [IndexField("externalURL")]
        public string externalURL { get; set; }

        [JsonProperty]
        [IndexField("showPlayIcon")]
        public bool showPlayIcon { get; set; }


        [IndexField("Value")]
        public string value { get; set; }
    }
}