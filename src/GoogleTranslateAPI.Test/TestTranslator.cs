/**
 * TestTranslator.cs
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
using NUnit.Framework;

namespace Google.API.Translate.Test
{
    [TestFixture]
    public class TestTranslator
    {
        private static readonly ICollection<Language> s_Undetectable = new Language[]
            {
                Language.Chinese_Simplified,
                Language.Croatian,
                Language.Greek,
                Language.Hindi,
                Language.Norwegian,
            };

        [Test]
        public void TranslateTest()
        {
            Language originalLanguage = Language.English;
            string originalText = "cat";

            Print(originalLanguage, originalText);

            foreach (Language language in LanguageUtility.translatableCollection)
            {
                if (language == originalLanguage)
                {
                    continue;
                }
                string translatedText = Translator.Translate(originalText, originalLanguage, language);
                Assert.AreNotEqual(originalText, translatedText,
                                   "[{0} -> {1}] {2} : translate failed! Because the result is same to the original one.",
                                   originalLanguage, language, originalText);

                Print(language, translatedText);

                string transbackText = Translator.Translate(translatedText, language, originalLanguage);
                StringAssert.AreEqualIgnoringCase(originalText, transbackText, "[{0} -> {1}] {2} -> {3} != {4}: translate faild!",
                                language, originalLanguage, translatedText, transbackText, originalText);
            }
        }

        [Test]
        public void TranslateTestForHtml()
        {
            // TODO : The test case TranslateTestForHtml is not stable. There may add some space after being translated.

            Language from = Language.English;
            Language to = Language.Chinese_Simplified;

            string textTemplate =
                "<html><head><title>{0} </title></head><body> <b>{1}</b> </body></html>";

            string sentenceA = "You are my sunshine.";
            string sentenceB = "Show me the money.";

            string text = string.Format(textTemplate, sentenceA, sentenceB);

            string translatedA = Translator.Translate(sentenceA, from, to);

            string translatedB = Translator.Translate(sentenceB, from, to);

            string translatedText = Translator.Translate(text, from, to, TranslateFormat.html);

            string expectedText = string.Format(textTemplate, translatedA, translatedB);

            StringAssert.AreEqualIgnoringCase(expectedText, translatedText,
                                              string.Format("expected:\t{1}{0}actual:\t{2}", Environment.NewLine,
                                                            expectedText, translatedText));
        }

        [Test]
        public void TranslateTestWithDetect()
        {
            string text = "I love this game.";

            Language from;
            Language to = Language.English;

            string translated = Translator.Translate(text, to, out from);

            Assert.AreEqual(Language.English, from);
            StringAssert.AreEqualIgnoringCase(text, translated);
        }

        [Test]
        public void DetectTest()
        {
            Language originalLanguage = Language.English;
            string originalText = "This is an apple. I love apple. I eat apple everyday.";

            Print(originalLanguage, originalText);

            foreach (Language language in LanguageUtility.translatableCollection)
            {
                if (language == originalLanguage)
                {
                    continue;
                }

                if (IsUndetectable(language))
                {
                    continue;
                }

                string translatedText = Translator.Translate(originalText, originalLanguage, language);
                Assert.AreNotEqual(originalText, translatedText,
                                   "[{0} -> {1}] {2} : translate failed! Because the result is same to the original one.",
                                   originalLanguage, language, originalText);

                bool isReliable;
                double confidence;
                Language detectedLanguage = Translator.Detect(translatedText, out isReliable, out confidence);

                string more = string.Format("isReliable : {0}, confidence : {1}", isReliable, confidence);
                Print(language, translatedText, more);

                Assert.AreEqual(language, detectedLanguage,
                                "[{0} != {1}] {2} ({3}): detect failed!"
                                , detectedLanguage, language, translatedText, more);
            }
        }

        private static bool IsUndetectable(Language language)
        {
            return s_Undetectable.Contains(language);
        }

        private static void Print(Language language, string text, string more)
        {
            Console.WriteLine("[{0}]\t{1}\t{2}", language, text, more);
        }

        private static void Print(Language language, string text)
        {
            Console.WriteLine("[{0}]\t{1}", language, text);
        }
    }
}
