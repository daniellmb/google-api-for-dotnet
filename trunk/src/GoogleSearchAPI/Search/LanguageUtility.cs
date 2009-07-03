//-----------------------------------------------------------------------
// <copyright file="LanguageUtility.cs" company="iron9light">
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
    using System.Collections.Generic;

    /// <summary>
    /// Utility class for language and language codes.
    /// </summary>
    public static class LanguageUtility
    {
        private static readonly IDictionary<Language, string> languageCodeDict;

        static LanguageUtility()
        {
            languageCodeDict = new Dictionary<Language, string>();
            languageCodeDict[Language.Arabic] = "lang_ar";
            languageCodeDict[Language.Bulgarian] = "lang_bg";
            languageCodeDict[Language.Catalan] = "lang_ca";
            languageCodeDict[Language.ChineseSimplified] = "lang_zh-CN";
            languageCodeDict[Language.ChineseTraditional] = "lang_zh-TW";
            languageCodeDict[Language.Croatian] = "lang_hr";
            languageCodeDict[Language.Czech] = "lang_cs";
            languageCodeDict[Language.Danish] = "lang_da";
            languageCodeDict[Language.Dutch] = "lang_nl";
            languageCodeDict[Language.English] = "lang_en";
            languageCodeDict[Language.Estonian] = "lang_et";
            languageCodeDict[Language.Finnish] = "lang_fi";
            languageCodeDict[Language.French] = "lang_fr";
            languageCodeDict[Language.German] = "lang_de";
            languageCodeDict[Language.Greek] = "lang_el";
            languageCodeDict[Language.Hebrew] = "lang_iw";
            languageCodeDict[Language.Hungarian] = "lang_hu";
            languageCodeDict[Language.Icelandic] = "lang_is";
            languageCodeDict[Language.Indonesian] = "lang_id";
            languageCodeDict[Language.Italian] = "lang_it";
            languageCodeDict[Language.Japanese] = "lang_ja";
            languageCodeDict[Language.Korean] = "lang_ko";
            languageCodeDict[Language.Latvian] = "lang_lv";
            languageCodeDict[Language.Lithuanian] = "lang_lt";
            languageCodeDict[Language.Norwegian] = "lang_no";
            languageCodeDict[Language.Polish] = "lang_pl";
            languageCodeDict[Language.Portuguese] = "lang_pt";
            languageCodeDict[Language.Romanian] = "lang_ro";
            languageCodeDict[Language.Russian] = "lang_ru";
            languageCodeDict[Language.Serbian] = "lang_sr";
            languageCodeDict[Language.Slovak] = "lang_sk";
            languageCodeDict[Language.Slovenian] = "lang_sl";
            languageCodeDict[Language.Spanish] = "lang_es";
            languageCodeDict[Language.Swedish] = "lang_sv";
            languageCodeDict[Language.Turkish] = "lang_tr";
        }

        /// <summary>
        /// Gets supported language collection.
        /// </summary>
        public static ICollection<Language> LanguageCollection
        {
            get
            {
                return languageCodeDict.Keys;
            }
        }

        /// <summary>
        /// Gets language code dictionary.
        /// </summary>
        internal static IDictionary<Language, string> LanguageCodeDict
        {
            get
            {
                return languageCodeDict;
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
            if (!IsSupported(language))
            {
                return null;
            }

            var code = LanguageCodeDict[language];
            return code;
        }
    }
}