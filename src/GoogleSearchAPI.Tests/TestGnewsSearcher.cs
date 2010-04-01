//-----------------------------------------------------------------------
// <copyright file="TestGnewsSearcher.cs" company="iron9light">
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

namespace Google.API.Search.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class TestGnewsSearcher
    {
        private GnewsSearchClient Client { get; set; }

        [SetUp]
        public void SetUp()
        {
#if SILVERLIGHT
            this.Client = new GnewsSearchClient();
#else
            this.Client = new GnewsSearchClient(@"http://code.google.com/p/google-api-for-dotnet/");
#endif
        }

#if !SILVERLIGHT
        [Test]
        public void SearchTest()
        {
            var keyword = "NBA";
            var count = 15;
            var results = this.Client.Search(keyword, count);
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
            var keyword = "earthquake";
            var geo = "China";
            var count = 32;
            var results = this.Client.Search(keyword, count, geo, SortType.GetDefault());
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
            var keyword = "Obama";
            var count = 32;
            var resultsByRelevance = this.Client.Search(keyword, count, null, SortType.Relevance);
            var resultsByDate = this.Client.Search(keyword, count, null, SortType.Date);
            Assert.IsNotNull(resultsByRelevance);
            Assert.IsNotNull(resultsByDate);
            Assert.AreEqual(resultsByRelevance.Count, resultsByDate.Count);
            var areSame = true;
            for (var i = 0; i < resultsByRelevance.Count; ++i)
            {
                if (resultsByRelevance[i].ToString() != resultsByDate[i].ToString())
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
            var count = 16;
            var resultsInTokyo = this.Client.SearchLocal("Tokyo", count);
            var resultsInJapan = this.Client.SearchLocal("Japan", count);
            Assert.IsNotNull(resultsInTokyo);
            Assert.IsNotNull(resultsInJapan);
            Assert.AreEqual(count, resultsInTokyo.Count);
            Assert.AreEqual(count, resultsInJapan.Count);

            var areSame = true;
            for (var i = 0; i < resultsInTokyo.Count; ++i)
            {
                if (resultsInTokyo[i].ToString() != resultsInJapan[i].ToString())
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
        public void SearchTopicTest()
        {
            var count = 16;
            var resultsOfSports = this.Client.SearchTopic(NewsTopic.Sports, count);
            var resultsOfTechnology = this.Client.SearchTopic(NewsTopic.Technology, count);
            Assert.IsNotNull(resultsOfSports);
            Assert.IsNotNull(resultsOfTechnology);
            Assert.AreEqual(count, resultsOfSports.Count);
            Assert.AreEqual(count, resultsOfTechnology.Count);

            var areSame = true;
            for (var i = 0; i < resultsOfSports.Count; ++i)
            {
                if (resultsOfSports[i].ToString() != resultsOfTechnology[i].ToString())
                {
                    areSame = false;
                    break;
                }
            }

            Assert.IsFalse(areSame);

            Console.WriteLine("News of sports");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsOfSports)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }

            Console.WriteLine("News of technology");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsOfTechnology)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchWithBigResultTest()
        {
            var results = this.Client.Search("a", 1000);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, 1000);
        }
#endif

        [Test]
        public void AsyncSearchTest()
        {
            var keyword = "NBA";
            var count = 15;
            var results = this.Client.RunSearch<IList<INewsResult>>(keyword, count);
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
        public void AsyncSearchTest2()
        {
            var keyword = "earthquake";
            var geo = "China";
            var count = 32;
            var results = this.Client.RunSearch<IList<INewsResult>>(keyword, count, geo, SortType.GetDefault());
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
        public void AsyncSearchTest3()
        {
            var keyword = "Obama";
            var count = 32;
            var resultsByRelevance = this.Client.RunSearch<IList<INewsResult>>(keyword, count, null, SortType.Relevance);
            var resultsByDate = this.Client.RunSearch<IList<INewsResult>>(keyword, count, null, SortType.Date);
            Assert.IsNotNull(resultsByRelevance);
            Assert.IsNotNull(resultsByDate);
            Assert.AreEqual(resultsByRelevance.Count, resultsByDate.Count);
            var areSame = true;
            for (var i = 0; i < resultsByRelevance.Count; ++i)
            {
                if (resultsByRelevance[i].ToString() != resultsByDate[i].ToString())
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
        public void AsyncSearchLocalTest()
        {
            var count = 16;
            var resultsInTokyo = this.Client.AsyncRun<IList<INewsResult>>("SearchLocal", "Tokyo", count);
            var resultsInJapan = this.Client.AsyncRun<IList<INewsResult>>("SearchLocal", "Japan", count);
            Assert.IsNotNull(resultsInTokyo);
            Assert.IsNotNull(resultsInJapan);
            Assert.AreEqual(count, resultsInTokyo.Count);
            Assert.AreEqual(count, resultsInJapan.Count);

            var areSame = true;
            for (var i = 0; i < resultsInTokyo.Count; ++i)
            {
                if (resultsInTokyo[i].ToString() != resultsInJapan[i].ToString())
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
        public void AsyncSearchTopicTest()
        {
            var count = 16;
            var resultsOfSports = this.Client.AsyncRun<IList<INewsResult>>("SearchTopic", NewsTopic.Sports, count);
            var resultsOfTechnology = this.Client.AsyncRun<IList<INewsResult>>("SearchTopic", NewsTopic.Technology, count);
            Assert.IsNotNull(resultsOfSports);
            Assert.IsNotNull(resultsOfTechnology);
            Assert.AreEqual(count, resultsOfSports.Count);
            Assert.AreEqual(count, resultsOfTechnology.Count);

            var areSame = true;
            for (var i = 0; i < resultsOfSports.Count; ++i)
            {
                if (resultsOfSports[i].ToString() != resultsOfTechnology[i].ToString())
                {
                    areSame = false;
                    break;
                }
            }

            Assert.IsFalse(areSame);

            Console.WriteLine("News of sports");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsOfSports)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }

            Console.WriteLine("News of technology");
            Console.WriteLine("-----------------------------");
            foreach (var result in resultsOfTechnology)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void AsyncSearchWithBigResultTest()
        {
            var results = this.Client.RunSearch<IList<INewsResult>>("a", 1000);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, 1000);
        }
    }
}