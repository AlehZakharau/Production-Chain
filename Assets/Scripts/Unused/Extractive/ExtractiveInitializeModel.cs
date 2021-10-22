using System;
using DefaultNamespace;
using UnityEngine;

namespace Extractive
{
    [Serializable]
    public class ExtractiveInitializeModel
    {

        [Serializable]
        public struct InitializeData
        {
            public ResourceType ResourceType;

            public ExtractiveType ExtractiveType;

            public float ProductionSpeed;

            public Transform SpawnPosition;
        }
    }
}