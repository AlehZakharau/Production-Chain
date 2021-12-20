using System;
using UnityEngine.UIElements;

namespace GameLogic.Manufacture
{
    public interface IResourceStorageModel
    {
        public event Action OnProducingResource;
        public int ResourceAmount { get; set; }
        public bool AddDemandResources(ResourceType resource);
        public bool CheckResource(ResourceType resource);
        public bool ProduceResource();
        public IBuildingModel BuildingModel { get; }
        public void OnClick();
    }
}