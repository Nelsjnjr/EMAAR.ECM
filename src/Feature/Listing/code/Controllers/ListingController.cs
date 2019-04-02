using EMAAR.ECM.Foundation.Search.Interfaces;
using EMAAR.ECM.Foundation.Search.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EMAAR.ECM.Feature.Listing.Controllers
{
    public class ListingController : Controller
    {
        #region Private property

        private readonly ISearchManager _searchManager;

        #endregion

        #region constructor

        /// <summary>
        /// Listing Controller constructor
        /// </summary>
        /// <param name="searchManager">ISearchManager object</param>
        public ListingController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
            
        }
        #endregion

        /// <summary>
        /// Generic method to get search results
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>
        /// <param name="type">type</param>        
        /// <returns>json string.</returns>   
        public string GetSearchResults(int pageNumber=-1, int pageSize=-1, string filter="", string type="")
        {
            List<SearchCondition> conditions = new List<SearchCondition>();
            conditions.Add(new SearchCondition() { Name = "_templatename", Value = "*", CompareType = CompareType.PartialMatch });
            conditions.Add(new SearchCondition() { Name = "_name", Value = "*", CompareType = CompareType.PartialMatch });


            List<Facet> facets = new List<Facet>();

            facets.Add(new Facet() { facetField = "_template",  allLabel = "All Templates", minCount=1 });
            facets.Add(new Facet() { facetField = "_group", allLabel = "All Ids", minCount=1 });

            SearchResultsGeneric<ListingSearchResultItem> results = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets,null,pageNumber,pageSize);
            return JsonConvert.SerializeObject(results, Formatting.None);
            
        }
    }
}