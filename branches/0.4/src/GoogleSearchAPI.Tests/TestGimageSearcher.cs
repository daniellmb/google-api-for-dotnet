//-----------------------------------------------------------------------
// <copyright file="TestGimageSearcher.cs" company="iron9light">
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
    public class TestGimageSearcher
    {
        private GimageSearchClient Client { get; set; }

        [SetUp]
        public void SetUp()
        {
#if SILVERLIGHT
            this.Client = new GimageSearchClient();
#else
            this.Client = new GimageSearchClient(@"http://code.google.com/p/google-api-for-dotnet/");
#endif
        }

#if !SILVERLIGHT
        [Test]
        public void SearchTest()
        {
            var keyword = "Virgin Islands";
            var count = 15;
            var imageSize = ImageSize.Xxlarge;
            var colorization = Colorization.All;
            var imageType = ImageType.All;
            var fileType = ImageFileType.Bmp;
            string searchSite = null;
            var safeLevel = SafeLevel.Active;

            var results = this.Client.Search(
                keyword, count, safeLevel, imageSize, colorization, imageType, fileType, searchSite);
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
        public void SearchTest1()
        {
            var keyword = "x game";
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
            var keyword = "iPhone";
            var count = 6;
            var site = "yahoo.com";

            var results = this.Client.Search(keyword, count, site);
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
            var keyword = "American Idol";
            var count = 32;
            var imageSize = ImageSize.Medium;
            var colorization = Colorization.Gray;
            var imageType = ImageType.Face;
            var fileType = ImageFileType.Gif;

            var results = this.Client.Search(keyword, count, imageSize, colorization, imageType, fileType);
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
            var keyword = "金城武";
            var count = 25;
            var imageSize = ImageSize.All;
            var colorization = Colorization.Color;
            var imageType = ImageType.All;
            var fileType = ImageFileType.Jpg;
            var site = "sina.com";

            var results = this.Client.Search(keyword, count, imageSize, colorization, imageType, fileType, site);
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
        public void AsyncAsyncSearchTest()
        {
            var keyword = "Virgin Islands";
            var count = 15;
            var imageSize = ImageSize.Xxlarge;
            var colorization = Colorization.All;
            var imageType = ImageType.All;
            var fileType = ImageFileType.Bmp;
            string searchSite = null;
            var safeLevel = SafeLevel.Active;

            var results = this.Client.RunSearch<IList<IImageResult>>(
                keyword, count, safeLevel, imageSize, colorization, imageType, fileType, searchSite);
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
        public void AsyncSearchTest1()
        {
            var keyword = "x game";
            var count = 10;

            var results = this.Client.RunSearch<IList<IImageResult>>(keyword, count);
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
            var keyword = "iPhone";
            var count = 6;
            var site = "yahoo.com";

            var results = this.Client.RunSearch<IList<IImageResult>>(keyword, count, site);
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
            var keyword = "American Idol";
            var count = 32;
            var imageSize = ImageSize.Medium;
            var colorization = Colorization.Gray;
            var imageType = ImageType.Face;
            var fileType = ImageFileType.Gif;

            var results = this.Client.RunSearch<IList<IImageResult>>(keyword, count, imageSize, colorization, imageType, fileType);
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
            var keyword = "金城武";
            var count = 25;
            var imageSize = ImageSize.All;
            var colorization = Colorization.Color;
            var imageType = ImageType.All;
            var fileType = ImageFileType.Jpg;
            var site = "sina.com";

            var results = this.Client.RunSearch<IList<IImageResult>>(keyword, count, imageSize, colorization, imageType, fileType, site);
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