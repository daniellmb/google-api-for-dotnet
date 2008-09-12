/**
 * GlocalSearcher.cs
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

namespace Google.API.Search
{
    /// <summary>
    /// Utility class for Google Local Search service.
    /// </summary>
    public static class GlocalSearcher
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

        internal static SearchData<GlocalResult> GSearch(
            string keyword,
            int start,
            ResultSize resultSize,
            float latitude,
            float longitude,
            float? width,
            float? height,
            LocalResultType resultType)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GlocalSearchRequest(keyword, start, resultSize, latitude, longitude, width, height, resultType);

            var responseData = RequestUtility.GetResponseData<SearchData<GlocalResult>>(request, Timeout);

            return responseData;
        }

        /// <summary>
        /// Search local infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="latitude">The latitude value of local.</param>
        /// <param name="longitude">The longitude value of local.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;ILocalResult&gt; results = GlocalSearcher.Search("white house", 4, -77.036667f, 38.895000f);
        /// foreach(ILocalResult result in results)
        /// {
        ///     Console.WriteLine("{0} at {1}, {2}", result.Title, result.StreetAddress, result.Region);
        /// }
        /// </code>
        /// </example>
        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude)
        {
            return Search(keyword, resultCount, latitude, longitude, null, null, new LocalResultType());
        }

        /// <summary>
        /// Search local infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="latitude">The latitude value of local.</param>
        /// <param name="longitude">The longitude value of local.</param>
        /// <param name="resultType">The type of local search results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;ILocalResult&gt; results = GlocalSearcher.Search("white house", 4, -77.036667f, 38.895000f, LocalResultType.localonly);
        /// foreach(ILocalResult result in results)
        /// {
        ///     Console.WriteLine("{0} at {1}, {2}", result.Title, result.StreetAddress, result.Region);
        /// }
        /// </code>
        /// </example>
        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            LocalResultType resultType)
        {
            return Search(keyword, resultCount, latitude, longitude, null, null, resultType);
        }

        /// <summary>
        /// Search local infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="latitude">The latitude value of local.</param>
        /// <param name="longitude">The longitude value of local.</param>
        /// <param name="width">The width value of search bouding.</param>
        /// <param name="height">The height value of search bounding.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;ILocalResult&gt; results = GlocalSearcher.Search("white house", 4, -77.036667f, 38.895000f, 1.0f, 0.5f);
        /// foreach(ILocalResult result in results)
        /// {
        ///     Console.WriteLine("{0} at {1}, {2}", result.Title, result.StreetAddress, result.Region);
        /// }
        /// </code>
        /// </example>
        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float width,
            float height)
        {
            return Search(keyword, resultCount, latitude, longitude, (float?)width, (float?)height, new LocalResultType());
        }

        /// <summary>
        /// Search local infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="latitude">The latitude value of local.</param>
        /// <param name="longitude">The longitude value of local.</param>
        /// <param name="width">The width value of search bouding.</param>
        /// <param name="height">The height value of search bounding.</param>
        /// <param name="resultType">The type of local search results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;ILocalResult&gt; results = GlocalSearcher.Search("white house", 4, -77.036667f, 38.895000f, 1.0f, 0.5f, LocalResultType.blended);
        /// foreach(ILocalResult result in results)
        /// {
        ///     Console.WriteLine("{0} at {1}, {2}", result.Title, result.StreetAddress, result.Region);
        /// }
        /// </code>
        /// </example>
        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float width,
            float height,
            LocalResultType resultType)
        {
            return Search(keyword, resultCount, latitude, longitude, (float?)width, (float?)height, resultType);
        }

        private static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float? width,
            float? height,
            LocalResultType resultType)
        {
            if (keyword == null)
                throw new ArgumentNullException("keyword");

            SearchUtility.GSearchCallback<GlocalResult> gsearch = (start, resultSize) => GSearch(
                                                                               keyword,
                                                                               start,
                                                                               resultSize,
                                                                               latitude,
                                                                               longitude,
                                                                               width,
                                                                               height,
                                                                               resultType);

            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (ILocalResult)item);
        }
    }
}
