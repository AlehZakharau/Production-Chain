using CommonBaseUI.Data;
using CommonBaseUI.Localization.LocalizationAsset;
using TMPro;
using UnityEngine;

namespace CommonBaseUI.Localization
{
    public class LocalizationGameScene : MonoBehaviour
    {

        [SerializeField] private GameSettingsDataManager gameSettingsDataManager;
        [SerializeField] private TextMeshProUGUI introText;
        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private TextMeshProUGUI epilogueText;
        [SerializeField] private TextMeshProUGUI S_SoundText;
        [SerializeField] private TextMeshProUGUI S_MusicText;
        [SerializeField] private TextMeshProUGUI S_VoiceText;
        [SerializeField] private TextMeshProUGUI Dd_resolutionText;
        [SerializeField] private TextMeshProUGUI T_FullscreenText;
        [SerializeField] private TextMeshProUGUI Bt_BackText;
        [SerializeField] private TextMeshProUGUI Bt_ContinueText;
        [SerializeField] private TextMeshProUGUI Bt_SettingsText;
        [SerializeField] private TextMeshProUGUI Bt_ExitText;
        [SerializeField] private TextMeshProUGUI Bt_RestartText;


        private void OnEnable()
        {
            LocalizationManager.LocalizationChanged += LocalizationManagerOnLocalizationChanged;
        }

        private void LocalizationManagerOnLocalizationChanged()
        {
            introText.text = LocalizationManager.Localize("Intro");
            gameOverText.text = LocalizationManager.Localize("GameOver");
            epilogueText.text = LocalizationManager.Localize("Epilogue");
            S_SoundText.text = LocalizationManager.Localize("UI.S_Sound");
            S_MusicText.text = LocalizationManager.Localize("UI.S_Music");
            S_VoiceText.text = LocalizationManager.Localize("UI.S_Voice");
            Dd_resolutionText.text = LocalizationManager.Localize("UI.Dd_Resolution");
            T_FullscreenText.text = LocalizationManager.Localize("UI.Fullscreen");
            Bt_BackText.text = LocalizationManager.Localize("UI.Bt_Back");
            Bt_ContinueText.text = LocalizationManager.Localize("UI.Bt_Continue");
            Bt_SettingsText.text = LocalizationManager.Localize("UI.Bt_Settings");
            Bt_ExitText.text = LocalizationManager.Localize("UI.Bt_Exit");
            Bt_RestartText.text = LocalizationManager.Localize("UI.Bt_Restart");
        }
    }
}
