using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UiElements
{
    /// <summary>
    /// Simple class for managing game timer
    /// </summary>
    internal class Timer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI timerText;
        [SerializeField]
        private GameState gameState;

        public void UpdateTimer()
        {
            gameState.timer += Time.deltaTime;
            var sec = (int)gameState.timer % 60;
            var min = (int)(gameState.timer - sec) / 60;

            timerText.SetText($"{min}:{sec}");
        }
    }
}
