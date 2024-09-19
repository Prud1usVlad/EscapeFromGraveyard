using UnityEngine;

namespace Assets.Scripts.EventSystem
{
    public interface IGameEventListener
    {
        void OnEventRaised(string parameter = null);
    }
}
