//-----------------------------------------------------------------------
// <copyright file="GlocalSearchRequest.cs" company="iron9light">
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
    internal class GlocalSearchRequest : GoogleSearchRequest
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float? Width { get; set; }

        public float? Height { get; set; }

        [Argument("mrt")]
        public string ResultType { get; set; }

        [Argument("sll")]
        public string Center
        {
            get
            {
                return this.Latitude + "," + this.Longitude;
            }
        }

        [Argument("sspn")]
        public string Bounding
        {
            get
            {
                if (this.Width != null && this.Height != null)
                {
                    return this.Width + "," + this.Height;
                }

                return null;
            }
        }

        protected override string BaseAddress
        {
            get { return "http://ajax.googleapis.com/ajax/services/search/local"; }
        }
    }
}
