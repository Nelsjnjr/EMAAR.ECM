#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.Navigation.Interface;
using static EMAAR.ECM.Foundation.Constants.Settings.SitecoreSettings;
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
        public ActionResult GetFooter()
        {
            return View($"{ViewPath}NavigationMenu/Footer.cshtml", _navigationMenuRepository.GetFooter());
        }
        #endregion
    }
}