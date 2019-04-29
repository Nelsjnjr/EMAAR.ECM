using EMAAR.ECM.Feature.Listing.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using Newtonsoft.Json;
using System.Web.Mvc;
using static EMAAR.ECM.Foundation.SitecoreExtensions.Settings.SitecoreSettings;

namespace EMAAR.ECM.Feature.Listing.Controllers
{
    /// <summary>
    /// ListingController class definition.
    /// </summary>

    public class ListingController : Controller
    {
        #region Private property


        private readonly IListingRepository _repo;

        #endregion

        #region constructor

        /// <summary>
        /// Listing Controller constructor
        /// </summary>        
        public ListingController(IListingRepository repo)
        {
            _repo = repo;
        }
        #endregion





        /// <summary>
        /// Method to get album images
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        public string GetListingJSON(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "", string listItemTemplateId = "", bool showFilters = false)
        {
            return JsonConvert.SerializeObject(_repo.GetListingModel(pageNumber, pageSize, filter, itemId, listItemTemplateId, showFilters), Formatting.None);

        }

        #region Image Gallery

        /// <summary>
        /// Method to get image albums
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        [HttpGet]
        public ActionResult ImageGallery()
        {
            IImage_Gallery_Page imageGallery = _repo.GetImageGallery();
            return View($"{ViewPath}Listing/Images/ImageGallery.cshtml", imageGallery);
        }


        #endregion

        #region Image Album

        /// <summary>
        /// Method to get view of Album images
        /// </summary>    
        [HttpGet]
        public ActionResult ImagesAlbum()
        {
            IImage_Album imageAlbum = _repo.GetImageAlbum();
            return View($"{ViewPath}Listing/Images/ImageAlbum.cshtml", imageAlbum);
        }
        #endregion


        #region Video Gallery

        /// <summary>
        /// Method to get video albums
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        [HttpGet]
        public ActionResult VideoGallery()
        {
            IVideo_Gallery_Page videoGallery = _repo.GetVideoGalleryModel();
            return View($"{ViewPath}Listing/Videos/VideoGallery.cshtml", videoGallery);
        }

        #endregion



        #region Image Album

        /// <summary>
        /// Method to get view of Album videos
        /// </summary>    
        [HttpGet]
        public ActionResult VideosAlbum()
        {
            IVideo_Album videoAlbum = _repo.GetVideoAlbumsModel();
            return View($"{ViewPath}Listing/Videos/VideoAlbum.cshtml", videoAlbum);
        }


        #endregion


        #region News

        /// <summary>
        /// Method to get News
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        [HttpGet]
        public ActionResult NewsListing()
        {
            INews_Listing_Page newsListing = _repo.GetNewsListingPageModel();
            return View($"{ViewPath}Listing/News/NewsListing.cshtml", newsListing);
        }

        #endregion

        #region Events

        /// <summary>
        /// Method to get Events
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        [HttpGet]
        public ActionResult EventsListing()
        {
            IEvents_Listing_Page eventsListing = _repo.GetEventsListingPageModel();
            return View($"{ViewPath}Listing/Events/EventsListing.cshtml", eventsListing);
        }

        #endregion

        #region Downloads

        /// <summary>
        /// Method to get downloads
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        [HttpGet]
        public ActionResult DownloadsListing()
        {
            IDownloads_Page downloadsListing = _repo.GetDownloadsListingPageModel();
            return View($"{ViewPath}Listing/Downloads/DownloadsListing.cshtml", downloadsListing);
        }

        #endregion
    }
}