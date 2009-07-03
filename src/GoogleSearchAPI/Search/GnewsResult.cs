//-----------------------------------------------------------------------
// <copyright file="GnewsResult.cs" company="iron9light">
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
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract]
    internal class GnewsResult : GnewsResultItem, INewsResult
    {
        private string plainContent;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [DataMember(Name = "GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// When a news result has a set of related stories, this URL is available and non-null. In this situation, the URL points to a landing page that points to all of the related stories.
        /// </summary>
        [DataMember(Name = "clusterUrl")]
        public string ClusterUrl { get; private set; }

        /// <summary>
        /// Supplies a snippet of content from the news story associated with this search result.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; private set; }

        /// <summary>
        /// This property is optional. It only appears in a result when the story also has a set of closely related stories. In this case, the relatedStories[] array will be present.
        /// </summary>
        [DataMember(Name = "relatedStories")]
        public GnewsResultItem[] RelatedStories { get; private set; }

        /// <summary>
        /// This property is optional. It only appears in a result when the system has determined that there is a good image that represents the cluster of news articles related to this result.
        /// </summary>
        [DataMember(Name = "image")]
        public GnewsImage Image { get; private set; }

        [DataMember(Name = "author")]
        public string Author { get; private set; }

        public override string ToString()
        {
            INewsResult result = this;

            var sb = new StringBuilder();
            if (result.IsQuote)
            {
                sb.Append("[quote]");
                sb.AppendLine(result.Author);
            }

            sb.AppendLine(base.ToString());
            sb.Append(result.Content);

            return sb.ToString();
        }

        #region INewsResult Members

        string INewsResult.ClusterUrl
        {
            get
            {
                return this.ClusterUrl;
            }
        }

        string INewsResult.Content
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

        INewsResultItem[] INewsResult.RelatedStories
        {
            get
            {
                return this.RelatedStories;
            }
        }

        INewsImage INewsResult.Image
        {
            get
            {
                return this.Image;
            }
        }

        string INewsResult.Author
        {
            get
            {
                return this.Author;
            }
        }

        bool INewsResult.IsQuote
        {
            get
            {
                return this.GSearchResultClass == "GnewsSearch.quote";
            }
        }

        #endregion
    }
}