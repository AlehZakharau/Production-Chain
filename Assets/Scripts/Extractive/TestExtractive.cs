using System;
using System.Collections;
using UnityEngine;

namespace Extractive
{
    public class TestExtractive : MonoBehaviour
    {
        [SerializeField] private ExtractiveViewFactory viewFactory;
        private void Awake()
        {
            var modelFactory = new ExtractiveModelFactory();
            var model = modelFactory.Model;

            viewFactory.Initiate();
            var view = viewFactory.View;

            var controllerFactory = new ExtractiveControllerFactory(model, view);
            var controller = controllerFactory.Controller;

            StartCoroutine(Producing(model));
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