namespace Google.API.Translate
{
    using System.Collections.Generic;

    public sealed class Language : Enumeration<Language>
    {
        public static readonly Language Unknown = new Language("Unknown", string.Empty, true);
        public static readonly Language Afrikaans = new Language("Afrikaans", "af");
        public static readonly Language Albanian = new Language("Albanian", "sq");
        public static readonly Language Amharic = new Language("Amharic", "am");
        public static readonly Language Arabic = new Language("Arabic", "ar");
        public static readonly Language Armenian = new Language("Armenian", "hy");
        public static readonly Language Azerbaijani = new Language("Azerbaijani", "az");
        public static readonly Language Basque = new Language("Basque", "eu");
        public static readonly Language Belarusian = new Language("Belarusian", "be");
        public static readonly Language Bengali = new Language("Bengali", "bn");
        public static readonly Language Bihari = new Language("Bihari", "bh");
        public static readonly Language Bulgarian = new Language("Bulgarian", "bg");
        public static readonly Language Burmese = new Language("Burmese", "my");
        public static readonly Language Catalan = new Language("Catalan", "ca");
        public static readonly Language Cherokee = new Language("Cherokee", "chr");
        public static readonly Language Chinese = new Language("Chinese", "zh");
        public static readonly Language ChineseSimplified = new Language("ChineseSimplified", "zh-CN");
        public static readonly Language ChineseTraditional = new Language("ChineseTraditional", "zh-TW");
        public static readonly Language Croatian = new Language("Croatian", "hr");
        public static readonly Language Czech = new Language("Czech", "cs");
        public static readonly Language Danish = new Language("Danish", "da");
        public static readonly Language Dhivehi = new Language("Dhivehi", "dv");
        public static readonly Language Dutch = new Language("Dutch", "nl");
        public static readonly Language English = new Language("English", "en");
        public static readonly Language Esperanto = new Language("Esperanto", "eo");
        public static readonly Language Estonian = new Language("Estonian", "et");
        public static readonly Language Filipino = new Language("Filipino", "tl");
        public static readonly Language Finnish = new Language("Finnish", "fi");
        public static readonly Language French = new Language("French", "fr");
        public static readonly Language Galician = new Language("Galician", "gl");
        public static readonly Language Georgian = new Language("Georgian", "ka");
        public static readonly Language German = new Language("German", "de");
        public static readonly Language Greek = new Language("Greek", "el");
        public static readonly Language Guarani = new Language("Guarani", "gn");
        public static readonly Language Gujarati = new Language("Gujarati", "gu");
        public static readonly Language Hebrew = new Language("Hebrew", "iw");
        public static readonly Language Hindi = new Language("Hindi", "hi");
        public static readonly Language Hungarian = new Language("Hungarian", "hu");
        public static readonly Language Icelandic = new Language("Icelandic", "is");
        public static readonly Language Indonesian = new Language("Indonesian", "id");
        public static readonly Language Inuktitut = new Language("Inuktitut", "iu");
        public static readonly Language Irish = new Language("Irish", "ga");
        public static readonly Language Italian = new Language("Italian", "it");
        public static readonly Language Japanese = new Language("Japanese", "ja");
        public static readonly Language Kannada = new Language("Kannada", "kn");
        public static readonly Language Kazakh = new Language("Kazakh", "kk");
        public static readonly Language Khmer = new Language("Khmer", "km");
        public static readonly Language Korean = new Language("Korean", "ko");
        public static readonly Language Kurdish = new Language("Kurdish", "ku");
        public static readonly Language Kyrgyz = new Language("Kyrgyz", "ky");
        public static readonly Language Laothian = new Language("Laothian", "lo");
        public static readonly Language Latvian = new Language("Latvian", "lv");
        public static readonly Language Lithuanian = new Language("Lithuanian", "lt");
        public static readonly Language Macedonian = new Language("Macedonian", "mk");
        public static readonly Language Malay = new Language("Malay", "ms");
        public static readonly Language Malayalam = new Language("Malayalam", "ml");
        public static readonly Language Maltese = new Language("Maltese", "mt");
        public static readonly Language Marathi = new Language("Marathi", "mr");
        public static readonly Language Mongolian = new Language("Mongolian", "mn");
        public static readonly Language Nepali = new Language("Nepali", "ne");
        public static readonly Language Norwegian = new Language("Norwegian", "no");
        public static readonly Language Oriya = new Language("Oriya", "or");
        public static readonly Language Pashto = new Language("Pashto", "ps");
        public static readonly Language Persian = new Language("Persian", "fa");
        public static readonly Language Polish = new Language("Polish", "pl");
        public static readonly Language Portuguese = new Language("Portuguese", "pt-PT");
        public static readonly Language Punjabi = new Language("Punjabi", "pa");
        public static readonly Language Romanian = new Language("Romanian", "ro");
        public static readonly Language Russian = new Language("Russian", "ru");
        public static readonly Language Sanskrit = new Language("Sanskrit", "sa");
        public static readonly Language Serbian = new Language("Serbian", "sr");
        public static readonly Language Sindhi = new Language("Sindhi", "sd");
        public static readonly Language Sinhalese = new Language("Sinhalese", "si");
        public static readonly Language Slovak = new Language("Slovak", "sk");
        public static readonly Language Slovenian = new Language("Slovenian", "sl");
        public static readonly Language Spanish = new Language("Spanish", "es");
        public static readonly Language Swahili = new Language("Swahili", "sw");
        public static readonly Language Swedish = new Language("Swedish", "sv");
        public static readonly Language Tajik = new Language("Tajik", "tg");
        public static readonly Language Tamil = new Language("Tamil", "ta");
        public static readonly Language Tagalog = new Language("Tagalog", "tl");
        public static readonly Language Telugu = new Language("Telugu", "te");
        public static readonly Language Thai = new Language("Thai", "th");
        public static readonly Language Tibetan = new Language("Tibetan", "bo");
        public static readonly Language Turkish = new Language("Turkish", "tr");
        public static readonly Language Ukrainian = new Language("Ukrainian", "uk");
        public static readonly Language Urdu = new Language("Urdu", "ur");
        public static readonly Language Uzbek = new Language("Uzbek", "uz");
        public static readonly Language Uighur = new Language("Uighur", "ug");
        public static readonly Language Vietnamese = new Language("Vietnamese", "vi");
        public static readonly Language Welsh = new Language("Welsh", "cy");
        public static readonly Language Yiddish = new Language("Yiddish", "yi");

