using System;
using System.Collections.Generic;
using GameLogic.Data;
using GameLogic.Manufacture;
using UnityEngine;

namespace CommonBaseUI.Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private SaveLoadJsonWindows saveLoadJsonWindows;
        [SerializeField] private SaveLoadJsonWeb saveLoadJsonWeb;
        [SerializeField] private SaveLoadAsyncTest saveLoadAsyncTest;

        public static DataManager Instance;
        
        private SaveLoadJson saveLoadJson;
        private GameSettingsDataManager gameSettingDataManager;
        private ManufactureDataManager manufactureDataManager;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            #if UNITY_WEBGL
                saveLoadJson = saveLoadJsonWeb;
            #else
                saveLoadJson = saveLoadJsonWindows;
            #endif

            gameSettingDataManager = new GameSettingsDataManager(saveLoadJson);
        }

        public void CreateManufactureDataManager(List<IManufactureModel> manufactures)
        {
            manufactureDataManager = new ManufactureDataManager(saveLoadJson, manufactures);
        }
        
        public void Save()
        {
            manufactureDataManager.SaveData();
        }

        public void Load()
        {
            manufactureDataManager.LoadData();
        }
    }
}