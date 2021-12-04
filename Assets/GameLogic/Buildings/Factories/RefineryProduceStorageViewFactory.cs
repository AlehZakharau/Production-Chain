﻿using UnityEngine;

namespace GameLogic.Manufacture
{
    public interface IRefineryProduceStorageViewFactory
    {
        public IRefineryProduceStorageView RefineryProduceStorageView { get; }
    }
    [CreateAssetMenu(fileName = "RefineryProduceStorageView", menuName = "SO/RefineryProduceStorageView", order = 0)]
    public class RefineryProduceStorageViewFactory : ScriptableObject, IRefineryProduceStorageViewFactory
    {
        [SerializeField] private RefineryProduceStorageView refineryProduceStorageView;
        public IRefineryProduceStorageView RefineryProduceStorageView { get; private set; }

        public void Initiate(Transform parent)
        {
            var instance = Instantiate(refineryProduceStorageView, parent, true);
            RefineryProduceStorageView = instance.GetComponent<IRefineryProduceStorageView>();
            instance.transform.position = new Vector3(0, 0, 0);
        }
    }
}