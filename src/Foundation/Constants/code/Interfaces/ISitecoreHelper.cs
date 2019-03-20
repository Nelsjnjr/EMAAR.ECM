namespace EMAAR.ECM.Foundation.Constants.Interfaces
{
    /// <summary>
    /// This SitecoreHelper interface used to retrieve common data from Sitecore
    /// </summary>
    public interface ISitecoreHelper
    {
        #region property
        /// <summary>
        /// Getting RightArrow image url from Sitecore settings based on Site
        /// </summary>
        string RightArrow { get; }
        /// <summary>
        /// Getting Scrolldown image url from Sitecore settings based on Site
        /// </summary>
        string Scrolldown { get; }
        #endregion

    }
}
