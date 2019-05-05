namespace EMAAR.ECM.Foundation.Search.Models
{
    /// <summary>
    /// SearchCondition class definition
    /// </summary>
    public class SearchCondition
    {
        #region properties
        public string Name { get; set; }
        public string Value { get; set; }
        public CompareType CompareType { get; set; }

        #endregion
    }

    /// <summary>
    /// CompareType Enum definition.
    /// </summary>
    public enum CompareType
    {
        /// <summary>
        /// Exact match
        /// </summary>
        ExactMatch,
        /// <summary>
        /// Partail match
        /// </summary>
        PartialMatch,
        /// <summary>
        /// Date greater than or equal to
        /// </summary>
        GreaterOrEqual,
        /// <summary>
        /// Date Less than 
        /// </summary>
        LessThan
    }
}