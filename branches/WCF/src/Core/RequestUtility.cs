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
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace Google.API
{
    internal delegate T RequestCallback<T, TService>(TService service) where TService : class;

    internal class RequestUtility
    {
        private static Binding binding;

        public static Binding Binding
        {
            get
            {
                if (binding == null)
                {
                    var customBinding = new CustomBinding();
                    var webMessageEncodingBindingElement = new WebMessageEncodingBindingElement() { ContentTypeMapper = new MyWebContentTypeMapper() };
                    var httpTransportBindingElement = new HttpTransportBindingElement() { ManualAddressing = true };
                    customBinding.Elements.Add(webMessageEncodingBindingElement);
                    customBinding.Elements.Add(httpTransportBindingElement);
                    binding = customBinding;
                }
                return binding;
            }
        }

        public static T GetResponseData<T, TService>(
            RequestCallback<ResultObject<T>, TService> request,
            string address
            ) where TService : class
        {
            return GetResponseData(request, new Uri(address));
        }

        public static T GetResponseData<T, TService>(
            RequestCallback<ResultObject<T>, TService> request,
            Uri address
            ) where TService : class
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (address == null)
                throw new ArgumentNullException("address");

            ResultObject<T> resultObject;
            try
            {
                resultObject = GetResultObject(request, address, Binding);
            }
            catch (Exception ex)
            {
                throw new GoogleAPIException("Failed to get response.", ex);
            }

            if (resultObject.ResponseStatus != ResponseStatusConstant.DefaultStatus)
                throw new GoogleServiceException(resultObject.ResponseStatus, resultObject.ResponseDetails);

            return resultObject.ResponseData;
        }

        private static T GetResultObject<TService, T>(
            RequestCallback<T, TService> request,
            Uri address,
            Binding binding
            ) where TService : class
        {
            var channelFactory = new WebChannelFactory<TService>(binding, address);
            var client = channelFactory.CreateChannel();
            using (client as IDisposable)
            {
                var resultObject = request(client);
                return resultObject;
            }
        }
    }
}
