using Assets.Scripts.Helpers;
using Assets.Scripts.UiElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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

        [SerializeField]
        private KeysCount keysCount;
        [SerializeField]
        private Timer timer;

        public void Start() 
        {
            keysCount.UpdateCount();
        }

        public void Update()
        {
            if (pauseInput.action.WasPressedThisFrame())
            {
                modals.OpenModal(ModalType.Pause);
            }

            timer.UpdateTimer();
        }

        /// <summary>
        /// Called by EventListener on PlayerKilled event opens corresponding modal
        /// </summary>
        /// <param name="param">String representation of killing source</param>
        public void OnPlayerDied(string param)
        {
            var str = $"During your trip, the following unfortunate " +
                $"thing happened {param}. Do you want to try again or quit the game?";

            ModalWindowsController.instance.OpenModal(
                ModalType.Died,
                "Unfortunately, you are dead...",
                str);
        }

        /// <summary>
        /// Called by EventListener on KeyCollected event opens corresponding modal
        /// </summary>
        public void OnKeyCollected()
        {
            keysCount.UpdateCount();
        }

        /// <summary>
        /// Called by EventListener on CantOpenDoor event opens corresponding modal
        /// </summary>
        public void OnCantEscape()
        {
            ModalWindowsController.instance.OpenModal(ModalType.CantOpenTheDoor);
        }

        /// <summary>
        /// Called by EventListener on Escaped event opens corresponding modal
        /// </summary>
        public void OnEscaped()
        {
            ModalWindowsController.instance.OpenModal(ModalType.Win);
        }
    }
}
