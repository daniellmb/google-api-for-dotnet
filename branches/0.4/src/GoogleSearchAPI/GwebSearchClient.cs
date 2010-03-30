//-----------------------------------------------------------------------
// <copyright file="GwebSearchClient.cs" company="iron9light">
// Copyright (c) 2010 iron9light
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
#if !SILVERLIGHT
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
        /// Search web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IWebResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, Language.GetDefault(), SafeLevel.GetDefault());
        }

        /// <summary>
        /// Search web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IWebResult> Search(string keyword, int resultCount, string language)
        {
            return this.Search(keyword, resultCount, language, SafeLevel.GetDefault());
        }

        /// <summary>
        /// Search web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IWebResult> Search(string keyword, int resultCount, string language, string safeLevel)
        {
            return this.Search(keyword, resultCount, null, null, safeLevel, language, DuplicateFilter.GetDefault(), null);
        }

        /// <summary>
        /// Search web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="customSearchId">This optional argument supplies the unique id for the Custom Search Engine that should be used for this request.</param>
        /// <param name="customSearchReference">This optional argument supplies the url of a linked Custom Search Engine specification that should be used to satisfy this request.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="duplicateFilter">This optional argument controls turning on or off the duplicate content filter. Default value is true.</param>
        /// <param name="country">This optional argument allows the caller to tailor the results to a specific country. The value should be a valid <a href="http://en.wikipedia.org/wiki/ISO_3166-1">country code</a> (e.g. uk, de, etc.).</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IWebResult> Search(
            string keyword,
            int resultCount,
            string customSearchId,
            string customSearchReference,
            string safeLevel,
            string language,
            string duplicateFilter,
            string country)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GwebSearchRequest
                {
                    Query = keyword,
                    CustomSearchId = customSearchId,
                    CustomSearchReference = customSearchReference,
                    SafeLevel = safeLevel,
                    Language = language,
                    DuplicateFilter = duplicateFilter,
                    Country = country
                };
            return this.Search<GwebResult, IWebResult>(request, resultCount);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request for searching web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, Language.GetDefault(), SafeLevel.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, string language, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, language, SafeLevel.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, string language, string safeLevel, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, null, null, safeLevel, language, DuplicateFilter.GetDefault(), null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching web infos.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="customSearchId">This optional argument supplies the unique id for the Custom Search Engine that should be used for this request.</param>
        /// <param name="customSearchReference">This optional argument supplies the url of a linked Custom Search Engine specification that should be used to satisfy this request.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="language">The language you want to search.</param>
        /// <param name="duplicateFilter">This optional argument controls turning on or off the duplicate content filter. Default value is true.</param>
        /// <param name="country">This optional argument allows the caller to tailor the results to a specific country. The value should be a valid <a href="http://en.wikipedia.org/wiki/ISO_3166-1">country code</a> (e.g. uk, de, etc.).</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            string customSearchId,
            string customSearchReference,
            string safeLevel,
            string language,
            string duplicateFilter,
            string country,
            AsyncCallback callback,
            object state)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GwebSearchRequest
            {
                Query = keyword,
                CustomSearchId = customSearchId,
                CustomSearchReference = customSearchReference,
                SafeLevel = safeLevel,
                Language = language,
                DuplicateFilter = duplicateFilter,
                Country = country
            };
            return this.BeginSearch<GwebResult>(request, resultCount, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<IWebResult> EndSearch(IAsyncResult asyncResult)
        {
            return this.EndSearch<GwebResult, IWebResult>(asyncResult);
        }
    }
}