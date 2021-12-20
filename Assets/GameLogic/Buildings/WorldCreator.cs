using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Manufacture;
using GameLogic.Transport;
using UnityEngine;

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
