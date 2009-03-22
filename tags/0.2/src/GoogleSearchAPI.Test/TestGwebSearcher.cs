/**
 * TestGwebSearcher.cs
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
    public class TestGwebSearcher
    {
        [Test]
        public void GSearchTest()
        {
            string keyword = "Google Translate API .NET";
            int start = 1;
            ResultSize resultSize = ResultSize.small;
            Language language = new Language();
            SafeLevel safeLevel = SafeLevel.active;

            SearchData<GwebResult> searchData = GwebSearcher.GSearch(keyword, start, resultSize, language, safeLevel);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);

            foreach (GwebResult result in searchData.Results)
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
            IList<IWebResult> results = GwebSearcher.Search("Kobe bryant", count);
            Assert.IsNotNull(results);
            foreach (IWebResult result in results)
            {
                Assert.IsNotNull(result);
            }
            Assert.AreEqual(count, results.Count);
            foreach (var result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest2()
        {
            int count = 50;
            Language language = Language.Japanese;
            IList<IWebResult> results = GwebSearcher.Search("Kobe bryant", count, language);
            Assert.IsNotNull(results);
            foreach (IWebResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest3()
        {
            string keyword = "Disney";
            int count = 25;
            Language language = Language.French;
            SafeLevel safeLevel = SafeLevel.off;

            IList<IWebResult> results = GwebSearcher.Search(keyword, count, language, safeLevel);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IWebResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}
