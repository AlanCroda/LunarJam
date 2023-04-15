using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LunarJam
{
    public enum GameState
    {
        Story,
        Arcade
    }
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        public static GameManager instance;
        private GameState state;
        private float volume;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                AudioListener.volume = volume;
            };
            volume = 1;
        }

        public void SwitchGameStates(GameState newState)
        {
            state = newState;
        }

        public GameState GetState()
        {
            return state;
        }

        public float GetVolume()
        {
            return volume;
        }

        public void OnVolumeSliderValueChanged(float newValue)
        {
            volume = newValue;
            AudioListener.volume = volume;
        }
    }
}
