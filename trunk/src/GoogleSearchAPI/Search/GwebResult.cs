/**
 * GwebResult.cs
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
using System.Runtime.Serialization;

namespace Google.API.Search
{
    [DataContract]
    internal class GwebResult : IWebResult
    {
        private string m_PlainTitle;
        private string m_PlainContent;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [DataMember(Name = "GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

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
        /// Supplies a shortened version of the URL associated with the result. Typically displayed in green, stripped of a protocol and path.
        /// </summary>
        [DataMember(Name = "visibleUrl")]
        public string VisibleUrl { get; private set; }

        /// <summary>
        /// Supplies a url to google's cached version of the page responsible for producting this result. This property may be null indicating that there is no cache, and it might be out of date in cases where the search result has been saved and in the mean time, the cache has gone stale. For best results, this property should not be persisted.
        /// </summary>
        [DataMember(Name = "cacheUrl")]
        public string CacheUrl { get; private set; }

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
        /// Supplies a brief snippet of information from the page associated with the search result.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; private set; }

        public override string ToString()
        {
            IWebResult result = this;
            return string.Format("{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}",
                                 result.Title,
                                 result.Content,
                                 result.VisibleUrl);
        }

        #region IWebResult Members

        string IWebResult.Url
        {
            get { return UnescapedUrl; }
        }

        string IWebResult.VisibleUrl
        {
            get { return VisibleUrl; }
        }

        string IWebResult.CacheUrl
        {
            get { return CacheUrl; }
        }

        string IWebResult.Title
        {
            get
            {
                if (TitleNoFormatting == null)
                {
                    return null;
                }

                if(m_PlainTitle == null)
                {
                    m_PlainTitle = HttpUtility.HtmlDecode(TitleNoFormatting);
                }
                return m_PlainTitle;
            }
        }

        string IWebResult.Content
        {
            get
            {
                if(Content == null)
                {
                    return null;
                }

                if(m_PlainContent == null)
                {
                    m_PlainContent = HttpUtility.RemoveHtmlTags(Content);
                }
                return m_PlainContent;
            }
        }

        #endregion
    }
}
