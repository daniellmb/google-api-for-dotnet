//-----------------------------------------------------------------------
// <copyright file="ISearchService.cs" company="iron9light">
// Copyright (c) 2009 iron9light
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
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    internal interface ISearchService
    {
        [OperationContract]
        [WebGet(
            UriTemplate =
                "/web?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&cx={customSearchId}&cref={customSearchReference}&safe={safeLevel}&lr={language}&filter={duplicateFilter}",
                ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GwebResult>> WebSearch(
            string acceptLanguage,
            string key,
            string query,
            string resultSize,
            int start,
            string customSearchId,
            string customSearchReference,
            string safeLevel,
            string language,
            string duplicateFilter);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/local?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&sll={local}&sspn={bounding}&mrt={resultType}",
                ResponseFormat = WebMessageFormat.Json)]
        ResultObject<LocalSearchData> LocalSearch(
            string acceptLanguage,
            string key,
            string query,
            string resultSize,
            int start,
            string local,
            string bounding,
            string resultType);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/video?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&scoring={scoring}",
            ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GvideoResult>> VideoSearch(
            string acceptLanguage, string key, string query, string resultSize, int start, string scoring);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/blogs?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&scoring={scoring}",
            ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GblogResult>> BlogSearch(
            string acceptLanguage, string key, string query, string resultSize, int start, string scoring);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/news?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&scoring={scoring}&geo={geo}&qsid={quoteId}&topic={topic}&edition={edition}",
                ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GnewsResult>> NewsSearch(
            string acceptLanguage,
            string key,
            string query,
            string resultSize,
            int start,
            string scoring,
            string geo,
            string quoteId,
            string topic,
            string edition);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/books?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&as_brr={fullViewOnly}&as_list={library}",
                ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GbookResult>> BookSearch(
            string acceptLanguage,
            string key,
            string query,
            string resultSize,
            int start,
            string fullViewOnly,
            string library);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/images?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&safe={safeLevel}&imgsz={imageSize}&imgc={colorization}&imgcolor={color}&imgtype={imageType}&as_filetype={fileType}&as_sitesearch={site}",
                ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GimageResult>> ImageSearch(
            string acceptLanguage,
            string key,
            string query,
            string resultSize,
            int start,
            string safeLevel,
            string imageSize,
            string colorization,
            string color,
            string imageType,
            string fileType,
            string site);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/patent?v=1.0&hl={acceptLanguage}&key={key}&q={query}&rsz={resultSize}&start={start}&as_psrg={issuedOnly}&as_psra={filedOnly}&scoring={scoring}",
                ResponseFormat = WebMessageFormat.Json)]
        ResultObject<SearchData<GpatentResult>> PatentSearch(
            string acceptLanguage,
            string key,
            string query,
            string resultSize,
            int start,
            string issuedOnly,
            string filedOnly,
            string scoring);
    }
}