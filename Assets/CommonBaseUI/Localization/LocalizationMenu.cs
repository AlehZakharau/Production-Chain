using CommonBaseUI.Localization.LocalizationAsset;
using TMPro;
using UnityEngine;

namespace CommonBaseUI.Localization
{
    public class LocalizationMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI Bt_StartText;
        [SerializeField] private TextMeshProUGUI Bt_SettingsText;
        [SerializeField] private TextMeshProUGUI Bt_SettingsText2;
        [SerializeField] private TextMeshProUGUI Bt_ExitText;
        [SerializeField] private TextMeshProUGUI Bt_ExitText2;
        [SerializeField] private TextMeshProUGUI Bt_Credits;
        [SerializeField] private TextMeshProUGUI S_SoundText;
        [SerializeField] private TextMeshProUGUI S_MusicText;
        [SerializeField] private TextMeshProUGUI S_VoiceText;
        [SerializeField] private TextMeshProUGUI Dd_ResolutionText;
        [SerializeField] private TextMeshProUGUI T_FullscreenText;
        [SerializeField] private TextMeshProUGUI T_FullscreenText2;
        [SerializeField] private TextMeshProUGUI Bt_BackText;
        [SerializeField] private TextMeshProUGUI Bt_ContinueText;
        [SerializeField] private TextMeshProUGUI MessageText;
        [SerializeField] private TextMeshProUGUI CreditsText;
        [SerializeField] private TextMeshProUGUI CreditsText2;
        [SerializeField] private TextMeshProUGUI CreditsText3;
        
        
        void OnEnable()
        {
            LocalizationManager.LocalizationChanged += ApplyLanguageChanges; //подписываемся на смену языка
        }
        
        public void ApplyLanguageChanges()
        {
            Bt_StartText.text = LocalizationManager.Localize("UI.Bt_Start");
            Bt_SettingsText.text = LocalizationManager.Localize("UI.Bt_Settings");
            Bt_SettingsText2.text = LocalizationManager.Localize("UI.Bt_Settings");
            Bt_ExitText.text = LocalizationManager.Localize("UI.Bt_Exit");
            Bt_ExitText2.text = LocalizationManager.Localize("UI.Bt_Exit");
            Bt_Credits.text = LocalizationManager.Localize("UI.Bt_Credits");
            S_SoundText.text = LocalizationManager.Localize("UI.S_Sound");
            S_MusicText.text = LocalizationManager.Localize("UI.S_Music");
            S_VoiceText.text = LocalizationManager.Localize("UI.S_Voice");
            Dd_ResolutionText.text = LocalizationManager.Localize("UI.Dd_Resolution");
            T_FullscreenText.text = LocalizationManager.Localize("UI.Fullscreen");
            T_FullscreenText2.text = LocalizationManager.Localize("UI.Fullscreen");
            Bt_BackText.text = LocalizationManager.Localize("UI.Bt_Back");
            Bt_ContinueText.text = LocalizationManager.Localize("UI.Bt_Continue");
            MessageText.text = LocalizationManager.Localize("UI.Message");
            CreditsText.text = LocalizationManager.Localize("UI.Credits");
            CreditsText2.text = LocalizationManager.Localize("UI.Credits2");
            CreditsText3.text = LocalizationManager.Localize("UI.Credits3");
        }
    }
}