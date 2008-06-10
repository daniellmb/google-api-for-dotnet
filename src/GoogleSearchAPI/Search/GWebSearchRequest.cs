/**
 * GWebSearchRequest.cs
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
    internal class GWebSearchRequest : RequestBase
    {
        public enum ResultSizeEnum
        {
            small = 0,
            large = 1,
        }

        private static readonly string s_BaseAddress = @"http://ajax.googleapis.com/ajax/services/search/web";

        public GWebSearchRequest(string text)
            : base(text)
        { }

        public GWebSearchRequest(string text, int start)
            : base(text)
        {
            Start = start;
        }

        public GWebSearchRequest(string text, int start, ResultSizeEnum resultSize)
            : base(text)
        {
            Start = start;
            ResultSize = resultSize;
        }

        [Argument("rsz?")]
        public ResultSizeEnum ResultSize { get; private set; }

        [Argument("start?")]
        public int Start { get; private set; }

        protected override string BaseAddress
        {
            get { return s_BaseAddress; }
        }
    }
}
