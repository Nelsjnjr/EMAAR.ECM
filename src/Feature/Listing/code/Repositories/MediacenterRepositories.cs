#region namespace
using System;
using EMAAR.ECM.Feature.Listing.Interface;
using EMAAR.ECM.Feature.Listing.Interfaces;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Listing;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types.Mediacenter;
using EMAAR.ECM.Foundation.Search.Interfaces;
using EMAAR.ECM.Foundation.SitecoreExtensions;
using EMAAR.ECM.Foundation.SitecoreExtensions.Interfaces;
using Glass.Mapper.Sc.Web.Mvc;
#endregion
namespace EMAAR.ECM.Feature.Listing.Repositories
{
    [Service(typeof(IMediacenterRepositories))]
    public class MediacenterRepositories : IMediacenterRepositories
    {
        #region property
        private readonly Func<IMvcContext> _mvcContext;      
        private readonly IMediacenterViewmodel _mediacenterViewmodel;      
        private readonly IListingRepository _listingRepository;
        private readonly ISitecoreHelper _sitecoreHelper;
        #endregion
        #region construtor
        public MediacenterRepositories(Func<IMvcContext> mvcContext, ISitecoreHelper sitecoreHelper, IListingRepository listingRepository, IMediacenterViewmodel mediacenterViewmodel)
        {
           
            _mvcContext = mvcContext;           
            _mediacenterViewmodel = mediacenterViewmodel;          
            _listingRepository = listingRepository;
            _sitecoreHelper = sitecoreHelper;


        }
        #endregion
        #region method
        /// <summary>
        /// This is used to get the Media page with all necessary components(Top 3 News,Events,Downloads,I,age Gallery and Video gallery)
        /// </summary>
        /// <returns>Mediacenter page</returns>
        public IMediacenterViewmodel GetMediacenterPage()
        {
            IMvcContext mvcContext = _mvcContext();
            IMediacenter mediacenter = mvcContext.GetContextItem<IMediacenter>();
            _mediacenterViewmodel.Mediacenter = mediacenter;
            _mediacenterViewmodel.ImageGalleryItem = _sitecoreHelper.ImageGalleryItem;
            _mediacenterViewmodel.ImageAlbumItem = _sitecoreHelper.ImageAlbumItem;
            _mediacenterViewmodel.VideoGalleryItem = _sitecoreHelper.VideoGalleryItem;
            _mediacenterViewmodel.VideoAlbumItem = _sitecoreHelper.VideoAlbumItem;
            _mediacenterViewmodel.VideoItem = _sitecoreHelper.VideoItem;
            _mediacenterViewmodel.NewsListingPageItem = _sitecoreHelper.NewsListingPageItem;
            _mediacenterViewmodel.DownloadPageItem = _sitecoreHelper.DownloadPageItem;
            _mediacenterViewmodel.EventsListingPageItem = _sitecoreHelper.EventsListingPageItem;
            
            if (_sitecoreHelper.ImageGalleryItem != null)
            {
                //Getting Image Albums from Image Gallery in Media Center
                _mediacenterViewmodel.IsImageAlbum = false;
                _mediacenterViewmodel.ImageAlbumItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.ImageGalleryItem.ID.ToGuid().ToString(), CommonConstants.ImageAlbumPageTemplateID, false);
            }
            else if(_sitecoreHelper.ImageAlbumItem !=null)
            {
                //Getting Image Items from Image Albums in Media Center
                _mediacenterViewmodel.IsImageAlbum = true;
                _mediacenterViewmodel.ImageAlbumItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.ImageAlbumItem.ID.ToGuid().ToString(), CommonConstants.ImageItemTemplateID, false);
            }
            if (_sitecoreHelper.VideoGalleryItem != null)
            {  
                //Getting Video Albums from Video Gallery in Media Center
                _mediacenterViewmodel.IsVideoAlbum = false;
                _mediacenterViewmodel.VideoAlbumItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.VideoGalleryItem.ID.ToGuid().ToString(), CommonConstants.VideoAlbumPageTemplateID, false);
            }
            else if(_sitecoreHelper.VideoAlbumItem != null)
            {
                //Getting Video Items from Video Albums in Media Center
                _mediacenterViewmodel.IsVideoAlbum = true;
                _mediacenterViewmodel.VideoAlbumItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.VideoAlbumItem.ID.ToGuid().ToString(), CommonConstants.VideoItemTemplateID, false);
            }
            if (_sitecoreHelper.NewsListingPageItem != null)
            {
                //Getting News from Media Center
                _mediacenterViewmodel.NewsItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.NewsListingPageItem.ID.ToGuid().ToString(), CommonConstants.NewsTemplateID, false);
            }

            if (_sitecoreHelper.DownloadPageItem != null)
            {
                //Getting Downloads from Media Center
                _mediacenterViewmodel.DownloadsItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.DownloadPageItem.ID.ToGuid().ToString(), CommonConstants.DownloadItemTemplateID, false);
            }

            if (_sitecoreHelper.EventsListingPageItem != null)
            {
                //Getting Events from Media Center
                _mediacenterViewmodel.EventsItems = _listingRepository.GetListingModel(0, 3, null, _sitecoreHelper.EventsListingPageItem.ID.ToGuid().ToString(), CommonConstants.EventsTemplateID, false);
            }

            return _mediacenterViewmodel;
        }
        #endregion
  
    }
}