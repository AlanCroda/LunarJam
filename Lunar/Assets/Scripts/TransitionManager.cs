using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace LunarJam
{
    public class TransitionManager : MonoBehaviour
    {
        public static TransitionManager instance;
        
        [SerializeField] private Image fadeImage;
        private bool isFading;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        public void Fade( float duration, Action onComplete)
        {
            if(isFading)
                return;
            isFading = true;
            fadeImage.DOFade(1f, duration).OnComplete(() =>
            {
                onComplete?.Invoke();
                fadeImage.DOFade(0f, duration).OnComplete(() => isFading = false);
            });
        }
    }
}
