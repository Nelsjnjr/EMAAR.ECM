﻿#region namespace
using System;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.SitecoreExtensions.Interfaces;
using EMAAR.ECM.Foundation.SitecoreExtensions.Settings;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
#endregion

namespace EMAAR.ECM.Foundation.SitecoreExtensions
{
    /// <summary>
    /// This SitecoreHelper class used to retrieve common data from Sitecore
    /// </summary>
    [Service(typeof(ISitecoreHelper))]
    public class SitecoreHelper : ISitecoreHelper
    {
        #region variable
        private readonly Func<IMvcContext> _mvcContext;
        #endregion
        #region constructor

        public SitecoreHelper(Func<IMvcContext> mvcContext)
        {
            _mvcContext = mvcContext;

        }
        #endregion
        #region property
        /// <summary>
        ///  Getting Home page search icon image url from Sitecore settings based on Site
        /// </summary>
        public string HomePageSearch => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.HomePageSearch}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Home page Close icon image url from Sitecore settings based on Site
        /// </summary>
        public string HomePageClose => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.HomePageClose}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Content page search icon image url from Sitecore settings based on Site
        /// </summary>
        public string ContentPageSearch => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.ContentPageSearch}")?.Image?.Src ?? string.Empty;
        /// <summary>
        /// Getting Content page Close icon image url from Sitecore settings based on Site
        /// </summary>
        public string ContentPageClose => _mvcContext()?.SitecoreService.GetItem<IIconImages>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.ContentPageClose}")?.Image?.Src ?? string.Empty;

        /// <summary>
        /// Getting Header Navigation details
        /// </summary>
        public IHeader NavigationHeader => _mvcContext()?.SitecoreService.GetItem<IHeader>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.NavigationHeaderPath}");
        /// <summary>
        /// Getting footer navigation details
        /// </summary>
        public IFooter NavigationFooter => _mvcContext()?.SitecoreService.GetItem<IFooter>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.NavigationFooterPath}");

        /// <summary>
        ///Image Gallery Item in Mediacenter 
        /// </summary>
        public Item ImageGalleryItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.ImageGalleryPageTemplateName}']");
        /// <summary>
        ///Image Album Item in Mediacenter 
        /// </summary>
        public Item ImageAlbumItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.ImageAlbumPageTemplateName}']");
        /// <summary>
        ///Image  Item in Mediacenter 
        /// </summary>
        public Item ImageItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.ImageItemPageTemplateName}']");
        /// <summary>
        ///Video Gallery Item in Mediacenter 
        /// </summary>
        public Item VideoGalleryItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.VideoGalleryPageTemplateName}']");
        /// <summary>
        ///Video Album Item in Mediacenter 
        /// </summary>
        public Item VideoAlbumWithoutFilterItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.VideoAlbumWithoutFilterPageTemplateName}']");
        /// <summary>
        ///Video Album Item in Mediacenter 
        /// </summary>
        public Item VideoAlbumWithFilterItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.VideoAlbumWithFilterPageTemplateName}']");
        /// <summary>
        ///Video Album Item in Mediacenter 
        /// </summary>
        public Item VideoItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.VideoItemPageTemplateName}']");
        /// <summary>
        ///News Item in Mediacenter 
        /// </summary>
        public Item NewsListingPageItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.NewsPageTemplateName}']");
        /// <summary>
        ///Downloads Item in Mediacenter 
        /// </summary>
        public Item DownloadPageItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.DownloadsPageTemplateName}']");

        /// <summary>
        ///Events Item from Mediacenter 
        /// </summary>
        public Item EventsListingPageItem => Sitecore.Context.Database.SelectSingleItem($"{Sitecore.Context.Site.RootPath}/Home/mediacenter/*[@@templatename='{CommonConstants.EventsPageTemplateName}']");
        /// <summary>
        /// Sitemap Datasource from Header navigation datasource
        /// </summary>
        public IHeader Sitemap => _mvcContext()?.SitecoreService.GetItem<IHeader>
            ($"{Sitecore.Context.Site.RootPath}{SitecoreSettings.NavigationHeaderPath}");
             
        #endregion


    }

}
