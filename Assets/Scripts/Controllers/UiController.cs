using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Basic manager for ui components
    /// </summary>
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private ModalWindowsController modals;

        [SerializeField]
        private InputActionReference pauseInput;

        public void Update()
        {
            if (pauseInput.action.WasPressedThisFrame())
            {
                if (PauseManager.instance.IsPaused)
                {
                    Unpause();
                }
                else
                {
                    Pause();
                }
            }
        }

        /// <summary>
        /// Pauses game and shows modal
        /// </summary>
        public void Pause()
        {
            PauseManager.instance.PauseGame();
            modals.TriggerModal(ModalType.Pause);
        }

        /// <summary>
        /// Unpauses game and hides the modal
        /// </summary>
        public void Unpause()
        {
            PauseManager.instance.UnpauseGame();
            modals.TriggerModal(ModalType.Pause);
        }
    }
}
