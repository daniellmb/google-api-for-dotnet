//-----------------------------------------------------------------------
// <copyright file="RequestUtility.cs" company="iron9light">
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

namespace Google.API
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;

    using Newtonsoft.Json;

    internal class RequestUtility
    {
        private static readonly Encoding Encoding = Encoding.UTF8;

        public static T GetResponseData<T>(IRequestInfo requestInfo)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException("requestInfo");
            }

            var webRequest = WebRequest.Create(requestInfo.Url);

#if PocketPC
            webRequest.Headers["Referer"] = requestInfo.Referrer;
#else
            webRequest.Headers[HttpRequestHeader.Referer] = requestInfo.Referrer;
#endif

            var postBytes = new byte[0];

            if (!string.IsNullOrEmpty(requestInfo.PostContent))
            {
#if PocketPC || SILVERLIGHT
                webRequest.Method = "POST";
#else
                webRequest.Method = WebRequestMethods.Http.Post;
#endif

                postBytes = Encoding.GetBytes(requestInfo.PostContent);

#if SILVERLIGHT
                webRequest.Headers[HttpRequestHeader.ContentLength] = postBytes.Length.ToString();
#else
                webRequest.ContentLength = postBytes.Length;
#endif
            }

            var requestStream = GetRequestStream(webRequest, requestInfo.OpenTimeout);

            WriteRequestStream(requestStream, postBytes, requestInfo.SendTimeout);

            string resultString = GetResultString(webRequest, requestInfo);

            return Deserialize<T>(resultString);
        }

        private static Stream GetRequestStream(WebRequest webRequest, TimeSpan timeout)
        {
            return Invoke<Stream>(webRequest.BeginGetRequestStream, webRequest.EndGetRequestStream, timeout);
        }

        private static void WriteRequestStream(Stream stream, byte[] postBytes, TimeSpan timeout)
        {
            using (stream)
            {
                stream.WriteTimeout = (int)timeout.TotalMilliseconds;
                stream.Write(postBytes, 0, postBytes.Length);
            }
        }

        private static string GetResultString(WebRequest webRequest, IRequestInfo requestInfo)
        {
            try
            {
                // HACK: Not sure it should be OpenTimeout, CloseTimeout or ReceiveTimeout.
                using (var webResponse = GetResponse(webRequest, requestInfo.OpenTimeout))
                {
                    using (var reader = new StreamReader(webResponse.GetResponseStream(), Encoding))
                    {
                        reader.BaseStream.ReadTimeout = (int)requestInfo.ReceiveTimeout.TotalMilliseconds;
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                throw new GoogleAPIException("Failed to get response.", ex);
            }
            catch (IOException ex)
            {
                throw new GoogleAPIException("Cannot read the response stream.", ex);
            }
        }

        private static WebResponse GetResponse(WebRequest webRequest, TimeSpan timeout)
        {
            return Invoke<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, timeout);
        }

        private static T Deserialize<T>(string text)
        {
            ResultObject<T> resultObject;
            try
            {
                resultObject = JsonConvert.DeserializeObject<ResultObject<T>>(text);
            }
            catch (Exception ex)
            {
                throw new DeserializeException(typeof(ResultObject<T>), text, ex);
            }

            if (resultObject.ResponseStatus != ResponseStatusConstant.DefaultStatus)
            {
                throw new GoogleServiceException(resultObject.ResponseStatus, resultObject.ResponseDetails);
            }

            return resultObject.ResponseData;
        }

        ////private static T Invoke<T>(Func<T> func, TimeSpan timeout)
        ////{
        ////    return Invoke<T>(func.BeginInvoke, func.EndInvoke, timeout);
        ////}

        private static T Invoke<T>(Func<AsyncCallback, object, IAsyncResult> beginInvoke, Func<IAsyncResult, T> endInvoke, TimeSpan timeout)
        {
            Thread threadToKill = null;

            Func<IAsyncResult> wrappedFunc = () =>
                {
                    threadToKill = Thread.CurrentThread;
                    return beginInvoke(null, null);
                };

            var asyncResult = wrappedFunc.BeginInvoke(null, null);
#if PocketPC
            if (!asyncResult.AsyncWaitHandle.WaitOne((int)timeout.TotalMilliseconds, false))
#else
            if (!asyncResult.AsyncWaitHandle.WaitOne(timeout))
#endif
            {
                threadToKill.Abort();
                throw new TimeoutException();
            }

            return endInvoke(asyncResult);
        }
    }
}
