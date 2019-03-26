#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Content_Types.InteractiveMap;
#endregion
namespace EMAAR.ECM.Feature.Map.Interfaces
{
    public interface IMapRepository
    {

        #region method
        /// <summary>
        /// Getting all Interactive Map component asigned in Sitecore on field (Interactive Maps)
        /// </summary>
        /// <returns>InteractiveMapList</returns>
        IInteractiveMapList GetInteractiveMap();
        #endregion
    }
}
