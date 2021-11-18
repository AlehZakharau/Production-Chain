using System;
using System.Collections.Generic;
using GameLogic.Data;
using GameLogic.Manufacture;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic
{
    public class Initialize : MonoBehaviour
    {
        [SerializeField] private ManufactureViewFactory viewFactory;
        [SerializeField] private TransportViewFactory transportViewFactory;
        [SerializeField] private DataManagerView dataManagerView;
        
        [SerializeField] private ManufactureInitData[] specData;
        [SerializeField] private Tick tick;

        private List<IManufactureModel> manufactures;

        private void Awake()
        {
            manufactures = new List<IManufactureModel>(specData.Length);
            var transportationService = new TransportationService(transportViewFactory, tick);
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

            var dataManagerModel = new DataManagerModel(manufactures);
            var dataManagerController = new DataManagerController(dataManagerModel, dataManagerView);
        }
    }
}