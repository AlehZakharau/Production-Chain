using System;
using CommonBaseUI.Data;

namespace GameLogic.Manufacture
{
    public class RefineryProduceModel : IProduceModel
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
        private readonly IRefineryProduceStorageModel refineryProduceStorageModel;

        private int resourceAmount;

        public bool ProduceResource()
        {
            if (refineryProduceStorageModel.SpendResourceForCreateResource())
            {
                ResourceAmount++;
                return true;
            }
            return false;
        }

        public RefineryProduceModel(IRefineryProduceStorageModel refineryProduceStorageModel)
        {

            this.refineryProduceStorageModel = refineryProduceStorageModel;
            
            resourceStorageData = new ResourceStorageData();
            DataManager.Instance.buildingsData.ResourceStorageData.Add(resourceStorageData);
            DataManager.Instance.GetDataOnSave += SaveData;
            DataManager.Instance.SendDataOnLoad += LoadData;
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