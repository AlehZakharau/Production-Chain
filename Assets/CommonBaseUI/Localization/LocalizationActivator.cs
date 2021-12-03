using System.Collections;
using CommonBaseUI.Data;
using CommonBaseUI.Localization.LocalizationAsset;
using UnityEngine;

namespace CommonBaseUI.Localization
{
    public class LocalizationActivator : MonoBehaviour
    {
        [SerializeField] private GameSettingsDataManager gameSettingsDataManager;
        
        public void Start()
        {
            LocalizationManager.Read(); //читаем словарь из файла
            
            switch (gameSettingsDataManager.Languages)
            {
                case Languages.Russian:
                    LocalizationManager.Language = "Russian";
                    break;
                case Languages.English:
                    LocalizationManager.Language = "English";
                    break;
            } //применяем текущий выбранный язык

            StartCoroutine(DelayForApplyLocalization());
            //LocalizationManager.ApplyLocalization();
        }

        private IEnumerator DelayForApplyLocalization()
        {
            yield return new WaitForSeconds(0.1f);
            LocalizationManager.ApplyLocalization();
        }
    }
}