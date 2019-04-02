#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.Map.Interfaces;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Interactive_Map;
using static EMAAR.ECM.Foundation.Constants.Settings.SitecoreSettings;
#endregion
namespace EMAAR.ECM.Feature.Map.Controllers
{
    public class MapController : Controller
    {
        #region Private property
        private readonly IMapRepository _mapRepository;
        #endregion
        #region construtor     
        public MapController(IMapRepository mapRepository, ISitecoreHelper sitecoreHelper)
        {
           
               _mapRepository = mapRepository;
        }
        #endregion
        #region method     
        /// <summary>
        /// Getting Interactive map points from sitecore and place it on the background image
        /// </summary>
        /// <returns></returns>
        public ActionResult InteractiveMaps()
        {
            IInteractive_Map interactive_Map   = _mapRepository.InteractiveMaps();
            return View($"{ViewPath}Map/InteractiveMap/InteractiveMap.cshtml", interactive_Map);
        }
        #endregion
    }
}