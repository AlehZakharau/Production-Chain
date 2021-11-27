using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonView : UnityEngine.MonoBehaviour
    {
        [SerializeField] private UIController controller;
        [SerializeField] private Button button;
        [SerializeField] private ButtonJobs buttonJobs;


        private void Awake()
        {
            button.onClick.AddListener(DoJob);
        }

        private void DoJob()
        {
            controller.PressButton(buttonJobs);
        }
    }
}