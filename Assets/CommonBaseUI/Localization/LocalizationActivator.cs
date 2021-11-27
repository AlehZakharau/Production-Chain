using System;
using System.Collections;
using UI.Data;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.SimpleLocalization
{
    public class LocalizationActivator : MonoBehaviour
    {
        [SerializeField] private DataManager data;
        
        public void Start()
        {
            LocalizationManager.Read(); //читаем словарь из файла
            
            switch (data.Languages)
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