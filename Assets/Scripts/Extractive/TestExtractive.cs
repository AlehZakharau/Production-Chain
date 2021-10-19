using System;
using System.Collections;
using UnityEngine;

namespace Extractive
{
    public class TestExtractive : MonoBehaviour
    {
        [SerializeField] private ExtractiveViewFactory viewFactory;

        [SerializeField] private ExtractiveInitializeData[] initData; 
        private void Awake()
        {

            foreach (var initializeData in initData)
            {
                var modelFactory = new ExtractiveModelFactory();
                var model = modelFactory.Model;
                model.Initialize(initializeData.InitializeData);

                viewFactory.Initiate();
                var view = viewFactory.View;
                
 
                var controllerFactory = new ExtractiveControllerFactory(model, view);
                var controller = controllerFactory.Controller;
            }
            
            //StartCoroutine(Producing(model));
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