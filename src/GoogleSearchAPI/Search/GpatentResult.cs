/**
 * GpatentResult.cs
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
using Newtonsoft.Json;

namespace Google.API.Search
{
    internal class GpatentResult
    {
        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        /// <summary>
        /// Supplies the title value of the result.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.)
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting { get; private set; }

        /// <summary>
        /// Supplies a snippet style description of the patent.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; private set; }

        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        [JsonProperty("unescapedUrl")]
        public string UnescapedUrl { get; private set; }

        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; private set; }

        /// <summary>
        /// Supplies the application filing date of the patent (rfc-822 format).
        /// </summary>
        [JsonProperty("applicationDate")]
        public DateTime ApplicationDate { get; private set; }

        /// <summary>
        /// Supplies the patent number for issued patents, and the application number for filed, but not yet issued patents.
        /// </summary>
        [JsonProperty("patentNumber")]
        public string PatentNumber { get; private set; }

        /// <summary>
        /// Supplies the status of the patent which can either be "filed" for filed, but not yet issued patents, or "issued" for issued patents.
        /// </summary>
        [JsonProperty("patentStatus")]
        public string PatentStatus { get; private set; }

        /// <summary>
        /// Supplies the assignee of the patent.
        /// </summary>
        [JsonProperty("assignee")]
        public string Assignee { get; private set; }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the patent.
        /// </summary>
        [JsonProperty("tbUrl")]
        public string TbUrl { get; private set; }

        public override string ToString()
        {
            GpatentResult result = this;
            return
                string.Format(
                    "{0}" + Environment.NewLine + "US Pat. {1} - filed {2:d} - {3}" + Environment.NewLine + "{4}",
                    result.Title,
                    result.PatentNumber,
                    result.ApplicationDate,
                    result.Assignee,
                    result.Content);
        }
    }
}
