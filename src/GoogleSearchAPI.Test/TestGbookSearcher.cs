/**
 * TestGbookSearcher.cs
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
    public class TestGbookSearcher
    {
        [Test]
        public void GSearchTest()
        {
            string keyword = "Grimm's Fairy Tales";
            int start = 0;
            ResultSize resultSize = ResultSize.large;
            bool fullViewOnly = false;
            string library = null;

            SearchData<GbookResult> searchData =
                GbookSearcher.GSearch(keyword, start, resultSize, fullViewOnly, library);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);
            foreach (GbookResult result in searchData.Results)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual("GbookSearch", result.GSearchResultClass);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest()
        {
            string keyword = "cookbook";
            int count = 20;

            IList<IBookResult> results = GbookSearcher.Search(keyword, count);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IBookResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest2()
        {
            string keyword = "love";
            int count = 4;
            bool isFullViewable = true;

            IList<IBookResult> results = GbookSearcher.Search(keyword, count, isFullViewable);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IBookResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest3()
        {
            string keyword = "falkdjfaj;eage";
            int count = 3;
            bool isFullViewable = false;
            string library = "Madelena";

            IList<IBookResult> results = GbookSearcher.Search(keyword, count, isFullViewable, library);
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
            foreach (IBookResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}
