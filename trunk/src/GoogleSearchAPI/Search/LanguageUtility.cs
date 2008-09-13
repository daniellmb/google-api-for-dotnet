/**
 * LanguageUtility.cs
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

using System.Collections.Generic;

namespace Google.API.Search
{
    /// <summary>
    /// Utility class for language and language codes.
    /// </summary>
    public static class LanguageUtility
    {
        private static readonly IDictionary<Language, string> s_LanguageCodeDict;

        static LanguageUtility()
        {
            s_LanguageCodeDict = new Dictionary<Language, string>();
            s_LanguageCodeDict[Language.Arabic] = "lang_ar";
            s_LanguageCodeDict[Language.Bulgarian] = "lang_bg";
            s_LanguageCodeDict[Language.Catalan] = "lang_ca";
            s_LanguageCodeDict[Language.ChineseSimplified] = "lang_zh-CN";
            s_LanguageCodeDict[Language.ChineseTraditional] = "lang_zh-TW";
            s_LanguageCodeDict[Language.Croatian] = "lang_hr";
            s_LanguageCodeDict[Language.Czech] = "lang_cs";
            s_LanguageCodeDict[Language.Danish] = "lang_da";
            s_LanguageCodeDict[Language.Dutch] = "lang_nl";
            s_LanguageCodeDict[Language.English] = "lang_en";
            s_LanguageCodeDict[Language.Estonian] = "lang_et";
            s_LanguageCodeDict[Language.Finnish] = "lang_fi";
            s_LanguageCodeDict[Language.French] = "lang_fr";
            s_LanguageCodeDict[Language.German] = "lang_de";
            s_LanguageCodeDict[Language.Greek] = "lang_el";
            s_LanguageCodeDict[Language.Hebrew] = "lang_iw";
            s_LanguageCodeDict[Language.Hungarian] = "lang_hu";
            s_LanguageCodeDict[Language.Icelandic] = "lang_is";
            s_LanguageCodeDict[Language.Indonesian] = "lang_id";
            s_LanguageCodeDict[Language.Italian] = "lang_it";
            s_LanguageCodeDict[Language.Japanese] = "lang_ja";
            s_LanguageCodeDict[Language.Korean] = "lang_ko";
            s_LanguageCodeDict[Language.Latvian] = "lang_lv";
            s_LanguageCodeDict[Language.Lithuanian] = "lang_lt";
            s_LanguageCodeDict[Language.Norwegian] = "lang_no";
            s_LanguageCodeDict[Language.Polish] = "lang_pl";
            s_LanguageCodeDict[Language.Portuguese] = "lang_pt";
            s_LanguageCodeDict[Language.Romanian] = "lang_ro";
            s_LanguageCodeDict[Language.Russian] = "lang_ru";
            s_LanguageCodeDict[Language.Serbian] = "lang_sr";
            s_LanguageCodeDict[Language.Slovak] = "lang_sk";
            s_LanguageCodeDict[Language.Slovenian] = "lang_sl";
            s_LanguageCodeDict[Language.Spanish] = "lang_es";
            s_LanguageCodeDict[Language.Swedish] = "lang_sv";
            s_LanguageCodeDict[Language.Turkish] = "lang_tr";
        }

        /// <summary>
        /// Get supported language collection.
        /// </summary>
        public static ICollection<Language> LanguageCollection
        {
            get
            {
                return s_LanguageCodeDict.Keys;
            }
        }

        /// <summary>
        /// Get language code dictionary.
        /// </summary>
        internal static IDictionary<Language, string> LanguageCodeDict
        {
            get
            {
                return s_LanguageCodeDict;
            }
        }

        /// <summary>
        /// Whether this language is supported.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>Return true if the language is supported.</returns>
        public static bool IsSupported(Language language)
        {
            return LanguageCollection.Contains(language);
        }

        /// <summary>
        /// Get the language code of a language.
        /// </summary>
        /// <param name="language">The language</param>
        /// <returns>The language code of this language or null for unsupported language.</returns>
        internal static string GetLanguageCode(Language language)
        {
            if(!IsSupported(language))
            {
                return null;
            }
            string code = LanguageCodeDict[language];
            return code;
        }
    }
}
