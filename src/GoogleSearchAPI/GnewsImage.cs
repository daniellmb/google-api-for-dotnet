//-----------------------------------------------------------------------
// <copyright file="GnewsImage.cs" company="iron9light">
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
    using Newtonsoft.Json;

    [JsonObject]
    internal class GnewsImage : INewsImage
    {
        /// <summary>
        /// supplies the title of the article associated with the image
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; internal set; }

        /// <summary>
        /// same as above but stripped of HTML formatting
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting { get; internal set; }

        /// <summary>
        /// supplies the URL of the image
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        /// supplies the URL of the article that contains this image. The image, when displayed, should normally link through this URL
        /// </summary>
        [JsonProperty("originalContextUrl")]
        public string OriginalContextUrl { get; internal set; }

        /// <summary>
        /// supplies the publisher of the news article containing the image. The suggested user interface is to display this under or in close proximity to the image, hyper linked through the .url property from above
        /// </summary>
        [JsonProperty("publisher")]
        public string Publisher { get; internal set; }

        [JsonProperty("tbUrl")]
        public string TbUrl { get; internal set; }

        /// <summary>
        /// supplies the width of the image referenced above. The standard size of this image is 80 pixels wide and 50 pixels tall
        /// </summary>
        [JsonProperty("tbWidth")]
        public int TbWidth { get; internal set; }

        /// <summary>
        /// supplies the height of the image referenced above. The standard size of this image is 80 pixels wide and 50 pixels tall
        /// </summary>
        [JsonProperty("tbHeight")]
        public int TbHeight { get; internal set; }

        public override string ToString()
        {
            return this.Url ?? string.Empty;
        }

        #region INewsImage Members

        ITbImage INewsImage.TbImage
        {
            get
            {
                return new TbImage(this.TbUrl, this.TbWidth, this.TbHeight);
            }
        }

        #endregion
    }
}