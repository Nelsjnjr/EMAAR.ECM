#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.Map.Interfaces;
using EMAAR.ECM.Feature.Map.Settings;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Interactive_Map_Location_Points;
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
        public ActionResult InteractiveMapLocationPoints()
        {
            IInteractive_Map_Location_PointList interactive_Map_Location_PointList  = _mapRepository.InteractiveMapLocationPoints();
            return View($"{ViewPath}Map/InteractiveMapLocationPoints/InteractiveMapLocationPoint.cshtml", interactive_Map_Location_PointList);
        }
        #endregion
    }
}