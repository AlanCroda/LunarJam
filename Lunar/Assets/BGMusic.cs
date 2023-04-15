using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class BGMusic : MonoBehaviour
    {
        private AudioSource musicSource;
        [SerializeField] private AudioClip musicClip;
        public static BGMusic instance;
        void Start()
        {
            musicSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        public void ChangeClip()
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }
}
