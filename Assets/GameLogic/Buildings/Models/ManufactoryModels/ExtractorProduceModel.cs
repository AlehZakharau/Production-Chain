﻿using System;
using CommonBaseUI.Data;

namespace GameLogic.Buildings.Models.ManufactoryModels
{
    public interface IProduceModel
    {
        public event Action OnProducingResource;
        public int ResourceAmount { get; set; }
        public int ResourceCapacity { get; set; }
        public bool ProduceResource();

    }
    
    public class ExtractorProduceModel : IProduceModel
    {
        public event Action OnProducingResource;
        public int ResourceCapacity { get; set; }
        public int ResourceAmount
        {
            get => resourceAmount < 1 ? 0 : resourceAmount;
            set
            {
                if(resourceAmount >= ResourceCapacity) return;
                OnProducingResource?.Invoke();
                resourceAmount = value;
            }
        }

        private readonly ResourceStorageData resourceStorageData;

        private int resourceAmount;

        public ExtractorProduceModel()
        {
            resourceStorageData = new ResourceStorageData();
            DataManager.Instance.buildingsData.ResourceStorageData.Add(resourceStorageData);
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
        }

        public bool ProduceResource()
        {
            ResourceAmount++;
            return true;
        }


        private void SaveData()
        {
            resourceStorageData.resourceAmount = ResourceAmount;
        }

        private void LoadData()
        {
            ResourceAmount = resourceStorageData.resourceAmount;
        }
    }
}