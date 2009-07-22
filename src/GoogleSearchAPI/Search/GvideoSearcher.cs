//-----------------------------------------------------------------------
// <copyright file="GvideoSearcher.cs" company="iron9light">
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
    /// Utility class for Google Video Search service.
    /// </summary>
    [Obsolete("Use GvideoSearchClient instead.")]
    public static class GvideoSearcher
    {
        /// <summary>
        /// Search video.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IVideoResult&gt; results = GvideoSearcher.Search("South Park", 32);
        /// foreach(IVideoResult result in results)
        /// {
        ///     Console.WriteLine("[{0} - {1} seconds by {2}] {3} => {4}", result.Title, result.Duration, result.Publisher, result.Content, result.Url);
        /// }
        /// </code>
        /// </example>
        public static IList<IVideoResult> Search(string keyword, int resultCount)
        {
            return Search(keyword, resultCount, new SortType());
        }

        /// <summary>
        /// Search video.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="sortBy">The way to order results.</param>
        /// <returns>The result items.</returns>
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// IList&lt;IVideoResult&gt; results = GvideoSearcher.Search("Metal Gear Solid", 10, SortType.date);
        /// foreach(IVideoResult result in results)
        /// {
        ///     Console.WriteLine("[{0} - {1} seconds by {2}] {3} => {4}", result.Title, result.Duration, result.Publisher, result.Content, result.Url);
        /// }
        /// </code>
        /// </example>
        public static IList<IVideoResult> Search(string keyword, int resultCount, SortType sortBy)
        {
            var client = new GvideoSearchClient();
            return client.Search(keyword, resultCount, sortBy);
        }
    }
}