#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.Interactive_Map_Location_Points;
#endregion
namespace EMAAR.ECM.Feature.Map.Interfaces
{
    public interface IMapRepository
    {

        #region method
        /// <summary>
        /// Getting all Interactive Map Location points component asigned in Sitecore on field (Interactive Maps)
        /// </summary>
        /// <returns>InteractiveMapList</returns>
        IInteractive_Map_Location_PointList InteractiveMapLocationPoints();
        #endregion
    }
}
