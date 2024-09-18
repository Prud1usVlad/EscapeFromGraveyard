using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EventSystem
{
    /// <summary>
    /// Description of ScriptableObject wich acts as event 
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/GameEvent", fileName = "Event")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        protected readonly List<IGameEventListener> eventListeners =
            new List<IGameEventListener>();

        public void Raise(Object parameter = null)
        {
            Debug.Log($"Event {name} raised");
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(parameter);
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
