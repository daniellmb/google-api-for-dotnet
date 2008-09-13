/**
 * SearchUtility.cs
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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Google.API.Search
{
    internal static class SearchUtility
    {
        public delegate ISearchData<T> GSearchCallback<T>(int start, ResultSize resultSize);

        public static List<T> Search<T>(GSearchCallback<T> gsearch, int resultCount)
        {
            int start = 0;
            List<T> results = new List<T>();
            int restCount = resultCount;
            while (restCount > 0)
            {
                ISearchData<T> searchData;
                try
                {
                    if (restCount > 4)
                    {
                        searchData = gsearch(start, ResultSize.large);
                    }
                    else
                    {
                        searchData = gsearch(start, ResultSize.small);
                    }
                }
                catch (GoogleAPIException ex)
                {
                    if (ex.InnerException == null)
                        return results;

                    throw;
                }

                int count = searchData.Results.Length;
                if (count == 0)
                {
                    break;
                }
                if (count <= restCount)
                {
                    results.AddRange(searchData.Results);
                }
                else
                {
                    count = restCount;
                    for (int i = 0; i < count; ++i)
                    {
                        results.Add(searchData.Results[i]);
                    }
                }
                start += count;
                restCount -= count;
            }

            return results;
        }

        public static DateTime RFC2822DateTimeParse(string str)
        {
            string tmp;
            string[] resp;
            string dayName;
            string dpart;
            string hour, minute;
            string timeZone;
            DateTime dt;
            //--- strip comments
            //--- XXX : FIXME : how to handle nested comments ?
            tmp = Regex.Replace(str, "(\\([^(].*\\))", "");

            // strip extra white spaces
            tmp = Regex.Replace(tmp, "\\s+", " ");
            tmp = Regex.Replace(tmp, "^\\s+", "");
            tmp = Regex.Replace(tmp, "\\s+$", "");

            // extract week name part
            resp = tmp.Split(new char[] { ',' }, 2);
            if (resp.Length == 2)
            {
                // there's week name
                dayName = resp[0];
                tmp = resp[1];
            }
            else dayName = "";

            try
            {
                // extract date and time
                int pos = tmp.LastIndexOf(" ");
                if (pos < 1) throw new FormatException("probably not a date");
                dpart = tmp.Substring(0, pos - 1);
                timeZone = tmp.Substring(pos + 1);
                dt = Convert.ToDateTime(dpart);

                // check weekDay name
                // this must be done befor convert to GMT 
                if (dayName != string.Empty)
                {
                    if ((dt.DayOfWeek == DayOfWeek.Friday && dayName != "Fri") ||
                        (dt.DayOfWeek == DayOfWeek.Monday && dayName != "Mon") ||
                        (dt.DayOfWeek == DayOfWeek.Saturday && dayName != "Sat") ||
                        (dt.DayOfWeek == DayOfWeek.Sunday && dayName != "Sun") ||
                        (dt.DayOfWeek == DayOfWeek.Thursday && dayName != "Thu") ||
                        (dt.DayOfWeek == DayOfWeek.Tuesday && dayName != "Tue") ||
                        (dt.DayOfWeek == DayOfWeek.Wednesday && dayName != "Wed")
                        )
                        throw new FormatException("invalide week of day");
                }

                // adjust to localtime
                if (Regex.IsMatch(timeZone, "[+\\-][0-9][0-9][0-9][0-9]"))
                {
                    // it's a modern ANSI style timezone
                    int factor = 0;
                    hour = timeZone.Substring(1, 2);
                    minute = timeZone.Substring(3, 2);
                    if (timeZone.Substring(0, 1) == "+") factor = 1;
                    else if (timeZone.Substring(0, 1) == "-") factor = -1;
                    else throw new FormatException("incorrect tiem zone");
                    dt = dt.AddHours(factor * Convert.ToInt32(hour));
                    dt = dt.AddMinutes(factor * Convert.ToInt32(minute));
                }
                else
                {
                    // it's a old style military time zone ?
                    switch (timeZone)
                    {
                        case "A": dt = dt.AddHours(1); break;
                        case "B": dt = dt.AddHours(2); break;
                        case "C": dt = dt.AddHours(3); break;
                        case "D": dt = dt.AddHours(4); break;
                        case "E": dt = dt.AddHours(5); break;
                        case "F": dt = dt.AddHours(6); break;
                        case "G": dt = dt.AddHours(7); break;
                        case "H": dt = dt.AddHours(8); break;
                        case "I": dt = dt.AddHours(9); break;
                        case "K": dt = dt.AddHours(10); break;
                        case "L": dt = dt.AddHours(11); break;
                        case "M": dt = dt.AddHours(12); break;
                        case "N": dt = dt.AddHours(-1); break;
                        case "O": dt = dt.AddHours(-2); break;
                        case "P": dt = dt.AddHours(-3); break;
                        case "Q": dt = dt.AddHours(-4); break;
                        case "R": dt = dt.AddHours(-5); break;
                        case "S": dt = dt.AddHours(-6); break;
                        case "T": dt = dt.AddHours(-7); break;
                        case "U": dt = dt.AddHours(-8); break;
                        case "V": dt = dt.AddHours(-9); break;
                        case "W": dt = dt.AddHours(-10); break;
                        case "X": dt = dt.AddHours(-11); break;
                        case "Y": dt = dt.AddHours(-12); break;
                        case "Z":
                        case "UT":
                        case "GMT": break;    // It's UTC
                        case "EST": dt = dt.AddHours(5); break;
                        case "EDT": dt = dt.AddHours(4); break;
                        case "CST": dt = dt.AddHours(6); break;
                        case "CDT": dt = dt.AddHours(5); break;
                        case "MST": dt = dt.AddHours(7); break;
                        case "MDT": dt = dt.AddHours(6); break;
                        case "PST": dt = dt.AddHours(8); break;
                        case "PDT": dt = dt.AddHours(7); break;
                        default: throw new FormatException("invalide time zone");
                    }
                }
            }
            catch (Exception e)
            {
                throw new FormatException(string.Format("Invalide date:{0}:{1}", e.Message, str));
            }
            return dt;
        }
    }
}
