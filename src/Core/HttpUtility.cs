/**
 * HttpUtility.cs
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
using System.Text.RegularExpressions;

namespace Google.API
{
    /// <summary>
    /// Provides methods for encoding and decoding URLs when processing Web requests. This class cannot be inherited.
    /// </summary>
    internal static class HttpUtility
    {
        private static readonly string s_HtmlTagPattern = "<[^>]*>";
        static readonly Regex s_HtmlTagRegex = new Regex(s_HtmlTagPattern, RegexOptions.Compiled);

        /// <summary>
        /// Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.
        /// </summary>
        /// <param name="s">The string to decode.</param>
        /// <returns>A decoded string.</returns>
        public static string HtmlDecode(string s)
        {
            return System.Web.HttpUtility.HtmlDecode(s);
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The text to encode.</param>
        /// <returns>An encoded string.</returns>
        public static string UrlEncode(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// Capture the text content from a html formatted string.
        /// </summary>
        /// <param name="s">The html formatted string.</param>
        /// <returns>The plane text.</returns>
        public static string RemoveHtmlTags(string s)
        {
            if(s == null)
            {
                throw new ArgumentNullException("s");
            }
            string tagRemovedS = s_HtmlTagRegex.Replace(s, string.Empty);
            string text = HtmlDecode(tagRemovedS);
            return text;
        }
    }
}
