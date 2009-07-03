//-----------------------------------------------------------------------
// <copyright file="GnewsResultItem.cs" company="iron9light">
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
    using System.Text;

    [DataContract]
    internal class GnewsResultItem : INewsResultItem
    {
        private string plainTitle;

        private string plainPublisher;

        private string plainLocation;

        /// <summary>
        /// Supplies the title value of the result.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; protected set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.)
        /// </summary>
        [DataMember(Name = "titleNoFormatting")]
        public string TitleNoFormatting { get; protected set; }

        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        [DataMember(Name = "unescapedUrl")]
        public string UnescapedUrl { get; protected set; }

        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; protected set; }

        /// <summary>
        /// Supplies the name of the publisher of the news story.
        /// </summary>
        [DataMember(Name = "publisher")]
        public string Publisher { get; protected set; }

        /// <summary>
        /// Contains the location of the news story. This is a list of locations in most specific to least specific order where the components are seperated by ",". Note, there may only be one element in the list... A typical value for this property is "Edinburgh,Scotland,UK" or possibly "USA".
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; protected set; }

        /// <summary>
        /// Supplies the published date (rfc-822 format) of the news story referenced by this search result.
        /// </summary>
        [DataMember(Name = "publishedDate")]
        public string PublishedDateString { get; protected set; }

        [DataMember(Name = "signedRedirectUrl")]
        public string SignedRedirectUrl { get; private set; }

        public override string ToString()
        {
            INewsResultItem result = this;
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(result.Title))
            {
                sb.AppendLine(result.Title);
            }

            sb.Append(result.Publisher);
            sb.Append(", ");
            if (!string.IsNullOrEmpty(result.Location))
            {
                sb.Append(result.Location);
                sb.Append(" - ");
            }

            sb.Append(result.PublishedDate.ToShortDateString());
            return sb.ToString();
        }

        #region INewsResultItem Members

        string INewsResultItem.Url
        {
            get
            {
                return this.UnescapedUrl;
            }
        }

        string INewsResultItem.Title
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

        string INewsResultItem.Publisher
        {
            get
            {
                if (this.Publisher == null)
                {
                    return null;
                }

                if (this.plainPublisher == null)
                {
                    this.plainPublisher = HttpUtility.HtmlDecode(this.Publisher);
                }

                return this.plainPublisher;
            }
        }

        string INewsResultItem.Location
        {
            get
            {
                if (this.Location == null)
                {
                    return null;
                }

                if (this.plainLocation == null)
                {
                    this.plainLocation = HttpUtility.HtmlDecode(this.Location);
                }

                return this.plainLocation;
            }
        }

        DateTime INewsResultItem.PublishedDate
        {
            get
            {
                return SearchUtility.RFC2822DateTimeParse(this.PublishedDateString);
            }
        }

        #endregion
    }
}