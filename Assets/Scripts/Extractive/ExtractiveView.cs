using System;
using System.Timers;
using TMPro;
using UnityEngine;

namespace Extractive
{
    public interface IExtractiveView
    {
        public event Action OnProducing;
        int ResourceItem {  set; }
        float ProducingSpeed { get; set; }
        ExtractiveType ExtractiveType { set; }
        Vector3 Position { set; }
    }
    
    public class ExtractiveView : MonoBehaviour, IExtractiveView
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Material material;

        public event Action OnProducing;
        public int ResourceItem { set => text.text = value.ToString(); }
        public float ProducingSpeed { get; set; }
        public Vector3 Position { set => transform.position = value; }
        public ExtractiveType ExtractiveType
        {
            set => material.color = GetColor(value); 
        }


        private float timer;
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > ProducingSpeed)
            {
                timer = 0;
                OnProducing?.Invoke();
            }
        }

        private Color GetColor(ExtractiveType extractiveType)
        {
            switch (extractiveType)
            {
                case ExtractiveType.Blue:
                    return Color.blue;
                case ExtractiveType.Green:
                    return Color.green;
                case ExtractiveType.Red:
                    return Color.red;
                default:
                    return Color.white;
            }
        }
    }
}