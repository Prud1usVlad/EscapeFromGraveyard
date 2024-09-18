using Assets.Scripts.EventSystem;
using UnityEngine;

namespace Assets.Scripts.UiElements
{
    /// <summary>
    /// ModalWindow class that defines PauseWindow behaviour
    /// </summary>
    public class PauseWindow : ModalWindow
    {
        [SerializeField]
        private GameEvent cancelPause;

        /// <summary>
        /// Close the application
        /// </summary>
        public void OnExitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        /// <summary>
        /// Cancel Pause
        /// </summary>
        public void OnCancelPause() 
        {
            cancelPause.Raise();
        }
    }
}
