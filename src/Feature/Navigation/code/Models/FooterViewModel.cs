#region namespace
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
using EMAAR.ECM.Foundation.DependencyInjection;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Models
{
    /// <summary>
    /// This class used to load Footer component
    /// </summary>
    [Service(typeof(IFooterViewModel))]
    public class FooterViewModel : IFooterViewModel
    {
        /// <summary>
        /// Getting Footer Menu details from Sitecore
        /// </summary>
        public IFooter Footer { get; set; }
        /// <summary>
        /// Getting Logo details from Sitecore SiteRoot item
        /// </summary>
        public ILogo Logos { get; set; }
      
    }
}