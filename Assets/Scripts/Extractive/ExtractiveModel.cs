using System;
using DefaultNamespace;
using UnityEngine;

namespace Extractive
{
    public interface IExtractiveModel
    {
        event Action OnProducingItem;
        event Action OnInitial;
        
        int ResourceItem { get; set; }

        float ProducingSpeed { get; set; }
        
        Vector3 Position { get; set; }
        
        ExtractiveType ExtractiveType { get; set; }
        
        public Color ExtractiveColor { get; set; }

        public void Initialize(ExtractiveInitializeModel.InitializeData initializeData);
    }
    
    public class ExtractiveModel: IExtractiveModel
    {
        
    private int resourceItem;

    public event Action OnProducingItem;
    public event Action OnInitial;

    public int ResourceItem
    {
        get => resourceItem;
        set
        {
            if (resourceItem == value) return;
            resourceItem = value;
            OnProducingItem?.Invoke();
        }
    }
    public float ProducingSpeed { get; set; }
    public Vector3 Position { get; set; }
    public ExtractiveType ExtractiveType { get; set; }
    public Color ExtractiveColor { get; set; }
    public void Initialize(ExtractiveInitializeModel.InitializeData initializeData)
    {
        ProducingSpeed = initializeData.ProductionSpeed;
        ExtractiveType = initializeData.ExtractiveType;
        Position = initializeData.SpawnPosition.position;
        ExtractiveColor = GetColor(initializeData.ExtractiveType);
        //OnInitial?.Invoke();
    }


    private Color GetColor(ExtractiveType extractiveType)
    {
        switch (extractiveType)
        {
            case ExtractiveType.Blue:
                return Color.blue;
            case ExtractiveType.Green:
                return Color.green;
            case ExtractiveType.Yellow:
                return Color.yellow;
            default:
                return Color.white;
        }
    }
    }
}