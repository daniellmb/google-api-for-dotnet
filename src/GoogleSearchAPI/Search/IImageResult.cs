//-----------------------------------------------------------------------
// <copyright file="IImageResult.cs" company="iron9light">
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
    /// <summary>
    /// Image search result.
    /// </summary>
    public interface IImageResult
    {
        /// <summary>
        /// Get a hashcode of the image.
        /// </summary>
        string ImageId { get; }

        /// <summary>
        /// Get the title of the image.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Get the the URL of the result.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Get a shortened version of the URL associated with the result.
        /// </summary>
        string VisibleUrl { get; }

        /// <summary>
        /// Get the URL of the page containing the image.
        /// </summary>
        string OriginalContextUrl { get; }

        /// <summary>
        /// Get the width of the image in pixels.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Get the height of the image in pixels.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Get a thumbnail image.
        /// </summary>
        ITbImage TbImage { get; }

        /// <summary>
        /// Get a brief snippet of information from the page associated with the search result.
        /// </summary>
        string Content { get; }
    }
}