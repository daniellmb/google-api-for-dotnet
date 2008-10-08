/**
 * TestGnewsSearcher.cs
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
    public class TestGnewsSearcher
    {
        [Test]
        public void GSearchTest()
        {
            string keyword = "Olympic";
            int start = 0;
            ResultSize resultSize = new ResultSize();
            string geo = "Beijing China";
            SortType sortBy = new SortType();

            SearchData<GnewsResult> results =
                GnewsSearcher.GSearch(keyword, start, resultSize, geo, sortBy);

            Assert.IsNotNull(results);
            Assert.IsNotNull(results.Results);
            Assert.Greater(results.Results.Length, 0);
            foreach (GnewsResult result in results.Results)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual("GnewsSearch", result.GSearchResultClass);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest()
        {
            string keyword = "NBA";
            int count = 15;
            IList<INewsResult> results = GnewsSearcher.Search(keyword, count);
            Assert.IsNotNull(results);
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
            string keyword = "earthquake";
            string geo = "China";
            int count = 32;
            IList<INewsResult> results = GnewsSearcher.Search(keyword, count, geo);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (var result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest3()
        {
            string keyword = "Obama";
            int count = 32;
            IList<INewsResult> resultsByRelevance = GnewsSearcher.Search(keyword, count, SortType.relevance);
            IList<INewsResult> resultsByDate = GnewsSearcher.Search(keyword, count, SortType.date);
            Assert.IsNotNull(resultsByRelevance);
            Assert.IsNotNull(resultsByDate);
            Assert.AreEqual(resultsByRelevance.Count, resultsByDate.Count);
            bool areSame = true;
            for(int i = 0; i < resultsByRelevance.Count;++i)
            {
                if(resultsByRelevance[i].ToString() != resultsByDate[i].ToString())
                {
                    areSame = false;
                    break;
                }
            }
            Assert.IsFalse(areSame);

            Console.WriteLine("News by relevance");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsByRelevance)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }

            Console.WriteLine("News by date");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsByDate)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchLocalTest()
        {
            int count = 16;
            IList<INewsResult> resultsInTokyo = GnewsSearcher.SearchLocal("Tokyo", count);
            IList<INewsResult> resultsInJapan = GnewsSearcher.SearchLocal("Japan", count);
            Assert.IsNotNull(resultsInTokyo);
            Assert.IsNotNull(resultsInJapan);
            Assert.AreEqual(count, resultsInTokyo.Count);
            Assert.AreEqual(count, resultsInJapan.Count);

            bool areSame = true;
            for(int i = 0; i < resultsInTokyo.Count; ++i)
            {
                if(resultsInTokyo[i].ToString() != resultsInJapan[i].ToString())
                {
                    areSame = false;
                    break;
                }
            }
            Assert.IsFalse(areSame);

            Console.WriteLine("News in Tokyo");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsInTokyo)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }

            Console.WriteLine("News in Japan");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsInJapan)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchWithBigResultTest()
        {
            var results = GwebSearcher.Search("a", 50);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, 50);
        }
    }
}
