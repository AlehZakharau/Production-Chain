using System.Collections.Generic;
using GameLogic.Buildings.DataBase;
using GameLogic.Buildings.Factories;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic.Buildings
{
    public class WorldCreator : MonoBehaviour
    {
        [SerializeField] private List<BuildingInitData> buildingInitData;
        [SerializeField] private BuildingBuilder builder;
        [SerializeField] private TransportViewFactory transportViewFactory;
        [SerializeField] private ResourceIcons resourceIcons;
    

        private void Start()
        {
            var transportService = new TransportationService(transportViewFactory);
            resourceIcons.Init();
        
            foreach (var initData in buildingInitData)
            {
                builder.CreateBuilding(initData, transportService);
            }
        }
    }
}
