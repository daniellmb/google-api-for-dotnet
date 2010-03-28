//-----------------------------------------------------------------------
// <copyright file="GwebSearchRequest.cs" company="iron9light">
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
    internal class GwebSearchRequest : GoogleSearchRequest
    {
        /// <summary>
        /// This optional argument supplies the unique id for the Custom Search Engine that should be used for this request (e.g., cx=000455696194071821846:reviews).
        /// </summary>
        [Argument("cx")]
        public string CustomSearchId { get; set; }

        /// <summary>
        /// This optional argument supplies the url of a linked Custom Search Engine specification that should be used to satisfy this request.
        /// </summary>
        [Argument("cref")]
        public string CustomSearchReference { get; set; }

        /// <summary>
        /// This optional argument supplies the search safety level.
        /// </summary>
        [Argument("safe")]
        public string SafeLevel { get; set; }

        /// <summary>
        /// This optional argument allows the caller to restrict the search to documents written in a particular language, e.g., lr=lang_ja.
        /// </summary>
        [Argument("lr")]
        public string Language { get; set; }

        /// <summary>
        /// This optional argument controls turning on or off the duplicate content filter.
        /// </summary>
        [Argument("filter")]
        public string DuplicateFilter { get; set; }

        /// <summary>
        /// This optional argument allows the caller to tailor the results to a specific country. The value should be a valid country code (e.g. uk, de, etc.). If this argument is not present, then the system will use a value based on the domain used to load the API (e.g. http://www.google.com/jsapi). If the API loader was not used, a value of "us" is assumed.
        /// </summary>
        [Argument("gl")]
        public string Country { get; set; }

        protected override string BaseAddress
        {
            get { return "http://ajax.googleapis.com/ajax/services/search/web"; }
        }
    }
}