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
        #region Search
        /// <summary>
        /// Index Language field
        /// </summary>
        public static string Language { get; } = "_language";

        /// <summary>
        /// Index Latest version field
        /// </summary>
        public static string Latestversion { get; } = "_latestversion";

        /// <summary>
        /// Index ID field
        /// </summary>
        public const string IndexIdField = "_group";

        /// <summary>
        /// All filter value
        /// </summary>
        public const string AllValue = "all";


        /// <summary>
        /// Invalid ID
        /// </summary>
        public const string InvalidID = "00000000000000000000000000000000";

        /// <summary>
        /// None Value
        /// </summary>
        public const string NoneValue = "None";

        /// <summary>
        /// None Value
        /// </summary>
        public const string NameStandardValueToken = "$name";


        /// <summary>
        /// Batch Size
        /// </summary>
        public const int BatchSize = 50;

        /// <summary>
        /// Index Name Prefix
        /// </summary>
        public const string IndexNamePrefix = "ecm";

        /// <summary>
        /// DefaultIndex Name Prefix
        /// </summary>
        public const string DefaultIndexNamePrefix = "sitecore";

        #endregion
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
