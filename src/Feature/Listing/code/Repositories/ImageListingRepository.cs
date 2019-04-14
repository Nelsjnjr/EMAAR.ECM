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
    [Service(typeof(IImageListingRepository))]
    public class ImageListingRepository : IImageListingRepository
    {

        #region Property
        private readonly Func<IMvcContext> _mvcContext;
        private readonly ISearchManager _searchManager;
        private readonly IImage_Gallery_Page _imageGallery;
        private readonly IImage_Album _imageAlbum;
        #endregion

        #region constructor
        public ImageListingRepository(Func<IMvcContext> mvcContext, ISearchManager searchManager, IImage_Gallery_Page imageGallery, IImage_Album imageAlbum)
        {            
            _mvcContext = mvcContext;
            _searchManager = searchManager;
            _imageGallery = imageGallery;
            _imageAlbum = imageAlbum;
        }
        #endregion
        #region method

        #region Image Gallery

        public IImage_Gallery_Page GetImageGallery()
        {
            IMvcContext mvcContext = _mvcContext();
            IImage_Gallery_Page imageGallery = mvcContext.GetContextItem<IImage_Gallery_Page>();
            return imageGallery ?? _imageGallery;
        }

        /// <summary>
        /// Method to get albums
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>           
        /// <returns>SearchResultsGeneric<ListingSearchResultItem> </returns>   
        public SearchResultsGeneric<ListingSearchResultItem> GetAlbums(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "")
        {

            List<SearchCondition> conditions = new List<SearchCondition>();
            conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.ImageAlbumPageTemplateID), CompareType = CompareType.ExactMatch });


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


            //Get First image of each album as cover image
            int count = 0;
            while (count < resultsList.results.results.Count)
            {
                if (resultsList.results.results[count] != null && resultsList.results.results[count].images != null && resultsList.results.results[count].images.Count > 0)
                {
                    conditions = new List<SearchCondition>();
                    conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.ImageItemTemplateID), CompareType = CompareType.ExactMatch });
                    conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = resultsList.results.results[count].images[0].ToString(), CompareType = CompareType.ExactMatch });
                    SearchResultsGeneric<ListingSearchResultItem> images = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, null, null, 0, 1);

                    if (images != null && images.results.results != null && images.results.results.Count > 0)
                    {
                        resultsList.results.results[count].imageUrl = images.results.results[0].imageUrl;

                    }
                }

                count++;
            }


            return resultsList;

        }

        #endregion


        #region Image Album

        public IImage_Album GetImageAlbum()
        {
            IMvcContext mvcContext = _mvcContext();
            IImage_Album imageAlbum = mvcContext.GetContextItem<IImage_Album>();
            return imageAlbum ?? _imageAlbum;
        }

        


        /// <summary>
        /// Method to get imagesof album
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>
        /// <param name="itemId">itemId</param>        
        /// <returns>SearchResultsGeneric<ListingSearchResultItem></returns>   
        public SearchResultsGeneric<ListingSearchResultItem> GetAlbumImages(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "")
        {
            // Add conditions to get album based on item id
            List<SearchCondition> conditions = new List<SearchCondition>();
            conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.ImageAlbumPageTemplateID), CompareType = CompareType.ExactMatch });
            conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = SearchHelper.FormatGuid(itemId), CompareType = CompareType.ExactMatch });
            SearchResultsGeneric<ListingSearchResultItem> albums = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, null, null, 0, 1);

            //Get images of album
            SearchResultsGeneric<ListingSearchResultItem> imageResults = new SearchResultsGeneric<ListingSearchResultItem>();
            if (albums != null && albums.results.results.Count > 0)
            {
                List<string> images = albums.results.results[0].images;
                if (images == null || !images.Any())
                    return imageResults;

                List<string> currentPageImages = images.Skip(pageNumber*pageSize).Take(pageSize).ToList();
                conditions = new List<SearchCondition>();
                conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = string.Join(",", currentPageImages), CompareType = CompareType.ExactMatch });
                conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.ImageItemTemplateID), CompareType = CompareType.ExactMatch });
                imageResults = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions,null,null,-1,-1);

                //Sort images based on order of images selected in multilist
                if (imageResults != null && imageResults.results.results != null && imageResults.results.results.Count > 0)
                {
                    List<ListingSearchResultItem> sortedList = new List<ListingSearchResultItem>();
                    List<ListingSearchResultItem> list = imageResults.results.results.ToList();
                    int count = 0;
                    while (count < currentPageImages.Count)
                    {
                        sortedList.Add(list.FirstOrDefault(x => SearchHelper.FormatGuid(x.ItemId.ToString()).Equals(currentPageImages[count])));
                        count++;
                    }
                    if (sortedList.Count == list.Count)
                        imageResults.results.results = sortedList;

                    imageResults.results.Totalcount = images.Count;
                }
            }
            return imageResults;

        }

        #endregion


        #region Video Gallery

        public IImage_Gallery_Page GetVideoGallery()
        {
            IMvcContext mvcContext = _mvcContext();
            IImage_Gallery_Page imageGallery = mvcContext.GetContextItem<IImage_Gallery_Page>();
            return imageGallery ?? _imageGallery;
        }

        /// <summary>
        /// Method to get albums
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>           
        /// <returns>SearchResultsGeneric<ListingSearchResultItem> </returns>   
        public SearchResultsGeneric<ListingSearchResultItem> GetVideos(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "")
        {

            List<SearchCondition> conditions = new List<SearchCondition>();
            conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.ImageAlbumPageTemplateID), CompareType = CompareType.ExactMatch });


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


            //Get First image of each album as cover image
            int count = 0;
            while (count < resultsList.results.results.Count)
            {
                if (resultsList.results.results[count] != null && resultsList.results.results[count].images != null && resultsList.results.results[count].images.Count > 0)
                {
                    conditions = new List<SearchCondition>();
                    conditions.Add(new SearchCondition() { Name = CommonConstants.TemplateID, Value = SearchHelper.FormatGuid(CommonConstants.ImageItemTemplateID), CompareType = CompareType.ExactMatch });
                    conditions.Add(new SearchCondition() { Name = CommonConstants.IndexIdField, Value = resultsList.results.results[count].images[0].ToString(), CompareType = CompareType.ExactMatch });
                    SearchResultsGeneric<ListingSearchResultItem> images = _searchManager.GetSearchResults<ListingSearchResultItem>(conditions, null, null, 0, 1);

                    if (images != null && images.results.results != null && images.results.results.Count > 0)
                    {
                        resultsList.results.results[count].imageUrl = images.results.results[0].imageUrl;

                    }
                }

                count++;
            }


            return resultsList;

        }

        #endregion

        #endregion

    }
}