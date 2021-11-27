using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace UI.Data
{
    public abstract class SaveLoadJson : MonoBehaviour
    {
        public virtual void SaveToJson(string name, ISerializable data)
        {
            
        }

        public virtual void LoadFromJson(string name , ISerializable data)
        {
            
        }
    }

    public sealed class SaveLoadJsonWindows : SaveLoadJson
    {
        public override void SaveToJson(string name, ISerializable data)
        {
            // путь к файлу
            string filePath = Path.Combine(Application.dataPath, name + ".json"); // это то же самое, что Application.dataPath+"\SaveData.json"

            // переносим все переменные класса в формат json
            string jsonData = JsonUtility.ToJson(data);
            // записываем данные в файл
            File.WriteAllText(filePath, jsonData);
            //Debug.Log("Game saved to: " + filePath);
        }

        public override void LoadFromJson(string name , ISerializable data)
        {
            //string filePath = Path.Combine(Application.dataPath, "SaveData.json");
            string filePath = Path.Combine(Application.dataPath, name + ".json");
            // если файл существует
            if (File.Exists(filePath))
            {
                // вытаскиваем их файла все данные в формате json
                string jsonData = File.ReadAllText(filePath);
                // переносим данные в класс
                JsonUtility.FromJsonOverwrite(jsonData, data);
                //Debug.Log("Game loaded from: " + filePath);
            }
            else
            {
                SaveToJson(name, data);
            }
        }
    }

    public sealed class SaveLoadJsonWeb : SaveLoadJson
    {
        public override void SaveToJson(string name, ISerializable data)
        {
            StartCoroutine(SaveToJsonWeb(name, data));
        }

        private IEnumerator SaveToJsonWeb(string name, ISerializable data)
        {
            string filePath = Path.Combine(Path.Combine
                (Application.streamingAssetsPath, name + ".json"));
            // переносим все переменные класса в формат json
            string jsonData = JsonUtility.ToJson(data);
            
            using (UnityWebRequest www = UnityWebRequest.Put(filePath, jsonData))
            {
                yield return www.SendWebRequest();
        
                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Upload complete!");
                }
            }
        }

        public override void LoadFromJson(string name, ISerializable data)
        {
            StartCoroutine(LoadDataFromJsonWeb(name, data));
        }

        private IEnumerator LoadDataFromJsonWeb(string name, ISerializable data)
        {
            //string filePath = Path.Combine(Application.dataPath, "SaveData.json");
            string filePath = Path.Combine(Path.Combine
                (Application.streamingAssetsPath, name + ".json"));
            UnityWebRequest www = new UnityWebRequest(filePath);
            www.downloadHandler = new DownloadHandlerBuffer();
            
            yield return www.SendWebRequest();
            
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else
            {
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, data);
                Debug.Log($"<color=green>Game data downloaded");
            }
        }
    }
}