namespace Source.ServicesStatic.Localization.Data
{
    public interface ITextData
    {
        Language CurrentLanguage { get; }
        void SetLanguage(Language language);
        string GetText(TextKey textKey);
        string GetLanguageText(Language languageKey);
    }
}
