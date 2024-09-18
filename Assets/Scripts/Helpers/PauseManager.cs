using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Defines logic of pause and unpause
    /// </summary>
    public class PauseManager : MonoBehaviour
    {
        public PlayerInput playerInput;

        public static PauseManager instance;

        public bool IsPaused { get; private set; }

        /// <summary>
        /// Sets the game to paused state, disabling time based and standart input based logic
        /// </summary>
        public void PauseGame()
        {
            IsPaused = true;
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            playerInput.SwitchCurrentActionMap("UI");
        }

        /// <summary>
        /// Sets the game to unpaused state, enabling time based and standart input based logic
        /// </summary>
        public void UnpauseGame()
        {
            IsPaused = false;
            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                playerInput = GetComponent<PlayerInput>();
            }
            else
            {
                Destroy(instance);
            }
        }
    }
}
