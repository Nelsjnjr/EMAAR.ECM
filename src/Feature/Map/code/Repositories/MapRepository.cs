#region namespace
using System;
using EMAAR.ECM.Feature.Map.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.InteractiveMap;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Foundation.DependencyInjection;
#endregion
namespace EMAAR.ECM.Feature.Map.Repositories
{
    /// <summary>
    /// Repositoy class for interacting with business objects
    /// </summary>
    [Service(typeof(IMapRepository))]
    public class MapRepository: IMapRepository
    {
        private readonly Func<IMvcContext> _mvcContext;
        private readonly IInteractiveMapList _interactiveMapList;
        public MapRepository(Func<IMvcContext> mvcContext, IInteractiveMapList interactiveMapList)
        {
            _interactiveMapList = interactiveMapList;
            _mvcContext = mvcContext;
        }
        /// <summary>
        /// Getting all Interactive Map component asigned in Sitecore on field (Interactive Maps)
        /// </summary>
        /// <returns>InteractiveMapList</returns>
        public IInteractiveMapList GetInteractiveMap()
        {
            IMvcContext mvcContext = _mvcContext();
            IInteractiveMapList interactiveMapList = mvcContext.GetDataSourceItem<IInteractiveMapList>();
            return interactiveMapList ?? _interactiveMapList;
        }
    }
}