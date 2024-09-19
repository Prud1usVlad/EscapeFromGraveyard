using Assets.Scripts.Controllers;
using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UiElements
{
    /// <summary>
    /// Defines simple modal window
    /// </summary>
    public class ModalWindow : MonoBehaviour
    {
        [SerializeField]
        private ModalType type;
        [SerializeField]
        private TextMeshProUGUI header;
        [SerializeField]
        private TextMeshProUGUI content;

        /// <summary>
        /// Sets different header and content for allowing dynamic content
        /// </summary>
        /// <param name="header"></param>
        /// <param name="content"></param>
        public void SetText(string header = null, string content = null)
        {
            if (header != null)
            {
                this.header.SetText(header);
            }
            if (content != null)
            {
                this.content.SetText(content);
            }
        }

        /// <summary>
        /// Closes modal using ModalWindowsController.CloseModal
        /// </summary>
        public void Close()
        {
            ModalWindowsController.instance.CloseModal(type);
        }
    }
}
