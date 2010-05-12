//-----------------------------------------------------------------------
// <copyright file="LocalSearchData.cs" company="iron9light">
// Copyright (c) 2009 iron9light
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
    using System.Runtime.Serialization;

    [DataContract]
    internal class LocalSearchData : ISearchData<GlocalResult>
    {
        [DataMember(Name = "results")]
        public GlocalResult[] Results { get; private set; }

        [DataMember(Name = "viewport")]
        public ViewportObject Viewport { get; private set; }

        [DataContract]
        public class Point
        {
            [DataMember(Name = "lat")]
            public float Latitude { get; private set; }

            [DataMember(Name = "lng")]
            public float Longitude { get; private set; }
        }

        [DataContract]
        public class ViewportObject
        {
            [DataMember(Name = "center")]
            public Point center { get; private set; }

            [DataMember(Name = "span")]
            public Point span { get; private set; }

            [DataMember(Name = "sw")]
            public Point sw { get; private set; }

            [DataMember(Name = "ne")]
            public Point ne { get; private set; }
        }
    }
}