//-----------------------------------------------------------------------
// <copyright file="GnewsResult.cs" company="iron9light">
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
    using Newtonsoft.Json.Converters;

    [JsonObject]
    internal class GnewsResult : GnewsResultItem, INewsResult
    {
        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; internal set; }

        /// <summary>
        /// When a news result has a set of related stories, this URL is available and non-null. In this situation, the URL points to a landing page that points to all of the related stories.
        /// </summary>
        [JsonProperty("clusterUrl")]
        public string ClusterUrl { get; internal set; }

        /// <summary>
        /// Supplies a snippet of content from the news story associated with this search result.
        /// </summary>
        [JsonProperty("content")]
        [JsonConverter(typeof(HtmlTagConverter))]
        public string Content { get; internal set; }

        /// <summary>
        /// This property is optional. It only appears in a result when the story also has a set of closely related stories. In this case, the relatedStories[] array will be present.
        /// </summary>
        [JsonProperty("relatedStories")]
        [JsonConverter(typeof(NewsResultItemConverter))]
        public INewsResultItem[] RelatedStories { get; internal set; }

        /// <summary>
        /// This property is optional. It only appears in a result when the system has determined that there is a good image that represents the cluster of news articles related to this result.
        /// </summary>
        [JsonProperty("image")]
        [JsonConverter(typeof(NewsImageConverter))]
        public INewsImage Image { get; internal set; }

        [JsonProperty("author")]
        public string Author { get; internal set; }

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

        bool INewsResult.IsQuote
        {
            get
            {
                return this.GSearchResultClass == "GnewsSearch.quote";
            }
        }

        #endregion

        internal class NewsImageConverter : CustomCreationConverter<INewsImage>
        {
            public override INewsImage Create(Type objectType)
            {
                return new GnewsImage();
            }
        }

        internal class NewsResultItemConverter : CustomArrayCreationConverter<INewsResultItem, GnewsResultItem>
        {
        }
    }
}