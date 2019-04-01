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
        ExactMatch,
        PartialMatch
    }
}