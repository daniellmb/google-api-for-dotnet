//-----------------------------------------------------------------------
// <copyright file="GnewsResultItem.cs" company="iron9light">
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
    using System.Text;

    using Converters;

    using Newtonsoft.Json;

    [JsonObject]
    internal class GnewsResultItem : INewsResultItem
    {
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
        /// Supplies the raw URL of the result.
        /// </summary>
        [JsonProperty("unescapedUrl")]
        public string Url { get; internal set; }

        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        [JsonProperty("url")]
        public string EscapedUrl { get; internal set; }

        /// <summary>
        /// Supplies the name of the publisher of the news story.
        /// </summary>
        [JsonProperty("publisher")]
        [JsonConverter(typeof(HtmlFormatConverter))]
        public string Publisher { get; internal set; }

        /// <summary>
        /// Contains the location of the news story. This is a list of locations in most specific to least specific order where the components are seperated by ",". Note, there may only be one element in the list... A typical value for this property is "Edinburgh,Scotland,UK" or possibly "USA".
        /// </summary>
        [JsonProperty("location")]
        [JsonConverter(typeof(HtmlFormatConverter))]
        public string Location { get; internal set; }

        /// <summary>
        /// Supplies the published date (rfc-822 format) of the news story referenced by this search result.
        /// </summary>
        [JsonProperty("publishedDate")]
        [JsonConverter(typeof(RFC822DateTimeConverter))]
        public DateTime PublishedDate { get; internal set; }

        [JsonProperty("signedRedirectUrl")]
        public string SignedRedirectUrl { get; internal set; }

        /// <summary>
        /// This property is optional. When present, it indicates the language of the news story.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; internal set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(this.Title))
            {
                sb.AppendLine(this.Title);
            }

            sb.Append(this.Publisher);
            sb.Append(", ");
            if (!string.IsNullOrEmpty(this.Location))
            {
                sb.Append(this.Location);
                sb.Append(" - ");
            }

            sb.Append(this.PublishedDate.ToShortDateString());
            return sb.ToString();
        }
    }
}