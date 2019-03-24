using System.Web.Mvc;
using EMAAR.ECM.Feature.Map.Interfaces;
using EMAAR.ECM.Feature.Map.Settings;
using EMAAR.ECM.Foundation.Constants.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.InteractiveMap;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult InteractiveMap()
        {
            IInteractiveMapList mapRepository = _mapRepository.GetInteractiveMap();
            return View($"{SitecoreSettings.ViewPath}Map/InteractiveMap/InteractiveMap.cshtml", mapRepository);
        }
        #endregion
    }
}