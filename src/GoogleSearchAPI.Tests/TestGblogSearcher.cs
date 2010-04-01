//-----------------------------------------------------------------------
// <copyright file="TestGblogSearcher.cs" company="iron9light">
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
    public class TestGblogSearcher
    {
        private GblogSearchClient Client { get; set; }

        [SetUp]
        public void SetUp()
        {
#if SILVERLIGHT
            this.Client = new GblogSearchClient();
#else
            this.Client = new GblogSearchClient(@"http://code.google.com/p/google-api-for-dotnet/");
#endif
        }

#if !SILVERLIGHT
        [Test]
        public void SearchTest()
        {
            var keyword = "Coldplay";
            var count = 20;
            var results = this.Client.Search(keyword, count);
            Assert.IsNotNull(results);
            ////Assert.AreEqual(count, results.Count);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, count);
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
            var keyword = "iron9light";
            var count = 3;
            var sortBy = SortType.Date;
            var results = this.Client.Search(keyword, count, sortBy);
            Assert.IsNotNull(results);
            ////Assert.AreEqual(count, results.Count);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, count);
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
            var keyword = "Coldplay";
            var count = 20;

            var results = this.Client.RunSearch<IList<IBlogResult>>(keyword, count);

            Assert.IsNotNull(results);
            ////Assert.AreEqual(count, results.Count);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, count);
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
            var keyword = "iron9light";
            var count = 3;
            var sortBy = SortType.Date;

            var results = this.Client.RunSearch<IList<IBlogResult>>(keyword, count, sortBy);

            Assert.IsNotNull(results);
            ////Assert.AreEqual(count, results.Count);
            Assert.Greater(results.Count, 0);
            Assert.LessOrEqual(results.Count, count);
            foreach (var result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}