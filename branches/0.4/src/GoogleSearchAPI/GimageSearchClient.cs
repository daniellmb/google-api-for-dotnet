//-----------------------------------------------------------------------
// <copyright file="GimageSearchClient.cs" company="iron9light">
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
    /// The client for image search.
    /// </summary>
    /// <remarks>
    /// You can use public static fields of <see cref="SafeLevel"/>, <see cref="ImageSize"/>, <see cref="Colorization"/>, <see cref="ImageColor"/>, <see cref="ImageType"/> and <see cref="ImageFileType"/> as your parameters.
    /// </remarks>
    /// <seealso cref="SafeLevel"/>
    /// <seealso cref="ImageSize"/>
    /// <seealso cref="Colorization"/>
    /// <seealso cref="ImageColor"/>
    /// <seealso cref="ImageType"/>
    /// <seealso cref="ImageFileType"/>
    public class GimageSearchClient : GSearchClient
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new instance of the <see cref="GimageSearchClient"/> class.
        /// </summary>
        /// <param name="referrer">The http referrer header.</param>
        /// <remarks>Applications MUST always include a valid and accurate http referer header in their requests.</remarks>
        public GimageSearchClient(string referrer)
            : base(referrer)
        {
        }

        /// <summary>
        /// Search images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IImageResult> Search(string keyword, int resultCount)
        {
            return this.Search(
                keyword,
                resultCount,
                SafeLevel.GetDefault(),
                ImageSize.GetDefault(),
                Colorization.GetDefault(),
                ImageType.GetDefault(),
                ImageFileType.GetDefault(),
                null);
        }

        /// <summary>
        /// Search images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IImageResult> Search(string keyword, int resultCount, string site)
        {
            return this.Search(
                keyword,
                resultCount,
                SafeLevel.GetDefault(),
                ImageSize.GetDefault(),
                Colorization.GetDefault(),
                ImageType.GetDefault(),
                ImageFileType.GetDefault(),
                site);
        }

        /// <summary>
        /// Search images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IImageResult> Search(
            string keyword,
            int resultCount,
            string imageSize,
            string colorization,
            string imageType,
            string fileType)
        {
            return this.Search(
                keyword, resultCount, SafeLevel.GetDefault(), imageSize, colorization, imageType, fileType, null);
        }

        /// <summary>
        /// Search images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IImageResult> Search(
            string keyword,
            int resultCount,
            string imageSize,
            string colorization,
            string imageType,
            string fileType,
            string site)
        {
            return this.Search(
                keyword, resultCount, SafeLevel.GetDefault(), imageSize, colorization, imageType, fileType, site);
        }

        /// <summary>
        /// Search images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IImageResult> Search(
            string keyword,
            int resultCount,
            string safeLevel,
            string imageSize,
            string colorization,
            string imageType,
            string fileType,
            string site)
        {
            return this.Search(
                keyword, resultCount, safeLevel, imageSize, colorization, ImageColor.GetDefault(), imageType, fileType, site);
        }

        /// <summary>
        /// Search images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="color">The specified color of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <returns>The result itmes.</returns>
        /// <remarks>Now, the max count of items Google given is <b>64</b>.</remarks>
        public IList<IImageResult> Search(
            string keyword,
            int resultCount,
            string safeLevel,
            string imageSize,
            string colorization,
            string color,
            string imageType,
            string fileType,
            string site)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GimageSearchRequest
                {
                    Query = keyword,
                    SafeLevel = safeLevel,
                    ImageSize = imageSize,
                    Colorization = colorization,
                    ImageColor = color,
                    ImageType = imageType,
                    FileType = fileType,
                    Site = site
                };
            return this.Search<GimageResult, IImageResult>(request, resultCount);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request for searching images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount,
            AsyncCallback callback,
            object state)
        {
            return this.BeginSearch(
                keyword,
                resultCount,
                SafeLevel.GetDefault(),
                ImageSize.GetDefault(),
                Colorization.GetDefault(),
                ImageType.GetDefault(),
                ImageFileType.GetDefault(),
                null,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(string keyword, int resultCount, string site,
            AsyncCallback callback,
            object state)
        {
            return this.BeginSearch(
                keyword,
                resultCount,
                SafeLevel.GetDefault(),
                ImageSize.GetDefault(),
                Colorization.GetDefault(),
                ImageType.GetDefault(),
                ImageFileType.GetDefault(),
                site,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            string imageSize,
            string colorization,
            string imageType,
            string fileType,
            AsyncCallback callback,
            object state)
        {
            return this.BeginSearch(
                keyword,
                resultCount,
                SafeLevel.GetDefault(),
                imageSize,
                colorization,
                imageType,
                fileType,
                null,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            string imageSize,
            string colorization,
            string imageType,
            string fileType,
            string site,
            AsyncCallback callback,
            object state)
        {
            return this.BeginSearch(
                keyword,
                resultCount,
                SafeLevel.GetDefault(),
                imageSize,
                colorization,
                imageType,
                fileType,
                site,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            string safeLevel,
            string imageSize,
            string colorization,
            string imageType,
            string fileType,
            string site,
            AsyncCallback callback,
            object state)
        {
            return this.BeginSearch(
                keyword,
                resultCount,
                safeLevel,
                imageSize,
                colorization,
                ImageColor.GetDefault(),
                imageType,
                fileType,
                site,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous request for searching images.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="resultCount">The count of result itmes.</param>
        /// <param name="safeLevel">The search safety level.</param>
        /// <param name="imageSize">The size of image.</param>
        /// <param name="colorization">The specified colorization of image.</param>
        /// <param name="color">The specified color of image.</param>
        /// <param name="imageType">The special type of image.</param>
        /// <param name="fileType">The specified file type of image.</param>
        /// <param name="site">The specified domain. It will restrict the search to images within this domain.e.g., <c>photobucket.com</c>.</param>
        /// <param name="callback">The <see cref="AsyncCallback"/> delegate.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous request.</returns>
        public IAsyncResult BeginSearch(
            string keyword,
            int resultCount,
            string safeLevel,
            string imageSize,
            string colorization,
            string color,
            string imageType,
            string fileType,
            string site,
            AsyncCallback callback,
            object state)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var request = new GimageSearchRequest
            {
                Query = keyword,
                SafeLevel = safeLevel,
                ImageSize = imageSize,
                Colorization = colorization,
                ImageColor = color,
                ImageType = imageType,
                FileType = fileType,
                Site = site
            };
            return this.BeginSearch<GimageResult>(request, resultCount, callback, state);
        }

        /// <summary>
        /// returns search results.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references a pending request for a response.</param>
        /// <returns>The search results.</returns>
        public IList<IImageResult> EndSearch(IAsyncResult asyncResult)
        {
            return this.EndSearch<GimageResult, IImageResult>(asyncResult);
        }
    }
}