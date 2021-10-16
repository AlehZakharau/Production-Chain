using UnityEngine;

namespace Extractive
{
    public interface IExtractiveViewFactory
    {
        IExtractiveView View { get; }
    }
    
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class ExtractiveViewFactory : ScriptableObject
    {
        public ExtractiveView extractiveView;
        
        public IExtractiveView View { get; private set; }

        public void Initiate()
        {
            var instance = Instantiate(extractiveView);
            View = instance.GetComponent<IExtractiveView>();
            instance.transform.position = new Vector3(0, 0, 0);
        }
    }
}