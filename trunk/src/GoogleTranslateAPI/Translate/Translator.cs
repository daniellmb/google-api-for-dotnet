/**
 * Translator.cs
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
using System.Net;
using System.Web;

namespace Google.API.Translate
{
    /// <summary>
    /// Translate format.
    /// </summary>
    public enum TranslateFormat
    {
        /// <summary>
        /// Text format. Default value.
        /// </summary>
        text,
        /// <summary>
        /// Html format.
        /// </summary>
        html,
    }

    /// <summary>
    /// Utility class for translate and detect.
    /// </summary>
    public static class Translator
    {
        private static int s_Timeout = 0;

        /// <summary>
        /// Get or set the length of time, in milliseconds, before the request times out.
        /// </summary>
        public static int Timeout
        {
            get
            {
                return s_Timeout;
            }
            set
            {
                if (s_Timeout <= 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                s_Timeout = value;
            }
        }

        /// <summary>
        /// Translate the text from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="from">The language of the original text. You can set it as <c>Language.Unknown</c> to the auto detect it.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = "我喜欢跑步。";
        /// string translated = Translator.Translate(text, Language.Chinese_Simplified, Language.English);
        /// Console.WriteLine(translated);
        /// // I like running.
        /// </code>
        /// </example>
        public static string Translate(string text, Language from, Language to)
        {
            return Translate(text, from, to, TranslateFormat.text);
        }

        /// <summary>
        /// Translate the text from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="from">The language of the original text. You can set it as <c>Language.Unknown</c> to the auto detect it.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="format">The format of the text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = GetYourHtmlString();
        /// string translated = Translator.Translate(text, Language.English, Language.French, TranslateFormat.html);
        /// </code>
        /// </example>
        public static string Translate(string text, Language from, Language to, TranslateFormat format)
        {
            if (from != Language.Unknown && !LanguageUtility.IsTranslatable(from))
            {
                throw new TranslateException("Can not translate this language : " + from);
            }
            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new TranslateException(string.Format("Can not translate this language to \"{0}\"", to));
            }
            TranslateData result;
            try
            {
                result = Translate(text, LanguageUtility.GetLanguageCode(from), LanguageUtility.GetLanguageCode(to), format);
            }
            catch (TranslateException ex)
            {
                throw new TranslateException("Translate failed!", ex);
            }

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
        /// <exception cref="TranslateException">Translate failed.</exception>
        /// <example>
        /// This is the c# code example.
        /// <code>
        /// string text = "Je t'aime.";
        /// Language from;
        /// string translated = Translator.Translate(text, Language.English, out from);
        /// Console.WriteLine("\"{0}\" is \"{1}\" in {2}", text, translated, from);
        /// // "Je t'aime." is "I love you." in French.
        /// </code>
        /// </example>
        public static string Translate(string text, Language to, out Language from)
        {
            return Translate(text, to, TranslateFormat.text, out from);
        }

        /// <summary>
        /// Translate the text to <paramref name="to"/> and auto detect which language the text is from.
        /// </summary>
        /// <param name="text">The content to translate.</param>
        /// <param name="to">The target language you want to translate to.</param>
        /// <param name="format">The format of the text.</param>
        /// <param name="from">The detected language of the original text.</param>
        /// <returns>The translate result.</returns>
        /// <exception cref="TranslateException">Translate failed.</exception>
        public static string Translate(string text, Language to, TranslateFormat format, out Language from)
        {
            if (!LanguageUtility.IsTranslatable(to))
            {
                throw new TranslateException(string.Format("Can not translate this language to \"{0}\"", to));
            }
            TranslateData result;
            try
            {
                result = Translate(text, LanguageUtility.GetLanguageCode(Language.Unknown), LanguageUtility.GetLanguageCode(to), format);
            }
            catch (TranslateException ex)
            {
                throw new TranslateException("Translate failed!", ex);
            }
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
        /// <exception cref="TranslateException">Detect failed.</exception>
        public static Language Detect(string text, out bool isReliable, out double confidence)
        {
            DetectData result;
            try
            {
                result = Detect(text);
            }
            catch (TranslateException ex)
            {
                throw new TranslateException("Detect failed!", ex);
            }
            string languageCode = result.LanguageCode;
            isReliable = result.IsReliable;
            confidence = result.Confidence;
            Language language = LanguageUtility.GetLanguage(languageCode);
            return language;
        }

        internal static TranslateData Translate(string text, string from, string to)
        {
            return Translate(text, from, to, TranslateFormat.text);
        }

        internal static TranslateData Translate(string text, string from, string to, TranslateFormat format)
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

            TranslateRequest request = new TranslateRequest(text, from, to, format);

            WebRequest webRequest;
            if(Timeout != 0)
            {
                webRequest = request.GetWebRequest(Timeout);
            }
            else
            {
                webRequest = request.GetWebRequest();
            }

            TranslateData responseData;
            try
            {
                responseData = RequestUtility.GetResponseData<TranslateData>(webRequest);
            }
            catch (GoogleAPIException ex)
            {
                throw new TranslateException(string.Format("request:\"{0}\"", request), ex);
            }

            return responseData;
        }

        internal static DetectData Detect(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            DetectRequest request = new DetectRequest(text);

            WebRequest webRequest;
            if (Timeout != 0)
            {
                webRequest = request.GetWebRequest(Timeout);
            }
            else
            {
                webRequest = request.GetWebRequest();
            }

            DetectData responseData;
            try
            {
                responseData = RequestUtility.GetResponseData<DetectData>(webRequest);
            }
            catch (GoogleAPIException ex)
            {
                throw new TranslateException(string.Format("request:\"{0}\"", request), ex);
            }

            return responseData;
        }
    }
}
