/**
 * GlocalResult.cs
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

using System.Text;
using Newtonsoft.Json;

namespace Google.API.Search
{
    [JsonObject]
    internal class GlocalResult : ILocalResult
    {
        private static readonly int s_TbWidth = 150;
        private static readonly int s_TbHeight = 100;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; private set; }

        [JsonProperty("viewportmode")]
        public string ViewportMode { get; private set; }

        /// <summary>
        /// Supplies the title for the result. In some cases, the title and the streetAddress are the same. This typically occurs when the search term is a street address such as 1231 Lisa Lane, Los Altos, CA. 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.) 
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting { get; private set; }

        /// <summary>
        /// Supplies a url to a Google Maps Details page associated with the search result 
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; private set; }

        /// <summary>
        /// Supplies the latitude value of the result.
        /// </summary>
        [JsonProperty("lat")]
        public float Latitude { get; private set; }

        /// <summary>
        /// Supplies the longitude value of the result.
        /// </summary>
        [JsonProperty("lng")]
        public float Longitude { get; private set; }

        /// <summary>
        /// Supplies the street address and number for the given result. Note:, in some cases, this property may be set to "" if the result has no known street address. address line. 
        /// </summary>
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; private set; }

        /// <summary>
        /// Supplies the city name for the result. Note:, in some cases, this property may be set to "". 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        /// Supplies a region name for the result (e.g., in the us, this is typically a state abbreviation, in other regions it might be a province, etc.) Note:, in some cases, this property may be set to "". 
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; private set; }

        /// <summary>
        /// Supplies a country name for the result. Note:, in some cases, this property may be set to "". 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>
        /// Supplies an array of phone number objects
        /// </summary>
        [JsonProperty("phoneNumbers")]
        public PhoneNumber[] PhoneNumbers { get; private set; }

        /// <summary>
        /// Supplies a url that can be used to provide driving directions from the center of the set of search results to this search result. Note, in some cases this property may be missing or null.
        /// </summary>
        [JsonProperty("ddUrl")]
        public string DirectionUrl { get; private set; }

        /// <summary>
        /// Supplies a url that can be used to provide driving directions from a user specified location to this search result. Note, in some cases this property may be missing or null.
        /// </summary>
        [JsonProperty("ddUrlToHere")]
        public string ToHereDirectionUrl { get; private set; }

        /// <summary>
        /// Supplies a url that can be used to provide driving directions from this search result to a user specified location. Note, in some cases this property may be missing or null.
        /// </summary>
        [JsonProperty("ddUrlFromHere")]
        public string FromHereDirectionUrl { get; private set; }

        /// <summary>
        /// Supplies a url to a static map image representation of the current result. The image is 150px wide by 100px tall with a single marker representing the current location. Expected usage is to hyperlink this image using the url property.
        /// </summary>
        [JsonProperty("staticMapUrl")]
        public string StaticMapUrl { get; private set; }

        /// <summary>
        /// This property indicates the type of this result which can either be "local" in the case of a local business listing or geocode result, or "kml" in the case of a KML listing. 
        /// </summary>
        [JsonProperty("listingType")]
        public string ListingType { get; private set; }

        /// <summary>
        /// For "kml" results, this property contains a content snippet associated with the KML result. For "local" results, this property is the empty string.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; private set; }

        [JsonProperty("addressLookupResult")]
        public string AddressLookupResult { get; private set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; private set; }

        [JsonProperty("addressLines")]
        public string[] AddressLines { get; private set; }

        public override string ToString()
        {
            ILocalResult result = this;
            var sb = new StringBuilder();
            sb.Append(result.Title);
            if (!string.IsNullOrEmpty(result.StreetAddress))
            {
                sb.AppendLine();
                sb.Append(result.StreetAddress);
            }
            if (!string.IsNullOrEmpty(result.City))
            {
                sb.AppendLine();
                sb.Append(result.City);
                if (!string.IsNullOrEmpty(result.Region))
                {
                    sb.Append(", " + result.Region);
                    if (!string.IsNullOrEmpty(result.PostalCode))
                        sb.Append(" " + result.PostalCode);
                }
            }
            else if (!string.IsNullOrEmpty(result.Region))
            {
                sb.AppendLine();
                sb.Append(result.Region);
                if (!string.IsNullOrEmpty(result.PostalCode))
                    sb.Append(" " + result.PostalCode);
            }
            if (PhoneNumbers != null)
            {
                foreach (var phoneNumber in result.PhoneNumbers)
                {
                    sb.AppendLine();
                    sb.Append(phoneNumber);
                }
            }
            return sb.ToString();
        }

        #region ILocalResult Members

        string ILocalResult.Title
        {
            get { return TitleNoFormatting; }
        }

        string ILocalResult.Url
        {
            get { return Url; }
        }

        float ILocalResult.Latitude
        {
            get { return Latitude; }
        }

        float ILocalResult.Longitude
        {
            get { return Longitude; }
        }

        string ILocalResult.StreetAddress
        {
            get { return StreetAddress; }
        }

        string ILocalResult.City
        {
            get { return City; }
        }

        string ILocalResult.Region
        {
            get { return Region; }
        }

        string ILocalResult.Country
        {
            get { return Country; }
        }

        IPhoneNumber[] ILocalResult.PhoneNumbers
        {
            get { return PhoneNumbers; }
        }

        string ILocalResult.DirectionUrl
        {
            get { return DirectionUrl; }
        }

        string ILocalResult.ToHereDirectionUrl
        {
            get { return ToHereDirectionUrl; }
        }

        string ILocalResult.FromHereDirectionUrl
        {
            get { return FromHereDirectionUrl; }
        }

        ITbImage ILocalResult.StaticMap
        {
            get { return new TbImage(StaticMapUrl, s_TbWidth, s_TbHeight); }
        }

        string ILocalResult.ListingType
        {
            get { return ListingType; }
        }

        string ILocalResult.Content
        {
            get { return Content; }
        }

        string ILocalResult.PostalCode
        {
            get { return PostalCode; }
        }

        #endregion
    }
}
