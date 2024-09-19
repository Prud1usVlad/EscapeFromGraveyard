using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    /// <summary>
    /// Abstraction of audio source with randomized clips 
    /// </summary>
    public class AudioController : MonoBehaviour
    {
        private AudioSource audioSource;
        
        // Audio clips initialized from inspector
        [SerializeField]
        private List<AudioClip> clips;
        [SerializeField]
        private bool playCycled = false;
        [SerializeField]
        private float playDelay = 5;

        public void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            if (playCycled)
            {
                StartCoroutine(PlayCycledRoutine());
            }
        }

        /// <summary>
        /// Plays one of AudioClips provided to component
        /// </summary>
        public void PlayRandom()
        {
            audioSource.PlayOneShot(GetRandom(clips));
        }

        /// <summary>
        /// Returns random clip from provided list
        /// </summary>
        /// <param name="clips">List from wich to pick</param>
        /// <returns>Picked Clip</returns>
        private AudioClip GetRandom(List<AudioClip> clips)
        {
            return clips[Random.Range(0, clips.Count)];
        }


        /// <summary>
        /// Coroutine based mechanism to play one clip repeatedly
        /// </summary>
        /// <returns>IEnumerator for Coroutine</returns>
        private IEnumerator PlayCycledRoutine()
        {
            var wait = new WaitForSeconds(playDelay);

            while(true) 
            {
                yield return wait;

                PlayRandom();
            }
        }
    }
}
