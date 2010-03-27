﻿//-----------------------------------------------------------------------
// <copyright file="GimageResult.cs" company="iron9light">
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

    using Newtonsoft.Json;

    [JsonObject]
    internal class GimageResult : IImageResult
    {
        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        [JsonProperty("imageId")]
        public string ImageId { get; private set; }

        /// <summary>
        /// Supplies the title of the image, which is usually the base filename.
        /// </summary>
        [JsonProperty("title")]
        public string TitleWithFormatting { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.)
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        [JsonConverter(typeof(HtmlFormatConverter))]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        [JsonProperty("unescapedUrl")]
        public string Url { get; private set; }

        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        [JsonProperty("url")]
        public string EscapedUrl { get; private set; }

        /// <summary>
        /// Supplies a shortened version of the URL associated with the result. Typically displayed in green, stripped of a protocol and path.
        /// </summary>
        [JsonProperty("visibleUrl")]
        public string VisibleUrl { get; private set; }

        /// <summary>
        /// Supplies the URL of the page containing the image.
        /// </summary>
        [JsonProperty("originalContextUrl")]
        public string OriginalContextUrl { get; private set; }

        /// <summary>
        /// Supplies the width of the image in pixels.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; private set; }

        /// <summary>
        /// Supplies the height of the image in pixels.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; private set; }

        /// <summary>
        /// Supplies the width in pixels of the image thumbnail.
        /// </summary>
        [JsonProperty("tbWidth")]
        public int TbWidth { get; private set; }

        /// <summary>
        /// Supplies the height in pixels of the image thumbnail.
        /// </summary>
        [JsonProperty("tbHeight")]
        public int TbHeight { get; private set; }

        /// <summary>
        /// Supplies the url of a thumbnail image.
        /// </summary>
        [JsonProperty("tbUrl")]
        public string TbUrl { get; private set; }

        /// <summary>
        /// Supplies a brief snippet of information from the page associated with the search result.
        /// </summary>
        [JsonProperty("content")]
        [JsonConverter(typeof(HtmlTagConverter))]
        public string Content { get; private set; }

        /// <summary>
        /// Supplies the same information as .content only stripped of HTML formatting.
        /// </summary>
        [JsonProperty("contentNoFormatting")]
        public string ContentNoFormatting { get; private set; }

        public override string ToString()
        {
            IImageResult result = this;
            return string.Format(
                "{0}" + Environment.NewLine + "{1} x {2} - {3}" + Environment.NewLine + "{4}",
                result.Content,
                result.Width,
                result.Height,
                result.Title,
                result.VisibleUrl);
        }

        #region IImageResult Members

        ITbImage IImageResult.TbImage
        {
            get
            {
                return new TbImage(this.TbUrl, this.TbWidth, this.TbHeight);
            }
        }

        #endregion
    }
}