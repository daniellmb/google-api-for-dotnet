/**
 * GlocalSearcher.cs
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

namespace Google.API.Search
{
    /// <summary>
    /// Utility class for Google Local Search service.
    /// </summary>
    public static class GlocalSearcher
    {
        internal static SearchData<GlocalResult> GSearch(
            string keyword,
            int start,
            ResultSize resultSize,
            float latitude,
            float longitude,
            float? width,
            float? height,
            LocalResultType resultType)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            var local = latitude + "," + longitude;

            string bounding = null;
            if (width != null && height != null)
                bounding = width + "," + longitude;

            var responseData = SearchUtility.GetResponseData(
                service => service.LocalSearch(
                               keyword,
                               resultSize.GetString(),
                               start,
                               local,
                               bounding,
                               resultType.GetString())
                );

            return responseData;
        }

        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude)
        {
            return Search(keyword, resultCount, latitude, longitude, null, null, new LocalResultType());
        }

        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            LocalResultType resultType)
        {
            return Search(keyword, resultCount, latitude, longitude, null, null, resultType);
        }

        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float width,
            float height)
        {
            return Search(keyword, resultCount, latitude, longitude, (float?)width, (float?)height, new LocalResultType());
        }

        public static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float width,
            float height,
            LocalResultType resultType)
        {
            return Search(keyword, resultCount, latitude, longitude, (float?)width, (float?)height, resultType);
        }

        private static IList<ILocalResult> Search(
            string keyword,
            int resultCount,
            float latitude,
            float longitude,
            float? width,
            float? height,
            LocalResultType resultType)
        {
            if (keyword == null)
                throw new ArgumentNullException("keyword");

            GSearchCallback<GlocalResult> gsearch = (start, resultSize) => GSearch(
                                                                               keyword,
                                                                               start,
                                                                               resultSize,
                                                                               latitude,
                                                                               longitude,
                                                                               width,
                                                                               height,
                                                                               resultType);

            var results = SearchUtility.Search(gsearch, resultCount);
            return results.ConvertAll(item => (ILocalResult)item);
        }
    }
}
