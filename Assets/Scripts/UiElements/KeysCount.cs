using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UiElements
{
    /// <summary>
    /// Simple class defining logic for managing keys counter
    /// </summary>
    public class KeysCount : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI currentKeys;
        [SerializeField]
        private TextMeshProUGUI maxKeys;
        [SerializeField]
        private GameState gameState;

        public void UpdateCount()
        {
            currentKeys.SetText(gameState.collectedKeys.ToString());
            maxKeys.SetText(gameState.MaxKeys.ToString());
        }
    }
}
