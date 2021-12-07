using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Tick : MonoBehaviour
    {
        public static readonly List<ITickable> Tickable = new List<ITickable>();

        private void Update()
        {
            foreach (var tick in Tickable)
            {
                tick.Tick();
            }
        }
    }
}