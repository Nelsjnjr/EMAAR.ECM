﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Feature.Navigation.Settings;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;

namespace EMAAR.ECM.Feature.Navigation.Controllers
{
    public class NavigationMenuController : Controller
    {
        #region Private property
        private readonly INavigationMenuRepository _navigationMenuRepository;
        #endregion
        #region construtor    
        public NavigationMenuController(INavigationMenuRepository navigationMenuRepository)
        {
            _navigationMenuRepository = navigationMenuRepository;
        }
        #endregion
        /// <summary>
        /// Getting Header with all necessary details like(Menus,Logo,Search text,Login Text etc)
        /// </summary>
        /// <returns>Header</returns>
        public ActionResult GetHeader()
        {
            return View($"{SitecoreSettings.ViewPath}NavigationMenu/Header.cshtml", _navigationMenuRepository.GetHeader());
        }
    }
}