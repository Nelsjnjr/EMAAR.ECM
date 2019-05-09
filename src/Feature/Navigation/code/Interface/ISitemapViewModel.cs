#region namespace
using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Project.ECM.Common.Content_Types;
#endregion
namespace EMAAR.ECM.Feature.Navigation.Interface
{
    /// <summary>
    /// Getting Sitemap datasource
    /// </summary>
    public interface ISitemapViewModel
    {
        #region property
        // List<KeyValuePair<INavigable, List<INavigable>>> SitemapItems { get; set; }
        /// <summary>
        /// Getting Sitemap details from Header navigation datasource
        /// </summary>
        IHeader Sitemap { get; set; }
        #endregion

    }
}
