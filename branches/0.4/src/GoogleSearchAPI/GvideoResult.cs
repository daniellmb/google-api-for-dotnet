//-----------------------------------------------------------------------
// <copyright file="GvideoResult.cs" company="iron9light">
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
    using System.Diagnostics.CodeAnalysis;

    using Converters;

    using Newtonsoft.Json;

    [JsonObject]
    internal class GvideoResult : IVideoResult
    {
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "Reviewed. Suppression is OK here.")]
        private ITbImage tbImage;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; internal set; }

        /// <summary>
        /// Supplies the title of the video result.
        /// </summary>
        [JsonProperty("title")]
        public string TitleWithFormatting { get; internal set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.) 
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        [JsonConverter(typeof(HtmlFormatConverter))]
        public string Title { get; internal set; }

        /// <summary>
        /// Supplies a snippet style description of the video clip.
        /// </summary>
        [JsonProperty("content")]
        [JsonConverter(typeof(HtmlTagConverter))]
        public string Content { get; internal set; }

        /// <summary>
        /// Supplies the url of a playable version of the video result.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        /// Supplies the published date of the video (rfc-822 format).
        /// </summary>
        [JsonProperty("published")]
        [JsonConverter(typeof(RFC822DateTimeConverter))]
        public DateTime PublishedDate { get; internal set; }

        /// <summary>
        /// Supplies the name of the video's publisher, typically displayed in green below the video thumbnail, similar to the treatment used for visibleUrl in the other search result objects.
        /// </summary>
        [JsonProperty("publisher")]
        public string Publisher { get; internal set; }

        /// <summary>
        /// The approximate duration, in seconds, of the video.
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; internal set; }

        /// <summary>
        /// Supplies the width in pixels of the video thumbnail.
        /// </summary>
        [JsonProperty("tbWidth")]
        public int TbWidth { get; internal set; }

        /// <summary>
        /// Supplies the height in pixels of the video thumbnail.
        /// </summary>
        [JsonProperty("tbHeight")]
        public int TbHeight { get; internal set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the video.
        /// </summary>
        [JsonProperty("tbUrl")]
        public string TbUrl { get; internal set; }

        /// <summary>
        /// If present, supplies the url of the flash version of the video that can be played inline on your page. To play this video simply create and &lt;embed&gt; element on your page using this value as the src attribute and using application/x-shockwave-flash as the type attribute. If you want the video to play right away, make sure to append &amp;autoPlay=is true to the url.
        /// </summary>
        [JsonProperty("playUrl")]
        public string PlayUrl { get; internal set; }

        [JsonProperty("videoType")]
        public string VideoType { get; internal set; }

        /// <summary>
        /// If present, this property supplies the YouTube user name of the author of the video.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; internal set; }

        /// <summary>
        /// If present, this property supplies a count of the number of plays for this video.
        /// </summary>
        [JsonProperty("viewCount")]
        public int ViewCount { get; internal set; }

        /// <summary>
        /// If present, this property supplies the rating of the video on a scale of 1 to 5.
        /// </summary>
        [JsonProperty("rating")]
        public float Rating { get; internal set; }

        public override string ToString()
        {
            return
                string.Format(
                    "{0}" + Environment.NewLine + "{1} seconds - {2:d} by {3}" + Environment.NewLine + "{4}",
                    this.Title,
                    this.Duration,
                    this.PublishedDate,
                    this.Publisher,
                    this.Content);
        }

        #region IVideoResult Members

        ITbImage IVideoResult.TbImage
        {
            get
            {
                if (this.tbImage == null)
                {
                    this.tbImage = new TbImage(this.TbUrl, this.TbWidth, this.TbHeight);
                }

                return this.tbImage;
            }
        }

        #endregion
    }
}