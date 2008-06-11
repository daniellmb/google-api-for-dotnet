/**
 * GWebSearcher.cs
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
using System.Net;

namespace Google.API.Search
{
    public static class GWebSearcher
    {
        internal static SearchData<GWebSearchResult> Search(string keyword)
        {
            return Search(keyword, 0, new ResultSizeEnum());
        }

        internal static SearchData<GWebSearchResult> Search(string keyword, int start)
        {
            return Search(keyword, start, new ResultSizeEnum());
        }

        internal static SearchData<GWebSearchResult> Search(string keyword, int start, ResultSizeEnum resultSize)
        {
            if(keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }

            GWebSearchRequest request = new GWebSearchRequest(keyword, start, resultSize);

            WebRequest webRequest = request.GetWebRequest();

            SearchData<GWebSearchResult> responseData;
            try
            {
                responseData = RequestUtility.GetResponseData<SearchData<GWebSearchResult>>(webRequest);
            }
            catch (GoogleAPIException ex)
            {
                throw new SearchException(string.Format("request:\"{0}\"", request), ex);
            }
            return responseData;
        }

        public static IList<IWebSearchResult> Search(string keyword, int start, int resultCount)
        {
            if(keyword == null)
            {
                throw new ArgumentNullException("keyword");
            }
            if(start < 0)
            {
                start = 0;
            }

            List<IWebSearchResult> results = new List<IWebSearchResult>();
            int restCount = resultCount;
            while(restCount > 0)
            {
                SearchData<GWebSearchResult> searchData;
                try
                {
                    if (restCount > 4)
                    {
                        searchData = Search(keyword, start, ResultSizeEnum.large);
                    }
                    else
                    {
                        searchData = Search(keyword, start);
                    }
                }
                catch(SearchException ex)
                {
                    //throw new SearchException("Search Failed.", ex);
                    return results;
                }

                
                int count = searchData.Results.Length;
                if(count <= restCount)
                {
                    results.AddRange(searchData.Results);
                }
                else
                {
                    count = restCount;
                    for(int i = 0; i < count; ++i)
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
