//-----------------------------------------------------------------------
// <copyright file="GpatentResult.cs" company="iron9light">
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
    internal class GpatentResult : IPatentResult
    {
        private static readonly int tbWidth = 128;

        private static readonly int tbHeight = 188;

        private string plainTitle;

        private string plainContent;

        private string plainAssignee;

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
        /// Supplies a snippet style description of the patent.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; private set; }

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
        /// Supplies the application filing date of the patent (rfc-822 format).
        /// </summary>
        [DataMember(Name = "applicationDate")]
        public string ApplicationDateString { get; private set; }

        /// <summary>
        /// Supplies the patent number for issued patents, and the application number for filed, but not yet issued patents.
        /// </summary>
        [DataMember(Name = "patentNumber")]
        public string PatentNumber { get; private set; }

        /// <summary>
        /// Supplies the status of the patent which can either be "filed" for filed, but not yet issued patents, or "issued" for issued patents.
        /// </summary>
        [DataMember(Name = "patentStatus")]
        public string PatentStatus { get; private set; }

        /// <summary>
        /// Supplies the assignee of the patent.
        /// </summary>
        [DataMember(Name = "assignee")]
        public string Assignee { get; private set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the patent.
        /// </summary>
        [DataMember(Name = "tbUrl")]
        public string TbUrl { get; private set; }

        public override string ToString()
        {
            IPatentResult result = this;
            return
                string.Format(
                    "{0}" + Environment.NewLine + "US Pat. {1} - filed {2:d} - {3}" + Environment.NewLine + "{4}",
                    result.Title,
                    result.PatentNumber,
                    result.ApplicationDate,
                    result.Assignee,
                    result.Content);
        }

        #region IPatentResult Members

        string IPatentResult.Title
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

        string IPatentResult.Content
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

        string IPatentResult.Url
        {
            get
            {
                return this.UnescapedUrl;
            }
        }

        DateTime IPatentResult.ApplicationDate
        {
            get
            {
                return SearchUtility.RFC2822DateTimeParse(this.ApplicationDateString);
            }
        }

        string IPatentResult.PatentNumber
        {
            get
            {
                return this.PatentNumber;
            }
        }

        string IPatentResult.PatentStatus
        {
            get
            {
                return this.PatentStatus;
            }
        }

        string IPatentResult.Assignee
        {
            get
            {
                if (this.Assignee == null)
                {
                    return null;
                }

                if (this.plainAssignee == null)
                {
                    this.plainAssignee = HttpUtility.HtmlDecode(this.Assignee);
                }

                return this.plainAssignee;
            }
        }

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