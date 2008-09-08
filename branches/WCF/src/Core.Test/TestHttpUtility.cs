/**
 * TestHttpUtility.cs
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

namespace Google.API.Test
{
    [TestFixture]
    public class TestHttpUtility
    {
        [Test]
        public void HtmlDecodeTest()
        {
            string s = @"<%xxx>\\\<///>hi...";

            string encodedS = System.Web.HttpUtility.HtmlEncode(s);

            string decodedBackS = HttpUtility.HtmlDecode(encodedS);

            Assert.AreEqual(s, decodedBackS);
        }

        [Test]
        public void RemoveHtmlTagsTest()
        {
            string s = "<chinese>我爱我家。</chinese>" + Environment.NewLine + "<english>I love my family.</english>";
            string encodedS = System.Web.HttpUtility.HtmlEncode(s);
            encodedS = string.Format("<html><b><i>{0}</i></b></html>", encodedS);

            string decodedBackS = HttpUtility.RemoveHtmlTags(encodedS);
            Assert.AreEqual(s, decodedBackS);
        }
    }
}
