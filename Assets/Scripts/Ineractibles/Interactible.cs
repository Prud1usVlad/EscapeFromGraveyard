using Assets.Scripts.Audio;
using Assets.Scripts.EventSystem;
using UnityEngine;

namespace Assets.Scripts.Ineractibles
{
    /// <summary>
    /// Abstract class for different interactible objects like keys or traps
    /// </summary>
    public abstract class Interactible : MonoBehaviour
    {
        protected Animator animator;
        protected AudioController sounds;

        [SerializeField]
        protected GameEvent activationEvent;

        protected abstract void Activate();

        private void Start()
        {
            animator = GetComponent<Animator>();
            sounds = GetComponent<AudioController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                activationEvent.Raise();
                Activate();
            }
        }
    }
}
