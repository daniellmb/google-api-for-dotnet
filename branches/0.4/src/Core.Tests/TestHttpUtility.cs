//-----------------------------------------------------------------------
// <copyright file="TestHttpUtility.cs" company="iron9light">
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
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class TestHttpUtility
    {
#if !SILVERLIGHT && !PocketPC
        [Test]
        public void HtmlDecodeTest()
        {
            var s = @"<%xxx>\\\<///>hi...";

            var encodedS = System.Web.HttpUtility.HtmlEncode(s);

            var decodedBackS = HttpUtility.HtmlDecode(encodedS);

            Assert.AreEqual(s, decodedBackS);
        }

        [Test]
        public void RemoveHtmlTagsTest()
        {
            var s = "<chinese>我爱我家。</chinese>" + Environment.NewLine + "<english>I love my family.</english>";
            var encodedS = System.Web.HttpUtility.HtmlEncode(s);
            encodedS = string.Format("<html><b><i>{0}</i></b></html>", encodedS);

            var decodedBackS = HttpUtility.RemoveHtmlTags(encodedS);
            Assert.AreEqual(s, decodedBackS);
        }

        [Test]
        public void UrlEncodeTest()
        {
            var s = @"!!@#$@$%Y#$^%$^$%&&&*?+{S_|";
            var encodedS = HttpUtility.UrlEncode(s);
            var expectedEncodedS = System.Web.HttpUtility.UrlEncode(s);
            Assert.AreEqual(expectedEncodedS, encodedS);
        }
#endif
    }
}