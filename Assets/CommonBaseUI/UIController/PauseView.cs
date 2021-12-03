using UnityEngine;

namespace CommonBaseUI.UIController
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private ButtonJobs closePauseReaction = ButtonJobs.OpenMain;

        private bool isPause;

        private void Start()
        {
            uiController.OnCloseButtonPressed += UiControllerOnOnCloseButtonPressed;
        }

        private void UiControllerOnOnCloseButtonPressed()
        {
            isPause = !isPause;
            OpenClosePauseMenu(isPause);
        }

        private void OpenClosePauseMenu(bool isPause)
        {
            if (isPause)
            {
                Time.timeScale = 0;
                uiController.PressButton(ButtonJobs.OpenPause);
            }
            else
            {
                Time.timeScale = 1;
                uiController.PressButton(closePauseReaction);
            }
        }
    }
}