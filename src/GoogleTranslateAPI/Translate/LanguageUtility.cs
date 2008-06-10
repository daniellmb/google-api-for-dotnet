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

namespace Google.API.Translate
{
    /// <summary>
    /// The enum of languages.
    /// </summary>
    public enum Language
    {
        Unknown = 0,
        Arabic,
        Bulgarian,
        Catalan,
        Chinese,
        Chinese_Simplified,
        Chinese_Traditional,
        Croatian,
        Czech,
        Danish,
        Dutch,
        English,
        Estonian,
        Filipino,
        Finnish,
        French,
        German,
        Greek,
        Hebrew,
        Hindi,
        Hungarian,
        Indonesian,
        Italian,
        Japanese,
        Korean,
        Latvian,
        Lithuanian,
        Norwegian,
        Persian,
        Polish,
        Portuguese,
        Romanian,
        Russian,
        Serbian,
        Slovak,
        Slovenian,
        Spanish,
        Swedish,
        Thai,
        Turkish,
        Ukranian, 
        Vietnamese
    }

    /// <summary>
    /// Utility class for language and language codes.
    /// </summary>
    public static class LanguageUtility
    {
        private static readonly IDictionary<Language, string> s_LanguageCodeDict;

        private static readonly IList<Language> s_TranslatableList;

        static LanguageUtility()
        {
            s_LanguageCodeDict = new Dictionary<Language, string>();
            s_LanguageCodeDict[Language.Unknown] = "";
            s_LanguageCodeDict[Language.Arabic] = "ar";
            s_LanguageCodeDict[Language.Bulgarian] = "bg";
            s_LanguageCodeDict[Language.Catalan] = "ca";
            s_LanguageCodeDict[Language.Chinese] = "zh";
            s_LanguageCodeDict[Language.Chinese_Simplified] = "zh-CN";
            s_LanguageCodeDict[Language.Chinese_Traditional] = "zh-TW";
            s_LanguageCodeDict[Language.Croatian] = "hr";
            s_LanguageCodeDict[Language.Czech] = "cs";
            s_LanguageCodeDict[Language.Danish] = "da";
            s_LanguageCodeDict[Language.Dutch] = "nl";
            s_LanguageCodeDict[Language.English] = "en";
            s_LanguageCodeDict[Language.Estonian] = "et";
            s_LanguageCodeDict[Language.Filipino] = "tl";
            s_LanguageCodeDict[Language.Finnish] = "fi";
            s_LanguageCodeDict[Language.French] = "fr";
            s_LanguageCodeDict[Language.German] = "de";
            s_LanguageCodeDict[Language.Greek] = "el";
            s_LanguageCodeDict[Language.Hebrew] = "iw";
            s_LanguageCodeDict[Language.Hindi] = "hi";
            s_LanguageCodeDict[Language.Hungarian] = "hu";
            s_LanguageCodeDict[Language.Indonesian] = "id";
            s_LanguageCodeDict[Language.Italian] = "it";
            s_LanguageCodeDict[Language.Japanese] = "ja";
            s_LanguageCodeDict[Language.Korean] = "ko";
            s_LanguageCodeDict[Language.Latvian] = "lv";
            s_LanguageCodeDict[Language.Lithuanian] = "lt";
            s_LanguageCodeDict[Language.Norwegian] = "no";
            s_LanguageCodeDict[Language.Persian] = "fa";
            s_LanguageCodeDict[Language.Polish] = "pl";
            s_LanguageCodeDict[Language.Portuguese] = "pt-PT";
            s_LanguageCodeDict[Language.Romanian] = "ro";
            s_LanguageCodeDict[Language.Russian] = "ru";
            s_LanguageCodeDict[Language.Serbian] = "sr";
            s_LanguageCodeDict[Language.Slovak] = "sk";
            s_LanguageCodeDict[Language.Slovenian] = "sl";
            s_LanguageCodeDict[Language.Spanish] = "es";
            s_LanguageCodeDict[Language.Swedish] = "sv";
            s_LanguageCodeDict[Language.Thai] = "th";
            s_LanguageCodeDict[Language.Turkish] = "tr";
            s_LanguageCodeDict[Language.Ukranian] = "uk";
            s_LanguageCodeDict[Language.Vietnamese] = "vi";

            s_TranslatableList = new Language[]
                {
                    Language.Arabic,
                    Language.Bulgarian,
                    Language.Chinese_Simplified,
                    Language.Chinese_Traditional,
                    Language.Croatian,
                    Language.Czech,
                    Language.Danish,
                    Language.Dutch,
                    Language.English,
                    Language.Finnish,
                    Language.French,
                    Language.German,
                    Language.Greek,
                    Language.Hindi,
                    Language.Italian,
                    Language.Japanese,
                    Language.Korean,
                    Language.Norwegian,
                    Language.Polish,
                    Language.Portuguese,
                    Language.Romanian,
                    Language.Russian,
                    Language.Spanish,
                    Language.Swedish,
                };
        }

        /// <summary>
        /// Get translatable language collection.
        /// </summary>
        public static ICollection<Language> translatableCollection
        {
            get
            {
                return s_TranslatableList;
            }
        }

        /// <summary>
        /// Get language collection.
        /// </summary>
        public static ICollection<Language> languageCollection
        {
            get
            {
                return LanguageCodeDict.Keys;
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
        /// Whether this language is translatable.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>Return true if the language is translatable.</returns>
        public static bool IsTranslatable(Language language)
        {
            return translatableCollection.Contains(language);
        }

        /// <summary>
        /// Get language from a language code.
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <returns>The language of this code or unknown language if of language match this code.</returns>
        internal static Language GetLanguage(string languageCode)
        {
            languageCode = languageCode.Trim();
            if(string.IsNullOrEmpty(languageCode))
            {
                return Language.Unknown;
            }
            foreach (KeyValuePair<Language, string> pair in LanguageCodeDict)
            {
                if(languageCode == pair.Value)
                {
                    return pair.Key;
                }
            }
            if (string.Compare(languageCode, "zh-Hant", true) == 0)
            {
                return Language.Chinese_Traditional;
            }
            return Language.Unknown;
        }

        /// <summary>
        /// Get the language code of a language.
        /// </summary>
        /// <param name="language">The language</param>
        /// <returns>The language code of this language or code for unknown language.</returns>
        internal static string GetLanguageCode(Language language)
        {
            string code;
            if(!LanguageCodeDict.TryGetValue(language, out code))
            {
                code = LanguageCodeDict[Language.Unknown];
            }
            return code;
        }
    }
}
