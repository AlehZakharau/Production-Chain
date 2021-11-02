using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic;
using GameLogic.ProductionPoint;
using UnityEngine;


public class ProductionPointSpec
{
    public event Action OnUpgradeAvailable;

    public ProductionPointSpec(InitializeData.InitData initData, InitializeData.LevelData[] levelsData)
    {
        Type = initData.productionPointType;
        Resource = initData.resourceType;
        Position = initData.Position.position;
        demandProductionResources = initData.demandProducingResources;
        Extractor = initData.extractor;

        this.levelsData = levelsData;
        CurrentLevel = levelsData[0];
        ProductionSpeed = CurrentLevel.productionSpeed;
        demandUpgradeResources = CurrentLevel.demandUpgradeResource;
        
        upgradeResources = new Dictionary<ResourceType, int>();
        for (int i = 0; i < demandUpgradeResources.Length; i++)
        {
            upgradeResources.Add(demandUpgradeResources[i], CurrentLevel.demandUpgradeResourceCapacity[i]);
        }

        productionResources = new Dictionary<ResourceType, int>();
        foreach (var resource in demandProductionResources)
        {
            productionResources.Add(resource, 0);
        }
    }

    public ProductionPointType Type { get; set; }
    public ResourceType Resource { get; set; }
    public InitializeData.LevelData CurrentLevel { get; set; }
    public float ProductionSpeed { get; set; }
    public Vector3 Position { get; set; }
    public bool Extractor { get; }

    
    private int level;
    
    private readonly InitializeData.LevelData[] levelsData;
    private ResourceType[] demandUpgradeResources;
    private Dictionary<ResourceType, int> upgradeResources;
    private readonly ResourceType[] demandProductionResources;
    private readonly Dictionary<ResourceType, int> productionResources;

    public bool AddDemandResources(ResourceType resource)
    {
        if (demandUpgradeResources.Contains(resource))
        {
            upgradeResources[resource]--;
            CheckUpgradeOpportunity();
            return true;
        }

        if (demandProductionResources.Length > 0 && demandProductionResources.Contains(resource))
        {
            productionResources[resource]++;
            return true;
        }
        return false;
    }

    public bool CheckProductionOpportunity()
    {
        if (productionResources.Any(
            resource => resource.Value < 1))
        {
            return false;
        }
        foreach (var varResource in demandProductionResources)
        {
            productionResources[varResource]--;
        }
        return true;
    }

    public void Upgrade()
    {
        level++;
        CurrentLevel = levelsData[level];
        ProductionSpeed = CurrentLevel.productionSpeed;
        demandUpgradeResources = CurrentLevel.demandUpgradeResource;
        upgradeResources = new Dictionary<ResourceType, int>();
        for (int i = 0; i < demandUpgradeResources.Length; i++)
        {
            upgradeResources.Add(demandUpgradeResources[i], CurrentLevel.demandUpgradeResourceCapacity[i]);
        }
    }

    private void CheckUpgradeOpportunity()
    {
        if(upgradeResources.All(resource => resource.Value < 1))
        {
            OnUpgradeAvailable?.Invoke();
        }
    }

    


    
}