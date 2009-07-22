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
                new SafeLevel(),
                new ImageSize(),
                new Colorization(),
                new ImageType(),
                new FileType(),
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
                new SafeLevel(),
                new ImageSize(),
                new Colorization(),
                new ImageType(),
                new FileType(),
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
            ImageSize imageSize,
            Colorization colorization,
            ImageType imageType,
            FileType fileType)
        {
            return this.Search(
                keyword, resultCount, new SafeLevel(), imageSize, colorization, imageType, fileType, null);
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
            ImageSize imageSize,
            Colorization colorization,
            ImageType imageType,
            FileType fileType,
            string site)
        {
            return this.Search(
                keyword, resultCount, new SafeLevel(), imageSize, colorization, imageType, fileType, site);
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
            SafeLevel safeLevel,
            ImageSize imageSize,
            Colorization colorization,
            ImageType imageType,
            FileType fileType,
            string site)
        {
            return this.Search(
                keyword, resultCount, safeLevel, imageSize, colorization, new ImageColor(), imageType, fileType, site);
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
            [Optional] SafeLevel safeLevel,
            [Optional] ImageSize imageSize,
            [Optional] Colorization colorization,
            [Optional] ImageColor color,
            [Optional] ImageType imageType,
            [Optional] FileType fileType,
            string site)
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
            ResultSize resultSize,
            SafeLevel safeLevel,
            ImageSize imageSize,
            Colorization colorization,
            ImageColor color,
            ImageType imageType,
            FileType fileType,
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
                        resultSize.GetString(),
                        start,
                        safeLevel.GetString(),
                        imageSize.GetString(),
                        colorization.GetString(),
                        color.GetString(),
                        imageType.GetString(),
                        fileType.GetString(),
                        searchSite));
            return responseData;
        }
    }
}