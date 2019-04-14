using EMAAR.ECM.Foundation.Search.Models;
using Sitecore.ContentSearch.SearchTypes;
using System.Collections.Generic;

namespace EMAAR.ECM.Foundation.Search.Interfaces
{
    /// <summary>
    /// Contract of generic search methods
    /// </summary>
    public interface ISearchManager
    {
        /// <summary>
        /// Generic Search Method 
        /// </summary>
        /// <param name="searchConditions">search conditions.</param>
        /// <param name="pageNo">Page Number.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <returns>Search Results of Generic Type</returns>  
        SearchResultsGeneric<T> GetSearchResults<T>(List<SearchCondition> searchConditions, List<Facet> facetFields= null, SortOption sortOption = null, int pageNo = -1, int pageSize = -1) where T : SearchResultItem;
    }
}
