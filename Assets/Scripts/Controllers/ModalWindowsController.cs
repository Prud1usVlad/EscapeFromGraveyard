using Assets.Scripts.Helpers;
using Assets.Scripts.UiElements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Simple interface for showing modals 
    /// </summary>
    public class ModalWindowsController : MonoBehaviour
    {
        private Dictionary<ModalType, ModalDesc> modalsDict;

        [SerializeField]
        private List<ModalDesc> modals;

        public static ModalWindowsController instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                modalsDict = modals.ToDictionary(m => m.type);
            }
            else
            {
                Destroy(instance);
            }
        }

        /// <summary>
        /// Creates modal defined by type parameter if not created already
        /// </summary>
        /// <param name="type">Type of the modal to open</param>
        /// <param name="header">Modal header</param>
        /// <param name="content">Modal content</param>
        public void OpenModal(ModalType type, string header = null, string content = null)
        {
            if (modalsDict.ContainsKey(type))
            {
                var modal = modalsDict[type];

                if (!modal.IsActive)
                {
                    if (!PauseManager.instance.IsPaused)
                        PauseManager.instance.PauseGame();

                    modal.OpenModal(transform);
                    modal.window.SetText(header, content);
                }
            }
        }

        /// <summary>
        /// Closes modal defined by type parameter if opened
        /// </summary>
        /// <param name="type">Type of the modal to close</param>
        public void CloseModal(ModalType type)
        {
            if (modalsDict.ContainsKey(type))
            {
                var modal = modalsDict[type];

                if (modal.IsActive)
                {
                    if (PauseManager.instance.IsPaused)
                        PauseManager.instance.UnpauseGame();

                    modal.CloseModal();
                }
            }
        }

        /// <summary>
        /// Auxilary class that describes ModalWindow in current context
        /// </summary>
        [Serializable]
        private class ModalDesc
        {
            [NonSerialized]
            public GameObject instance;
            [NonSerialized]
            public ModalWindow window;

            public GameObject prefab;
            public ModalType type;

            public bool IsActive => instance != null;

            /// <summary>
            /// Creates an instance of modal defined in prefab
            /// </summary>
            /// <param name="parent">Parent of the modal</param>
            public void OpenModal(Transform parent)
            {
                instance = Instantiate(prefab, parent);
                window = instance.GetComponent<ModalWindow>();
            }

            /// <summary>
            /// Calls Close() function om modal and nullifies instance field
            /// </summary>
            public void CloseModal()
            {
                Destroy(instance);
                window = null;
                instance = null;
            }
        }
    }
}
