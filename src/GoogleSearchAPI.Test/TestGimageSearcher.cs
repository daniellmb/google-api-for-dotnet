/**
 * TestGimageSearcher.cs
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
    public class TestGimageSearcher
    {
        [Test]
        public void GSearchTest()
        {
            string keyword = "bra";
            int start = 4;
            ResultSize resultSize = ResultSize.large;
            ImageSize imageSize = ImageSize.all;
            Colorization colorization = Colorization.color;
            ImageType imageType = ImageType.all;
            FileType fileType = FileType.jpg;
            string searchSite = null;
            SafeLevel safeLevel = SafeLevel.off;

            SearchData<GimageResult> searchData =
                GimageSearcher.GSearch(keyword, start, resultSize, safeLevel, imageSize, colorization, imageType,
                                       fileType, searchSite);
            Assert.IsNotNull(searchData);
            Assert.IsNotNull(searchData.Results);
            Assert.Greater(searchData.Results.Length, 0);
            foreach (GimageResult result in searchData.Results)
            {
                Assert.IsNotNull(result);
                Assert.AreEqual("GimageSearch", result.GSearchResultClass);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest()
        {
            string keyword = "Virgin Islands";
            int count = 15;
            ImageSize imageSize = ImageSize.xxlarge;
            Colorization colorization = Colorization.all;
            ImageType imageType = ImageType.all;
            FileType fileType = FileType.bmp;
            string searchSite = null;
            SafeLevel safeLevel = SafeLevel.active;

            IList<IImageResult> results =
                GimageSearcher.Search(keyword, count, imageSize, colorization, imageType, fileType, searchSite,
                                      safeLevel);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IImageResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest1()
        {
            string keyword = "x game";
            int count = 10;

            IList<IImageResult> results = GimageSearcher.Search(keyword, count);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IImageResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest2()
        {
            string keyword = "iPhone";
            int count = 6;
            string site = "yahoo.com";

            IList<IImageResult> results = GimageSearcher.Search(keyword, count, site);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IImageResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest3()
        {
            string keyword = "American Idol";
            int count = 32;
            ImageSize imageSize = ImageSize.medium;
            Colorization colorization = Colorization.gray;
            ImageType imageType = ImageType.face;
            FileType fileType = FileType.gif;

            IList<IImageResult> results = GimageSearcher.Search(keyword, count, imageSize, colorization, imageType, fileType);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IImageResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        [Test]
        public void SearchTest4()
        {
            string keyword = "金城武";
            int count = 25;
            ImageSize imageSize = ImageSize.all;
            Colorization colorization = Colorization.color;
            ImageType imageType = ImageType.all;
            FileType fileType = FileType.jpg;
            string site = "sina.com";

            IList<IImageResult> results = GimageSearcher.Search(keyword, count, imageSize, colorization, imageType, fileType, site);
            Assert.IsNotNull(results);
            Assert.AreEqual(count, results.Count);
            foreach (IImageResult result in results)
            {
                Assert.IsNotNull(result);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }
    }
}
