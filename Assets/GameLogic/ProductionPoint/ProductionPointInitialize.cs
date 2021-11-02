using System;
using DefaultNamespace;
using DefaultNamespace.ProductionPoint;
using GameLogic.ProductionPoint;
using UnityEngine;

namespace GameLogic
{
    public class ProductionPointInitialize : MonoBehaviour
    {
        [SerializeField] private ProductionPointSpecInitializeData[] specData;
        [SerializeField] private Tick tick;

        private void Awake()
        {
            foreach (var t in specData)
            {
                if (t == null) throw new NullReferenceException();
                var spec = new ProductionPointSpec(t.InitData, t.LevelsData);
                var modelFactory = new ProductionPointModelFactory(spec);
                tick.ProductionPointModels.Add(modelFactory.Model);
            }
        }
    }
}