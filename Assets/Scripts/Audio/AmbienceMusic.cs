using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    /// <summary>
    /// Class used to play music, uses coroutines to replay one track
    /// </summary>
    public class AmbienceMusic : MonoBehaviour
    {
        private AudioSource music;

        // Audio clips initialized from inspector
        [SerializeField]
        private AudioClip musicClip;

        public void Awake()
        {
            music = GetComponent<AudioSource>();
            StartCoroutine(MusicPlayerRoutine());
        }

        /// <summary>
        /// Describes routine to start and replay ambience music clip
        /// </summary>
        /// <returns> IEnumerator to use in Coroutine </returns>
        private IEnumerator MusicPlayerRoutine()
        {
            var wait = new WaitForSeconds(1);

            while (true)
            {
                if (!music.isPlaying)
                {
                    music.PlayOneShot(musicClip);
                }

                yield return wait;
            }
        }
    }
}
