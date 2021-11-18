using System.IO;
using UnityEngine;

namespace GameLogic.Data
{
    public class DataManager
    {
        private readonly ManufacturesDates data;

        private ColectionTestObjects colection;
        
        public DataManager(ColectionTestObjects colection)
        {
            this.colection = colection;
            data = new ManufacturesDates(colection.tests.Count);
            for (int i = 0; i < colection.tests.Count; i++)
            {
                colection.tests[i].SaveIndex = i;
                data.manufactureDates[i] = new ManufactureData(colection.tests[i].Name);
            }
        }

        public void SaveData()
        {
            foreach (var test in colection.tests)
            {
                data.manufactureDates[test.SaveIndex].name = test.Name;
            }
            SaveToJson();
        }

        public void LoadData()
        {
            LoadDataFromJson();
            foreach (var test in colection.tests)
            {
                test.Name = data.manufactureDates[test.SaveIndex].name;
            }
        }
        
        
        private void SaveToJson()
        {
            // путь к файлу
            string filePath = Path.Combine(Application.dataPath, "GameData.json"); // это то же самое, что Application.dataPath+"\SaveData.json"

            // переносим все переменные класса в формат json
            string jsonData = JsonUtility.ToJson(data);
            // записываем данные в файл
            File.WriteAllText(filePath, jsonData);
            //Debug.Log("Game saved to: " + filePath);
        }

        /// <summary>
        /// Загружает данные из JSON
        /// </summary>
        private void LoadDataFromJson()
        {
            //string filePath = Path.Combine(Application.dataPath, "SaveData.json");
            string filePath = Path.Combine(Application.dataPath, "GameData.json");
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
                SaveToJson();
            }
        }
    }
}