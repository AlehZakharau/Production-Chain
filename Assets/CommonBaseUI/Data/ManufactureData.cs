using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommonBaseUI.Data
{
    [Serializable]
    public class BuildingsData : ISerializable
    {
        public ManufactureData[] Manufactures;
        public List<ResourceStorageData> ResourceStorageData;
        public List<UpgradeData> UpgradeData;
        public List<RefineryData> RefineryData;

        // public ManufacturesDates(int length)
        // {
        //     //Manufactures = new ManufactureData[length];
        // }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
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
    [Serializable]
    public class ResourceStorageData
    {
        public int resourceAmount;
    }
    [Serializable]
    public class UpgradeData
    {
        public int level;
        public int[] upgradeResources;
    }
    [Serializable]
    public class RefineryData
    {
        public int[] demandResources;
    }
}