/**
 * GlocalSearchRequest.cs
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
    /// <summary>
    /// The result type of GlocalSearch.
    /// </summary>
    public enum LocalResultType
    {
        /// <summary>
        /// Request KML, Local Business Listings, and Geocode results.
        /// </summary>
        blended,

        /// <summary>
        /// Request KML and Geocode results.
        /// </summary>
        kmlonly,

        /// <summary>
        /// Request Local Business Listings and Geocode results.
        /// </summary>
        localonly = 0,
    }

    internal class GlocalSearchRequest : GSearchRequestBase
    {
        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/search/local";

        public GlocalSearchRequest(
            string keyword,
            int start,
            ResultSize resultSize,
            float latitude,
            float longitude,
            float? width,
            float? height,
            LocalResultType resultType)
            : base(keyword, start, resultSize)
        {
            Latitude = latitude;
            Longitude = longitude;
            Width = width;
            Height = height;
            ResultType = resultType;
        }

        public float Latitude { get; private set; }

        public float Longitude { get; private set; }

        public float? Width { get; private set; }

        public float? Height { get; private set; }

        [Argument("mrt")]
        public LocalResultType ResultType { get; private set; }

        [Argument("sll")]
        private string Center
        {
            get
            {
                return Latitude + "," + Longitude;
            }
        }

        [Argument("sspn")]
        private string Bounding
        {
            get
            {
                if (Width != null && Height != null)
                    return Width + "," + Height;

                return null;
            }
        }

        protected override string BaseAddress
        {
            get { return s_BaseAddress; }
        }
    }
}
