using System.Collections;
using System.IO;
using CommonBaseUI.Localization.LocalizationAsset;
using UnityEngine;
using UnityEngine.Networking;

namespace CommonBaseUI.Localization
{
    public class LocalizationDownloder : MonoBehaviour
    {
        private string resultText;
        void Start() {
            StartCoroutine(GetText());
        }

        IEnumerator GetText() {
            Debug.Log($"Start Downloading");
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
                Debug.Log($"Downloaded Text");
            }

            yield return new WaitForSeconds(0.1f);
            LocalizationManager.ApplyLocalization();
        }
    }
}