//-----------------------------------------------------------------------
// <copyright file="INewsResult.cs" company="iron9light">
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
    /// <summary>
    /// News search result.
    /// </summary>
    public interface INewsResult : INewsResultItem
    {
        /// <summary>
        /// Gets the URL points to a landing page that points to all of the related stories. When a news result has a set of related stories, this URL is available and non-null. Otherwise, it is null.
        /// </summary>
        string ClusterUrl { get; }

        /// <summary>
        /// Gets a snippet of content from the news story associated with this search result.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets a set of closely related stories. If there is no related story it will return null.
        /// </summary>
        INewsResultItem[] RelatedStories { get; }

        /// <summary>
        /// Gets a image that represents the cluster of news articles related to this result. If there is no good image for this result it will return null.
        /// </summary>
        INewsImage Image { get; }

        /// <summary>
        /// Gets the name of the person that the quote is attributed to. Note, you can get the author only when this is a quote. 
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Gets whether it is a quote or a normal news.
        /// </summary>
        bool IsQuote { get; }
    }
}