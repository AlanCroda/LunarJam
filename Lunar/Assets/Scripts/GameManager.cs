using UnityEngine;

namespace LunarJam
{
    public enum GameState
    {
        Story,
        Arcade
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private GameState state;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SwitchGameStates(GameState newState)
        {
            state = newState;
        }

        public GameState GetState()
        {
            return state;
        }
    }
}
