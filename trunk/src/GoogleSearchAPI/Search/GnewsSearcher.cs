//-----------------------------------------------------------------------
// <copyright file="GnewsSearcher.cs" company="iron9light">
// Copyright (c) 2009 iron9light
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>
// <author>iron9light@gmail.com</author>
//-----------------------------------------------------------------------

namespace Google.API.Search
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Utility class for Google News Search service.
    /// </summary>
    public static class GnewsSearcher
    {
        ////private static int s_Timeout = 0;

        /////// <summary>
        /////// Get or set the length of time, in milliseconds, before the request times out.
        /////// </summary>
        ////public static int Timeout
        ////{
        ////    get
        ////    {
        ////        return s_Timeout;
        ////    }
        ////    set
        ////    {
        ////        if (s_Timeout < 0)
        ////        {
        ////            throw new ArgumentOutOfRangeException("value");
        ////        }
        ////        s_Timeout = value;
        ////    }
        ////}

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GnewsSearcher.Search("Olympic", 16);
        /// foreach(INewsResult result in results)
        /// {
        ///     Console.WriteLine("[{0}, {1} - {2:d}]{3}", result.Publisher, result.Location, result.PublishedDate, result.Title);
        /// }
        /// </code>
        /// </example>
        public static IList<INewsResult> Search(string keyword, int resultCount)
        {
            return Search(keyword, resultCount, null, new SortType());
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GnewsSearcher.Search("Olympic", 16, SortType.date);
        /// foreach(INewsResult result in results)
        /// {
        ///     Console.WriteLine("[{0}, {1} - {2:d}]{3}", result.Publisher, result.Location, result.PublishedDate, result.Title);
        /// }
        /// </code>
        /// </example>
        public static IList<INewsResult> Search(string keyword, int resultCount, SortType sortBy)
        {
            return Search(keyword, resultCount, null, sortBy);
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GnewsSearcher.Search("Olympic", 16, "Beijing China");
        /// foreach(INewsResult result in results)
        /// {
        ///     Console.WriteLine("[{0}, {1} - {2:d}]{3}", result.Publisher, result.Location, result.PublishedDate, result.Title);
        /// }
        /// </code>
        /// </example>
        public static IList<INewsResult> Search(string keyword, int resultCount, string geo)
        {
            return Search(keyword, resultCount, geo, new SortType());
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GnewsSearcher.Search("Olympic", 16, "Beijing China", SortType.date);
        /// foreach(INewsResult result in results)
        /// {
        ///     Console.WriteLine("[{0}, {1} - {2:d}]{3}", result.Publisher, result.Location, result.PublishedDate, result.Title);
        /// }
        /// </code>
        /// </example>
        public static IList<INewsResult> Search(string keyword, int resultCount, string geo, SortType sortBy)
        {
            if (keyword == null && string.IsNullOrEmpty(geo))
            {
                throw new ArgumentNullException("keyword");
            }

            GSearchCallback<GnewsResult> gsearch =
                (start, resultSize) => GSearch(keyword, start, resultSize, geo, sortBy);
            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (INewsResult)item);
        }

        /// <summary>
        /// Search the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GnewsSearcher.SearchLocal("Tokyo", 16);
        /// foreach(INewsResult result in results)
        /// {
        ///     Console.WriteLine("[{0}, {1} - {2:d}]{3}", result.Publisher, result.Location, result.PublishedDate, result.Title);
        /// }
        /// </code>
        /// </example>
        public static IList<INewsResult> SearchLocal(string geo, int resultCount)
        {
            return SearchLocal(geo, resultCount, new SortType());
        }

        /// <summary>
        /// Search the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GnewsSearcher.Search("Tokyo", 16, SortType.date);
        /// foreach(INewsResult result in results)
        /// {
        ///     Console.WriteLine("[{0}, {1} - {2:d}]{3}", result.Publisher, result.Location, result.PublishedDate, result.Title);
        /// }
        /// </code>
        /// </example>
        public static IList<INewsResult> SearchLocal(string geo, int resultCount, SortType sortBy)
        {
            if (geo == null)
            {
                throw new ArgumentNullException("geo");
            }

            return Search(null, resultCount, geo, sortBy);
        }

        internal static SearchData<GnewsResult> GSearch(
            string keyword, int start, ResultSize resultSize, string geo, SortType sortBy)
        {
            if (keyword == null && string.IsNullOrEmpty(geo))
            {
                throw new ArgumentNullException("keyword");
            }

            var responseData =
                SearchUtility.GetResponseData(
                    service => service.NewsSearch(keyword, resultSize.ToString(), start, sortBy.GetString(), geo));
            return responseData;
        }
    }
}