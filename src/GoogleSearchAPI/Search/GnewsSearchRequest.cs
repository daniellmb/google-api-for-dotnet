/**
 * GnewsSearchRequest.cs
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
    internal class GnewsSearchRequest : GSearchRequestBase
    {
        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/search/news";

        public GnewsSearchRequest(string keyword, int start, ResultSizeEnum resultSize)
            : base(keyword, start, resultSize)
        { }

        public GnewsSearchRequest(string keyword, int start, ResultSizeEnum resultSize, SortType sortBy)
            : base(keyword, start, resultSize)
        {
            SortBy = sortBy;
        }

        public GnewsSearchRequest(string keyword, int start, ResultSizeEnum resultSize, string geo)
            : base(keyword, start, resultSize)
        {
            if (!string.IsNullOrEmpty(geo))
            {
                Geo = geo;
                if (keyword == null)
                {
                    Content = string.Empty;
                }
            }
        }

        public GnewsSearchRequest(string keyword, int start, ResultSizeEnum resultSize, string geo, SortType sortBy)
            : this(keyword, start, resultSize, geo)
        {
            SortBy = sortBy;
        }

        public SortType SortBy { get; private set; }

        /// <summary>
        /// This optional argument tells the news search system how to order results. Results may be ordered by relevance (which is the default), or by date. To select ordering by relevance, do not supply this argument. To select ordering by date, set scoring as scoring=d.
        /// </summary>
        [Argument("scoring")]
        private string Scoring
        {
            get
            {
                switch (SortBy)
                {
                    case SortType.relevance:
                        return null;
                    case SortType.date:
                        return "d";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// This optional argument tells the news search system to scope search results to a particular location. With this argument present, the query argument (q) becomes optional. Note, this is a very new feature and locally scoped query coverage is somewhat sparse. You must supply either a city, state, country, or zip code as in geo=Santa%20Barbara or geo=British%20Columbia or geo=Peru or geo=93108.
        /// </summary>
        [Argument("geo", NeedEncode = true)]
        public string Geo { get; private set; }

        protected override string BaseAddress
        {
            get { return s_BaseAddress; }
        }
    }
}
