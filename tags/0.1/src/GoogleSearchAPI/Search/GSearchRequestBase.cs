namespace Google.API.Search
{
    /// <summary>
    /// The search safety level.
    /// </summary>
    public enum SafeLevel
    {
        /// <summary>
        /// Disables safe search filtering.
        /// </summary>
        off,

        /// <summary>
        /// Enables moderate safe search filtering. Default value.
        /// </summary>
        moderate = 0,

        /// <summary>
        /// Enables the highest level of safe search filtering.
        /// </summary>
        active,
    }

    internal enum ResultSize
    {
        small = 0,
        large,
    }

    /// <summary>
    /// Sort type enum.
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// Sort by relevance. Default value.
        /// </summary>
        relevance = 0,
        /// <summary>
        /// Sort by date.
        /// </summary>
        date,
    }

    internal abstract class GSearchRequestBase : RequestBase
    {
        protected GSearchRequestBase(string keyword)
            : base(keyword)
        { }

        protected GSearchRequestBase(string keyword, int start)
            : base(keyword)
        {
            Start = start;
        }

        protected GSearchRequestBase(string keyword, int start, ResultSize resultSize)
            : base(keyword)
        {
            Start = start;
            ResultSize = resultSize;
        }

        /// <summary>
        /// This optional argument supplies the number of results that the application would like to recieve. A value of small indicates a small result set size or 4 results. A value of large indicates a large result set or 8 results. If this argument is not supplied, a value of small is assumed.
        /// </summary>
        [Argument("rsz")]
        public ResultSize ResultSize { get; private set; }

        /// <summary>
        /// This optional argument supplies the start index of the first search result. Each successful response contains a cursor object which includes an array of pages. The start property for a page may be used as a valid value for this argument.
        /// </summary>
        [Argument("start")]
        public int Start { get; private set; }
    }
}