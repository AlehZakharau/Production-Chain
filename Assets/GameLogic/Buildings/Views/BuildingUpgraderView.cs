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
        [SerializeField] private GameObject tileDeActive;
        [SerializeField] private GameObject tileActive;
        // [SerializeField] private TMP_Text upgradeResourceText;
        private int level;
        public int Level
        {
            get => level;
            set
            {
                level = value;
                levelText.text = value.ToString();
                if (level > 0)
                {
                    tileDeActive.SetActive(false);
                    tileActive.SetActive(true);
                }
            }
        }

        public Dictionary<ResourceType, int> UpgradeResources { get; set; }


        private void Awake()
        {
            var testDictionary = new Dictionary<ResourceType, int>()
            {
                { ResourceType.Wood, 1 },
                { ResourceType.Stone, 2 }
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