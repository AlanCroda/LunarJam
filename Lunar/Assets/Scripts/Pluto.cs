using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarJam
{
    public class Pluto : MonoBehaviour
    {
        [SerializeField] private float finalX;
        [SerializeField] private float duration;

        private void Start()
        {
            CountdownScript.instance.OnTimerEnd += () =>
            {
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
