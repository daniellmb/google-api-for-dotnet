//-----------------------------------------------------------------------
// <copyright file="GblogResult.cs" company="iron9light">
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

    using Converters;

    using Newtonsoft.Json;

    [JsonObject]
    internal class GblogResult : IBlogResult
    {
        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; internal set; }

        /// <summary>
        /// Supplies the title value of the result.
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
        /// Supplies the URL to the blog post referenced in this search result.
        /// </summary>
        [JsonProperty("postUrl")]
        public string PostUrl { get; internal set; }

        /// <summary>
        /// Supplies a snippet of content from the blog post associated with this search result.
        /// </summary>
        [JsonProperty("content")]
        [JsonConverter(typeof(HtmlTagConverter))]
        public string Content { get; internal set; }

        /// <summary>
        /// Supplies the name of the author that wrote the blog post.
        /// </summary>
        [JsonProperty("author")]
        [JsonConverter(typeof(HtmlFormatConverter))]
        public string Author { get; internal set; }

        /// <summary>
        /// Supplies the URL of the blog which contains the post. Typically, this URL is displayed in green, beneath the blog search result and is linked to the blog.
        /// </summary>
        [JsonProperty("blogUrl")]
        public string BlogUrl { get; internal set; }

        /// <summary>
        /// Supplies the published date (rfc-822 format) of the blog post referenced by this search result.
        /// </summary>
        [JsonProperty("publishedDate")]
        [JsonConverter(typeof(RFC822DateTimeConverter))]
        public DateTime PublishedDate { get; internal set; }

        public override string ToString()
        {
            return
                string.Format(
                    "{0}" + Environment.NewLine + "[{1:d} by {2}]" + Environment.NewLine + "{3}" + Environment.NewLine +
                    "{4}",
                    this.Title,
                    this.PublishedDate,
                    this.Author,
                    this.Content,
                    this.BlogUrl);
        }
    }
}