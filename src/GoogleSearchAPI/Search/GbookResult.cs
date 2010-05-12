/**
 * GbookResult.cs
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

namespace Google.API.Search
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    internal class GbookResult : IBookResult
    {
        private string plainTitle;

        private string plainAuthors;

        private ITbImage tbImage;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [DataMember(Name = "GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// Supplies the title of the book.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.)
        /// </summary>
        [DataMember(Name = "titleNoFormatting")]
        public string TitleNoFormatting { get; private set; }

        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        [DataMember(Name = "unescapedUrl")]
        public string UnescapedUrl { get; private set; }

        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; private set; }

        /// <summary>
        /// Supplies the list of authors of the book.
        /// </summary>
        [DataMember(Name = "authors")]
        public string Authors { get; private set; }

        /// <summary>
        /// Supplies the identifier associated with the book. This is typically an ISBN.
        /// </summary>
        [DataMember(Name = "bookId")]
        public string BookId { get; private set; }

        /// <summary>
        /// Supplies the year that the book was published.
        /// </summary>
        [DataMember(Name = "publishedYear")]
        public string PublishedYear { get; private set; }

        /// <summary>
        /// Supplies the number of pages contained within the book.
        /// </summary>
        [DataMember(Name = "pageCount")]
        public int PageCount { get; private set; }

        /// <summary>
        /// Supplies the width in pixels of the book cover thumbnail.
        /// </summary>
        [DataMember(Name = "tbWidth")]
        public int TbWidth { get; private set; }

        /// <summary>
        /// Supplies the height in pixels of the book cover thumbnail.
        /// </summary>
        [DataMember(Name = "tbHeight")]
        public int TbHeight { get; private set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents book cover.
        /// </summary>
        [DataMember(Name = "tbUrl")]
        public string TbUrl { get; private set; }

        public override string ToString()
        {
            IBookResult result = this;
            return string.Format(
                "{0}" + Environment.NewLine + "by {1} - {2} - {3} pages" + Environment.NewLine + "{4}",
                result.Title,
                result.Authors,
                result.PublishedYear,
                result.PageCount,
                result.BookId);
        }

        #region IBookResult Members

        string IBookResult.Title
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

        string IBookResult.Url
        {
            get
            {
                return this.UnescapedUrl;
            }
        }

        string IBookResult.Authors
        {
            get
            {
                if (this.Authors == null)
                {
                    return null;
                }

                if (this.plainAuthors == null)
                {
                    this.plainAuthors = HttpUtility.RemoveHtmlTags(this.Authors);
                }

                return this.plainAuthors;
            }
        }

        string IBookResult.BookId
        {
            get
            {
                return this.BookId;
            }
        }

        string IBookResult.PublishedYear
        {
            get
            {
                return this.PublishedYear;
            }
        }

        int IBookResult.PageCount
        {
            get
            {
                return this.PageCount;
            }
        }

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