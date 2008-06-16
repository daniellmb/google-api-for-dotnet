/**
 * GNewsSearcher.cs
 *
 * Copyright (C) 2008,  iron9light
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Net;

namespace Google.API.Search
{
    /// <summary>
    /// Utility class for Google News Search service.
    /// </summary>
    public static class GNewsSearcher
    {
        private static int s_Timeout = 0;

        /// <summary>
        /// Get or set the length of time, in milliseconds, before the request times out.
        /// </summary>
        public static int Timeout
        {
            get
            {
                return s_Timeout;
            }
            set
            {
                if (s_Timeout < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                s_Timeout = value;
            }
        }

        internal static SearchData<GNewsResult> GSearch(string keyword, int start, ResultSizeEnum resultSize, string geo, SortType sortBy)
        {
            if (keyword == null && string.IsNullOrEmpty(geo))
            {
                throw new ArgumentNullException("keyword");
            }

            GNewsSearchRequest request = new GNewsSearchRequest(keyword, start, resultSize, geo, sortBy);

            WebRequest webRequest;
            if (Timeout != 0)
            {
                webRequest = request.GetWebRequest(Timeout);
            }
            else
            {
                webRequest = request.GetWebRequest();
            }

            SearchData<GNewsResult> responseData;
            try
            {
                responseData = RequestUtility.GetResponseData<SearchData<GNewsResult>>(webRequest);
            }
            catch (GoogleAPIException ex)
            {
                throw new SearchException(string.Format("request:\"{0}\"", request), ex);
            }
            return responseData;
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <exception cref="SearchException">Search failed.</exception>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsResult&gt; results = GNewsSearcher.Search("Olympic", 16);
        /// foreach(INewsSearchResult result in results)
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
        /// <exception cref="SearchException">Search failed.</exception>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsSearchResult&gt; results = GNewsSearcher.Search("Olympic", 16, SortType.date);
        /// foreach(INewsSearchResult result in results)
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
        /// <exception cref="SearchException">Search failed.</exception>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsSearchResult&gt; results = GNewsSearcher.Search("Olympic", 16, "Beijing China");
        /// foreach(INewsSearchResult result in results)
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
        /// <exception cref="SearchException">Search failed.</exception>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsSearchResult&gt; results = GNewsSearcher.Search("Olympic", 16, "Beijing China", SortType.date);
        /// foreach(INewsSearchResult result in results)
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
            int start = 0;
            List<INewsResult> results = new List<INewsResult>();
            int restCount = resultCount;
            while (restCount > 0)
            {
                SearchData<GNewsResult> searchData;
                try
                {
                    if (restCount > 4)
                    {
                        searchData = GSearch(keyword, start, ResultSizeEnum.large, geo, sortBy);
                    }
                    else
                    {
                        searchData = GSearch(keyword, start, ResultSizeEnum.small, geo, sortBy);
                    }
                }
                catch (SearchException ex)
                {
                    return results;
                }

                int count = searchData.Results.Length;
                if (count <= restCount)
                {
                    results.AddRange(searchData.Results);
                }
                else
                {
                    count = restCount;
                    for (int i = 0; i < count; ++i)
                    {
                        results.Add(searchData.Results[i]);
                    }
                }
                start += count;
                restCount -= count;
            }

            return results;
        }

        /// <summary>
        /// Search the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <exception cref="SearchException">Search failed.</exception>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsSearchResult&gt; results = GNewsSearcher.SearchLocal("Tokyo", 16);
        /// foreach(INewsSearchResult result in results)
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
        /// <exception cref="SearchException">Search failed.</exception>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;INewsSearchResult&gt; results = GNewsSearcher.Search("Tokyo", 16, SortType.date);
        /// foreach(INewsSearchResult result in results)
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
    }
}
