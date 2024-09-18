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

        private void Awake()
        {
            modalsDict = modals.ToDictionary(m => m.type);
        }

        /// <summary>
        /// Triggers modal defined by type parameter (activates or destroyes it if active)
        /// </summary>
        /// <param name="type">Type of the modal to trigger</param>
        /// <param name="header">Modal header</param>
        /// <param name="content">Modal content</param>
        public void TriggerModal(ModalType type, string header = null, string content = null)
        {
            if (modalsDict.ContainsKey(type))
            {
                var modal = modalsDict[type];

                if (modal.IsActive)
                {
                    modal.CloseModal();
                }
                else
                {
                    modal.OpenModal(transform);
                    modal.window.SetText(header, content);
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
                window.Close();
                instance = null;
            }
        }
    }
}
