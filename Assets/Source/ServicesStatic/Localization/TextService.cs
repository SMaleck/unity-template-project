﻿using System;
using Source.ServicesStatic.Localization.Data;
using Source.ServicesStatic.LocalPlayerPrefs;

namespace Source.ServicesStatic.Localization
{
    public static class TextService
    {
        private static ITextData _textData;

        public static Language CurrentLanguage => _textData.CurrentLanguage;

        public static void Initialize(ITextData textData)
        {
            _textData = textData;

            var storedLanguage = PlayerPrefsService.Language;

            var isStoredLanguageValid = Enum.IsDefined(typeof(Language), storedLanguage);
            var language = isStoredLanguageValid
                ? (Language) storedLanguage
                : Language.English;

            SetLanguage(language);
        }

        public static void SetLanguage(Language language)
        {
            PlayerPrefsService.Language = (int)language;
            _textData.SetLanguage(language);
        }

        public static string HelloWorld()
        {
            return _textData.GetText(TextKey.HelloWorld);
        }
    }
}