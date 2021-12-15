using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IBuildingUpgraderView
    {
        public int Level { get; set; }
        public Dictionary<ResourceType, int> UpgradeResources { get; set; }
    }
    
    
    public class BuildingUpgraderView : MonoBehaviour, IBuildingUpgraderView
    {
        [SerializeField] private TMP_Text levelText;
        // [SerializeField] private TMP_Text upgradeResourceText;
        public int Level { get => Level; set => levelText.text = value.ToString(); }
        public Dictionary<ResourceType, int> UpgradeResources { get; set; }


        private void Awake()
        {
            var testDictionary = new Dictionary<ResourceType, int>()
            {
                { ResourceType.BlueResource, 1 },
                { ResourceType.GreenResource, 2 }, { ResourceType.OrangeResource, 25 }
            };
            CreateListUpgradeResources(testDictionary);
        }

        private void CreateListUpgradeResources(Dictionary<ResourceType, int> resources)
        {
            // upgradeResourceText.text = "";
            // foreach (var resource in resources)
            // {
            //     upgradeResourceText.text += resource.Key.ToString() + " " + resource.Value.ToString() + "\n";
            // }
        }
    }
}