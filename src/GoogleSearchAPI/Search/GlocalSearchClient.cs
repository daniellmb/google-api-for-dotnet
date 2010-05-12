//-----------------------------------------------------------------------
// <copyright file="GlocalSearchClient.cs" company="iron9light">
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
    /// The client for local search.
    /// </summary>
    /// <remarks>
    /// You can use public static fields of <see cref="LocalResultType"/> as your parameter.
    /// </remarks>
    /// <seealso cref="LocalResultType"/>
    public class GlocalSearchClient : GSearchClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlocalSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GlocalSearchClient(string referrer)
            : base(referrer)
        {
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
        public IList<ILocalResult> Search(string keyword, int resultCount, float latitude, float longitude)
        {
            return this.Search(keyword, resultCount, latitude, longitude, null, null, LocalResultType.GetDefault());
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
        public IList<ILocalResult> Search(
            string keyword, int resultCount, float latitude, float longitude, string resultType)
        {
            return this.Search(keyword, resultCount, latitude, longitude, null, null, resultType);
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
        public IList<ILocalResult> Search(
            string keyword, int resultCount, float latitude, float longitude, float width, float height)
        {
            return this.Search(
                keyword, resultCount, latitude, longitude, (float?)width, (float?)height, LocalResultType.GetDefault());
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
        public IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float width,
            float height,
            string resultType)
        {
            return this.Search(keyword, resultCount, latitude, longitude, (float?)width, (float?)height, resultType);
        }

        internal LocalSearchData GSearch(
            string keyword,
            int start,
            string resultSize,
            float latitude,
            float longitude,
            float? width,
            float? height,
            string resultType)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var local = latitude + "," + longitude;

            string bounding = null;
            if (width != null && height != null)
            {
                bounding = width + "," + longitude;
            }

            var responseData =
                this.GetResponseData(
                    service =>
                    service.LocalSearch(
                        this.AcceptLanguage,
                        this.ApiKey,
                        keyword,
                        resultSize,
                        start,
                        local,
                        bounding,
                        resultType));

            return responseData;
        }

        private IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float? width,
            float? height,
            string resultType)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            GSearchCallback<GlocalResult> gsearch =
                (start, resultSize) =>
                this.GSearch(keyword, start, resultSize, latitude, longitude, width, height, resultType);

            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (ILocalResult)item);
        }
    }
}