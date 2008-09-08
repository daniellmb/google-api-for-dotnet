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

namespace Google.API.Search
{
    /// <summary>
    /// The image size.
    /// </summary>
    public enum ImageSize
    {
        /// <summary>
        /// All sizes. Default value.
        /// </summary>
        all = 0,

        /// <summary>
        /// Icon size.
        /// </summary>
        icon,

        /// <summary>
        /// Small size.
        /// </summary>
        small,

        /// <summary>
        /// Medium size.
        /// </summary>
        medium,

        /// <summary>
        /// Large size.
        /// </summary>
        large,

        /// <summary>
        /// Large plus size.
        /// </summary>
        xlarge,

        /// <summary>
        /// Large plus plus size.
        /// </summary>
        xxlarge,

        /// <summary>
        /// Huge size.
        /// </summary>
        huge,
    }

    /// <summary>
    /// A specified colorization of images.
    /// </summary>
    public enum Colorization
    {
        /// <summary>
        /// All colorizations. Default value.
        /// </summary>
        all = 0,

        /// <summary>
        /// The black and white images.
        /// </summary>
        mono,

        /// <summary>
        /// The grayscale images.
        /// </summary>
        gray,

        /// <summary>
        /// The color images.
        /// </summary>
        color,
    }

    /// <summary>
    /// The special type of image.
    /// </summary>
    public enum ImageType
    {
        /// <summary>
        /// All types. Default value.
        /// </summary>
        all = 0,

        /// <summary>
        /// Images of faces.
        /// </summary>
        face,
    }

    /// <summary>
    /// The specified file type of image.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// All types. Default value.
        /// </summary>
        all = 0,

        /// <summary>
        /// The jpg images.
        /// </summary>
        jpg,

        /// <summary>
        /// The png images.
        /// </summary>
        png,

        /// <summary>
        /// The gif images.
        /// </summary>
        gif,

        /// <summary>
        /// The bmp images.
        /// </summary>
        bmp,
    }

    internal class GimageSearchRequest : GSearchRequestBase
    {
        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/search/images";

        public GimageSearchRequest(string keyword, int start, ResultSize resultSize, ImageSize imageSize, Colorization colorization, ImageType imageType, FileType fileType, string site, SafeLevel safeLevel)
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
