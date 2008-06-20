/**
 * TestGpatentSearcher.cs
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
    public class TestGpatentSearcher
    {
        [Test]
        public void GSearchTest()
        {
            string keyword = "search engine";
            int start = 0;
            ResultSize resultSize = ResultSize.small;
            bool issuedOnly = true;
            bool filedOnly = false;
            SortType sortBy = SortType.relevance;

            SearchData<GpatentResult> searchData =
                GpatentSearcher.GSearch(keyword, start, resultSize, issuedOnly, filedOnly, sortBy);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);
            foreach (GpatentResult result in searchData.Results)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual("GpatentSearch", result.GSearchResultClass);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest()
        {
            string keyword = "Artificial Intelligence";
            int count = 10;
            IList<IPatentResult> results = GpatentSearcher.Search(keyword, count);

            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IPatentResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest2()
        {
            string keyword = "encode";
            int count = 32;
            SortType sortBy = SortType.relevance;
            IList<IPatentResult> results = GpatentSearcher.Search(keyword, count, sortBy);

            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IPatentResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest3()
        {
            string keyword = "wifi";
            int count = 20;
            bool issuedOnly = false;
            bool filedOnly = true;
            IList<IPatentResult> results = GpatentSearcher.Search(keyword, count, issuedOnly, filedOnly);

            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IPatentResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest4()
        {
            string keyword = "render";
            int count = 30;
            bool issuedOnly = true;
            bool filedOnly = true;
            SortType sortBy = SortType.date;
            IList<IPatentResult> results = GpatentSearcher.Search(keyword, count, issuedOnly, filedOnly, sortBy);

            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IPatentResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}
