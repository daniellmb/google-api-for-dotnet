//-----------------------------------------------------------------------
// <copyright file="GpatentSearchClient.cs" company="iron9light">
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
    /// The client for patent search.
    /// </summary>
    public class GpatentSearchClient : GSearchClient
    {
        /// <summary>
        /// Search patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>
        /// Now, the max count of items Google given is <b>32</b>.
        /// </remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IPatentResult&gt; results = GpatentSearcher.Search("auto", 10);
        /// foreach(IPatentResult result in results)
        /// {
        ///     Console.WriteLine("[{0} - US Pat. {1} - filed {2:d} - {3}] {4}", result.Title, result.PatentNumber, result.ApplicationDate, result.Assignee, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IPatentResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, false, false, new SortType());
        }

        /// <summary>
        /// Search patents.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>
        /// Now, the max count of items Google given is <b>32</b>.
        /// </remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IPatentResult&gt; results = GpatentSearcher.Search("encode", 32, SortType.relevance);
        /// foreach(IPatentResult result in results)
        /// {
        ///     Console.WriteLine("[{0} - US Pat. {1} - filed {2:d} - {3}] {4}", result.Title, result.PatentNumber, result.ApplicationDate, result.Assignee, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IPatentResult> Search(string keyword, int resultCount, SortType sortBy)
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
        /// Now, the max count of items Google given is <b>32</b>.
        /// </remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IPatentResult&gt; results = GpatentSearcher.Search("Wifi", 20, true, false);
        /// foreach(IPatentResult result in results)
        /// {
        ///     Console.WriteLine("[{0} - US Pat. {1} - filed {2:d} - {3}] {4}", result.Title, result.PatentNumber, result.ApplicationDate, result.Assignee, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IPatentResult> Search(string keyword, int resultCount, bool issuedOnly, bool filedOnly)
        {
            return this.Search(keyword, resultCount, issuedOnly, filedOnly, new SortType());
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
        /// Now, the max count of items Google given is <b>32</b>.
        /// </remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IPatentResult&gt; results = GpatentSearcher.Search("search engine", 30, true, false, SortType.date);
        /// foreach(IPatentResult result in results)
        /// {
        ///     Console.WriteLine("[{0} - US Pat. {1} - filed {2:d} - {3}] {4}", result.Title, result.PatentNumber, result.ApplicationDate, result.Assignee, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IPatentResult> Search(
            string keyword,
            int resultCount,
            [Optional] bool issuedOnly,
            [Optional] bool filedOnly,
            [Optional] SortType sortBy)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            GSearchCallback<GpatentResult> gsearch =
                (start, resultSize) => this.GSearch(keyword, start, resultSize, issuedOnly, filedOnly, sortBy);
            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (IPatentResult)item);
        }

        internal SearchData<GpatentResult> GSearch(
            string keyword, int start, ResultSize resultSize, bool issuedOnly, bool filedOnly, SortType sortBy)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var responseData =
                this.GetResponseData(
                    service =>
                    service.PatentSearch(
                        this.AcceptLanguage,
                        this.ApiKey,
                        keyword,
                        resultSize.GetString(),
                        start,
                        issuedOnly.GetString(),
                        filedOnly.GetString(),
                        sortBy.GetString()));
            return responseData;
        }
    }
}