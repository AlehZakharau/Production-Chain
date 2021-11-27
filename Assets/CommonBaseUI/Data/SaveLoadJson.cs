using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace UI.Data
{
    public abstract class SaveLoadJson : MonoBehaviour
    {
        public virtual void SaveToJson(string name, ISerializable data)
        {
            
        }

        public virtual void LoadFromJson(string name , ISerializable data)
        {
            
        }
    }
}
