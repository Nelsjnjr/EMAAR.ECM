#region namespace
using System;
using EMAAR.ECM.Feature.Map.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Interactive_Map_Location_Points;
using Glass.Mapper.Sc.Web.Mvc;
using EMAAR.ECM.Foundation.DependencyInjection;
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
        private readonly IInteractive_Map_Location_PointList _interactive_Map_Location_PointList;
        public MapRepository(Func<IMvcContext> mvcContext, IInteractive_Map_Location_PointList interactive_Map_Location_PointList )
        {
            _interactive_Map_Location_PointList = interactive_Map_Location_PointList;
            _mvcContext = mvcContext;
        }
        /// <summary>
        /// Getting all Interactive Map component asigned in Sitecore on field (Interactive Maps)
        /// </summary>
        /// <returns>InteractiveMapList</returns>
        public IInteractive_Map_Location_PointList InteractiveMapLocationPoints()
        {
            IMvcContext mvcContext = _mvcContext();
            IInteractive_Map_Location_PointList interactive_Map_Location_PointList  = mvcContext.GetDataSourceItem<IInteractive_Map_Location_PointList>();
            return interactive_Map_Location_PointList ?? _interactive_Map_Location_PointList;
        }
    }
}