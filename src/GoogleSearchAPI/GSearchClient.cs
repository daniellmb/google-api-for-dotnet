//-----------------------------------------------------------------------
// <copyright file="GSearchClient.cs" company="iron9light">
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

    public abstract class GSearchClient : GoogleClient
    {
#if !SILVERLIGHT
        protected GSearchClient(string referrer)
            : base(referrer)
        {
        }

        internal List<TResult> Search<T, TResult>(GoogleSearchRequest request, int resultCount)
            where T : TResult
        {
            this.SetValueTo(request);

            var list = SearchUtility.Search<T>(request, resultCount);

            return list.ConvertAll(item => (TResult)item);
        }
#endif

        internal IAsyncResult BeginSearch<T>(GoogleSearchRequest request, int resultCount, AsyncCallback callback, object state)
        {
            this.SetValueTo(request);

            return SearchUtility.BeginSearch<T>(request, resultCount, callback, state);
        }

        internal List<TResult> EndSearch<T, TResult>(IAsyncResult asyncResult) 
            where T : TResult
        {
            var list = SearchUtility.EndSearch<T>(asyncResult);

#if SILVERLIGHT
            return list.Select(item => (TResult)item).ToList();
#else
            return list.ConvertAll(item => (TResult)item);
#endif
        }
    }
}