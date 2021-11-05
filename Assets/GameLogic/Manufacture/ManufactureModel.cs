using System;
using System.Runtime.CompilerServices;
using DefaultNamespace.Transport;
using GameLogic;
using UnityEngine;

namespace GameLogic.ProductionPoint
{
    public interface IManufactureModel
    {
        public event Action OnProducingResource;
        public int ResourceAmount { get; set; }
        public ManufactureData ManufactureData { get; }
    }

    internal class ManufactureModel : IManufactureModel, ITickable
    {
        public event Action OnProducingResource;
        
        private float timer;

        private readonly IProducingSystem producingSystem;

        private int resourceAmount;

        private TransportationService transportationService;
        public ManufactureModel(ManufactureData manufactureData, TransportationService transportationService)
        {
            ManufactureData = manufactureData;
            
            this.transportationService = transportationService;
            
            producingSystem = manufactureData.Extractor
                ? (IProducingSystem)new ExtractorProducing(this, manufactureData)
                : (IProducingSystem)new RefineryProducing(this, manufactureData);
        }
        public ManufactureData ManufactureData { get; }
        public int ResourceAmount { get => resourceAmount;
            set
            {
                if (resourceAmount == value)
                    return;
                resourceAmount = value;
                OnProducingResource?.Invoke();
            } }
        
        public void Tick()
        {
            timer += Time.deltaTime;
            if (timer > ManufactureData.ProductionSpeed)
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

            private readonly IManufactureModel manufactureModel;
            private readonly ManufactureData manufactureData;

            public ExtractorProducing(IManufactureModel manufactureModel,
                ManufactureData manufactureData)
            {
                this.manufactureModel = manufactureModel;
                this.manufactureData = manufactureData;
            }

            public void Producing()
            {
                manufactureModel.ResourceAmount++;
            }
        }
    
        public class RefineryProducing : IProducingSystem
        {
            private readonly IManufactureModel manufactureModel;
            private readonly ManufactureData manufactureData;

            public RefineryProducing(IManufactureModel manufactureModel,
                ManufactureData manufactureData)
            {
                this.manufactureModel = manufactureModel;
                this.manufactureData = manufactureData;
            }

            public void Producing()
            {
                if (manufactureData.CheckProductionOpportunity())
                {
                    manufactureModel.ResourceAmount++;
                }
            }
        }
    }
}