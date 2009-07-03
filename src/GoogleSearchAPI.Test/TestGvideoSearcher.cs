//-----------------------------------------------------------------------
// <copyright file="TestGvideoSearcher.cs" company="iron9light">
// Copyright (c) 2009 iron9light
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

namespace Google.API.Search.Test
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class TestGvideoSearcher
    {
        [Test]
        public void GSearchTest()
        {
            var keyword = "super mario";
            var start = 10;
            var resultSize = ResultSize.large;
            var sortBy = SortType.relevance;

            var searchData = GvideoSearcher.GSearch(keyword, start, resultSize, sortBy);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);
            foreach (var result in searchData.Results)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual("GvideoSearch", result.GSearchResultClass);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest()
        {
            var keyword = "Metal Gear Solid";
            var count = 8;
            var results = GvideoSearcher.Search(keyword, count);
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
            var keyword = "and1";
            var count = 32;
            var sortBy = SortType.date;
            var results = GvideoSearcher.Search(keyword, count, sortBy);
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