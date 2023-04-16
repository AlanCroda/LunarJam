using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
            musicSource.DOFade(0f, 0.5f).OnComplete(() =>
            {
                musicSource.clip = musicClip;
                musicSource.Play();
                musicSource.DOFade(1f, 0.5f);
            });
        }
    
        public void ResetClip()
        {
            musicSource.DOFade(0f, 0.5f).OnComplete(() =>
            {
                musicSource.clip = defaultClip;
                musicSource.Play();
                musicSource.DOFade(1f, 0.5f);
            });
        }
    }

}
