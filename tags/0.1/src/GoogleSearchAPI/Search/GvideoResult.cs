/**
 * GvideoResult.cs
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
using Newtonsoft.Json;

namespace Google.API.Search
{
    [JsonObject]
    internal class GvideoResult : IVideoResult
    {
        private string m_PlainTitle;
        private string m_PlainContent;
        private ITbImage m_TbImage;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// Supplies the title of the video result.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.) 
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting { get; private set; }

        /// <summary>
        /// Supplies a snippet style description of the video clip.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; private set; }

        /// <summary>
        /// Supplies the url of a playable version of the video result.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; private set; }

        /// <summary>
        /// Supplies the published date of the video (rfc-822 format).
        /// </summary>
        [JsonProperty("published")]
        public string PublishedDateString { get; private set; }

        /// <summary>
        /// Supplies the name of the video's publisher, typically displayed in green below the video thumbnail, similar to the treatment used for visibleUrl in the other search result objects.
        /// </summary>
        [JsonProperty("publisher")]
        public string Publisher { get; private set; }

        /// <summary>
        /// The approximate duration, in seconds, of the video.
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; private set; }

        /// <summary>
        /// Supplies the width in pixels of the video thumbnail.
        /// </summary>
        [JsonProperty("tbWidth")]
        public int TbWidth { get; private set; }

        /// <summary>
        /// Supplies the height in pixels of the video thumbnail.
        /// </summary>
        [JsonProperty("tbHeight")]
        public int TbHeight { get; private set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the video.
        /// </summary>
        [JsonProperty("tbUrl")]
        public string TbUrl { get; private set; }

        /// <summary>
        /// If present, supplies the url of the flash version of the video that can be played inline on your page. To play this video simply create and &lt;embed&gt; element on your page using this value as the src attribute and using application/x-shockwave-flash as the type attribute. If you want the video to play right away, make sure to append &autoPlay=true to the url.
        /// </summary>
        [JsonProperty("playUrl")]
        public string PlayUrl { get; private set; }

        [JsonProperty("videoType")]
        public string VideoType { get; private set; }

        public override string ToString()
        {
            IVideoResult result = this;
            return
                string.Format("{0}" + Environment.NewLine + "{1} seconds - {2:d} by {3}" + Environment.NewLine + "{4}",
                              result.Title, result.Duration, result.PublishedDate, result.Publisher, result.Content);
        }

        #region IVideoResult Members

        string IVideoResult.Title
        {
            get
            {
                if (TitleNoFormatting == null)
                {
                    return null;
                }

                if (m_PlainTitle == null)
                {
                    m_PlainTitle = HttpUtility.HtmlDecode(TitleNoFormatting);
                }
                return m_PlainTitle;
            }
        }

        string IVideoResult.Content
        {
            get
            {
                if (Content == null)
                {
                    return null;
                }

                if (m_PlainContent == null)
                {
                    m_PlainContent = HttpUtility.RemoveHtmlTags(Content);
                }
                return m_PlainContent;
            }
        }

        string IVideoResult.Url
        {
            get { return Url; }
        }

        DateTime IVideoResult.PublishedDate
        {
            get
            {
                return SearchUtility.RFC2822DateTimeParse(PublishedDateString);
            }
        }

        string IVideoResult.Publisher
        {
            get { return Publisher; }
        }

        int IVideoResult.Duration
        {
            get { return Duration; }
        }

        ITbImage IVideoResult.TbImage
        {
            get
            {
                if (m_TbImage == null)
                {
                    m_TbImage = new TbImage(TbUrl, TbWidth, TbHeight);
                }
                return m_TbImage;
            }
        }

        string IVideoResult.PlayUrl
        {
            get { return PlayUrl; }
        }

        string IVideoResult.VideoType
        {
            get { return VideoType; }
        }

        #endregion
    }
}
