//-----------------------------------------------------------------------
// <copyright file="GblogSearchClient.cs" company="iron9light">
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
    /// The client for blog search.
    /// </summary>
    /// <remarks>
    /// You can use public static fields of <see cref="SortType"/> as your parameter.
    /// </remarks>
    /// <seealso cref="SortType"/>
    public class GblogSearchClient : GSearchClient
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the <see cref="GblogSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GblogSearchClient(string referrer)
            : base(referrer)
        {
        }

        /// <summary>
        /// Search blogs.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IBlogResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, SortType.GetDefault());
        }

        /// <summary>
        /// Search blogs.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IBlogResult> Search(string keyword, int resultCount, string sortBy)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GblogSearchRequest { Query = keyword, SortBy = sortBy };
            return this.Search<GblogResult, IBlogResult>(request, resultCount);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request for searching blogs.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, SortType.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching blogs.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, string sortBy, AsyncCallback callback, object state)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GblogSearchRequest { Query = keyword, SortBy = sortBy };
            return this.BeginSearch<GblogResult>(request, resultCount, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<IBlogResult> EndSearch(IAsyncResult asyncResult)
        {
            return EndSearch<GblogResult, IBlogResult>(asyncResult);
        }
    }
}