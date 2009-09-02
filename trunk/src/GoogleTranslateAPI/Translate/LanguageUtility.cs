//////-----------------------------------------------------------------------
////// <copyright file="LanguageUtility.cs" company="iron9light">
////// Copyright (c) 2009 iron9light
//////
////// Permission is hereby granted, free of charge, to any person obtaining a copy
////// of this software and associated documentation files (the "Software"), to deal
////// in the Software without restriction, including without limitation the rights
////// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////// copies of the Software, and to permit persons to whom the Software is
////// furnished to do so, subject to the following conditions:
//////
////// The above copyright notice and this permission notice shall be included in
////// all copies or substantial portions of the Software.
//////
////// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////// THE SOFTWARE.
////// </copyright>
////// <author>iron9light@gmail.com</author>
//////-----------------------------------------------------------------------

////namespace Google.API.Translate
////{
////    using System.Collections.Generic;

////    /// <summary>
////    /// Utility class for language and language codes.
////    /// </summary>
////    public static class LanguageUtility
////    {
////        private static readonly IDictionary<Language, string> languageCodeDict;

////        private static readonly IList<Language> translatableList;

////        static LanguageUtility()
////        {
////            languageCodeDict = new Dictionary<Language, string>();
////            languageCodeDict[Language.Unknown] = string.Empty;
////            languageCodeDict[Language.Afrikaans] = "af";
////            languageCodeDict[Language.Albanian] = "sq";
////            languageCodeDict[Language.Amharic] = "am";
////            languageCodeDict[Language.Arabic] = "ar";
////            languageCodeDict[Language.Armenian] = "hy";
////            languageCodeDict[Language.Azerbaijani] = "az";
////            languageCodeDict[Language.Basque] = "eu";
////            languageCodeDict[Language.Belarusian] = "be";
////            languageCodeDict[Language.Bengali] = "bn";
////            languageCodeDict[Language.Bihari] = "bh";
////            languageCodeDict[Language.Bulgarian] = "bg";
////            languageCodeDict[Language.Burmese] = "my";
////            languageCodeDict[Language.Catalan] = "ca";
////            languageCodeDict[Language.Cherokee] = "chr";
////            languageCodeDict[Language.Chinese] = "zh";
////            languageCodeDict[Language.ChineseSimplified] = "zh-CN";
////            languageCodeDict[Language.ChineseTraditional] = "zh-TW";
////            languageCodeDict[Language.Croatian] = "hr";
////            languageCodeDict[Language.Czech] = "cs";
////            languageCodeDict[Language.Danish] = "da";
////            languageCodeDict[Language.Dhivehi] = "dv";
////            languageCodeDict[Language.Dutch] = "nl";
////            languageCodeDict[Language.English] = "en";
////            languageCodeDict[Language.Esperanto] = "eo";
////            languageCodeDict[Language.Estonian] = "et";
////            languageCodeDict[Language.Filipino] = "tl";
////            languageCodeDict[Language.Finnish] = "fi";
////            languageCodeDict[Language.French] = "fr";
////            languageCodeDict[Language.Galician] = "gl";
////            languageCodeDict[Language.Georgian] = "ka";
////            languageCodeDict[Language.German] = "de";
////            languageCodeDict[Language.Greek] = "el";
////            languageCodeDict[Language.Guarani] = "gn";
////            languageCodeDict[Language.Gujarati] = "gu";
////            languageCodeDict[Language.Hebrew] = "iw";
////            languageCodeDict[Language.Hindi] = "hi";
////            languageCodeDict[Language.Hungarian] = "hu";
////            languageCodeDict[Language.Icelandic] = "is";
////            languageCodeDict[Language.Indonesian] = "id";
////            languageCodeDict[Language.Inuktitut] = "iu";
////            languageCodeDict[Language.Irish] = "ga";
////            languageCodeDict[Language.Italian] = "it";
////            languageCodeDict[Language.Japanese] = "ja";
////            languageCodeDict[Language.Kannada] = "kn";
////            languageCodeDict[Language.Kazakh] = "kk";
////            languageCodeDict[Language.Khmer] = "km";
////            languageCodeDict[Language.Korean] = "ko";
////            languageCodeDict[Language.Kurdish] = "ku";
////            languageCodeDict[Language.Kyrgyz] = "ky";
////            languageCodeDict[Language.Laothian] = "lo";
////            languageCodeDict[Language.Latvian] = "lv";
////            languageCodeDict[Language.Lithuanian] = "lt";
////            languageCodeDict[Language.Macedonian] = "mk";
////            languageCodeDict[Language.Malay] = "ms";
////            languageCodeDict[Language.Malayalam] = "ml";
////            languageCodeDict[Language.Maltese] = "mt";
////            languageCodeDict[Language.Marathi] = "mr";
////            languageCodeDict[Language.Mongolian] = "mn";
////            languageCodeDict[Language.Nepali] = "ne";
////            languageCodeDict[Language.Norwegian] = "no";
////            languageCodeDict[Language.Oriya] = "or";
////            languageCodeDict[Language.Pashto] = "ps";
////            languageCodeDict[Language.Persian] = "fa";
////            languageCodeDict[Language.Polish] = "pl";
////            languageCodeDict[Language.Portuguese] = "pt-PT";
////            languageCodeDict[Language.Punjabi] = "pa";
////            languageCodeDict[Language.Romanian] = "ro";
////            languageCodeDict[Language.Russian] = "ru";
////            languageCodeDict[Language.Sanskrit] = "sa";
////            languageCodeDict[Language.Serbian] = "sr";
////            languageCodeDict[Language.Sindhi] = "sd";
////            languageCodeDict[Language.Sinhalese] = "si";
////            languageCodeDict[Language.Slovak] = "sk";
////            languageCodeDict[Language.Slovenian] = "sl";
////            languageCodeDict[Language.Spanish] = "es";
////            languageCodeDict[Language.Swahili] = "sw";
////            languageCodeDict[Language.Swedish] = "sv";
////            languageCodeDict[Language.Tajik] = "tg";
////            languageCodeDict[Language.Tamil] = "ta";
////            languageCodeDict[Language.Tagalog] = "tl";
////            languageCodeDict[Language.Telugu] = "te";
////            languageCodeDict[Language.Thai] = "th";
////            languageCodeDict[Language.Tibetan] = "bo";
////            languageCodeDict[Language.Turkish] = "tr";
////            languageCodeDict[Language.Ukrainian] = "uk";
////            languageCodeDict[Language.Urdu] = "ur";
////            languageCodeDict[Language.Uzbek] = "uz";
////            languageCodeDict[Language.Uighur] = "ug";
////            languageCodeDict[Language.Vietnamese] = "vi";
////            languageCodeDict[Language.Welsh] = "cy";
////            languageCodeDict[Language.Yiddish] = "yi";

