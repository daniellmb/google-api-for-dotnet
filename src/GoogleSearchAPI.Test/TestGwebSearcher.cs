//-----------------------------------------------------------------------
// <copyright file="TestGwebSearcher.cs" company="iron9light">
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
    public class TestGwebSearcher
    {
        private GwebSearchClient Client { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.Client = new GwebSearchClient();
        }

        [Test]
        public void GSearchTest()
        {
            var keyword = "Google Translate API .NET";
            var start = 1;
            var resultSize = ResultSize.Small;
            var language = Language.GetDefault();
            var safeLevel = SafeLevel.Active;
            var duplicateFilter = DuplicateFilter.Off;

            var searchData = this.Client.GSearch(keyword, start, resultSize, null, null, safeLevel, language, duplicateFilter);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);

            foreach (var result in searchData.Results)
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
            var count = 11;
            var results = this.Client.Search("Kobe bryant", count);
            Assert.IsNotNull(results);
            foreach (var result in results)
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
            var count = 50;
            var language = Language.Japanese;
            var results = this.Client.Search("Kobe bryant", count, language);
            Assert.IsNotNull(results);
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
            var keyword = "Disney";
            var count = 25;
            var language = Language.French;
            var safeLevel = SafeLevel.Off;

            var results = this.Client.Search(keyword, count, language, safeLevel);
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