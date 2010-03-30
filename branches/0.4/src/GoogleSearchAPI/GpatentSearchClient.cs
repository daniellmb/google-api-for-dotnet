//-----------------------------------------------------------------------
// <copyright file="GpatentSearchClient.cs" company="iron9light">
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
    /// The client for patent search.
    /// </summary>
    /// <remarks>
    /// You can use public static fields of <see cref="SortType"/> as your parameter.
    /// </remarks>
    /// <seealso cref="SortType"/>
    public class GpatentSearchClient : GSearchClient
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the <see cref="GpatentSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GpatentSearchClient(string referrer)
            : base(referrer)
        {
        }

        /// <summary>
        /// Search patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>
        /// Now, the max count of items Google given is <b>64</b>.
        /// </remarks>
        public IList<IPatentResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, false, false, SortType.GetDefault());
        }

        /// <summary>
        /// Search patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>
        /// Now, the max count of items Google given is <b>64</b>.
        /// </remarks>
        public IList<IPatentResult> Search(string keyword, int resultCount, string sortBy)
        {
            return this.Search(keyword, resultCount, false, false, sortBy);
        }

        /// <summary>
        /// Search patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="issuedOnly">Whether restrict the search to ONLY patents that having been issued, skiping all patents that have only been filed.</param>
        /// <param name="filedOnly">Whether restrict the search to ONLY patents that only been filed, skipping over all patents that have been issued.</param>
        /// <returns>The result items.</returns>
        /// <remarks>
        /// When both issuedOnly and filedOnly are true, it equals to both are false.
        /// Now, the max count of items Google given is <b>64</b>.
        /// </remarks>
        public IList<IPatentResult> Search(string keyword, int resultCount, bool issuedOnly, bool filedOnly)
        {
            return this.Search(keyword, resultCount, issuedOnly, filedOnly, SortType.GetDefault());
        }

        /// <summary>
        /// Search patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="issuedOnly">Whether restrict the search to ONLY patents that having been issued, skiping all patents that have only been filed.</param>
        /// <param name="filedOnly">Whether restrict the search to ONLY patents that only been filed, skipping over all patents that have been issued.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>
        /// When both issuedOnly and filedOnly are true, it equals to both are false.
        /// Now, the max count of items Google given is <b>64</b>.
        /// </remarks>
        public IList<IPatentResult> Search(
            string keyword,
            int resultCount,
            bool issuedOnly,
            bool filedOnly,
            string sortBy)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GpatentSearchRequest
                {
                    Query = keyword, IssuedOnly = issuedOnly, FiledOnly = filedOnly, SortBy = sortBy 
                };
            return this.Search<GpatentResult, IPatentResult>(request, resultCount);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request for searching patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, false, false, SortType.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, string sortBy, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, false, false, sortBy, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="issuedOnly">Whether restrict the search to ONLY patents that having been issued, skiping all patents that have only been filed.</param>
        /// <param name="filedOnly">Whether restrict the search to ONLY patents that only been filed, skipping over all patents that have been issued.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        /// <remarks>
        /// When both issuedOnly and filedOnly are true, it equals to both are false.
        /// </remarks>
        public IAsyncResult BeginSearch(string keyword, int resultCount, bool issuedOnly, bool filedOnly, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, issuedOnly, filedOnly, SortType.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="issuedOnly">Whether restrict the search to ONLY patents that having been issued, skiping all patents that have only been filed.</param>
        /// <param name="filedOnly">Whether restrict the search to ONLY patents that only been filed, skipping over all patents that have been issued.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        /// <remarks>
        /// When both issuedOnly and filedOnly are true, it equals to both are false.
        /// </remarks>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            bool issuedOnly,
            bool filedOnly,
            string sortBy,
            AsyncCallback callback,
            object state)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GpatentSearchRequest
            {
                Query = keyword,
                IssuedOnly = issuedOnly,
                FiledOnly = filedOnly,
                SortBy = sortBy
            };
            return this.BeginSearch<GpatentResult>(request, resultCount, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<IPatentResult> EndSearch(IAsyncResult asyncResult)
        {
            return this.EndSearch<GpatentResult, IPatentResult>(asyncResult);
        }
    }
}