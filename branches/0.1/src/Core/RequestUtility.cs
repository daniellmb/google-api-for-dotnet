/**
 * RequestUtility.cs
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
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Google.API
{
    internal class RequestUtility
    {
        private static readonly Encoding s_Encoding = Encoding.UTF8;

        public static T GetResponseData<T>(WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            string resultString;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), s_Encoding))
                    {
                        resultString = reader.ReadToEnd();
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

            ResultObject<T> resultObject;
            try
            {
                resultObject = JavaScriptConvert.DeserializeObject<ResultObject<T>>(resultString);
            }
            catch (Exception ex)
            {
                throw new DeserializeException(typeof(ResultObject<T>), resultString, ex);
            }

            if (resultObject.ResponseStatus != ResponseStatusConstant.DefaultStatus)
            {
                throw new GoogleServiceException(resultObject.ResponseStatus, resultObject.ResponseDetails);
            }
            return resultObject.ResponseData;
        }

        public static T GetResponseData<T>(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            WebRequest request = WebRequest.Create(url);
            return GetResponseData<T>(request);
        }

        public static T GetResponseData<T>(RequestBase request, int timeout)
        {
            WebRequest webRequest;
            if (timeout != 0)
            {
                webRequest = request.GetWebRequest(timeout);
            }
            else
            {
                webRequest = request.GetWebRequest();
            }

            T responseData;
            try
            {
                responseData = GetResponseData<T>(webRequest);
            }
            catch (DeserializeException ex)
            {
                throw new GoogleAPIException(string.Format("request:\"{0}\"", request), ex);
            }
            return responseData;
        }
    }
}
