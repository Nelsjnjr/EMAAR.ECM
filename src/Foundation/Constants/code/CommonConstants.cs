﻿namespace EMAAR.ECM.Foundation.Constants
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
        public static string HomePageHeaderCss { get; } = "siteHeader";
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
        /// <summary>
        /// Registering the javascripts to bundle and minify with the name
        /// </summary>
        public static string JavascriptBundleName { get; } = "~/bundles/scripts";
        /// <summary>
        /// All Site javascripts files path
        /// </summary>
        public static string[] AllSiteJavascriptsFilePaths => new string[] {
            "~/Content/Project/ECM/js/vendor/jquery/jquery.js",
            "~/Content/Project/ECM/js/vendor/jquery/jquery.counterup.min.js",
            "~/Content/Project/ECM/js/vendor/jquery/jquery-ui.min.js",
            "~/Content/Project/ECM/js/vendor/jquery/jquery.scrollTo-1.4.2-min.js",
            "~/Content/Project/ECM/js/vendor/jquery/jquery.validate*",
            "~/Content/Project/ECM/js/vendor/bootstrap/bootstrap.js",
            "~/Content/Project/ECM/js/vendor/common/*.js",
            "~/Content/Project/ECM/js/application/app.js",
            "~/Content/Project/ECM/js/application/main.js"
        };
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

        #endregion;

    }

}
