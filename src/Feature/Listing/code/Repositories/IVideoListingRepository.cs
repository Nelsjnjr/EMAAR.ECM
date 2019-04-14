using EMAAR.ECM.Feature.Listing.Interfaces;
using EMAAR.ECM.Foundation.SitecoreExtensions;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using EMAAR.ECM.Foundation.Search.Helpers;
using EMAAR.ECM.Foundation.Search.Interfaces;
using EMAAR.ECM.Foundation.Search.Models;
using Glass.Mapper.Sc.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMAAR.ECM.Feature.Listing.Repositories
{
    [Service(typeof(IVideoListingRepository))]
    public class VideoListingRepository : IVideoListingRepository
    {

        #region Property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly ISearchManager _searchManager;
        private readonly IVideo_Gallery_Page _videoGallery;
        private readonly IVideo_Album _videoAlbum;
        #endregion

        #region constructor
        public VideoListingRepository(Func<IMvcContext> mvcContext, ISearchManager searchManager, IVideo_Gallery_Page videoGallery, IVideo_Album videoAlbum)
        {            
            _mvcContext = mvcContext;
            _searchManager = searchManager;
            _videoGallery = videoGallery;
            _videoAlbum = videoAlbum;
        }
        #endregion
        #region method

        #region Video Gallery

        public IVideo_Gallery_Page GetVideoGalleryModel()
        {
            IMvcContext mvcContext = _mvcContext();
            IVideo_Gallery_Page VideoGallery = mvcContext.GetContextItem<IVideo_Gallery_Page>();
            return VideoGallery ?? _videoGallery;
        }

        /// <summary>
        /// Method to get albums
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>           
        /// <returns>SearchResultsGeneric<ListingSearchResultItem> </returns>   
        public SearchResultsGeneric<ListingSearchResultItem> GetVideoAlbums(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "")
        {

            List<SearchCondition> conditions = new List<SearchCondition>();
            conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.VideoAlbumPageTemplateID), CompareType = CompareType.ExactMatch });


            conditions = SearchHelper.AddFilterConditions(filter, conditions);


            List<Facet> facets = new List<Facet>();

            //Facets not required From second request, 
            if (pageNumber <= 0)
            {
                facets.Add(new Facet() { facetField = CommonConstants.YearFacetField, allLabel = Sitecore.Globalization.Translate.Text(CommonConstants.AllYearsKey), minCount = 1 });
                facets.Add(new Facet() { facetField = CommonConstants.CategoriesFacetField, allLabel = Sitecore.Globalization.Translate.Text(CommonConstants.AllCategoriesKey), minCount = 1 });
            }

            // Add sort option
            SortOption option = new SortOption() { SortFieldName = CommonConstants.YearFacetField, SortOrder = SortOrder.Descending };
            SearchResultsGeneric<ListingSearchResultItem> resultsList = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, facets, option, pageNumber, pageSize);


            //Get First Video of each album as cover Video
            int count = 0;
            while (count < resultsList.results.results.Count)
            {
                if (resultsList.results.results[count] != null && resultsList.results.results[count].videos != null && resultsList.results.results[count].videos.Count > 0)
                {
                    conditions = new List<SearchCondition>();
                    conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.VideoItemTemplateID), CompareType = CompareType.ExactMatch });
                    conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = resultsList.results.results[count].videos[0].ToString(), CompareType = CompareType.ExactMatch });
                    SearchResultsGeneric<ListingSearchResultItem> Videos = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, null, null, 0, 1);

                    if (Videos != null && Videos.results.results != null && Videos.results.results.Count > 0)
                    {
                        resultsList.results.results[count].imageUrl = Videos.results.results[0].imageUrl;

                    }
                }

                count++;
            }


            return resultsList;

        }

        #endregion


        #region Video Album

        public IVideo_Album GetVideoAlbumsModel()
        {
            IMvcContext mvcContext = _mvcContext();
            IVideo_Album VideoAlbum = mvcContext.GetContextItem<IVideo_Album>();
            return VideoAlbum ?? _videoAlbum;
        }

        


        /// <summary>
        /// Method to get Videosof album
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>
        /// <param name="itemId">itemId</param>        
        /// <returns>SearchResultsGeneric<ListingSearchResultItem></returns>   
        public SearchResultsGeneric<ListingSearchResultItem> GetVideosOfAlbum(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "")
        {
            // Add conditions to get album based on item id
            List<SearchCondition> conditions = new List<SearchCondition>();
            conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.VideoAlbumPageTemplateID), CompareType = CompareType.ExactMatch });
            conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = SearchHelper.FormatGuid(itemId), CompareType = CompareType.ExactMatch });
            SearchResultsGeneric<ListingSearchResultItem> albums = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, null, null, 0, 1);

            //Get Videos of album
            SearchResultsGeneric<ListingSearchResultItem> VideoResults = new SearchResultsGeneric<ListingSearchResultItem>();
            if (albums != null && albums.results.results.Count > 0)
            {
                List<string> Videos = albums.results.results[0].videos;
                if (Videos == null || !Videos.Any())
                    return VideoResults;

                List<string> currentPageVideos = Videos.Skip(pageNumber*pageSize).Take(pageSize).ToList();
                conditions = new List<SearchCondition>();
                conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = string.Join(",", currentPageVideos), CompareType = CompareType.ExactMatch });
                conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.VideoItemTemplateID), CompareType = CompareType.ExactMatch });
                VideoResults = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions,null,null,-1,-1);

                //Sort Videos based on order of Videos selected in multilist
                if (VideoResults != null && VideoResults.results.results != null && VideoResults.results.results.Count > 0)
                {
                    List<ListingSearchResultItem> sortedList = new List<ListingSearchResultItem>();
                    List<ListingSearchResultItem> list = VideoResults.results.results.ToList();
                    int count = 0;
                    while (count < currentPageVideos.Count)
                    {
                        sortedList.Add(list.FirstOrDefault(x => SearchHelper.FormatGuid(x.ItemId.ToString()).Equals(currentPageVideos[count])));
                        count++;
                    }
                    if (sortedList.Count == list.Count)
                        VideoResults.results.results = sortedList;

                    VideoResults.results.Totalcount = Videos.Count;
                }
            }
            return VideoResults;

        }

        #endregion


    

        #endregion

    }
}