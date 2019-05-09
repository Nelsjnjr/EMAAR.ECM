#region namespace
using EMAAR.ECM.Feature.Navigation.Interface;
using EMAAR.ECM.Foundation.DependencyInjection;
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Models
{
    /// <summary>
    /// Getting Sitemap datasource
    /// </summary>
    [Service(typeof(ISitemapViewModel))]
    public class SitemapViewModel : ISitemapViewModel
    {
        #region property
        // public List<KeyValuePair<INavigable, List<INavigable>>> SitemapItems { get; set; }
        /// <summary>
        /// Getting Sitemap details from Header navigation datasource
        /// </summary>
        public IHeader Sitemap { get; set; }
        #endregion
    }

}