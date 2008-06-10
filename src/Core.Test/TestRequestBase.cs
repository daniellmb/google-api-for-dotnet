/**
 * TestRequestBase.cs
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

using System;
using NUnit.Framework;

namespace Google.API.Translate.Test
{
    [TestFixture]
    public class TestRequestBase
    {
        [Test]
        public void UrlStringTest()
        {
            MockRequest mockRequest = new MockRequest("http://www.xxx.com", "xx");
            mockRequest.ArgB = 50;
            Console.Write(mockRequest.Uri.Query);
            Assert.AreEqual("http://www.xxx.com?a=default&b=50&q=xx&v=1.0", mockRequest.UrlString);
        }
    }

    class MockRequest : RequestBase
    {
        public MockRequest(string address, string content)
            : base(content)
        {
            m_BaseAddress = address;
        }

        private string m_BaseAddress;

        [Argument("a", "default")]
        public string ArgA { get; set; }

        [Argument("b", Optional = false)]
        public object ArgB { get; set; }

        protected override string BaseAddress
        {
            get { return m_BaseAddress; }
        }
    }
}