        private static readonly ICollection<Language> translatableList = new[]
                {
                    Afrikaans,
                    Albanian,
                    Arabic,
                    Belarusian,
                    Bulgarian,
                    ChineseSimplified,
                    ChineseTraditional,
                    Catalan,
                    Croatian,
                    Czech,
                    Danish,
                    Dutch,
                    English,
                    Estonian,
                    Filipino,
                    Finnish,
                    French,
                    Galician,
                    German,
                    Greek,
                    Hebrew,
                    Hindi,
                    Hungarian,
                    Icelandic,
                    Indonesian,
                    Irish,
                    Italian,
                    Japanese,
                    Korean,
                    Latvian,
                    Lithuanian,
                    Macedonian,
                    Malay,
                    Maltese,
                    Norwegian,
                    Persian,
                    Polish,
                    Portuguese,
                    Romanian,
                    Russian,
                    Spanish,
                    Serbian,
                    Slovak,
                    Slovenian,
                    Swahili,
                    Swedish,
                    Thai,
                    Turkish,
                    Ukrainian,
                    Vietnamese,
                    Welsh,
                    Yiddish,
                };

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

        public static implicit operator Language(string value)
        {
            return Convert(value, s => new Language(s));
        }

        /// <summary>
        /// Gets translatable language collection.
        /// </summary>
        public static ICollection<Language> TranslatableCollection
        {
            get
            {
                return translatableList;
            }
        }

        /// <summary>
        /// Whether this language is translatable.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns>Return true if the language is translatable.</returns>
        public static bool IsTranslatable(Language language)
        {
            return TranslatableCollection.Contains(language);
        }
    }
}