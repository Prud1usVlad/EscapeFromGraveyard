
using Assets.Scripts.EventSystem;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Ineractibles
{
    /// <summary>
    /// Implements logic of the doors
    /// </summary>
    public class Doors : Interactible
    {
        [SerializeField]
        private GameEvent escaped;
        [SerializeField]
        private GameEvent cantEscape;
        [SerializeField]
        private GameState state;

        /// <summary>
        /// Checks amount of collected keys and makes Interactible throw corresponding events
        /// </summary>
        protected override void Activate()
        {
            if (state.MaxKeys == state.collectedKeys)
            {
                activationEvent = escaped;
            }
            else
            {
                activationEvent = cantEscape;
            }
        }
    }
}
