/**
 * ILocalResult.cs
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

namespace Google.API.Search
{
    /// <summary>
    /// Local search result.
    /// </summary>
    public interface ILocalResult
    {
        /// <summary>
        /// Get the title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Get the the URL of the result.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Get the latitude value of the result.
        /// </summary>
        float Latitude { get; }

        /// <summary>
        /// Get the longitude value of the result.
        /// </summary>
        float Longitude { get; }

        /// <summary>
        /// Get the street address and number for the given result.
        /// </summary>
        string StreetAddress { get; }

        /// <summary>
        /// Get the city name for the result.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Get the region name for the result (e.g., in the us, this is typically a state abbreviation, in other regions it might be a province, etc.).
        /// </summary>
        string Region { get; }

        /// <summary>
        /// Get the country name for the result.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Get an array of phone numbers.
        /// </summary>
        IPhoneNumber[] PhoneNumbers { get; }

        /// <summary>
        /// Get a url that can be used to provide driving directions from the center of the set of search results to this search result.
        /// </summary>
        string DirectionUrl { get; }

        /// <summary>
        /// Get a url that can be used to provide driving directions from a user specified location to this search result.
        /// </summary>
        string ToHereDirectionUrl { get; }

        /// <summary>
        /// Get a url that can be used to provide driving directions from this search result to a user specified location.
        /// </summary>
        string FromHereDirectionUrl { get; }

        /// <summary>
        /// Get a static map image representation of the current result.
        /// </summary>
        ITbImage StaticMap { get; }

        /// <summary>
        /// Get the type of this result which can either be "local" in the case of a local business listing or geocode result, or "kml" in the case of a KML listing.
        /// </summary>
        string ListingType { get; }

        /// <summary>
        /// For "kml" results, this property contains a content snippet associated with the KML result. For "local" results, this property is the empty string.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Get a postal code of this result.
        /// </summary>
        string PostalCode { get; }
    }
}