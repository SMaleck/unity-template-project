using System;
using System.Collections.Generic;

namespace Source.Framework.Services.Localization.Data
{
    public class TextDataSource : ITextData
    {
        public Language CurrentLanguage { get; private set; }

        public void SetLanguage(Language language)
        {
            CurrentLanguage = language;
        }

        public string GetText(TextKey textKey)
        {
            switch (CurrentLanguage)
            {
                case Language.English:
                    return _textsEN[textKey];

                case Language.German:
                    return _textsDE[textKey];

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentLanguage), CurrentLanguage, null);
            }
        }

        public string GetLanguageText(Language languageKey)
        {
            return _textsLANGUAGE[languageKey];
        }

        private static Dictionary<Language, string> _textsLANGUAGE = new Dictionary<Language, string>
        {
            { Language.English, "English"},
            { Language.German, "Deutsch"}
        };

        private static Dictionary<TextKey, string> _textsEN = new Dictionary<TextKey, string>
        {
            { TextKey.HelloWorld, "Hello World!"}
        };

        private static Dictionary<TextKey, string> _textsDE = new Dictionary<TextKey, string>
        {
            { TextKey.HelloWorld, "Hallo Welt!"}
        };
    }
}
