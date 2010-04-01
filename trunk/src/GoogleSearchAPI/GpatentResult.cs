//-----------------------------------------------------------------------
// <copyright file="GpatentResult.cs" company="iron9light">
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
    internal class GpatentResult : IPatentResult
    {
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "Reviewed. Suppression is OK here.")]
        private static readonly int tbWidth = 128;

        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "Reviewed. Suppression is OK here.")]
        private static readonly int tbHeight = 188;

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
        /// Supplies a snippet style description of the patent.
        /// </summary>
        [JsonProperty("content")]
        [JsonConverter(typeof(HtmlTagConverter))]
        public string Content { get; internal set; }

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
        /// Supplies the application filing date of the patent (rfc-822 format).
        /// </summary>
        [JsonProperty("applicationDate")]
        [JsonConverter(typeof(RFC822DateTimeConverter))]
        public DateTime ApplicationDate { get; internal set; }

        /// <summary>
        /// Supplies the patent number for issued patents, and the application number for filed, but not yet issued patents.
        /// </summary>
        [JsonProperty("patentNumber")]
        public string PatentNumber { get; internal set; }

        /// <summary>
        /// Supplies the status of the patent which can either be "filed" for filed, but not yet issued patents, or "issued" for issued patents.
        /// </summary>
        [JsonProperty("patentStatus")]
        public string PatentStatus { get; internal set; }

        /// <summary>
        /// Supplies the assignee of the patent.
        /// </summary>
        [JsonProperty("assignee")]
        [JsonConverter(typeof(HtmlFormatConverter))]
        public string Assignee { get; internal set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the patent.
        /// </summary>
        [JsonProperty("tbUrl")]
        public string TbUrl { get; internal set; }

        public override string ToString()
        {
            return
                string.Format(
                    "{0}" + Environment.NewLine + "US Pat. {1} - filed {2:d} - {3}" + Environment.NewLine + "{4}",
                    this.Title,
                    this.PatentNumber,
                    this.ApplicationDate,
                    this.Assignee,
                    this.Content);
        }

        #region IPatentResult Members

        ITbImage IPatentResult.TbImage
        {
            get
            {
                return new TbImage(this.TbUrl, tbWidth, tbHeight);
            }
        }

        #endregion
    }
}