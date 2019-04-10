#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.Navigation.Interface;
using static EMAAR.ECM.Foundation.SitecoreExtensions.Settings.SitecoreSettings;
#endregion
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
        #region method
        /// <summary>
        /// Getting Header with all necessary details like(Menus,Logo,Search text,Login Text etc)
        /// </summary>
        /// <returns>Header</returns>
        public ActionResult GetHeader()
        {
            return View($"{ViewPath}NavigationMenu/Header.cshtml", _navigationMenuRepository.GetHeader());
        }
        /// <summary>
        ///  Getting Footer with all necessary details like(Menus,Logo,Contact Info and Legalpages etc)
        /// </summary>
        /// <returns>Footer</returns>
        public ActionResult GetFooter()
        {
            return View($"{ViewPath}NavigationMenu/Footer.cshtml", _navigationMenuRepository.GetFooter());
        }
        #endregion
    }
}