//-----------------------------------------------------------------------
// <copyright file="Language.cs" company="iron9light">
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
    /// <summary>
    /// Languages for search API.
    /// </summary>
    public sealed class Language : Enumeration<Language>
    {
        /// <summary>
        /// The Unknown. Default value.
        /// </summary>
        public static readonly Language Unknown = new Language("Unknown", string.Empty, true);

        /// <summary>
        /// The Arabic.
        /// </summary>
        public static readonly Language Arabic = new Language("Arabic", "lang_ar");

        /// <summary>
        /// The Bulgarian.
        /// </summary>
        public static readonly Language Bulgarian = new Language("Bulgarian", "lang_bg");

        /// <summary>
        /// The Catalan.
        /// </summary>
        public static readonly Language Catalan = new Language("Catalan", "lang_ca");

        /// <summary>
        /// The ChineseSimplified.
        /// </summary>
        public static readonly Language ChineseSimplified = new Language("ChineseSimplified", "lang_zh-CN");

        /// <summary>
        /// The ChineseTraditional.
        /// </summary>
        public static readonly Language ChineseTraditional = new Language("ChineseTraditional", "lang_zh-TW");

        /// <summary>
        /// The Croatian.
        /// </summary>
        public static readonly Language Croatian = new Language("Croatian", "lang_hr");

        /// <summary>
        /// The Czech.
        /// </summary>
        public static readonly Language Czech = new Language("Czech", "lang_cs");

        /// <summary>
        /// The Danish.
        /// </summary>
        public static readonly Language Danish = new Language("Danish", "lang_da");

        /// <summary>
        /// The Dutch.
        /// </summary>
        public static readonly Language Dutch = new Language("Dutch", "lang_nl");

        /// <summary>
        /// The English. Default value.
        /// </summary>
        public static readonly Language English = new Language("English", "lang_en");

        /// <summary>
        /// The Estonian.
        /// </summary>
        public static readonly Language Estonian = new Language("Estonian", "lang_et");

        /// <summary>
        /// The Finnish.
        /// </summary>
        public static readonly Language Finnish = new Language("Finnish", "lang_fi");

        /// <summary>
        /// The French.
        /// </summary>
        public static readonly Language French = new Language("French", "lang_fr");

        /// <summary>
        /// The German.
        /// </summary>
        public static readonly Language German = new Language("German", "lang_de");

        /// <summary>
        /// The Greek.
        /// </summary>
        public static readonly Language Greek = new Language("Greek", "lang_el");

        /// <summary>
        /// The Hebrew.
        /// </summary>
        public static readonly Language Hebrew = new Language("Hebrew", "lang_iw");

        /// <summary>
        /// The Hungarian.
        /// </summary>
        public static readonly Language Hungarian = new Language("Hungarian", "lang_hu");

        /// <summary>
        /// The Icelandic.
        /// </summary>
        public static readonly Language Icelandic = new Language("Icelandic", "lang_is");

        /// <summary>
        /// The Indonesian.
        /// </summary>
        public static readonly Language Indonesian = new Language("Indonesian", "lang_id");

        /// <summary>
        /// The Italian.
        /// </summary>
        public static readonly Language Italian = new Language("Italian", "lang_it");

        /// <summary>
        /// The Japanese.
        /// </summary>
        public static readonly Language Japanese = new Language("Japanese", "lang_ja");

        /// <summary>
        /// The Korean.
        /// </summary>
        public static readonly Language Korean = new Language("Korean", "lang_ko");

        /// <summary>
        /// The Latvian.
        /// </summary>
        public static readonly Language Latvian = new Language("Latvian", "lang_lv");

        /// <summary>
        /// The Lithuanian.
        /// </summary>
        public static readonly Language Lithuanian = new Language("Lithuanian", "lang_lt");

        /// <summary>
        /// The Norwegian.
        /// </summary>
        public static readonly Language Norwegian = new Language("Norwegian", "lang_no");

        /// <summary>
        /// The Polish.
        /// </summary>
        public static readonly Language Polish = new Language("Polish", "lang_pl");

        /// <summary>
        /// The Portuguese.
        /// </summary>
        public static readonly Language Portuguese = new Language("Portuguese", "lang_pt");

        /// <summary>
        /// The Romanian.
        /// </summary>
        public static readonly Language Romanian = new Language("Romanian", "lang_ro");

        /// <summary>
        /// The Russian.
        /// </summary>
        public static readonly Language Russian = new Language("Russian", "lang_ru");

        /// <summary>
        /// The Serbian.
        /// </summary>
        public static readonly Language Serbian = new Language("Serbian", "lang_sr");

        /// <summary>
        /// The Slovak.
        /// </summary>
        public static readonly Language Slovak = new Language("Slovak", "lang_sk");

        /// <summary>
        /// The Slovenian.
        /// </summary>
        public static readonly Language Slovenian = new Language("Slovenian", "lang_sl");

        /// <summary>
        /// The Spanish.
        /// </summary>
        public static readonly Language Spanish = new Language("Spanish", "lang_es");

        /// <summary>
        /// The Swedish.
        /// </summary>
        public static readonly Language Swedish = new Language("Swedish", "lang_sv");

        /// <summary>
        /// The Turkish.
        /// </summary>
        public static readonly Language Turkish = new Language("Turkish", "lang_tr");

        private Language(string value)
            : base(value)
        {
        }

        private Language(string name, string value)
            : base(name, value)
        {
        }

        private Language(string name, string value, bool isDefault)
            : base(name, value, isDefault)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Language"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Language(string value)
        {
            return Convert(value, s => new Language(s));
        }
    }
}