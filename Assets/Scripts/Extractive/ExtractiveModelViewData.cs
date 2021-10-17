using UnityEngine;

namespace Extractive
{
    public enum ExtractiveType
    {
        Blue,
        Green,
        Red
    }
    public class ExtractiveModelViewData : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosition;

        [SerializeField] private float productionSpeed;

        [SerializeField]
        private ExtractiveType extractiveType;


        public ExtractiveType ExtractiveType => extractiveType;

        public float ProductionSpeed => productionSpeed;

        public Vector3 Position => spawnPosition.position;
    }
}