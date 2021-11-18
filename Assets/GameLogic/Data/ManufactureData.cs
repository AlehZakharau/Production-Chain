using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    [SerializeField]
    public class ManufacturesDates
    {
        public ManufactureData[] manufactureDates;

        public ManufacturesDates(int length)
        {
            manufactureDates = new ManufactureData[length];
        }
    }
    
    [Serializable]
    public class ManufactureData
    {
        public ManufactureData(string name)
        {
            this.name = name;
        }
        public string name;
    }
}