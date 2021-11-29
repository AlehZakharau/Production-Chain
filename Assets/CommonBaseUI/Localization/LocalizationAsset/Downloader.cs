using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace CommonBaseUI.Localization.LocalizationAsset
{
    /// <summary>
    /// Загружает словарь с гугл-таблиц в проект
    /// Использует HTTP протокол
    /// Автоматически создает экземпляр
    /// </summary>
    [ExecuteInEditMode]
    public class Downloader : MonoBehaviour
    {
        public static event Action OnNetworkReady = () => { }; 

        private static Downloader _instance;

	    public static Downloader Instance => _instance ? _instance : (_instance = new GameObject("Downloader").AddComponent<Downloader>());

        public static string resultText;

        public void OnDestroy()
        {
            _instance = null;
        }
       
        public static void Download(string url, Action<UnityWebRequest> callback)
        {
            Debug.LogFormat("downloading {0}", url);
            Instance.StartCoroutine(Coroutine(url, callback));
        }

        private static IEnumerator Coroutine(string url, Action<UnityWebRequest> callback)
        {
            var www = new UnityWebRequest(url);

            yield return www;

            Debug.LogFormat("downloaded {0}, www.text = {1}, www.error = {2}", url, CleaunupText(www.url), www.error);

            if (www.error == null)
            {
                OnNetworkReady();
            }

            callback(www);
        }

        private static string CleaunupText(string text)
        {
            return text.Replace("\n", " ").Replace("\t", null);
        }
        
        
        void Start() {
            StartCoroutine(GetText());
        }

        IEnumerator GetText() {
            UnityWebRequest www = new UnityWebRequest(Path.Combine(Application.streamingAssetsPath, "Localization.csv"));
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {

                // Or retrieve results as binary data
                resultText = www.downloadHandler.text;
                LocalizationManager.Read(resultText);
            }
        }
    }
}