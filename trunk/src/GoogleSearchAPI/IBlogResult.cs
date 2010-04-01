//-----------------------------------------------------------------------
// <copyright file="IBlogResult.cs" company="iron9light">
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

    /// <summary>
    /// Blog search result.
    /// </summary>
    public interface IBlogResult
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the URL to the blog post referenced in this search result.
        /// </summary>
        string PostUrl { get; }

        /// <summary>
        /// Gets a snippet of content from the blog post associated with this search result.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets the name of the author that wrote the blog post.
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Gets the URL of the blog which contains the post. 
        /// </summary>
        string BlogUrl { get; }

        /// <summary>
        /// Gets the published date of the blog post referenced by this search result.
        /// </summary>
        DateTime PublishedDate { get; }
    }
}