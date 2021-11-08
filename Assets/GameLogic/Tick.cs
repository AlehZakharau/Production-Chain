using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Tick : MonoBehaviour
    {
        public readonly List<ITickable> Tickable = new List<ITickable>();

        private void Update()
        {
            foreach (var tick in Tickable)
            {
                tick.Tick();
            }
        }
    }

    public interface ITickable
    {
        public void Tick();
    }
}