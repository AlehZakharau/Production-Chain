using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CommonBaseUI.UIController
{
    public class UIController : MonoBehaviour
    {

        [SerializeField] private Canvas mainMenu;
        [SerializeField] private Canvas settingsMenu;
        [SerializeField] private Canvas creditsMenu;
        [SerializeField] private Canvas pauseMenu;

        [SerializeField] private UIKeywordInputView inputView;
        
        private Canvas currentMenu;

        public event Action OnCloseButtonPressed;

        private void Start()
        {
            currentMenu = mainMenu;
            inputView.OnCloseButtonPressed += () => OnCloseButtonPressed?.Invoke();
        }

        public void PressButton(ButtonJobs buttonJobs)
        {
            Time.timeScale = 1;
            switch (buttonJobs)
            {
                case ButtonJobs.Exit:
                    Application.Quit();
                    break;
                case ButtonJobs.NewGame:
                    SceneManager.LoadScene(1);
                    break;
                case ButtonJobs.OpenMain:
                    OpenNewMenu(mainMenu);
                    break;
                case ButtonJobs.OpenSettings:
                    OpenNewMenu(settingsMenu);
                    break;
                case ButtonJobs.OpenCredits:
                    OpenNewMenu(creditsMenu);
                    break;
                case ButtonJobs.OpenPause:
                    OpenNewMenu(pauseMenu);
                    Time.timeScale = 0;
                    break;
            }
        }
        private void OpenNewMenu(Canvas newMenu)
        {
            currentMenu.enabled = false;
            currentMenu = newMenu;
            currentMenu.enabled = true;
        }
    }
}