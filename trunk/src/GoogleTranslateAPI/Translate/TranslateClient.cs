//-----------------------------------------------------------------------
// <copyright file="TranslateClient.cs" company="iron9light">
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

namespace Google.API.Translate
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Translate format.
    /// </summary>
    public enum TranslateFormat
    {
        /// <summary>
        /// Text format. Default value.
        /// </summary>
        text = 0,

        /// <summary>
        /// Html format.
        /// </summary>
        html,
    }

    /// <summary>
    /// The client for translate and detect.
    /// </summary>
    public class TranslateClient : GoogleClient
    {
        private static readonly string addressString = "http://ajax.googleapis.com/ajax/services/language";

        private static readonly Uri address = new Uri(addressString);

        protected override Uri Address
        {
            get
            {
                return address;
            }
        }

        /// <summary>
        /// Translate the text from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="from">The language of the original text. You can set it as <c>Language.Unknown</c> to the auto detect it.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="GoogleAPIException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = "Œ“œ≤ª∂≈‹≤Ω°£";
        /// TranslateClient client = new TranslateClient();
        /// string translated = client.Translate(text, Language.Chinese_Simplified, Language.English);
        /// Console.WriteLine(translated);
        /// // I like running.
        /// </code>
        /// </example>
        public string Translate(string text, Language from, Language to)
        {
            return this.Translate(text, from, to, new TranslateFormat());
        }

        /// <summary>
        /// Translate the text from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="from">The language of the original text. You can set it as <c>Language.Unknown</c> to the auto detect it.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="format">The format of the text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="GoogleAPIException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = GetYourHtmlString();
        /// TranslateClient client = new TranslateClient();
        /// string translated = client.Translate(text, Language.English, Language.French, TranslateFormat.html);
        /// </code>
        /// </example>
        public string Translate(string text, Language from, Language to, [Optional] TranslateFormat format)
        {
            if (from != Language.Unknown && !LanguageUtility.IsTranslatable(from))
            {
                throw new GoogleAPIException("Can not translate this language : " + from);
            }

            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new GoogleAPIException(string.Format("Can not translate this language to \"{0}\"", to));
            }

            var result = this.Translate(
                text, LanguageUtility.GetLanguageCode(from), LanguageUtility.GetLanguageCode(to), format);

            if (format == TranslateFormat.text)
            {
                return HttpUtility.HtmlDecode(result.TranslatedText);
            }

            return result.TranslatedText;
        }

        /// <summary>
        /// Translate the text to <paramref name="to"/> and auto detect which language the text is from.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="from">The detected language of the original text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="GoogleAPIException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = "Je t'aime.";
        /// Language from;
        /// TranslateClient client = new TranslateClient();
        /// string translated = client.TranslateAndDetect(text, Language.English, out from);
        /// Console.WriteLine("\"{0}\" is \"{1}\" in {2}", text, translated, from);
        /// // "Je t'aime." is "I love you." in French.
        /// </code>
        /// </example>
        public string TranslateAndDetect(string text, Language to, out Language from)
        {
            return this.TranslateAndDetect(text, to, new TranslateFormat(), out from);
        }

        /// <summary>
        /// Translate the text to <paramref name="to"/> and auto detect which language the text is from.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="format">The format of the text.</param>
        /// <param name="from">The detected language of the original text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="GoogleAPIException">Translate failed.</exception>
        public string TranslateAndDetect(string text, Language to, [Optional] TranslateFormat format, out Language from)
        {
            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new GoogleAPIException(string.Format("Can not translate this language to \"{0}\"", to));
            }

            var result = this.Translate(
                text, LanguageUtility.GetLanguageCode(Language.Unknown), LanguageUtility.GetLanguageCode(to), format);

            from = LanguageUtility.GetLanguage(result.DetectedSourceLanguage);

            if (format == TranslateFormat.text)
            {
                return HttpUtility.HtmlDecode(result.TranslatedText);
            }

            return result.TranslatedText;
        }

        /// <summary>
        /// Detect the language for this text.
        /// </summary>
        /// <param name="text">The text you want to test.</param>
        /// <param name="isReliable">Whether the result is reliable</param>
        /// <param name="confidence">The confidence percent of the result.</param>
        /// <returns>The detected language.</returns>
        /// <exception cref="GoogleAPIException">Detect failed.</exception>
        public Language Detect(string text, out bool isReliable, out double confidence)
        {
            var result = this.Detect(text);

            var languageCode = result.LanguageCode;
            isReliable = result.IsReliable;
            confidence = result.Confidence;
            var language = LanguageUtility.GetLanguage(languageCode);
            return language;
        }

        internal TranslateData Translate(string text, string from, string to, TranslateFormat format)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            var responseData =
                this.GetResponseData<TranslateData, ILanguageService>(
                    service =>
                    service.Translate(
                        this.AcceptLanguage, this.ApiKey, text, from + '|' + to, format.GetStringIgnoreDefault()));

            return responseData;
        }

        internal DetectData Detect(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            var responseData =
                this.GetResponseData<DetectData, ILanguageService>(
                    service => service.Detect(this.AcceptLanguage, this.ApiKey, text));

            return responseData;
        }
    }
}