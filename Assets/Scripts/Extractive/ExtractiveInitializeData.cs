using UnityEngine;

namespace Extractive
{
    public class ExtractiveInitializeData : MonoBehaviour
    {
        [SerializeField] ExtractiveInitializeModel.InitializeData data = default;

        public ExtractiveInitializeModel.InitializeData InitializeData => data;
    }
}