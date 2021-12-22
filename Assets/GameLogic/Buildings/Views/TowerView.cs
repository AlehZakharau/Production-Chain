using System;
using UnityEngine;

namespace GameLogic.Buildings.Views
{
    public interface ITowerView
    {
        public void OpenNewArea();
    }

    public class TowerView : MonoBehaviour, ITowerView
    {
        [SerializeField] private SpriteRenderer[] tiles;

        private void Start()
        {
            foreach (var tile in tiles)
            {
                tile.enabled = false;
            }
        }

        public void OpenNewArea()
        {
            foreach (var tile in tiles)
            {
                tile.enabled = true;
            }
        }
    }
}