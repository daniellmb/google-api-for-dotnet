//-----------------------------------------------------------------------
// <copyright file="GnewsSearchClient.cs" company="iron9light">
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
    /// The client for news search.
    /// </summary>
    /// <remarks>
    /// You can use public static fields of <see cref="SortType"/>, <see cref="NewsTopic"/> and <see cref="NewsEdition"/> as your parameters.
    /// </remarks>
    /// <seealso cref="SortType"/>
    /// <seealso cref="NewsTopic"/>
    /// <seealso cref="NewsEdition"/>
    public class GnewsSearchClient : GSearchClient
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the <see cref="GnewsSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GnewsSearchClient(string referrer)
            : base(referrer)
        {
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, null, SortType.GetDefault());
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> Search(string keyword, int resultCount, string geo, string sortBy)
        {
            return this.Search(keyword, resultCount, geo, sortBy, null, NewsTopic.GetDefault(), NewsEdition.GetDefault());
        }

        /// <summary>
        /// Search news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="quoteId">This optional argument tells the news search system to scope search results to include only quote typed results.</param>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="edition">This optional argument tells the news search system which edition of news to pull results from.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> Search(
            string keyword,
            int resultCount,
            string geo,
            string sortBy,
            string quoteId,
            string topic,
            string edition)
        {
            if (keyword == null && string.IsNullOrEmpty(geo) && string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GnewsSearchRequest
                {
                    Query = keyword, Geo = geo, SortBy = sortBy, QuoteId = quoteId, Topic = topic, Edition = edition 
                };
            return this.Search<GnewsResult, INewsResult>(request, resultCount);
        }

        /// <summary>
        /// Search the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> SearchLocal(string geo, int resultCount)
        {
            return this.SearchLocal(geo, resultCount, SortType.GetDefault());
        }

        /// <summary>
        /// Search the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> SearchLocal(string geo, int resultCount, string sortBy)
        {
            return this.SearchLocal(geo, resultCount, sortBy, null, NewsTopic.GetDefault(), NewsEdition.GetDefault());
        }

        /// <summary>
        /// Search the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="quoteId">This optional argument tells the news search system to scope search results to include only quote typed results.</param>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="edition">This optional argument tells the news search system which edition of news to pull results from.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> SearchLocal(
            string geo,
            int resultCount,
            string sortBy,
            string quoteId,
            string topic,
            string edition)
        {
            if (geo == null)
            {
                throw new ArgumentNullException("geo");
            }

            return this.Search(null, resultCount, geo, sortBy, quoteId, topic, edition);
        }

        /// <summary>
        /// Search the latest news of specified topic.
        /// </summary>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> SearchTopic(string topic, int resultCount)
        {
            return this.SearchTopic(topic, resultCount, SortType.GetDefault(), null, NewsEdition.GetDefault());
        }

        /// <summary>
        /// Search the latest news of specified topic.
        /// </summary>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="quoteId">This optional argument tells the news search system to scope search results to include only quote typed results.</param>
        /// <param name="edition">This optional argument tells the news search system which edition of news to pull results from.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<INewsResult> SearchTopic(
            string topic,
            int resultCount,
            string sortBy,
            string quoteId,
            string edition)
        {
            if (topic == null)
            {
                throw new ArgumentNullException("topic");
            }

            return this.Search(null, resultCount, null, sortBy, quoteId, topic, edition);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request for searching news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, null, SortType.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword, int resultCount, string geo, string sortBy, AsyncCallback callback, object state)
        {
            return this.BeginSearch(keyword, resultCount, geo, sortBy, null, NewsTopic.GetDefault(), NewsEdition.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching news.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="quoteId">This optional argument tells the news search system to scope search results to include only quote typed results.</param>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="edition">This optional argument tells the news search system which edition of news to pull results from.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            string geo,
            string sortBy,
            string quoteId,
            string topic,
            string edition,
            AsyncCallback callback,
            object state)
        {
            if (keyword == null && string.IsNullOrEmpty(geo) && string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GnewsSearchRequest
            {
                Query = keyword,
                Geo = geo,
                SortBy = sortBy,
                QuoteId = quoteId,
                Topic = topic,
                Edition = edition
            };
            return this.BeginSearch<GnewsResult>(request, resultCount, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<INewsResult> EndSearch(IAsyncResult asyncResult)
        {
            return this.EndSearch<GnewsResult, INewsResult>(asyncResult);
        }

        /// <summary>
        /// Begins an asynchronous request for searching the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearchLocal(string geo, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearchLocal(geo, resultCount, SortType.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearchLocal(
            string geo, int resultCount, string sortBy, AsyncCallback callback, object state)
        {
            return this.BeginSearchLocal(geo, resultCount, sortBy, null, NewsTopic.GetDefault(), NewsEdition.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching the latest local news.
        /// </summary>
        /// <param name="geo">A particular location of the news. You must supply either a city, state, country, or zip code as in "Santa Barbara" or "British Columbia" or "Peru" or "93108".</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="quoteId">This optional argument tells the news search system to scope search results to include only quote typed results.</param>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="edition">This optional argument tells the news search system which edition of news to pull results from.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearchLocal(
            string geo,
            int resultCount,
            string sortBy,
            string quoteId,
            string topic,
            string edition,
            AsyncCallback callback,
            object state)
        {
            if (geo == null)
            {
                throw new ArgumentNullException("geo");
            }

            return this.BeginSearch(null, resultCount, geo, sortBy, quoteId, topic, edition, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<INewsResult> EndSearchLocal(IAsyncResult asyncResult)
        {
            return this.EndSearch(asyncResult);
        }

        /// <summary>
        /// Begins an asynchronous request for searching the latest news of specified topic.
        /// </summary>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearchTopic(string topic, int resultCount, AsyncCallback callback, object state)
        {
            return this.BeginSearchTopic(topic, resultCount, SortType.GetDefault(), null, NewsEdition.GetDefault(), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching the latest news of specified topic.
        /// </summary>
        /// <param name="topic">This optional argument tells the news search system to scope search results to a particular topic.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <param name="quoteId">This optional argument tells the news search system to scope search results to include only quote typed results.</param>
        /// <param name="edition">This optional argument tells the news search system which edition of news to pull results from.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearchTopic(
            string topic,
            int resultCount,
            string sortBy,
            string quoteId,
            string edition,
            AsyncCallback callback,
            object state)
        {
            if (topic == null)
            {
                throw new ArgumentNullException("topic");
            }

            return this.BeginSearch(null, resultCount, null, sortBy, quoteId, topic, edition, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<INewsResult> EndSearchTopic(IAsyncResult asyncResult)
        {
            return this.EndSearch(asyncResult);
        }
    }
}