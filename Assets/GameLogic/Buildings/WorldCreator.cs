using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Manufacture;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
    [SerializeField] private List<BuildingInitData> buildingInitData;
    [SerializeField] private BuildingBuilder builder;
    

    private void Start()
    {
        foreach (var initData in buildingInitData)
        {
            builder.CreateBuilding(initData);
        }
    }
}
