namespace EMAAR.ECM.Foundation.Constants
{
    /// <summary>
    /// Common constants
    /// </summary>
    public static class CommonConstants
    {
        #region property
        /// <summary>
        /// Getting Alignment Variations
        /// </summary>
        public enum Alignment { Left, Right, Background };
        /// <summary>
        /// Getting Explore constants for CSS
        /// </summary>
        public static string Explore { get; } = "explore";
        /// <summary>
        /// Getting Home page header CSS class name
        /// </summary>
        public static string  HomePageHeaderCss { get; } = "siteHeader";
        /// <summary>
        /// Getting Content Page Css Class name
        /// </summary>
        public static string ContentPageHeaderCss { get; } = "siteHeader innerHeader";
        /// <summary>
        /// Getting Contact Types
        /// </summary>
        public enum ContactTypes { Email, Phone, Map };
        /// <summary>
        /// Year Token for dynamically modify it
        /// </summary>
        public static string YearToken { get; } = "{year}";
        #region method
        /// <summary>
        /// Getting name of the property
        /// </summary>
        /// <param name="value">name</param>
        /// <returns></returns>
        public static string GetPropertyName(string value)
        {
            return nameof(value).Replace('_', ':');
        }
        #endregion
        #endregion;

    }

}
