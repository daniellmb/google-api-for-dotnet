//-----------------------------------------------------------------------
// <copyright file="GpatentSearchRequest.cs" company="iron9light">
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
    internal class GpatentSearchRequest : GoogleSearchRequest
    {
        /// <summary>
        /// This optional argument tells the patent search system to restrict the search to ONLY patents that having been issued, skiping all patents that have only been filed. When specified, that value must be 1 as in &amp;as_psrg=1.
        /// </summary>
        [Argument("as_psrg")]
        public bool IssuedOnly { get; set; }

        /// <summary>
        /// This optional argument tells the patent search system to restrict the search to ONLY patents that only been filed, skipping over all patents that have been issued. When specified, that value must be 1 as in &amp;as_psra=1.
        /// </summary>
        [Argument("as_psra")]
        public bool FiledOnly { get; set; }

        /// <summary>
        /// This optional argument tells the patent search system how to order results. Results may be ordered by relevance (which is the default), or by date. To select ordering by relevance, do not supply this argument. To select ordering by descending date where the newest result is first, set scoring as scoring=d. To select ordering by ascending date where the oldest result is first, set scoring as scoring=ad.
        /// </summary>
        [Argument("scoring")]
        public string SortBy { get; set; }

        protected override string BaseAddress
        {
            get { return "http://ajax.googleapis.com/ajax/services/search/patent"; }
        }
    }
}