using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Manufacture
{
    [CreateAssetMenu(fileName = "ResourceIcons", menuName = "DB/ResourceIcons", order = 0)]
    public class ResourceIcons : ScriptableObject
    {
        [SerializeField] private ResourceType[] resourceTypes;
        [SerializeField] private Sprite[] resourceIcons;

        public Dictionary<ResourceType, Sprite> resourceIconsDB = new Dictionary<ResourceType, Sprite>();

        private void Awake()
        {
            if (resourceTypes.Length != resourceIcons.Length)
            {
                Debug.LogError($"Init Data has mistake {this.name}");
            }
            for (var i = 0; i < resourceTypes.Length; i++)
            {
                resourceIconsDB.Add(resourceTypes[i], resourceIcons[i]);
            }
        }
    }
}