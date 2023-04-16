using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LunarJam
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string gameplaySceneName = "Imated Scene";
        [SerializeField] private string cutsceneSceneName = "Intro Cutscene";
        [SerializeField] private string arcadeSceneName = "Arcade";
        [SerializeField] private float fadeSpeed = 1f;

        private void Update()
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        public void PlayStory()
        {
            GameManager.instance.SwitchGameStates(GameState.Story);
            Play(cutsceneSceneName);
        }
        
        public void PlayArcade()
        {
            GameManager.instance.SwitchGameStates(GameState.Arcade);
            BGMusic.instance.ChangeClip();
            Play(arcadeSceneName);
        }
        
        private void Play(string scene)
        {
            TransitionManager.instance.Fade(fadeSpeed, () =>
            {
                SceneManager.LoadScene(scene);
            });
        }

        public void Quit()
        {
            TransitionManager.instance.Fade(fadeSpeed, Application.Quit);
        }

        public void OpenURL(string person)
        {
            switch (person)
            {
                case "imated":
                    Application.OpenURL("https://imated.itch.io/");
                    break;
                case "static":
                    Application.OpenURL("https://staticvoidgd.itch.io/");
                    break;
                case "radu":
                    Application.OpenURL("https://rradu.itch.io/");
                    break;
                case "thxrst":
                    Application.OpenURL("https://thxrst.itch.io/");
                    break;
                case "lun":
                    Application.OpenURL("https://lunartix.itch.io/");
                    break;
            }
        }
    }
}
