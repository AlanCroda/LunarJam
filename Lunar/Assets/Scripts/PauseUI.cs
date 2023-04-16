using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LunarJam
{
    public class PauseUI : MonoBehaviour
    {
        private bool isPaused = false;
        [SerializeField] private GameObject pauseUI;

        private void Update()
        {
            if(DeathUI.instance.IsDead())
                return;
            if (isPaused)
            {
                if (Keyboard.current.escapeKey.wasPressedThisFrame)
                    UnPause();
                else if(Keyboard.current.qKey.wasPressedThisFrame)
                    DeathUI.instance.QuitToMenu();
            }
            else if (Keyboard.current.escapeKey.wasPressedThisFrame)
                Pause();
            
        }

        public void Pause()
        {
            pauseUI.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }

        public void UnPause()
        {
            pauseUI.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}
