using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.Data
{
    public class TestSaveUI : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private ColectionTestObjects colection;

        private DataManager dataManager;

        private void Start()
        {
            dataManager = new DataManager(colection);
            saveButton.onClick.AddListener(dataManager.SaveData);
            loadButton.onClick.AddListener(dataManager.LoadData);
        }
        
        
        
    }
}