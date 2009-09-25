//-----------------------------------------------------------------------
// <copyright file="GwebSearchClient.cs" company="iron9light">
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
    using System.Runtime.InteropServices;

    /// <summary>
    /// The client for web search.
    /// </summary>
    /// <remarks>
    /// You can use public static fields of <see cref="SafeLevel"/>, <see cref="Language"/> and <see cref="DuplicateFilter"/> as your parameters.
    /// </remarks>
    /// <seealso cref="SafeLevel"/>
    /// <seealso cref="Language"/>
    /// <seealso cref="DuplicateFilter"/>
    public class GwebSearchClient : GSearchClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GwebSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GwebSearchClient(string referrer)
            : base(referrer)
        {
        }

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        public IList<IWebResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, Language.GetDefault(), SafeLevel.GetDefault());
        }

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        public IList<IWebResult> Search(string keyword, int resultCount, string language)
        {
            return this.Search(keyword, resultCount, language, SafeLevel.GetDefault());
        }

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        public IList<IWebResult> Search(string keyword, int resultCount, string language, string safeLevel)
        {
            return this.Search(keyword, resultCount, null, null, safeLevel, language, DuplicateFilter.GetDefault());
        }

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="customSearchId">This optional argument supplies the unique id for the Custom Search Engine that should be used for this request.</param>
        /// <param name="customSearchReference">This optional argument supplies the url of a linked Custom Search Engine specification that should be used to satisfy this request.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="duplicateFilter">This optional argument controls turning on or off the duplicate content filter. Default value is true.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        public IList<IWebResult> Search(
            string keyword,
            int resultCount,
            [Optional] string customSearchId,
            [Optional] string customSearchReference,
            [Optional] string safeLevel,
            [Optional] string language,
            [Optional] string duplicateFilter)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            GSearchCallback<GwebResult> gsearch =
                (start, resultSize) =>
                this.GSearch(
                    keyword,
                    start,
                    resultSize,
                    customSearchId,
                    customSearchReference,
                    safeLevel,
                    language,
                    duplicateFilter);
            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (IWebResult)item);
        }

        internal SearchData<GwebResult> GSearch(
            string keyword,
            int start,
            string resultSize,
            string customSearchId,
            string customSearchReference,
            string safeLevel,
            string language,
            string duplicateFilter)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var responseData =
                this.GetResponseData(
                    service =>
                    service.WebSearch(
                        this.AcceptLanguage,
                        this.ApiKey,
                        keyword,
                        resultSize,
                        start,
                        customSearchId,
                        customSearchReference,
                        safeLevel,
                        language,
                        duplicateFilter));
            return responseData;
        }
    }
}