using System;

namespace Extractive
{
    public interface IExtractiveModel
    {
        event Action OnProducingItem;
        
        int ResourceItem { get; set; }
    }
    
    public class ExtractiveModel: IExtractiveModel
    {
        
    private int resourceItem;

    public event Action OnProducingItem;

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
    }
}