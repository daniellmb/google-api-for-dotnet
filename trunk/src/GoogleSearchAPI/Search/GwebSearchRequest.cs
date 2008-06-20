/**
 * GwebSearchRequest.cs
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
    internal class GwebSearchRequest : GSearchRequestBase
    {
        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/search/web";

        public GwebSearchRequest(string keyword)
            : base(keyword)
        { }

        public GwebSearchRequest(string keyword, string language)
            : base(keyword)
        {
            Language = language;
        }

        public GwebSearchRequest(string keyword, int start)
            : base(keyword, start)
        { }

        public GwebSearchRequest(string keyword, int start, string language)
            : base(keyword, start)
        {
            Language = language;
        }

        public GwebSearchRequest(string keyword, int start, ResultSize resultSize)
            : base(keyword, start, resultSize)
        { }

        public GwebSearchRequest(string keyword, int start, ResultSize resultSize, string language)
            : base(keyword, start, resultSize)
        {
            Language = language;
        }

        /// <summary>
        /// This optional argument allows the caller to restrict the search to documents written in a particular language, e.g., lr=lang_ja.
        /// </summary>
        [Argument("lr")]
        public string Language { get; private set; }

        protected override string BaseAddress
        {
            get { return s_BaseAddress; }
        }
    }
}
