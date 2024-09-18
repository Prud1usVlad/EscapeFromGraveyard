using UnityEngine;

namespace Assets.Scripts.EventSystem
{
    public interface IGameEventListener
    {
        void OnEventRaised(Object parameter = null);
    }
}
