using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;


namespace EMAAR.ECM.Feature.ContentComponents.Interfaces
{
    public interface IContentRepositories
    {
        #region method
        /// <summary>
        /// Getting Content Page details
        /// </summary>
        /// <returns></returns>
        IGeneric GetContentPage();
        #endregion

    }
}
