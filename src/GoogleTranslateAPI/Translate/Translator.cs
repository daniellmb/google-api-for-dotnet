//-----------------------------------------------------------------------
// <copyright file="Translator.cs" company="iron9light">
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

    /// <summary>
    /// Utility class for translate and detect.
    /// </summary>
    [Obsolete("Use TranslateClient instead.")]
    public static class Translator
    {
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
        /// string text = "我喜欢跑步。";
        /// string translated = Translator.Translate(text, Language.Chinese_Simplified, Language.English);
        /// Console.WriteLine(translated);
        /// // I like running.
        /// </code>
        /// </example>
        public static string Translate(string text, Language from, Language to)
        {
            return Translate(text, from, to, new TranslateFormat());
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
        /// string translated = Translator.Translate(text, Language.English, Language.French, TranslateFormat.html);
        /// </code>
        /// </example>
        public static string Translate(string text, Language from, Language to, TranslateFormat format)
        {
            var translateClient = new TranslateClient();
            return translateClient.Translate(text, from, to, format);
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
        /// string translated = Translator.TranslateAndDetect(text, Language.English, out from);
        /// Console.WriteLine("\"{0}\" is \"{1}\" in {2}", text, translated, from);
        /// // "Je t'aime." is "I love you." in French.
        /// </code>
        /// </example>
        public static string TranslateAndDetect(string text, Language to, out Language from)
        {
            return TranslateAndDetect(text, to, new TranslateFormat(), out from);
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
        public static string TranslateAndDetect(string text, Language to, TranslateFormat format, out Language from)
        {
            var translateClient = new TranslateClient();
            return translateClient.TranslateAndDetect(text, to, format, out from);
        }

        /// <summary>
        /// Detect the language for this text.
        /// </summary>
        /// <param name="text">The text you want to test.</param>
        /// <param name="isReliable">Whether the result is reliable</param>
        /// <param name="confidence">The confidence percent of the result.</param>
        /// <returns>The detected language.</returns>
        /// <exception cref="GoogleAPIException">Detect failed.</exception>
        public static Language Detect(string text, out bool isReliable, out double confidence)
        {
            var translateClient = new TranslateClient();
            return translateClient.Detect(text, out isReliable, out confidence);
        }
    }
}