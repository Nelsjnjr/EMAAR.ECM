using System;
using System.Collections.Generic;
using System.Linq;
using EMAAR.ECM.Feature.Listing.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Parameters;
using EMAAR.ECM.Foundation.Search.Helpers;
using EMAAR.ECM.Foundation.Search.Interfaces;
using EMAAR.ECM.Foundation.Search.Models;
using EMAAR.ECM.Foundation.SitecoreExtensions;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace EMAAR.ECM.Feature.Listing.Repositories
{
    [Service(typeof(IListingRepository))]
    public class ListingRepository : IListingRepository
    {

        #region Property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly ISearchManager _searchManager;
        private readonly IImage_Gallery_Page _imageGallery;
        private readonly IImage_Album _imageAlbum;
        private readonly IVideo_Gallery_Page _videoGallery;
        private readonly IVideo_Album_Without_Filters _videoAlbum;
        private readonly INews_Listing_Page _newsModel;
        private readonly IEvents_Listing_Page _eventsModel;
        private readonly IDownloads_Page _downloadsModel;
      //  private readonly ISearchPage _searchPageModel;
        
        #endregion

        #region constructor
        public ListingRepository(Func<IMvcContext> mvcContext, ISearchManager searchManager, IImage_Gallery_Page imageGallery, IImage_Album imageAlbum,
            IVideo_Gallery_Page videoGallery, IVideo_Album_Without_Filters videoAlbum, INews_Listing_Page newsModel, IEvents_Listing_Page eventsModel, IDownloads_Page downloadsModel)
        {
            _mvcContext = mvcContext;
            _searchManager = searchManager;
            _imageGallery = imageGallery;
            _imageAlbum = imageAlbum;
            _videoGallery = videoGallery;
            _videoAlbum = videoAlbum;
            _newsModel = newsModel;
            _eventsModel = eventsModel;
            _downloadsModel = downloadsModel;
          
        }
        #endregion
        #region method


        /// <summary>
        /// Method to get listing model
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>   
        /// <param name="parentItemId">Parent id when directly access Folder item</param>       
        /// <returns>SearchResultsGeneric<ListingSearchResultItem> </returns>   
        public SearchResultsGeneric<ListingSearchResultItem> GetListingModel(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "", string listItemTemplateId = "", bool showFilters = false, string parentItemId = "")
        {
            List<SearchCondition> yearFolderparentSearchCondition = new List<SearchCondition>();
            listItemTemplateId = SearchHelper.FormatGuid(listItemTemplateId);
            SearchResultsGeneric<ListingSearchResultItem> resultsList = new SearchResultsGeneric<ListingSearchResultItem>();
            SearchResultsGeneric<ListingSearchResultItem> parentResultsList = new SearchResultsGeneric<ListingSearchResultItem>();
            ID id = null;
            //This is used when the context item from folder template for SEO, so get its parent listing page as context item
            if (!string.IsNullOrEmpty(parentItemId) && !string.IsNullOrEmpty(filter))
            {
                Sitecore.Data.ID.TryParse(parentItemId, out id);
            }
            else//Context item id
            {
                Sitecore.Data.ID.TryParse(itemId, out id);
            }

            if (id.IsNull)
            {
                return resultsList;
            }      
            Item parent = null;

            if (!string.IsNullOrEmpty(parentItemId) && string.IsNullOrEmpty(filter))
            {
                //Filter from parent items
                parent = Sitecore.Context.Database.GetItem(parentItemId);
                yearFolderparentSearchCondition = new List<SearchCondition>
                {
                    new SearchCondition() { Name = CommonConstants.TemplateID, Value =listItemTemplateId , CompareType = CompareType.ExactMatch },
                    new SearchCondition() { Name = Sitecore.ContentSearch.BuiltinFields.Path, Value = SearchHelper.FormatGuid(parentItemId.ToString()), CompareType = CompareType.ExactMatch }
                };
            }
            //Filter current context item childs
            List<SearchCondition> conditions = new List<SearchCondition>
            {
                new SearchCondition() { Name = CommonConstants.TemplateID, Value = listItemTemplateId, CompareType = CompareType.ExactMatch },
                new SearchCondition() { Name = Sitecore.ContentSearch.BuiltinFields.Path, Value = SearchHelper.FormatGuid(id.ToString()), CompareType = CompareType.ExactMatch }
            };

            //Get Events of only current year
            if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.EventsTemplateID)))
            {
                conditions.Add(new SearchCondition() { Name = CommonConstants.YearFacetField, Value = DateTime.UtcNow.Year.ToString(), CompareType = CompareType.ExactMatch });
            }
            yearFolderparentSearchCondition = SearchHelper.AddFilterConditions(filter, yearFolderparentSearchCondition);
            conditions = SearchHelper.AddFilterConditions(filter, conditions);
            List<Facet> facets = new List<Facet>();

            //Facets not required From second request, 
            if (pageNumber <= 0 && showFilters)
            {
                // Add Year facet except events and downloads
                if (!listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.EventsTemplateID)) &&
                    !listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.DownloadItemTemplateID)))
                {
                    facets.Add(new Facet() { facetField = CommonConstants.YearFacetField, allLabel = Sitecore.Globalization.Translate.Text(CommonConstants.AllYearsKey), minCount = 1 });
                }

                // Add Categories facet except Image items (Image Album page)
                if (!listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.ImageItemTemplateID)))
                {
                    facets.Add(new Facet() { facetField = CommonConstants.CategoriesFacetField, allLabel = Sitecore.Globalization.Translate.Text(CommonConstants.AllCategoriesKey), minCount = 1 });
                }
            }


            //Sort Option
            if (parent != null && (parent.TemplateID.Equals(Sitecore.Data.ID.Parse(CommonConstants.NewsListingPageTemplateID)) ||
               parent.TemplateID.Equals(Sitecore.Data.ID.Parse(CommonConstants.EventsListingPageTemplateID))||
               parent.TemplateID.Equals(Sitecore.Data.ID.Parse(CommonConstants.ImageGalleryPageTemplateID))||
               parent.TemplateID.Equals(Sitecore.Data.ID.Parse(CommonConstants.VideoGalleryTemplateID))||
               parent.TemplateID.Equals(Sitecore.Data.ID.Parse(CommonConstants.VideoAlbumWithFiltersTemplateID))))
            {               
                parentResultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(yearFolderparentSearchCondition, facets, null, 0, 0, false, true, true);
                resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets, null, pageNumber, pageSize, false, true);
            }
            else if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.NewsTemplateID)))
            {
                resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets, null, pageNumber, pageSize, false, true);
            }
            else if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.EventsTemplateID)))
            {
                resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets, null, pageNumber, pageSize, false, false, true);
            }
            else if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.DownloadItemTemplateID)))
            {
                SortOption sortOption = new SortOption()
                {
                    SortFieldName = CommonConstants.CustomSortorder,
                    SortOrder = SortOrder.Ascending

                };
                resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets, sortOption, pageNumber, pageSize, false, false, false);
            }
            else
            {
                resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets, null, pageNumber, pageSize, true, false);
            }


            //Adding filter "Event Type"(Upcoming and Past events)
            if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.EventsTemplateID)) &&
                pageNumber <= 0 && resultsList != null && resultsList.filters != null)
            {
                List<FilterValues> filterValues = new List<FilterValues>
                {
                    new FilterValues() { id = CommonConstants.AllEvents, label = Sitecore.Globalization.Translate.Text(CommonConstants.AllEvents) },
                    new FilterValues() { id = CommonConstants.Upcoming, label = Sitecore.Globalization.Translate.Text(CommonConstants.UpcomingEvents) },
                    new FilterValues() { id = CommonConstants.Past, label = Sitecore.Globalization.Translate.Text(CommonConstants.PastEvents) }
                };
                resultsList.filters.Add(new Filters() { filterLabel = CommonConstants.EventType, filterValues = filterValues });

            }
            if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.ImageAlbumPageTemplateID)) ||
            listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoAlbumWithoutFiltersTemplateID)) ||
            listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoAlbumWithFiltersTemplateID)))
            {
                string contentItemTemplateId = string.Empty;
                if (listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoAlbumWithoutFiltersTemplateID)) ||
                    listItemTemplateId.Equals(SearchHelper.FormatGuid(CommonConstants.VideoAlbumWithFiltersTemplateID)))
                {
                    contentItemTemplateId = CommonConstants.VideoItemTemplateID;
                }
                else
                {
                    contentItemTemplateId = CommonConstants.ImageItemTemplateID;
                }         

            }
            //Changing the filter based on the template selected(whether it is folder page or listing page)
            if (!string.IsNullOrEmpty(parentItemId) && parentResultsList.filters != null)
            {

                resultsList.filters = parentResultsList.filters;
            }
            return resultsList;


        }


        #region Image Gallery

        /// <summary>
        /// Method to get image gallery
        /// </summary>       
        /// <returns>IImage_Gallery_Page<ListingSearchResultItem> </returns> 
        public IImage_Gallery_Page GetImageGallery()
        {
            IMvcContext mvcContext = _mvcContext();
            IImage_Gallery_Page imageGallery = mvcContext.GetContextItem<IImage_Gallery_Page>();
            return imageGallery ?? _imageGallery;
        }


        #endregion


        #region Image Album

        /// <summary>
        /// Method to get image album 
        /// </summary>             
        /// <returns>IImage_Album<ListingSearchResultItem></returns>   
        public IImage_Album GetImageAlbum()
        {
            IMvcContext mvcContext = _mvcContext();
            IImage_Album imageAlbum = mvcContext.GetContextItem<IImage_Album>();
            return imageAlbum ?? _imageAlbum;
        }




        #endregion


        #region Video Gallery

        public IVideo_Gallery_Page GetVideoGalleryModel()
        {
            IMvcContext mvcContext = _mvcContext();
            IVideo_Gallery_Page VideoGallery = mvcContext.GetContextItem<IVideo_Gallery_Page>();
            return VideoGallery ?? _videoGallery;
        }
        #endregion


        #region Video Album

        public IVideo_Album_Without_Filters GetVideoAlbumsModel(out bool ShowFilters)
        {
            IMvcContext mvcContext = _mvcContext();
            IVideo_Album_Without_Filters VideoAlbum = mvcContext.GetContextItem<IVideo_Album_Without_Filters>();
            ShowFilters = mvcContext.GetRenderingParameters<IShowfilters>().Show_Filters;
            return VideoAlbum ?? _videoAlbum;
        }



        #endregion


        #region News

        /// <summary>
        /// Method to get news model
        /// </summary>       
        /// <returns>INews_Listing_Page<ListingSearchResultItem> </returns> 
        public INews_Listing_Page GetNewsListingPageModel()
        {
            IMvcContext mvcContext = _mvcContext();
            INews_Listing_Page newsModel = mvcContext.GetContextItem<INews_Listing_Page>();
            return newsModel ?? _newsModel;
        }

        #endregion


        #region Events

        /// <summary>
        /// Method to get Events model
        /// </summary>       
        /// <returns>IEvents_Listing_Page<ListingSearchResultItem> </returns> 
        public IEvents_Listing_Page GetEventsListingPageModel(out string Year)
        {
            Year = string.Empty;
            IMvcContext mvcContext = _mvcContext();
            IEvents_Listing_Page eventsModel = mvcContext.GetContextItem<IEvents_Listing_Page>();
            if (mvcContext.ContextItem.TemplateID.Equals(ID.Parse(CommonConstants.EventsYearFolderTemplateID)))
            {
                Year = mvcContext.ContextItem.Name;
            }
            return eventsModel ?? _eventsModel;
        }

        #endregion

        #region Downloads

        /// <summary>
        /// Method to get downloads model
        /// </summary>       
        /// <returns>IDownloads_Page<ListingSearchResultItem> </returns> 
        public IDownloads_Page GetDownloadsListingPageModel()
        {
            IMvcContext mvcContext = _mvcContext();
            IDownloads_Page downloadsModel = mvcContext.GetContextItem<IDownloads_Page>();
            return downloadsModel ?? _downloadsModel;
        }

        #endregion

        #region Search

        /// <summary>
        /// Method to get listing model
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>        
        /// <returns>SearchResultsGeneric<ListingSearchResultItem> </returns>   
        //public SearchResultsGeneric<ListingSearchResultItem> GetSearchResultsModel(int pageNumber = -1, int pageSize = -1, string searchTerm = "*")
        //{

        //    List<SearchCondition> conditions = new List<SearchCondition>
        //    {
        //        //new SearchCondition() { Name = CommonConstants.TitleIndexField, Value = searchTerm, CompareType = CompareType.PartialMatch, AddORcondition=true },
        //        //new SearchCondition() { Name = CommonConstants.IntroductionIndexField, Value = searchTerm, CompareType = CompareType.PartialMatch,AddORcondition=true },
        //        //new SearchCondition() { Name = CommonConstants.ContentIndexField, Value = searchTerm, CompareType = CompareType.PartialMatch,AddORcondition=true },
        //        //new SearchCondition() { Name = CommonConstants.RenderingsContentIndexField, Value = searchTerm, CompareType = CompareType.PartialMatch,AddORcondition=true },
        //        //new SearchCondition() { Name = CommonConstants.PageUrl , Value = string.Empty, CompareType = CompareType.IsNotNull }
        //    };


        //    conditions = SearchHelper.AddFilterConditions("", conditions);

        //    SearchResultsGeneric<ListingSearchResultItem> resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, null, null, pageNumber, pageSize, false, false);

        //    if (searchTerm !="*" && resultsList != null && resultsList.results != null && resultsList.results.results != null && resultsList.results.results.Count > 0)
        //    {
        //        int count = 0;
        //        foreach (var listItem in resultsList.results.results)
        //        {
        //            resultsList.results.results[count].title = HighlightKeywords(resultsList.results.results[count].title, searchTerm);
        //            resultsList.results.results[count].description = HighlightKeywords(resultsList.results.results[count].description, searchTerm);
        //            if (!resultsList.results.results[count].description.Contains("<mark>"))
        //            {
        //                resultsList.results.results[count].description = HighlightKeywords(resultsList.results.results[count].Content, searchTerm);
        //            }
        //            count++;
        //        }

        //    }

        //    return resultsList;
        //}

        /// <summary>
        /// Method to get downloads model
        /// </summary>       
        /// <returns>IDownloads_Page<ListingSearchResultItem> </returns> 
        ////public ISearchPage GetSearchPageModel()
        ////{
        ////    IMvcContext mvcContext = _mvcContext();
        ////    ISearchPage searchPageModel = mvcContext.GetContextItem<ISearchPage>();
        ////    return searchPageModel ?? _searchPageModel;
        ////}


       // protected string HighlightKeywords(string input, string term)
       // {
       //     if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(term))
       //         return string.Empty;

       ////     return Regex.Replace(input, term,
       ////match => "<mark>" + match.Value + "</mark>",
       ////RegexOptions.Compiled | RegexOptions.IgnoreCase);

       //     //// Swap out the ,<space> for pipes and add the braces
       //     //Regex r = new Regex(@", ?");
       //     //keywords = "(" + r.Replace(keywords, @"|") + ")";

       //     //// Get ready to replace the keywords
       //     //r = new Regex(keywords, RegexOptions.Singleline | RegexOptions.IgnoreCase);

       //     //// Do the replace
       //     //return r.Replace(text, new MatchEvaluator(MatchEval));
       // }

        //private string MatchEval(Match match)
        //{
        //    if (match.Groups[1].Success)
        //    {
        //        return "<mark>" + match.ToString() + "</mark>";

        //    }

        //    return ""; //no match
        //}
        #endregion
        #endregion

    }
}