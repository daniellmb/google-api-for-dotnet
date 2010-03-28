//-----------------------------------------------------------------------
// <copyright file="GimageSearchRequest.cs" company="iron9light">
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
    internal class GimageSearchRequest : GoogleSearchRequest
    {
        /// <summary>
        /// This optional argument supplies the search safety level.
        /// </summary>
        [Argument("safe")]
        public string SafeLevel { get; set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified size.
        /// </summary>
        [Argument("imgsz")]
        public string ImageSize { get; set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified colorization.
        /// </summary>
        [Argument("imgc")]
        public string Colorization { get; set; }

        /// <summary>
        /// This optional argument tells the image search system to filter the search to images of the specified color.
        /// </summary>
        [Argument("imgcolor")]
        public string ImageColor { get; set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified type.
        /// </summary>
        [Argument("imgtype")]
        public string ImageType { get; set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images of the specified filetype.
        /// </summary>
        [Argument("as_filetype")]
        public string FileType { get; set; }

        /// <summary>
        /// This optional argument tells the image search system to restrict the search to images within the specified domain, e.g., as_sitesearch=photobucket.com.
        /// </summary>
        [Argument("as_sitesearch")]
        public string Site { get; set; }

        protected override string BaseAddress
        {
            get { return "http://ajax.googleapis.com/ajax/services/search/images"; }
        }
    }
}
