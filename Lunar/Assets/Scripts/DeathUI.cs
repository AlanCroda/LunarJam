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
        [SerializeField] private TMP_Text scoreText;

        private bool isDeathUIActive = false;
        public Action OnPlayerDied;
        private int lives = 1;
        private float timer;
        private float hits = 0;
        private float finalScore;

        private void Awake()
        {
            instance = this;
        }

        public void ShowDeathUI()
        {
            lives--;
            hits++;
            OnPlayerDied?.Invoke();
            if (GameManager.instance.GetState() == GameState.Arcade)
            {
                finalScore = Mathf.Round(timer) * 100 - hits * 100;
                if (survivedForText != null)
                    survivedForText.text = $"TIME: {timer:0.00}";
                if (scoreText != null)
                    scoreText.text = $"SCORE: {finalScore:0}";
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
