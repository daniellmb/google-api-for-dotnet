/**
 * TestGWebSearcher.cs
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
using System.Collections.Generic;
using NUnit.Framework;

namespace Google.API.Search.Test
{
    [TestFixture]
    public class TestGWebSearcher
    {
        [Test]
        public void GSearchTest()
        {
            string keyword = "Google Translate API .NET";
            int start = 1;
            ResultSizeEnum resultSize = ResultSizeEnum.small;
            Language language = new Language();

            SearchData<GWebResult> searchData = GWebSearcher.GSearch(keyword, start, resultSize, language);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);

            foreach (GWebResult result in searchData.Results)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual("GwebSearch", result.GSearchResultClass);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest()
        {
            int count = 11;
            IList<IWebResult> results = GWebSearcher.Search("Kobe bryant", count);
            Assert.IsNotNull(results);
            foreach (IWebResult result in results)
            {
                Assert.IsNotNull(result);
            }
            Assert.AreEqual(count, results.Count);
        }

        [Test]
        public void SearchTest2()
        {
            int count = 50;
            Language language = Language.Japanese;
            IList<IWebResult> results = GWebSearcher.Search("Kobe bryant", count, language);
            Assert.IsNotNull(results);
            foreach (IWebResult result in results)
            {
                Assert.IsNotNull(result);
            }
        }
    }
}
