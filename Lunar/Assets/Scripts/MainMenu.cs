using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LunarJam
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string gameplaySceneName = "Imated Scene";
        [SerializeField] private float fadeSpeed = 1f;

        private void Update()
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        public void PlayStory()
        {
            GameManager.instance.SwitchGameStates(GameState.Story);
            Play();
        }
        
        public void PlayArcade()
        {
            GameManager.instance.SwitchGameStates(GameState.Arcade);
            Play();
        }
        
        private void Play()
        {
            TransitionManager.instance.Fade(fadeSpeed, () =>
            {
                SceneManager.LoadScene(gameplaySceneName);
            });
        }

        public void Quit()
        {
            TransitionManager.instance.Fade(fadeSpeed, Application.Quit);
        }
    }
}
