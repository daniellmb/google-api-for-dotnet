/**
 * SearchUtility.cs
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

using System.Collections.Generic;

namespace Google.API.Search
{
    internal static class SearchUtility
    {
        public delegate SearchData<T> GSearchCallback<T>(int start, ResultSizeEnum resultSize);

        public static List<T> Search<T>(GSearchCallback<T> gsearch, int resultCount)
        {
            int start = 0;
            List<T> results = new List<T>();
            int restCount = resultCount;
            while (restCount > 0)
            {
                SearchData<T> searchData;
                try
                {
                    if (restCount > 4)
                    {
                        searchData = gsearch(start, ResultSizeEnum.large);
                    }
                    else
                    {
                        searchData = gsearch(start, ResultSizeEnum.small);
                    }
                }
                catch (SearchException)
                {
                    return results;
                }

                int count = searchData.Results.Length;
                if (count <= restCount)
                {
                    results.AddRange(searchData.Results);
                }
                else
                {
                    count = restCount;
                    for (int i = 0; i < count; ++i)
                    {
                        results.Add(searchData.Results[i]);
                    }
                }
                start += count;
                restCount -= count;
            }

            return results;
        }
    }
}
