using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Buildings.DataBase
{
    [CreateAssetMenu(fileName = "ResourceIcons", menuName = "DB/ResourceIcons", order = 0)]
    public class ResourceIcons : ScriptableObject
    {
        [SerializeField] private ResourceType[] resourceTypes;
        [SerializeField] private Sprite[] resourceIconsActive;
        [SerializeField] private Sprite[] resourceIconsDeActive;

        public Dictionary<ResourceType, Sprite> resourceIconsA = new Dictionary<ResourceType, Sprite>();
        public Dictionary<ResourceType, Sprite> resourceIconsDA = new Dictionary<ResourceType, Sprite>();

        public void Init()
        {
            if (resourceTypes.Length != resourceIconsActive.Length ||
                resourceTypes.Length != resourceIconsDeActive.Length)
            {
                Debug.LogError($"Init Data has mistake {this.name}");
            }
            for (var i = 0; i < resourceTypes.Length; i++)
            {
                resourceIconsA.Add(resourceTypes[i], resourceIconsActive[i]);
                resourceIconsDA.Add(resourceTypes[i], resourceIconsDeActive[i]);
            }

            foreach (var data in resourceIconsA)
            {
                Debug.Log($" Dictionary Key: {data.Key} Value: {data.Value} ");
            }
        }
    }
}