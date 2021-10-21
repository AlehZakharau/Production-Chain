using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Transport;
using UnityEngine;
using static DefaultNamespace.ProductionPoint.ProductionPointInitializeModel;

namespace DefaultNamespace.ProductionPoint
{
    public interface IProductionPointModel
    {
        public event Action OnProducingResource;
        
        public ProductionPointType ProductionPointType { get; set; }
        
        public ResourceType ProducingResourceType { get; set; }
        
        public int ProducingResource { get; set; }
        
        public Dictionary<ResourceType, int> DemandResources { get; set; }
        
        public ResourceType[] DemandResourceTypes { get; set; }
        
        public Vector3 Position { get; set; }
        
        public float ProductionSpeed { get; set; }
        
        bool Extractor { get; set; }

        public ITransportModel TransportModel { get; set; }

        public void Initialize(InitializeData initializeData);

        public void AddDemandResources(ResourceType resourceType);

        public void CallTransportService();

        public void Tick();

    }
    public class ProductionPointModel : IProductionPointModel
    {
        private int resource;
        private float timer;
        
        public event Action OnProducingResource;
        public ProductionPointType ProductionPointType { get; set; }
        public ResourceType ProducingResourceType { get; set; }

        public int ProducingResource
        {
            get => resource;
            set
            { 
                if(resource == value) return;
                {
                    resource = value;
                    OnProducingResource?.Invoke();
                }
            }
        }

        public Dictionary<ResourceType, int> DemandResources { get; set; }
        public ResourceType[] DemandResourceTypes { get; set; }
        public Vector3 Position { get; set; }
        public float ProductionSpeed { get; set; }
        public bool Extractor { get; set; }
        public ITransportModel TransportModel { get; set; }


        public void Initialize(InitializeData initializeData)
        {
            DemandResources = new Dictionary<ResourceType, int>();
            ProductionPointType = initializeData.productionPointType;
            ProducingResourceType = initializeData.resourceType;
            ProductionSpeed = initializeData.productionSpeed;
            Position = initializeData.spawnPosition.position;
            DemandResourceTypes = initializeData.demandResources;
            foreach (var resource in initializeData.demandResources)
            {
                if (!DemandResources.ContainsKey(resource))
                {
                    DemandResources.Add(resource, 0);
                }
            }
        }

        public void AddDemandResources(ResourceType resourceType)
        {
            DemandResources[resourceType]++;
        }
        
        private void ProduceItem()
        {
            if (DemandResources.Any(
                varResource => varResource.Value < 1))
            {
                return;
            }

            foreach (var varResource in DemandResources.Keys)
            {
                DemandResources[varResource]--;
            }
            resource++;
        }

        public void CallTransportService()
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            Producing();
        }

        private void Producing()
        {
            timer += Time.deltaTime;
            {
                if (!(timer > ProductionSpeed)) return;
                timer = 0;
                if (Extractor)
                {
                    resource++;
                }
                else
                {
                    ProduceItem();
                }
            }
        }
    }
}