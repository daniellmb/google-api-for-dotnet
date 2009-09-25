//-----------------------------------------------------------------------
// <copyright file="GimageSearchClient.cs" company="iron9light">
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
    /// The client for image search.
    /// </summary>
    public class GimageSearchClient : GSearchClient
    {
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
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
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
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
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
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
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
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
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
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
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
        /// <remarks>Now, the max count of items Google given is <b>32</b>.</remarks>
        public IList<IImageResult> Search(
            string keyword,
            int resultCount,
            [Optional] string safeLevel,
            [Optional] string imageSize,
            [Optional] string colorization,
            [Optional] string color,
            [Optional] string imageType,
            [Optional] string fileType,
            [Optional] string site)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            GSearchCallback<GimageResult> gsearch =
                (start, resultSize) =>
                this.GSearch(
                    keyword, start, resultSize, safeLevel, imageSize, colorization, color, imageType, fileType, site);
            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (IImageResult)item);
        }

        internal SearchData<GimageResult> GSearch(
            string keyword,
            int start,
            string resultSize,
            string safeLevel,
            string imageSize,
            string colorization,
            string color,
            string imageType,
            string fileType,
            string searchSite)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var responseData =
                this.GetResponseData(
                    service =>
                    service.ImageSearch(
                        this.AcceptLanguage,
                        this.ApiKey,
                        keyword,
                        resultSize,
                        start,
                        safeLevel,
                        imageSize,
                        colorization,
                        color,
                        imageType,
                        fileType,
                        searchSite));
            return responseData;
        }
    }
}