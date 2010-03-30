//-----------------------------------------------------------------------
// <copyright file="GbookSearchClient.cs" company="iron9light">
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
    /// The client for book search.
    /// </summary>
    public class GbookSearchClient : GSearchClient
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the <see cref="GbookSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GbookSearchClient(string referrer)
            : base(referrer)
        {
        }

        /// <summary>
        /// Search books.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IBookResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, false, null);
        }

        /// <summary>
        /// Search books.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="fullViewOnly">Whether to restrict the search to "full view" books.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IBookResult> Search(string keyword, int resultCount, bool fullViewOnly)
        {
            return this.Search(keyword, resultCount, fullViewOnly, null);
        }

        /// <summary>
        /// Search books.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="fullViewOnly">Whether to restrict the search to "full view" books.</param>
        /// <param name="library">The specified user-defined library. If it not null, the search will restrict the search to this library.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IBookResult> Search(string keyword, int resultCount, bool fullViewOnly, string library)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GbookSearchRequest { Query = keyword, FullViewOnly = fullViewOnly, Library = library };
            return this.Search<GbookResult, IBookResult>(request, resultCount);
        }
#endif

        /// <summary>
        /// Search books.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, false, null, callback, state);
        }

        /// <summary>
        /// Search books.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="fullViewOnly">Whether to restrict the search to "full view" books.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, bool fullViewOnly, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, fullViewOnly, null, callback, state);
        }

        /// <summary>
        /// Search books.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="fullViewOnly">Whether to restrict the search to "full view" books.</param>
        /// <param name="library">The specified user-defined library. If it not null, the search will restrict the search to this library.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, bool fullViewOnly, string library, AsyncCallback callback, object state)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GbookSearchRequest { Query = keyword, FullViewOnly = fullViewOnly, Library = library };
            return this.BeginSearch<GbookResult>(request, resultCount, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<IBookResult> EndSearch(IAsyncResult asyncResult)
        {
            return EndSearch<GbookResult, IBookResult>(asyncResult);
        }
    }
}