//-----------------------------------------------------------------------
// <copyright file="GnewsSearchRequest.cs" company="iron9light">
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
    internal class GnewsSearchRequest : GoogleSearchRequest
    {
        /// <summary>
        /// This optional argument tells the news search system how to order results. Results may be ordered by relevance (which is the default), or by date. To select ordering by relevance, do not supply this argument. To select ordering by date, set scoring as scoring=d.
        /// </summary>
        [Argument("scoring")]
        public string SortBy { get; set; }

        /// <summary>
        /// This optional argument tells the news search system to scope search results to a particular location. With this argument present, the query argument (q) becomes optional. Note, this is a very new feature and locally scoped query coverage is somewhat sparse. You must supply either a city, state, country, or zip code as in geo=Santa%20Barbara or geo=British%20Columbia or geo=Peru or geo=93108.
        /// </summary>
        [Argument("geo")]
        public string Geo { get; set; }

        /// <summary>
        /// This optional argument tells the news search system to scope search results to include only quote typed results (rather than classic news article style results). With this argument present, the query argument (q) becomes optional. The value of this argument designates a prominent individual whose quotes have been recognized and classified by the Google News search service. For instance, Barack Obama has a qsid  value of tPjE5CDNzMicmM and John McCain has a value of lE61RnznhxvadM. Note, this is a very new feature and we currently do not have a good search or descovery mechanism for these qsid values.. 
        /// </summary>
        [Argument("qsid")]
        public string QuoteId { get; set; }

        /// <summary>
        /// This optional argument tells the news search system to scope search results to a particular topic. The value of the argument specifies the topic in the current or selected edition.
        /// </summary>
        [Argument("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// This optional argument tells the news search system which edition of news to pull results from.
        /// </summary>
        [Argument("ned")]
        public string Edition { get; set; }

        protected override string BaseAddress
        {
            get { return "http://ajax.googleapis.com/ajax/services/search/news"; }
        }
    }
}
