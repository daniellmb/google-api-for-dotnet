//-----------------------------------------------------------------------
// <copyright file="TestGpatentSearcher.cs" company="iron9light">
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
    public class TestGpatentSearcher
    {
        private GpatentSearchClient Client { get; set; }

        [SetUp]
        public void SetUp()
        {
#if SILVERLIGHT
            this.Client = new GpatentSearchClient();
#else
            this.Client = new GpatentSearchClient(@"http://code.google.com/p/google-api-for-dotnet/");
#endif
        }

#if !SILVERLIGHT
        [Test]
        public void SearchTest()
        {
            var keyword = "Artificial Intelligence";
            var count = 10;
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
            var keyword = "encode";
            var count = 32;
            var sortBy = SortType.Relevance;
            var results = this.Client.Search(keyword, count, sortBy);

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
            var keyword = "wifi";
            var count = 20;
            var issuedOnly = false;
            var filedOnly = true;
            var results = this.Client.Search(keyword, count, issuedOnly, filedOnly);

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
        public void SearchTest4()
        {
            var keyword = "render";
            var count = 30;
            var issuedOnly = true;
            var filedOnly = true;
            var sortBy = SortType.Date;
            var results = this.Client.Search(keyword, count, issuedOnly, filedOnly, sortBy);

            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (var result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
#endif

        [Test]
        public void AsyncSearchTest()
        {
            var keyword = "Artificial Intelligence";
            var count = 10;
            var results = this.Client.RunSearch<IList<IPatentResult>>(keyword, count);

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
            var keyword = "encode";
            var count = 32;
            var sortBy = SortType.Relevance;
            var results = this.Client.RunSearch<IList<IPatentResult>>(keyword, count, sortBy);

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
            var keyword = "wifi";
            var count = 20;
            var issuedOnly = false;
            var filedOnly = true;
            var results = this.Client.RunSearch<IList<IPatentResult>>(keyword, count, issuedOnly, filedOnly);

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
        public void AsyncSearchTest4()
        {
            var keyword = "render";
            var count = 30;
            var issuedOnly = true;
            var filedOnly = true;
            var sortBy = SortType.Date;
            var results = this.Client.RunSearch<IList<IPatentResult>>(keyword, count, issuedOnly, filedOnly, sortBy);

            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (var result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}