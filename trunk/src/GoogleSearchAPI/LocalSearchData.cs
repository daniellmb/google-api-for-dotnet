//-----------------------------------------------------------------------
// <copyright file="LocalSearchData.cs" company="iron9light">
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
    using Newtonsoft.Json;

    [JsonObject]
    internal class LocalSearchData : ISearchData<GlocalResult>
    {
        [JsonProperty("results")]
        public GlocalResult[] Results { get; internal set; }

        [JsonProperty("viewport")]
        public ViewportObject Viewport { get; internal set; }

        [JsonObject]
        public class Point
        {
            [JsonProperty("lat")]
            public float Latitude { get; internal set; }

            [JsonProperty("lng")]
            public float Longitude { get; internal set; }
        }

        [JsonObject]
        public class ViewportObject
        {
            [JsonProperty("center")]
            public Point center { get; internal set; }

            [JsonProperty("span")]
            public Point span { get; internal set; }

            [JsonProperty("sw")]
            public Point sw { get; internal set; }

            [JsonProperty("ne")]
            public Point ne { get; internal set; }
        }
    }
}