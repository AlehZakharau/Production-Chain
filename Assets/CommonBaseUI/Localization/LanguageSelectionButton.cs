using CommonBaseUI.Data;
using CommonBaseUI.Localization.LocalizationAsset;
using UnityEngine;
using UnityEngine.UI;

namespace CommonBaseUI.Localization
{
    /// <summary>
    /// Класс для смены языка
    /// Пока (в тестовом режиме) панель c кнопочками для смены языка висит на панели настроек
    /// Потом нужно будет разобраться, как настраивать язык средствами стима
    /// </summary>
    public class LanguageSelectionButton : MonoBehaviour
    {

        [SerializeField] private GameSettingsDataManager gameSettingsDataManager;
        [SerializeField] private Button englishButton;
        [SerializeField] private Button russianButton;

        private void Start()
        {
            englishButton.onClick.AddListener(delegate { ChangeLanguage(Languages.English); });
            russianButton.onClick.AddListener(delegate { ChangeLanguage(Languages.Russian); });
        }

        private void ChangeLanguage(Languages language)
        {

            gameSettingsDataManager.Languages = language;
            
            LocalizationManager.Language = language.ToString();
        }

        private void OnDestroy()
        {
            englishButton.onClick.RemoveListener(delegate { ChangeLanguage(Languages.English); });
            russianButton.onClick.RemoveListener(delegate { ChangeLanguage(Languages.Russian); });
        }
    }
}
