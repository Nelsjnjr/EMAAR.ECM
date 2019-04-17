#region namespace
using System.Web.Mvc;
using EMAAR.ECM.Feature.ContentComponents.Interfaces;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Page_Types;
using static EMAAR.ECM.Foundation.SitecoreExtensions.Settings.SitecoreSettings;
#endregion

namespace EMAAR.ECM.Feature.ContentComponents.Controllers
{
    public class ContentComponentsController : Controller
    {
        #region Private property
        private readonly IContentRepositories _contentRepositories;
        #endregion
        #region construtor
        public ContentComponentsController(IContentRepositories contentRepositories)
        {
          
            _contentRepositories = contentRepositories;
        }
        #endregion
        #region method
        // GET: ContentComponents
        public ActionResult GetContentPage()
        {
            IGeneric_ContentPage generic = _contentRepositories.GetContentPage();
            return View($"{ViewPath}ContentPage/ContentPage.cshtml", generic);
        }
        #endregion
    }
}