﻿#region namespace
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.DependencyInjection;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Models
{
    /// <summary>
    /// This class used to load header component
    /// </summary>
    [Service(typeof(IHeaderViewModel))]
    public class HeaderViewModel : IHeaderViewModel
    {
        #region property
        /// <summary>
        /// Getting Header Menu details from Sitecore
        /// </summary>
        public IHeader Header { get; set; }

        public ISiteRoot SiteRoot  { get; set; }
        /// <summary>
        /// Getting Logo details from Sitecore SiteRoot item
        /// </summary>
        public ILogo Logos { get; set; }
        /// <summary>
        /// Getting Search Icon
        /// </summary>
        public string SearchIcon { get; set; }
        /// <summary>
        /// Getting Close icon
        /// </summary>
        public string CloseIcon { get; set; }
        /// <summary>
        /// Getting Header CSS Class name
        /// </summary>
        public string HeaderCss { get; set; }
        /// <summary>
        /// Check is this page is Home
        /// </summary>
        public bool IsHomePage { get; set; }
        #endregion
    }
}