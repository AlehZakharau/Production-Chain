using System;
using System.Collections.Generic;
using CommonBaseUI.Data;
using GameLogic.Manufacture;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic
{
    public class Initialize : MonoBehaviour
    {
        [SerializeField] private ManufactureViewFactory viewFactory;
        [SerializeField] private TransportViewFactory transportViewFactory;
        
        [SerializeField] private ManufactureInitData[] specData;
        [SerializeField] private Tick tick;

        private List<IManufactureModel> manufactures;

        private void Start()
        {
            manufactures = new List<IManufactureModel>(specData.Length);
            var transportationService = new TransportationService(transportViewFactory, tick);
            
            CreateManufacture(transportationService);
            
            DataManager.Instance.CreateManufactureDataManager(manufactures);
        }

        private void CreateManufacture(TransportationService transportationService)
        {
            foreach (var t in specData)
            {
                if (t == null) throw new NullReferenceException();
                var modelFactory = new ManufactureModelFactory(t.ManufactureData, transportationService);
                tick.Tickable.Add(modelFactory.Tickable);
                var model = modelFactory.Model;
                manufactures.Add(model);
                
                
                viewFactory.Initiate(t.transform);
                var view = viewFactory.View;

                var controllerFactory = new ManufactureControllerFactory(model, view);
                var controller = controllerFactory.Controller;
            }
        }
    }
}