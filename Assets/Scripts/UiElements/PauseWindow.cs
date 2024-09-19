using UnityEngine;

namespace Assets.Scripts.UiElements
{
    /// <summary>
    /// ModalWindow class that defines PauseWindow behaviour
    /// </summary>
    public class PauseWindow : ModalWindow
    {
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
    }
}
