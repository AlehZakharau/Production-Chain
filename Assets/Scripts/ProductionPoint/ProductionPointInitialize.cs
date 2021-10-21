using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.ProductionPoint
{
    public class ProductionPointInitialize : MonoBehaviour
    {
        [SerializeField] private ProductionPointViewFactory viewFactory;

        [SerializeField] private ProductionPointInitializeData[] initData;

        private List<IProductionPointModelFactory> productionModelFactories =
                new List<IProductionPointModelFactory>(20);
        
        private void Awake()
        {

            foreach (var initializeData in initData)
            {
                var modelFactory = new ProductionPointModelFactory();
                var model = modelFactory.Model;
                model.Initialize(initializeData.InitializeData);

                viewFactory.Initiate();
                var view = viewFactory.View;
                
 
                var controllerFactory = new ProductionPointControllerFactory(model, view);
                var controller = controllerFactory.Controller;
            }
        }

        private void Update()
        {
            foreach (var modelFactory in productionModelFactories)
            {
                modelFactory.Model.Tick();
            }
        }
    }
}