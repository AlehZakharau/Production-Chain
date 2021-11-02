using System.Runtime.CompilerServices;
using GameLogic;
using UnityEngine;

public interface IProductionPointModel
{
    public ProductionPointType Type { get; }
    public int ResourceAmount { get; set; }
    public ProductionPointSpec ProductionPointSpec { get; }
    public bool AddDemandResources(ResourceType resource);
    public ResourceType GetResource();

    public void Tick();
}

internal class ExtractorModel : IProductionPointModel
{
    public ExtractorModel(ProductionPointSpec productionPointSpec)
    {
        ProductionPointSpec = productionPointSpec;
    }
    
    public ProductionPointType Type => ProductionPointSpec.Type;
    public int ResourceAmount { get; set; } = 0;
    public ProductionPointSpec ProductionPointSpec { get; }
    
    private float timer;
    private void Producing()
    {
        ResourceAmount++;
    }

    public bool AddDemandResources(ResourceType resource)
    {
        return ProductionPointSpec.AddDemandResources(resource);
    }

    public ResourceType GetResource()
    {
        return ProductionPointSpec.Resource;
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        if (timer > ProductionPointSpec.ProductionSpeed)
        {
            timer = 0;
            Producing();
        }
    }
}

internal class RefineryModel : IProductionPointModel
{
    public RefineryModel(ProductionPointSpec productionPointSpec)
    {
        ProductionPointSpec = productionPointSpec;
    }
    private float timer;
    public ProductionPointType Type => ProductionPointSpec.Type;
    public int ResourceAmount { get; set; } = 0;

    public ProductionPointSpec ProductionPointSpec { get; }

    private void Producing()
    {
        if (ProductionPointSpec.CheckProductionOpportunity())
        {
            ResourceAmount++;
        }
    }

    public bool AddDemandResources(ResourceType resource)
    {
        return ProductionPointSpec.AddDemandResources(resource);
    }

    public ResourceType GetResource()
    {
        return ProductionPointSpec.Resource;
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        if (timer > ProductionPointSpec.ProductionSpeed)
        {
            timer = 0;
            Producing();
        }
    }
}