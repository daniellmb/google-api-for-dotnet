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
using System.Globalization;
using System.IO;
using System.Text;
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

        #region System.Web.HttpUtility

        // The code under this region is provided by Microsoft .NET reference source project.
        // http://referencesource.microsoft.com/

        /// <summary>
        /// Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.
        /// </summary>
        /// <param name="s">The string to decode.</param>
        /// <returns>A decoded string.</returns>
        //public static string HtmlDecode(string s)
        //{
        //    return System.Web.HttpUtility.HtmlDecode(s);
        //}
        public static string HtmlDecode(string s)
        {
            if (s == null)
                return null;

            // See if this string needs to be decoded at all.  If no 
            // ampersands are found, then no special HTML-encoded chars
            // are in the string.
            if (s.IndexOf('&') < 0)
                return s;

            StringBuilder builder = new StringBuilder();
            StringWriter writer = new StringWriter(builder);

            HtmlDecode(s, writer);

            return builder.ToString();
        }

        private static char[] s_entityEndingChars = new char[] { ';', '&' };

        public static void HtmlDecode(string s, TextWriter output)
        {
            if (s == null)
                return;

            if (s.IndexOf('&') < 0)
            {
                output.Write(s);        // good as is
                return;
            }

            int l = s.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = s[i];

                if (ch == '&')
                {
                    // We found a '&'. Now look for the next ';' or '&'. The idea is that
                    // if we find another '&' before finding a ';', then this is not an entity, 
                    // and the next '&' might start a real entity (
                    int index = s.IndexOfAny(s_entityEndingChars, i + 1);
                    if (index > 0 && s[index] == ';')
                    {
                        string entity = s.Substring(i + 1, index - i - 1);

                        if (entity.Length > 1 && entity[0] == '#')
                        {
                            try
                            {
                                // The # syntax can be in decimal or hex, e.g.
                                //      &#229;  --> decimal 
                                //      &#xE5;  --> same char in hex
                                // See http://www.w3.org/TR/REC-html40/charset.html#entities
                                if (entity[1] == 'x' || entity[1] == 'X')
                                    ch = (char)Int32.Parse(entity.Substring(2), NumberStyles.AllowHexSpecifier);
                                else
                                    ch = (char)Int32.Parse(entity.Substring(1));
                                i = index; // already looked at everything until semicolon 
                            }
                            catch (System.FormatException)
                            {
                                i++;    //if the number isn't valid, ignore it
                            }
                            catch (System.ArgumentException)
                            {
                                i++;    // if there is no number, ignore it. 
                            }
                        }
                        else
                        {
                            i = index; // already looked at everything until semicolon

                            char entityChar = HtmlEntities.Lookup(entity);
                            if (entityChar != (char)0)
                            {
                                ch = entityChar;
                            }
                            else
                            {
                                output.Write('&');
                                output.Write(entity);
                                output.Write(';');
                                continue;
                            }
                        }

                    }
                }

                output.Write(ch);
            }
        }

        #endregion

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
