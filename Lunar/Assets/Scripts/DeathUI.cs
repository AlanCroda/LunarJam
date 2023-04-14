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
        [SerializeField] private float fadeSpeed = 1f;

        private bool isDeathUIActive = false;

        private void Awake()
        {
            instance = this;
        }

        public void ShowDeathUI()
        {
            deathUI.SetActive(true);
            isDeathUIActive = true;
        }

        private void Update()
        {
            if (isDeathUIActive)
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            });
        }
    }
}
