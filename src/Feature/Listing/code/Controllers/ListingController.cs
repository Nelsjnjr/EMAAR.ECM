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

        private readonly IImageListingRepository _imageRepo;
        private readonly IVideoListingRepository _videoRepo;

        #endregion

        #region constructor

        /// <summary>
        /// Listing Controller constructor
        /// </summary>
        /// <param name="searchManager">ISearchManager object</param>
        public ListingController(IImageListingRepository imageRepo, IVideoListingRepository videoRepo)
        {
            _imageRepo = imageRepo;
            _videoRepo = videoRepo;
        }
        #endregion


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
            IImage_Gallery_Page imageGallery = _imageRepo.GetImageGallery();
            return View($"{ViewPath}Listing/Images/ImageGallery.cshtml", imageGallery);
        }

        /// <summary>
        /// Method to get album images
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        public string GetAlbumsJson(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId="")
        {
            return JsonConvert.SerializeObject(_imageRepo.GetAlbums(pageNumber,pageSize,filter), Formatting.None);

        }

        #endregion

        #region Image Album

        /// <summary>
        /// Method to get view of Album images
        /// </summary>    
        [HttpGet]
        public ActionResult ImagesAlbum()
        {
            IImage_Album imageAlbum = _imageRepo.GetImageAlbum();
            return View($"{ViewPath}Listing/Images/ImageAlbum.cshtml", imageAlbum);
        }


        /// <summary>
        /// Method to get json of album images
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>
        /// <param name="itemId">Item ID</param>            
        /// <returns>json string</returns>   
        public string GetImagesOfAlbumJson(int pageNumber = -1, int pageSize = -1, string itemId="", string filter = "")
        {
            return JsonConvert.SerializeObject(_imageRepo.GetAlbumImages(pageNumber,pageSize,filter,itemId), Formatting.None);

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
            IVideo_Gallery_Page videoGallery = _videoRepo.GetVideoGalleryModel();
            return View($"{ViewPath}Listing/Videos/VideoGallery.cshtml", videoGallery);
        }

        /// <summary>
        /// Method to get json of album videos
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>          
        /// <returns>json string.</returns>   
        public string GetVideoAlbumsJson(int pageNumber = -1, int pageSize = -1, string filter = "", string itemId = "")
        {
            return JsonConvert.SerializeObject(_videoRepo.GetVideoAlbums(pageNumber, pageSize, filter), Formatting.None);

        }

        #endregion



        #region Image Album

        /// <summary>
        /// Method to get view of Album videos
        /// </summary>    
        [HttpGet]
        public ActionResult VideosAlbum()
        {
            IVideo_Album videoAlbum = _videoRepo.GetVideoAlbumsModel();
            return View($"{ViewPath}Listing/Videos/VideoAlbum.cshtml", videoAlbum);
        }


        /// <summary>
        /// Method to get json of album videos
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <param name="filter">filter</param>
        /// <param name="itemId">Item ID</param>            
        /// <returns>json string</returns>   
        public string GetVideosOfAlbumJson(int pageNumber = -1, int pageSize = -1, string itemId = "", string filter = "")
        {
            return JsonConvert.SerializeObject(_videoRepo.GetVideosOfAlbum(pageNumber, pageSize, filter, itemId), Formatting.None);

        }

        #endregion
    }
}