//-----------------------------------------------------------------------
// <copyright file="GbookResult.cs" company="iron9light">
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
    internal class GbookResult : IBookResult
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
        /// Supplies the title of the book.
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
        public string UnescapedUrl { get; internal set; }

        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        /// Supplies the list of authors of the book.
        /// </summary>
        [JsonProperty("authors")]
        [JsonConverter(typeof(HtmlTagConverter))]
        public string Authors { get; internal set; }

        /// <summary>
        /// Supplies the identifier associated with the book. This is typically an ISBN.
        /// </summary>
        [JsonProperty("bookId")]
        public string BookId { get; internal set; }

        /// <summary>
        /// Supplies the year that the book was published.
        /// </summary>
        [JsonProperty("publishedYear")]
        public string PublishedYear { get; internal set; }

        /// <summary>
        /// Supplies the number of pages contained within the book.
        /// </summary>
        [JsonProperty("pageCount")]
        public int PageCount { get; internal set; }

        /// <summary>
        /// Supplies the width in pixels of the book cover thumbnail.
        /// </summary>
        [JsonProperty("tbWidth")]
        public int TbWidth { get; internal set; }

        /// <summary>
        /// Supplies the height in pixels of the book cover thumbnail.
        /// </summary>
        [JsonProperty("tbHeight")]
        public int TbHeight { get; internal set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents book cover.
        /// </summary>
        [JsonProperty("tbUrl")]
        public string TbUrl { get; internal set; }

        public override string ToString()
        {
            return string.Format(
                "{0}" + Environment.NewLine + "by {1} - {2} - {3} pages" + Environment.NewLine + "{4}",
                this.Title,
                this.Authors,
                this.PublishedYear,
                this.PageCount,
                this.BookId);
        }

        #region IBookResult Members

        ITbImage IBookResult.TbImage
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