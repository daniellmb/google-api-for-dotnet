//-----------------------------------------------------------------------
// <copyright file="GlocalResult.cs" company="iron9light">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using Converters;

    using Newtonsoft.Json;

    [JsonObject]
    internal class GlocalResult : ILocalResult
    {
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "Reviewed. Suppression is OK here.")]
        private static readonly int tbWidth = 150;

        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "Reviewed. Suppression is OK here.")]
        private static readonly int tbHeight = 100;

        /// <summary>
        /// Indicates the "type" of result.
        /// </summary>
        [JsonProperty("GsearchResultClass")]
        public string GSearchResultClass { get; internal set; }

        [JsonProperty("viewportmode")]
        public string ViewportMode { get; internal set; }

        /// <summary>
        /// Supplies the title for the result. In some cases, the title and the streetAddress are the same. This typically occurs when the search term is a street address such as 1231 Lisa Lane, Los Altos, CA. 
        /// </summary>
        [JsonProperty("title")]
        public string TitleWithFormatting { get; internal set; }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., &lt;b&gt;, &lt;i&gt;, etc.) 
        /// </summary>
        [JsonProperty("titleNoFormatting")]
        public string Title { get; internal set; }

        /// <summary>
        /// Supplies a url to a Google Maps Details page associated with the search result 
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        /// Supplies the latitude value of the result.
        /// </summary>
        [JsonProperty("lat")]
        public float Latitude { get; internal set; }

        /// <summary>
        /// Supplies the longitude value of the result.
        /// </summary>
        [JsonProperty("lng")]
        public float Longitude { get; internal set; }

        [JsonProperty("accuracy")]
        public int Accuracy { get; internal set; }

        /// <summary>
        /// Supplies the street address and number for the given result. Note:, in some cases, this property may be set to "" if the result has no known street address. address line. 
        /// </summary>
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; internal set; }

        /// <summary>
        /// Supplies the city name for the result. Note:, in some cases, this property may be set to "". 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; internal set; }

        /// <summary>
        /// Supplies a region name for the result (e.g., in the us, this is typically a state abbreviation, in other regions it might be a province, etc.) Note:, in some cases, this property may be set to "". 
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; internal set; }

        /// <summary>
        /// Supplies a country name for the result. Note:, in some cases, this property may be set to "". 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; internal set; }

        /// <summary>
        /// Supplies an array of phone number objects
        /// </summary>
        [JsonProperty("phoneNumbers")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public IPhoneNumber[] PhoneNumbers { get; internal set; }

        /// <summary>
        /// Supplies an array consisting of the mailing address lines for this result
        /// </summary>
        [JsonProperty("addressLines")]
        public string[] AddressLines { get; internal set; }

        /// <summary>
        /// Supplies a url that can be used to provide driving directions from the center of the set of search results to this search result. Note, in some cases this property may be missing or null.
        /// </summary>
        [JsonProperty("ddUrl")]
        public string DirectionUrl { get; internal set; }

        /// <summary>
        /// Supplies a url that can be used to provide driving directions from a user specified location to this search result. Note, in some cases this property may be missing or null.
        /// </summary>
        [JsonProperty("ddUrlToHere")]
        public string ToHereDirectionUrl { get; internal set; }

        /// <summary>
        /// Supplies a url that can be used to provide driving directions from this search result to a user specified location. Note, in some cases this property may be missing or null.
        /// </summary>
        [JsonProperty("ddUrlFromHere")]
        public string FromHereDirectionUrl { get; internal set; }

        /// <summary>
        /// Supplies a url to a static map image representation of the current result. The image is 150px wide by 100px tall with a single marker representing the current location. Expected usage is to hyperlink this image using the url property.
        /// </summary>
        [JsonProperty("staticMapUrl")]
        public string StaticMapUrl { get; internal set; }

        /// <summary>
        /// This property indicates the type of this result which can either be "local" in the case of a local business listing or geocode result, or "kml" in the case of a KML listing. 
        /// </summary>
        [JsonProperty("listingType")]
        public string ListingType { get; internal set; }

        /// <summary>
        /// For "kml" results, this property contains a content snippet associated with the KML result. For "local" results, this property is the empty string.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; internal set; }

        [JsonProperty("maxAge")]
        public int MaxAge { get; internal set; }

        [JsonProperty("addressLookupResult")]
        public string AddressLookupResult { get; internal set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; internal set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Title);
            if (!string.IsNullOrEmpty(this.StreetAddress))
            {
                sb.AppendLine();
                sb.Append(this.StreetAddress);
            }

            if (!string.IsNullOrEmpty(this.City))
            {
                sb.AppendLine();
                sb.Append(this.City);
                if (!string.IsNullOrEmpty(this.Region))
                {
                    sb.Append(", " + this.Region);
                    ////if (!string.IsNullOrEmpty(this.PostalCode))
                    ////{
                    ////    sb.Append(" " + this.PostalCode);
                    ////}
                }
            }
            else if (!string.IsNullOrEmpty(this.Region))
            {
                sb.AppendLine();
                sb.Append(this.Region);
                ////if (!string.IsNullOrEmpty(this.PostalCode))
                ////{
                ////    sb.Append(" " + this.PostalCode);
                ////}
            }

            if (this.PhoneNumbers != null)
            {
                foreach (var phoneNumber in this.PhoneNumbers)
                {
                    sb.AppendLine();
                    sb.Append(phoneNumber);
                }
            }

            return sb.ToString();
        }

        #region ILocalResult Members

        ITbImage ILocalResult.StaticMap
        {
            get
            {
                return new TbImage(this.StaticMapUrl, tbWidth, tbHeight);
            }
        }

        #endregion

        internal class PhoneNumberConverter : CustomArrayCreationConverter<IPhoneNumber, PhoneNumber>
        {
        }
    }
}