using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts.EventSystem
{
    /// <summary>
    /// MonoBehaviour wich can be added to GameObjects in order to register to different events
    /// </summary>
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with.")]
        public GameEvent @event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<string> response;

        private void OnEnable()
        {
            @event.RegisterListener(this);
        }

        private void OnDisable()
        {
            @event.UnregisterListener(this);
        }

        public void OnEventRaised(string parameter)
        {
            response?.Invoke(parameter);
        }
    }
}
