using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private TMP_Text survivedForText;

        private bool isDeathUIActive = false;
        public Action OnPlayerDied;
        private int lives = 1;
        private float timer;

        private void Awake()
        {
            instance = this;
        }

        public void ShowDeathUI()
        {
            lives--;
            OnPlayerDied?.Invoke();
            if (GameManager.instance.GetState() == GameState.Arcade)
            {
                if (survivedForText != null)
                    survivedForText.text = $"SURVIVED FOR {timer:0.00}";
            }
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
                if (Keyboard.current.rKey.wasPressedThisFrame)
                    Restart();
                else if (Keyboard.current.qKey.wasPressedThisFrame)
                    QuitToMenu();
            }
            else
                timer += Time.deltaTime;
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
