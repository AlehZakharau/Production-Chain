using System;
using UnityEngine;

namespace GameLogic
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.TryGetComponent<ICollisionally>(out var collision);
            collision.Execute();
        }
    }
    
    public interface ICollisionally
    {
        public void Execute();
    }
}