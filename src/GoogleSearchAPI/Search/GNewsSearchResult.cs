/**
 * GNewsSearchResult.cs
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

using Newtonsoft.Json;

namespace Google.API.Search
{
    [JsonObject]
    internal class GNewsSearchResult : GNewsSearchResultItem, INewsSearchResult
    {
        private string m_PlaneContent;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// When a news result has a set of related stories, this URL is available and non-null. In this situation, the URL points to a landing page that points to all of the related stories.
        /// </summary>
        [JsonProperty("clusterUrl")]
        public string ClusterUrl { get; private set; }

        /// <summary>
        /// Supplies a snippet of content from the news story associated with this search result.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; private set; }

        /// <summary>
        /// This property is optional. It only appears in a result when the story also has a set of closely related stories. In this case, the relatedStories[] array will be present.
        /// </summary>
        [JsonProperty("relatedStories")]
        public GNewsSearchResultItem[] RelatedStories { get; private set; }

        #region INewsSearchResult Members

        string INewsSearchResult.ClusterUrl
        {
            get { return ClusterUrl; }
        }

        string INewsSearchResult.Content
        {
            get
            {
                if (Content == null)
                {
                    return null;
                }

                if (m_PlaneContent == null)
                {
                    m_PlaneContent = HttpUtility.RemoveHtmlTags(Content);
                }
                return m_PlaneContent;
            }
        }

        INewsSearchResultItem[] INewsSearchResult.RelatedStories
        {
            get { return RelatedStories; }
        }

        #endregion
    }
}
