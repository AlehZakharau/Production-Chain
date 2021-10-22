using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extractive
{
    public class TestExtractive : MonoBehaviour
    {
        [SerializeField] private ExtractiveViewFactory viewFactory;

        [SerializeField] private ExtractiveInitializeData[] initData;

        [SerializeField] private List<IExtractiveModel> models = new List<IExtractiveModel>();
        private void Awake()
        {

            foreach (var initializeData in initData)
            {
                var modelFactory = new ExtractiveModelFactory();
                var model = modelFactory.Model;
                models.Add(model);
                model.Initialize(initializeData.InitializeData);

                viewFactory.Initiate();
                var view = viewFactory.View;
                
 
                var controllerFactory = new ExtractiveControllerFactory(model, view);
                var controller = controllerFactory.Controller;

            }
            
            //StartCoroutine(Producing(model));
        }

        private void Update()
        {
            foreach (var model in models)
            {
                model.Producing();
            }
        }

        private IEnumerator Producing(IExtractiveModel model)
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                model.ResourceItem++;
            }
        }
    }
}