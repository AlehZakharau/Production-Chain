using System;
using System.Runtime.Serialization;

namespace CommonBaseUI.Data
{
    [Serializable]
    public class ManufacturesDates : ISerializable
    {
        public ManufactureData[] Manufactures;

        public ManufacturesDates(int length)
        {
            Manufactures = new ManufactureData[length];
        }

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
}