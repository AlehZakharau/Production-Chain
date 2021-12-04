using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IResourceStorageView
    {
        public int ResourceAmount { get; set; }
    }
    public class ResourceStorageView : MonoBehaviour, IResourceStorageView
    {
        public int ResourceAmount { get; set; }
    }
}