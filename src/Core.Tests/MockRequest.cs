//-----------------------------------------------------------------------
// <copyright file="MockRequest.cs" company="iron9light">
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

namespace Google.API.Tests
{
    internal class MockRequest : RequestBase
    {
        private readonly string baseAddress;

        public MockRequest(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        [Argument("a", "default")]
        public string ArgA { get; set; }

        [Argument("b", Optional = false)]
        public int ArgB { get; set; }

        [Argument("c")]
        public bool ArgC { get; set; }

        [Argument("d")]
        public bool ArgD { get; set; }

        [Argument("e", IsPostContent = true)]
        public object ArgE { get; set; }

        [Argument("f")]
        public string ArgF { get; set; }

        [Argument("g")]
        public string ArgG { get; set; }

        protected override string BaseAddress
        {
            get { return this.baseAddress; }
        }
    }
}