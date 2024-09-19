using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// ScriptableObject to freely transfer and sync common data across the game
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/GameState")]
    public class GameState : ScriptableObject
    {
        [SerializeField]
        private int maxKeys;

        public int collectedKeys = 0;
        public float timer;

        public int MaxKeys => maxKeys;

        /// <summary>
        /// Resets game state
        /// </summary>
        public void ClearState()
        {
            collectedKeys = 0;
            timer = 0;
        }

        private void OnEnable()
        {
            collectedKeys = 0;
            timer = 0;
        }
    }
}
