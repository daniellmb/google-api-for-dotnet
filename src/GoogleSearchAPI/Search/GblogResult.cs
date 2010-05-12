//-----------------------------------------------------------------------
// <copyright file="GblogResult.cs" company="iron9light">
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
    internal class GblogResult : IBlogResult
    {
        private string plainTitle;

        private string plainContent;

        private string plainAuthor;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [DataMember(Name = "GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// Supplies the title value of the result.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.)
        /// </summary>
        [DataMember(Name = "titleNoFormatting")]
        public string TitleNoFormatting { get; private set; }

        /// <summary>
        /// Supplies the URL to the blog post referenced in this search result.
        /// </summary>
        [DataMember(Name = "postUrl")]
        public string PostUrl { get; private set; }

        /// <summary>
        /// Supplies a snippet of content from the blog post associated with this search result.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; private set; }

        /// <summary>
        /// Supplies the name of the author that wrote the blog post.
        /// </summary>
        [DataMember(Name = "author")]
        public string Author { get; private set; }

        /// <summary>
        /// Supplies the URL of the blog which contains the post. Typically, this URL is displayed in green, beneath the blog search result and is linked to the blog.
        /// </summary>
        [DataMember(Name = "blogUrl")]
        public string BlogUrl { get; private set; }

        /// <summary>
        /// Supplies the published date (rfc-822 format) of the blog post referenced by this search result.
        /// </summary>
        [DataMember(Name = "publishedDate")]
        public string PublishedDateString { get; private set; }

        public override string ToString()
        {
            IBlogResult result = this;
            return
                string.Format(
                    "{0}" + Environment.NewLine + "[{1:d} by {2}]" + Environment.NewLine + "{3}" + Environment.NewLine +
                    "{4}",
                    result.Title,
                    result.PublishedDate,
                    result.Author,
                    result.Content,
                    result.BlogUrl);
        }

        #region IBlogResult Members

        string IBlogResult.Title
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

        string IBlogResult.PostUrl
        {
            get
            {
                return this.PostUrl;
            }
        }

        string IBlogResult.Content
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

        string IBlogResult.Author
        {
            get
            {
                if (this.Author == null)
                {
                    return null;
                }

                if (this.plainAuthor == null)
                {
                    this.plainAuthor = HttpUtility.HtmlDecode(this.Author);
                }

                return this.plainAuthor;
            }
        }

        string IBlogResult.BlogUrl
        {
            get
            {
                return this.BlogUrl;
            }
        }

        DateTime IBlogResult.PublishedDate
        {
            get
            {
                return SearchUtility.RFC2822DateTimeParse(this.PublishedDateString);
            }
        }

        #endregion
    }
}