////            translatableList = new[]
////                {
////                    Language.Afrikaans,
////                    Language.Albanian,
////                    Language.Arabic,
////                    Language.Belarusian,
////                    Language.Bulgarian,
////                    Language.ChineseSimplified,
////                    Language.ChineseTraditional,
////                    Language.Catalan,
////                    Language.Croatian,
////                    Language.Czech,
////                    Language.Danish,
////                    Language.Dutch,
////                    Language.English,
////                    Language.Estonian,
////                    Language.Filipino,
////                    Language.Finnish,
////                    Language.French,
////                    Language.Galician,
////                    Language.German,
////                    Language.Greek,
////                    Language.Hebrew,
////                    Language.Hindi,
////                    Language.Hungarian,
////                    Language.Icelandic,
////                    Language.Indonesian,
////                    Language.Irish,
////                    Language.Italian,
////                    Language.Japanese,
////                    Language.Korean,
////                    Language.Latvian,
////                    Language.Lithuanian,
////                    Language.Macedonian,
////                    Language.Malay,
////                    Language.Maltese,
////                    Language.Norwegian,
////                    Language.Persian,
////                    Language.Polish,
////                    Language.Portuguese,
////                    Language.Romanian,
////                    Language.Russian,
////                    Language.Spanish,
////                    Language.Serbian,
////                    Language.Slovak,
////                    Language.Slovenian,
////                    Language.Swahili,
////                    Language.Swedish,
////                    Language.Thai,
////                    Language.Turkish,
////                    Language.Ukrainian,
////                    Language.Vietnamese,
////                    Language.Welsh,
////                    Language.Yiddish,
////                };
////        }

////        /// <summary>
////        /// Gets translatable language collection.
////        /// </summary>
////        public static ICollection<Language> TranslatableCollection
////        {
////            get
////            {
////                return translatableList;
////            }
////        }

////        /// <summary>
////        /// Gets language collection.
////        /// </summary>
////        public static ICollection<Language> LanguageCollection
////        {
////            get
////            {
////                return LanguageCodeDict.Keys;
////            }
////        }

////        /// <summary>
////        /// Gets language code dictionary.
////        /// </summary>
////        internal static IDictionary<Language, string> LanguageCodeDict
////        {
////            get
////            {
////                return languageCodeDict;
////            }
////        }

////        /// <summary>
////        /// Whether this language is translatable.
////        /// </summary>
////        /// <param name="language">The language.</param>
////        /// <returns>Return true if the language is translatable.</returns>
////        public static bool IsTranslatable(Language language)
////        {
////            return TranslatableCollection.Contains(language);
////        }

////        /// <summary>
////        /// Get language from a language code.
////        /// </summary>
////        /// <param name="languageCode">The language code.</param>
////        /// <returns>The language of this code or unknown language if of language match this code.</returns>
////        internal static Language GetLanguage(string languageCode)
////        {
////            languageCode = languageCode.Trim();
////            if (string.IsNullOrEmpty(languageCode))
////            {
////                return Language.Unknown;
////            }

////            foreach (var pair in LanguageCodeDict)
////            {
////                if (languageCode == pair.Value)
////                {
////                    return pair.Key;
////                }
////            }

////            if (string.Compare(languageCode, "zh-Hant", true) == 0)
////            {
////                return Language.ChineseTraditional;
////            }

////            return Language.Unknown;
////        }

////        /// <summary>
////        /// Get the language code of a language.
////        /// </summary>
////        /// <param name="language">The language</param>
////        /// <returns>The language code of this language or code for unknown language.</returns>
////        internal static string GetLanguageCode(Language language)
////        {
////            string code;
////            if (!LanguageCodeDict.TryGetValue(language, out code))
////            {
////                code = LanguageCodeDict[Language.Unknown];
////            }

////            return code;
////        }
////    }
////}