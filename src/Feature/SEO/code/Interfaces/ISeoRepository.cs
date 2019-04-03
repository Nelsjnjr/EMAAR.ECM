using EMAAR.ECM.Foundation.ORM.Models.sitecore.templates.Foundation.ECM.Base;

namespace EMAAR.ECM.Feature.SEO.Interfaces
{
    /// <summary>
    /// This is used to set SEO functionalities
    /// </summary>
    public interface ISeoRepository
    {
        #region method
        /// <summary>
        /// Getting page metadata
        /// </summary>
        /// <returns>Metadata/OG/Twitter,Canonical and hreflang</returns>
        I_PageBase GetPageMetaData();
        #endregion
    }
}
