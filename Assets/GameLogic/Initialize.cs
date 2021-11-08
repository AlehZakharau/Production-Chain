using System;
using GameLogic.Manufacture;
using GameLogic.Transport;
using UnityEngine;

namespace GameLogic
{
    public class Initialize : MonoBehaviour
    {
        [SerializeField] private ManufactureViewFactory viewFactory;
        [SerializeField]private TransportViewFactory transportViewFactory;
        
        [SerializeField] private ManufactureInitData[] specData;
        [SerializeField] private Tick tick;

        private void Awake()
        {
            var transportationService = new TransportationService(transportViewFactory, tick);
            foreach (var t in specData)
            {
                if (t == null) throw new NullReferenceException();
                var modelFactory = new ManufactureModelFactory(t.ManufactureData, transportationService);
                tick.Tickable.Add(modelFactory.Tickable);
                var model = modelFactory.Model;
                
                
                viewFactory.Initiate(t.transform);
                var view = viewFactory.View;

                var controllerFactory = new ManufactureControllerFactory(model, view);
                var controller = controllerFactory.Controller;
            }
        }
    }
}