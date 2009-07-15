//-----------------------------------------------------------------------
// <copyright file="GvideoResult.cs" company="iron9light">
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
    using System.Runtime.Serialization;

    [DataContract]
    internal class GvideoResult : IVideoResult
    {
        private string plainTitle;

        private string plainContent;

        private ITbImage tbImage;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [DataMember(Name = "GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// Supplies the title of the video result.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.) 
        /// </summary>
        [DataMember(Name = "titleNoFormatting")]
        public string TitleNoFormatting { get; private set; }

        /// <summary>
        /// Supplies a snippet style description of the video clip.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; private set; }

        /// <summary>
        /// Supplies the url of a playable version of the video result.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; private set; }

        /// <summary>
        /// Supplies the published date of the video (rfc-822 format).
        /// </summary>
        [DataMember(Name = "published")]
        public string PublishedDateString { get; private set; }

        /// <summary>
        /// Supplies the name of the video's publisher, typically displayed in green below the video thumbnail, similar to the treatment used for visibleUrl in the other search result objects.
        /// </summary>
        [DataMember(Name = "publisher")]
        public string Publisher { get; private set; }

        /// <summary>
        /// The approximate duration, in seconds, of the video.
        /// </summary>
        [DataMember(Name = "duration")]
        public int Duration { get; private set; }

        /// <summary>
        /// Supplies the width in pixels of the video thumbnail.
        /// </summary>
        [DataMember(Name = "tbWidth")]
        public int TbWidth { get; private set; }

        /// <summary>
        /// Supplies the height in pixels of the video thumbnail.
        /// </summary>
        [DataMember(Name = "tbHeight")]
        public int TbHeight { get; private set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the video.
        /// </summary>
        [DataMember(Name = "tbUrl")]
        public string TbUrl { get; private set; }

        /// <summary>
        /// If present, supplies the url of the flash version of the video that can be played inline on your page. To play this video simply create and &lt;embed&gt; element on your page using this value as the src attribute and using application/x-shockwave-flash as the type attribute. If you want the video to play right away, make sure to append &autoPlay=is true to the url.
        /// </summary>
        [DataMember(Name = "playUrl")]
        public string PlayUrl { get; private set; }

        [DataMember(Name = "videoType")]
        public string VideoType { get; private set; }

        /// <summary>
        /// If present, this property supplies the YouTube user name of the author of the video.
        /// </summary>
        [DataMember(Name = "author")]
        public string Author { get; private set; }

        /// <summary>
        /// If present, this property supplies a count of the number of plays for this video.
        /// </summary>
        [DataMember(Name = "viewCount")]
        public int ViewCount { get; private set; }

        /// <summary>
        /// If present, this property supplies the rating of the video on a scale of 1 to 5.
        /// </summary>
        [DataMember(Name = "rating")]
        public float Rating { get; private set; }

        public override string ToString()
        {
            IVideoResult result = this;
            return
                string.Format(
                    "{0}" + Environment.NewLine + "{1} seconds - {2:d} by {3}" + Environment.NewLine + "{4}",
                    result.Title,
                    result.Duration,
                    result.PublishedDate,
                    result.Publisher,
                    result.Content);
        }

        #region IVideoResult Members

        string IVideoResult.Title
        {
            get
            {
                if (this.TitleNoFormatting == null)
                {
                    return null;
                }

                if (this.plainTitle == null)
                {
                    this.plainTitle = HttpUtility.HtmlDecode(this.TitleNoFormatting);
                }

                return this.plainTitle;
            }
        }

        string IVideoResult.Content
        {
            get
            {
                if (this.Content == null)
                {
                    return null;
                }

                if (this.plainContent == null)
                {
                    this.plainContent = HttpUtility.RemoveHtmlTags(this.Content);
                }

                return this.plainContent;
            }
        }

        string IVideoResult.Url
        {
            get
            {
                return this.Url;
            }
        }

        DateTime IVideoResult.PublishedDate
        {
            get
            {
                return SearchUtility.RFC2822DateTimeParse(this.PublishedDateString);
            }
        }

        string IVideoResult.Publisher
        {
            get
            {
                return this.Publisher;
            }
        }

        int IVideoResult.Duration
        {
            get
            {
                return this.Duration;
            }
        }

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

        string IVideoResult.PlayUrl
        {
            get
            {
                return this.PlayUrl;
            }
        }

        string IVideoResult.VideoType
        {
            get
            {
                return this.VideoType;
            }
        }

        string IVideoResult.Author
        {
            get
            {
                return this.Author;
            }
        }

        int IVideoResult.ViewCount
        {
            get
            {
                return this.ViewCount;
            }
        }

        float IVideoResult.Rating
        {
            get
            {
                return this.Rating;
            }
        }

        #endregion
    }
}