//-----------------------------------------------------------------------
// <copyright file="AsyncUtility.cs" company="iron9light">
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
    using System.Linq;

    public static class AsyncUtility
    {
        public static T Run<T>(Func<AsyncCallback, object, IAsyncResult> beginInvoke, Func<IAsyncResult, T> endInvoke)
            where T : class
        {
#if SILVERLIGHT
            NUnit.Framework.Assert.Ignore("Silverlight runtime forbid blocking thread.");
#endif

            T result = null;
            var asyncResult = beginInvoke(ar => result = endInvoke(ar), null);
            asyncResult.AsyncWaitHandle.WaitOne();
            return result;
        }

        public static T RunSearch<T>(this object client, params object[] parameters)
            where T : class
        {
            return client.AsyncRun<T>("Search", parameters);
        }

        public static T AsyncRun<T>(this object client, string methodName, params object[] parameters)
            where T : class
        {
            var clientType = client.GetType();
            var paramTypes =
                parameters.Select<object, Type>(GetParameterType).Concat(
                    new[] { typeof(AsyncCallback), typeof(object) });
            var beginSearch = clientType.GetMethod("Begin" + methodName, paramTypes.ToArray());
            var endSearch = clientType.GetMethod("End" + methodName, new[] { typeof(IAsyncResult) });

            return
                Run(
                    (callback, state) =>
                    (IAsyncResult)
                    beginSearch.Invoke(
                        client,
                        parameters.Select<object, object>(ToSafeParameter).Concat(new[] { callback, state }).ToArray()),
                    ar => (T)endSearch.Invoke(client, new[] { ar }));
        }

        private static Type GetParameterType(object parameter)
        {
            if (parameter == null)
            {
                return typeof(string);
            }

            if (typeof(Enumeration).IsInstanceOfType(parameter))
            {
                return typeof(string);
            }

            return parameter.GetType();
        }

        private static object ToSafeParameter(this object parameter)
        {
            if (parameter == null)
            {
                return null;
            }

            if (typeof(Enumeration).IsInstanceOfType(parameter))
            {
                return (string)(parameter as Enumeration);
            }

            return parameter;
        }
    }
}