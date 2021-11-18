using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    [Serializable]
    public class ManufacturesDates
    {
        public ManufactureData[] Manufactures;

        public ManufacturesDates(int length)
        {
            Manufactures = new ManufactureData[length];
        }
    }
    
    [Serializable]
    public class ManufactureData
    {
        public int resourceAmount;
        public int level;
        public int[] demandResources;
        public int[] upgradeResources;
    }
}