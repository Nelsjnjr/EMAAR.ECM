using EMAAR.ECM.Foundation.SitecoreExtensions;
using EMAAR.ECM.Foundation.Search.Models;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EMAAR.ECM.Foundation.Search.Helpers
{
    public static class SearchHelper
    {
        /// <summary>
        ///Generic method to create predicate
        /// </summary>
        /// <param name="searchFields">List of Search Fields.</param>
        /// <returns>predicate.</returns>        
        public static Expression<Func<T, bool>> BuildPredicate<T>(List<SearchCondition> searchFields) where T : SearchResultItem
        {
            Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();
            if (searchFields != null && searchFields.Any())
            {
                foreach (SearchCondition searchField in searchFields)
                {
                    if (!string.IsNullOrWhiteSpace(searchField.Name) && !string.IsNullOrWhiteSpace(searchField.Value))
                    {
                        Expression<Func<T, bool>> innerPredicate = PredicateBuilder.False<T>();
                        foreach (string val in searchField.Value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (searchField.CompareType == CompareType.ExactMatch)
                                innerPredicate = innerPredicate.Or(item => item[searchField.Name].Equals(val));
                            else
                                innerPredicate = innerPredicate.Or(item => item[searchField.Name].Contains(val));

                        }

                        predicate = predicate.And<T>(innerPredicate);
                    }

                }

            }
            return predicate;

        }

        /// <summary>
        /// Add basic search conditions.
        /// </summary>
        /// <param name="searchConditions">searchConditions.</param>               
        /// <returns>List of search conditions.</returns>  
        public static List<SearchCondition> AddBasicSearchConditions(List<SearchCondition> searchConditions)
        {
            searchConditions.Add(new SearchCondition() { Name = CommonConstants.Language, Value = Sitecore.Context.Language.Name.ToLower() });
            searchConditions.Add(new SearchCondition() { Name = CommonConstants.Latestversion, Value = "1" });

            return searchConditions;

        }

        /// <summary>
        /// Get Search Index .
        /// </summary>            
        /// <returns>searh index.</returns>
        public static ISearchIndex GetIndex()
        {
            if (Context.Site != null && Context.Database != null)
            {

                return ContentSearchManager.GetIndex(string.Format("sitecore_{0}_index", Context.Database.Name).ToLower());
            }
            else
            {
                return ContentSearchManager.GetIndex("sitecore_master_index");
            }
        }

       


        /// <summary>
        /// Method to format guid - it removes hyphen, braces from th einput string and convert it to lower case
        /// </summary>
        /// <param name="unformattedGuid"></param>
        /// <returns></returns>
        public static string FormatGuid(string unformattedGuid)
        {
            string formattedGuid = string.Empty;
            string[] charactersTobeRemoved = { "-", "{", "}" };
            if (!string.IsNullOrWhiteSpace(unformattedGuid))
            {
                foreach (var character in charactersTobeRemoved)
                {
                    unformattedGuid = unformattedGuid.Replace(character, "");
                }
                formattedGuid = unformattedGuid.Trim().ToLower();
            }
            return formattedGuid;
        }

    }
}