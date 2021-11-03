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

internal class ProductionPointModel : IProductionPointModel
{
    public ProductionPointModel(ProductionPointSpec productionPointSpec)
    {
        ProductionPointSpec = productionPointSpec;

        if (productionPointSpec.Extractor)
        {
            producingSystem = new ExtractorProducing(this, productionPointSpec);
        }
        else
        {
            producingSystem = new RefineryProducing(this, productionPointSpec);
        }
    }
    public ProductionPointSpec ProductionPointSpec { get; }
    public ProductionPointType Type => ProductionPointSpec.Type;
    public int ResourceAmount { get; set; } = 0;

    private float timer;

    private readonly IProducingSystem producingSystem;


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
            producingSystem.Producing();
        }
    }

    private interface IProducingSystem
    {
        public void Producing();
    }
    
    public class ExtractorProducing : IProducingSystem
    {

        private readonly IProductionPointModel ProductionPointModel;
        private readonly ProductionPointSpec ProductionPointSpec;

        public ExtractorProducing(IProductionPointModel productionPointModel,
            ProductionPointSpec productionPointSpec)
        {
            this.ProductionPointModel = productionPointModel;
            this.ProductionPointSpec = productionPointSpec;
        }

        public void Producing()
        {
            ProductionPointModel.ResourceAmount++;
        }
    }
    
    public class RefineryProducing : IProducingSystem
    {
        private readonly IProductionPointModel ProductionPointModel;
        private readonly ProductionPointSpec ProductionPointSpec;

        public RefineryProducing(IProductionPointModel productionPointModel,
            ProductionPointSpec productionPointSpec)
        {
            this.ProductionPointModel = productionPointModel;
            this.ProductionPointSpec = productionPointSpec;
        }

        public void Producing()
        {
            if (ProductionPointSpec.CheckProductionOpportunity())
            {
                ProductionPointModel.ResourceAmount++;
            }
        }
    }
}