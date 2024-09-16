using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    // Abstraction of audio source with randomized clips 
    public class AudioController : MonoBehaviour
    {
        private AudioSource audioSource;
        
        // Audio clips initialized from inspector
        [SerializeField]
        private List<AudioClip> clips;

        public void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayRandom()
        {
            audioSource.PlayOneShot(GetRandom(clips));
        }

        private AudioClip GetRandom(List<AudioClip> clips)
        {
            return clips[Random.Range(0, clips.Count)];
        }
    }
}
