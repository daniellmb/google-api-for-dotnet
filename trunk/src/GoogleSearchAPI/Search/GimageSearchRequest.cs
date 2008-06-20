/**
 * GimageSearchRequest.cs
 *
 * Copyright (C) 2008,  iron9light
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;

namespace Google.API.Search
{
    /// <summary>
    /// The search safety level.
    /// </summary>
    public enum SafeLevel
    {
        /// <summary>
        /// Disables safe search filtering.
        /// </summary>
        off,
        /// <summary>
        /// Enables moderate safe search filtering. Default value.
        /// </summary>
        moderate = 0,
        /// <summary>
        /// Enables the highest level of safe search filtering.
        /// </summary>
        active,
    }

    public enum ImageSize
    {
        all = 0,
        icon,
        small,
        medium,
        large,
        xlarge,
        xxlarge,
        huge,
    }

    public enum Colorization
    {
        all = 0,
        mono,
        gray,
        color,
    }

    public enum ImageType
    {
        all = 0,
        face,
    }

    public enum FileType
    {
        all = 0,
        jpg,
        png,
        gif,
        bmp,
    }

    internal class GimageSearchRequest : GSearchRequestBase
    {
        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/search/images";

        public GimageSearchRequest(string keyword, int start, ResultSize resultSize, SafeLevel safeLevel, ImageSize imageSize, Colorization colorization, ImageType imageType, FileType fileType, string site)
            : base(keyword, start, resultSize)
        {
            SafeLevel = safeLevel;
            ImageSize = imageSize;
            Colorization = colorization;
            ImageType = imageType;
            FileType = fileType;
            Site = site;
        }

        /// <summary>
        /// This optional argument supplies the search safety level.
        /// </summary>
        [Argument("safe")]
        public SafeLevel SafeLevel { get; private set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified size.
        /// </summary>
        [Argument("imgsz")]
        public ImageSize ImageSize { get; private set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified colorization.
        /// </summary>
        [Argument("imgc")]
        public Colorization Colorization { get; private set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified type.
        /// </summary>
        [Argument("imgtype")]
        public ImageType ImageType { get; private set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified filetype.
        /// </summary>
        [Argument("as_filetype")]
        public FileType FileType { get; private set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images within the specified domain, e.g., as_sitesearch=photobucket.com.
        /// </summary>
        [Argument("as_sitesearch")]
        public string Site { get; private set; }

        protected override string BaseAddress
        {
            get { return s_BaseAddress; }
        }
    }
}
