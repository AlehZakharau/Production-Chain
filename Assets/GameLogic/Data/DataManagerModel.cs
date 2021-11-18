using System.Collections.Generic;
using System.IO;
using GameLogic.Manufacture;
using UnityEngine;

namespace GameLogic.Data
{
    public class DataManagerModel
    {
        private ManufacturesDates data;

        private readonly Dictionary<IManufactureModel, int> models;
        public DataManagerModel(List<IManufactureModel> models)
        {
            this.models = new Dictionary<IManufactureModel, int>(models.Count);
            data = new ManufacturesDates(models.Count);
            for (int i = 0; i < models.Count; i++)
            {
                this.models.Add(models[i], i);
                data.Manufactures[i] = new ManufactureData();
            }
        }

        public void SaveData()
        {
            foreach (var manufacture in models)
            {
                data.Manufactures[manufacture.Value].level = manufacture.Key.ManufactureData.Level;
                data.Manufactures[manufacture.Value].resourceAmount = manufacture.Key.ResourceAmount;
                data.Manufactures[manufacture.Value].demandResources =
                    manufacture.Key.ManufactureData.GetDemandResourceAmount();
                data.Manufactures[manufacture.Value].upgradeResources =
                    manufacture.Key.ManufactureData.GetUpgradeResourceAmount();
            }
            SaveToJson();
        }

        public void LoadData()
        {
            LoadDataFromJson();
            foreach (var manufacture in models)
            {
                manufacture.Key.ManufactureData.Level = data.Manufactures[manufacture.Value].level;
                manufacture.Key.ResourceAmount = data.Manufactures[manufacture.Value].resourceAmount;
                manufacture.Key.ManufactureData.SetDemandResourceAmount(data.Manufactures[manufacture.Value].demandResources);
                manufacture.Key.ManufactureData.SetUpgradeResourceAmount(data.Manufactures[manufacture.Value].upgradeResources);
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
                JsonUtility.FromJson<ManufacturesDates>(jsonData);
                //Debug.Log("Game loaded from: " + filePath);
            }
            else
            {
                SaveToJson();
            }
        }
    }
}