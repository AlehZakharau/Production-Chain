using System;
using DefaultNamespace.Transport;
using UnityEngine;

namespace GameLogic.ProductionPoint
{
    public class ManufactureInitialize : MonoBehaviour
    {
        [SerializeField] private ManufactureViewFactory viewFactory;
        
        [SerializeField] private ManufactureInitData[] specData;
        [SerializeField] private Tick tick;

        private void Awake()
        {
            var transportationService = new TransportationService();
            foreach (var t in specData)
            {
                if (t == null) throw new NullReferenceException();
                var modelFactory = new ManufactureModelFactory(t.ManufactureData, transportationService);
                tick.ProductionPointModels.Add(modelFactory.Tickable);
                var model = modelFactory.Model;
                
                
                viewFactory.Initiate(t.transform);
                var view = viewFactory.View;

                var controllerFactory = new ManufactureControllerFactory(model, view);
                var controller = controllerFactory.Controller;
            }
        }
    }
}