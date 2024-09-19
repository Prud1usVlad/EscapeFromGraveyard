using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Ineractibles
{
    /// <summary>
    /// Class defines behaviour of the keys
    /// </summary>
    public class Key : Interactible
    {
        [SerializeField]
        private GameState gameState;

        protected override void Activate()
        {
            gameState.collectedKeys++;
            sounds.PlayRandom();
            Destroy(gameObject, 0.2f);
        }
    }
}
