using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using EMAAR.ECM.Foundation.Search.Models;

namespace EMAAR.ECM.Feature.Listing.Interfaces
{
    public interface IListingRepository
    {

        SearchResultsGeneric<ListingSearchResultItem> GetListingModel(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "", string listItemTemplateId = "", bool showFilters = false,string parentItemId = "");
                       
       // SearchResultsGeneric<ListingSearchResultItem> GetSearchResultsModel(int pageNumber = -1, int pageSize = -1, string searchTerm = "*");

        IImage_Gallery_Page GetImageGallery();

        IImage_Album GetImageAlbum();

        
        IVideo_Gallery_Page GetVideoGalleryModel();

        IVideo_Album_Without_Filters GetVideoAlbumsModel(out bool ShowFilters);

        INews_Listing_Page GetNewsListingPageModel();

        IEvents_Listing_Page GetEventsListingPageModel(out string Year);

        IDownloads_Page GetDownloadsListingPageModel();

       // ISearchPage GetSearchPageModel();
    }
}
