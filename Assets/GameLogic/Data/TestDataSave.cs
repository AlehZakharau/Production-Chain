using UnityEngine;

namespace GameLogic.Data
{
    public class TestDataSave : MonoBehaviour, ITestDataSave
    {
        [SerializeField] private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public int SaveIndex { get; set; }
    }


    public interface ITestDataSave
    {
        public string Name { get; set; }
        
        public int SaveIndex { get; set; }
    }
}