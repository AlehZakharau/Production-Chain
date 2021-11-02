using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Tick : MonoBehaviour
    {
        public List<IProductionPointModel> ProductionPointModels { get; }

        private void Update()
        {
            foreach (var tick in ProductionPointModels)
            {
                tick.Tick();
            }
        }
    }

    // public interface ITickable
    // {
    //     public void Tick();
    // }
}