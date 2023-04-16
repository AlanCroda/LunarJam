using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class BGMusic : MonoBehaviour
    {
        public static BGMusic instance;
        private AudioSource musicSource;
        [SerializeField] private AudioClip musicClip;
        private AudioClip defaultClip;
    
        void Awake()
        {
            if (instance != null && instance != this) {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource = GetComponent<AudioSource>();
            defaultClip = musicSource.clip;
        }

        public void ChangeClip()
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    
        public void ResetClip()
        {
            musicSource.clip = defaultClip;
            musicSource.Play();
        }
    }

}
