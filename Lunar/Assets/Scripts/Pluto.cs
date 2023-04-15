using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarJam
{
    public class Pluto : MonoBehaviour
    {
        [SerializeField] private AudioClip arriveSound;
        [SerializeField] private float finalX;
        [SerializeField] private float duration;

        private AudioSource source;
        
        private void Awake()
        {
            source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
        }
        
        private void Start()
        {
            CountdownScript.instance.OnTimerEnd += () =>
            {
                source.clip = arriveSound;
                source.Play();
                transform.DOMoveX(finalX, duration).OnComplete(() =>
                {
                    Invoke(nameof(LoadNextScene), 1f);
                });
            };
        }

        private void LoadNextScene()
        {
            TransitionManager.instance.Fade(1f, () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });
        }
    }
}
