﻿using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Foundation.SitecoreExtensions.Interfaces
{
    /// <summary>
    /// This SitecoreHelper interface used to retrieve common data from Sitecore
    /// </summary>
    public interface ISitecoreHelper
    {
        #region property
      
        string HomePageSearch { get; }
        /// <summary>
        ///  Getting Home page search icon image url from Sitecore settings based on Site
        /// </summary>
        string HomePageClose { get; }
        /// <summary>
        ///  Getting Content page Close icon image url from Sitecore settings based on Site
        /// </summary>
        string ContentPageSearch { get; }
        /// <summary>
        ///  Getting Content page Close icon image url from Sitecore settings based on Site
        /// </summary>
        string ContentPageClose { get; }
      
        /// <summary>
        /// Getting Header Navigation details
        /// </summary>
        IHeader NavigationHeader { get; }
        /// <summary>
        /// Getting footer navigation details
        /// </summary>
        IFooter NavigationFooter { get; }
       
        #endregion
      
    }
}