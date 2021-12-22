using System;
using UnityEngine.UIElements;

namespace GameLogic.Manufacture
{
    public interface IResourceStorage
    {
        public bool AddDemandResources(ResourceType resource);
        public bool CheckResource(ResourceType resource);
        public IBuildingModel BuildingModel { get; }
        public void OnClick();
    }
}