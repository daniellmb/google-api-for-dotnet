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
    public class GwebSearchClient : GSearchClient
    {
        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IWebResult&gt; results = GwebSearcher.Search("Google API for .NET", 8);
        /// foreach(IWebResult result in results)
        /// {
        ///     Console.WriteLine("{0} - {1}", result.Title, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IWebResult> Search(string keyword, int resultCount)
        {
            return this.Search(keyword, resultCount, new Language(), new SafeLevel());
        }

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="language">The language you want to search.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IWebResult&gt; results = GwebSearcher.Search("Google API for .NET", 32, Language.ChineseSimplified);
        /// foreach(IWebResult result in results)
        /// {
        ///     Console.WriteLine("{0} - {1}", result.Title, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IWebResult> Search(string keyword, int resultCount, Language language)
        {
            return this.Search(keyword, resultCount, language, new SafeLevel());
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
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IWebResult&gt; results = GwebSearcher.Search("Google API for .NET", 20, Language.ChineseSimplified, SafeLevel.active);
        /// foreach(IWebResult result in results)
        /// {
        ///     Console.WriteLine("{0} - {1}", result.Title, result.Content);
        /// }
        /// </code>
        /// </example>
        public IList<IWebResult> Search(string keyword, int resultCount, Language language, SafeLevel safeLevel)
        {
            return this.Search(keyword, resultCount, null, null, safeLevel, language, true);
        }

        public IList<IWebResult> Search(
            string keyword,
            int resultCount,
            [Optional] string customSearchId,
            [Optional] string customSearchReference,
            [Optional] SafeLevel safeLevel,
            [Optional] Language language,
            [Optional, DefaultParameterValue(true)] bool duplicateFilter)
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
            ResultSize resultSize,
            string customSearchId,
            string customSearchReference,
            SafeLevel safeLevel,
            Language language,
            bool duplicateFilter)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var languageCode = LanguageUtility.GetLanguageCode(language);

            var responseData =
                this.GetResponseData(
                    service =>
                    service.WebSearch(
                        this.AcceptLanguage,
                        this.ApiKey,
                        keyword,
                        resultSize.GetString(),
                        start,
                        customSearchId,
                        customSearchReference,
                        safeLevel.GetString(),
                        languageCode,
                        duplicateFilter.GetStringWithTrueDefault()));
            return responseData;
        }
    }
}