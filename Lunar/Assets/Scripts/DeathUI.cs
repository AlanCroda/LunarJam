using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace LunarJam
{
    public class DeathUI : MonoBehaviour
    {
        public static DeathUI instance;
        [SerializeField] private GameObject deathUI;
        [SerializeField] private float timeBeforeActivation = 1.5f;
        [SerializeField] private float fadeSpeed = 1f;

        private bool isDeathUIActive = false;
        public Action OnPlayerDied;
        private int lives = 1;

        private void Awake()
        {
            instance = this;
        }

        public void ShowDeathUI()
        {
            lives--;
            OnPlayerDied?.Invoke();
            if (lives <= 0)
            {
                Invoke(nameof(ActivateDeathUI), timeBeforeActivation);
                isDeathUIActive = true;
            }
        }

        public void AddLives()
        {
            lives++;
        }
        
        private void ActivateDeathUI()
        {
            deathUI.SetActive(true);
        }

        private void Update()
        {
            if (deathUI.activeSelf)
            {
                if(Keyboard.current.rKey.wasPressedThisFrame)
                    Restart();
                else if(Keyboard.current.qKey.wasPressedThisFrame)
                    QuitToMenu();
            }
        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void QuitToMenu()
        {
            Time.timeScale = 1;
            TransitionManager.instance.Fade(fadeSpeed, () =>
            {
                BGMusic.instance.ResetClip();
                SceneManager.LoadScene(0);
            });
        }

        public bool IsDead()
        {
            return isDeathUIActive;
        }
    }
}
