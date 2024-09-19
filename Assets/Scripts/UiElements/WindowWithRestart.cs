using Assets.Scripts.Helpers;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UiElements
{
    /// <summary>
    /// Modal window with function of game restart
    /// </summary>
    public class WindowWithRestart : PauseWindow
    {
        [SerializeField]
        private GameState gameState;

        /// <summary>
        /// Reloads game scene
        /// </summary>
        public void Restart()
        {
            gameState.ClearState();

            if (PauseManager.instance.IsPaused)
                PauseManager.instance.UnpauseGame();

            SceneManager.LoadScene(0);
        }
    }
}
