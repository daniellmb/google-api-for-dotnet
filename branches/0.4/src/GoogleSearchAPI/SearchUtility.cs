//-----------------------------------------------------------------------
// <copyright file="SearchUtility.cs" company="iron9light">
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

namespace Google.API.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal static class SearchUtility
    {
#if !SILVERLIGHT
        public static List<T> Search<T>(GoogleSearchRequest request, int resultCount)
        {
            var start = 0;
            var results = new List<T>();
            var restCount = resultCount;
            while (restCount > 0)
            {
                ISearchData<T> searchData;
                try
                {
                    if (restCount > 4)
                    {
                        searchData = GetResponseData<T>(request, start, ResultSize.Large);
                    }
                    else
                    {
                        searchData = GetResponseData<T>(request, start, ResultSize.Small);
                    }
                }
                catch (GoogleServiceException ex)
                {
                    if (ex.ResponseStatus == ResponseStatusConstant.OutOfRangeStatus)
                    {
                        return results;
                    }

                    throw;
                }

                var count = searchData.Results.Length;
                if (count == 0)
                {
                    break;
                }

                if (count <= restCount)
                {
                    results.AddRange(searchData.Results);
                }
                else
                {
                    count = restCount;
                    for (var i = 0; i < count; ++i)
                    {
                        results.Add(searchData.Results[i]);
                    }
                }

                start += count;
                restCount -= count;
            }

            return results;
        }

        private static ISearchData<T> GetResponseData<T>(GoogleSearchRequest request, int start, string resultSize)
        {
            ResetRequest(request, start, resultSize);
            return RequestUtility.GetResponseData<SearchData<T>>(request);
        }
#endif

        public static IAsyncResult BeginSearch<T>(GoogleSearchRequest request, int resultCount, AsyncCallback callback, object state)
        {
            var searchAsyncResult = new SearchAsyncResult<T>(state);

            RunSearch(searchAsyncResult, request, 0, resultCount, callback);

            return searchAsyncResult;
        }

        public static List<T> EndSearch<T>(IAsyncResult asyncResult)
        {
            var searchAsyncResult = (SearchAsyncResult<T>)asyncResult;
            if (searchAsyncResult.Exception != null)
            {
                throw searchAsyncResult.Exception;
            }

            return searchAsyncResult.Result;
        }

        private static void RunSearch<T>(SearchAsyncResult<T> searchAsyncResult, GoogleSearchRequest request, int start, int restCount, AsyncCallback callback)
        {
            if (restCount > 0)
            {
                var resultSize = restCount > 4 ? ResultSize.Large : ResultSize.Small;

                BeginGetResponseData(
                    request,
                    start,
                    resultSize,
                    ar =>
                        {
                            try
                            {
                                ISearchData<T> searchData;
                                try
                                {
                                    searchData = EndGetResponseData<T>(ar);
                                }
                                catch (GoogleServiceException ex)
                                {
                                    if (ex.ResponseStatus == ResponseStatusConstant.OutOfRangeStatus)
                                    {
                                        FinishSearch(searchAsyncResult, callback);
                                        return;
                                    }

                                    throw;
                                }

                                var count = Math.Min(searchData.Results.Length, restCount);

                                if (count == 0)
                                {
                                    FinishSearch(searchAsyncResult, callback);
                                }
                                else
                                {
                                    searchAsyncResult.Result.AddRange(searchData.Results.Take(count));

                                    RunSearch(searchAsyncResult, request, start + count, restCount - count, callback);
                                }
                            }
                            catch (Exception ex)
                            {
                                searchAsyncResult.Exception = ex;
                                FinishSearch(searchAsyncResult, callback);
                            }
                        },
                    null);
            }
            else
            {
                FinishSearch(searchAsyncResult, callback);
            }
        }

        private static void FinishSearch<T>(SearchAsyncResult<T> searchAsyncResult, AsyncCallback callback)
        {
            try
            {
                callback(searchAsyncResult);
            }
            finally
            {
                searchAsyncResult.Complete();
            }
        }

        private static IAsyncResult BeginGetResponseData(GoogleSearchRequest request, int start, string resultSize, AsyncCallback callback, object state)
        {
            ResetRequest(request, start, resultSize);
            return RequestUtility.BeginGetResponseData(request, callback, state);
        }

        private static ISearchData<T> EndGetResponseData<T>(IAsyncResult asyncResult)
        {
            return RequestUtility.EndGetResponseData<SearchData<T>>(asyncResult);
        }

        private static void ResetRequest(GoogleSearchRequest request, int start, string resultSize)
        {
            request.Reset();
            request.Start = start;
            request.ResultSize = resultSize;
        }

        private class SearchAsyncResult<T> : IAsyncResult
        {
            private ManualResetEvent resetEvent;

            public SearchAsyncResult(object state)
            {
                this.AsyncState = state;
                this.Result = new List<T>();
            }

            public List<T> Result { get; private set; }

            public Exception Exception { get; set; }

            #region IAsyncResult Members

            public object AsyncState { get; private set; }

            public WaitHandle AsyncWaitHandle
            {
                get 
                {
                    if (this.resetEvent == null)
                    {
                        lock (this)
                        {
                            if (this.resetEvent == null)
                            {
                                this.resetEvent = new ManualResetEvent(this.IsCompleted);
                            }
                        }
                    }

                    return this.resetEvent;
                }
            }

            public bool CompletedSynchronously
            {
                get 
                {
                    return false;
                }
            }

            public bool IsCompleted { get; private set; }

            #endregion

            public void Complete()
            {
                this.IsCompleted = true;

                lock (this)
                {
                    if (this.resetEvent != null)
                    {
                        this.resetEvent.Set();
                    }
                }
            }
        }
    }
}