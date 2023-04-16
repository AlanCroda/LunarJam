using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LunarJam
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private bool isEnd;
        [SerializeField] private List<CutsceneData> cutscenes;
        [SerializeField] private Image cutsceneImage;
        [SerializeField] private TMP_Text cutsceneText;
        [SerializeField] private Image tutorialImage;
        private int currentIndex = -1;
        private bool tutorialClickThrough = false;

        private void Awake()
        {
            NextCutscene();
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
                NextCutscene();
        }

        private void NextCutscene()
        {
            if (currentIndex == cutscenes.Count - 1)
            {
                if (!isEnd)
                {
                    tutorialImage.gameObject.SetActive(true);
                    if (tutorialClickThrough)
                    {
                        TransitionManager.instance.Fade(0.5f, () => { LoadLevel1(); });
                        return;
                    }

                    Invoke(nameof(EnableClick), 1f);
                    return;
                }
                
                TransitionManager.instance.Fade(0.5f, () =>
                {
                    if (isEnd)
                    {
                        SceneManager.LoadScene(0);
                        BGMusic.instance.ResetClip();
                    }
                });
                return;
            }

            currentIndex++;
            cutsceneImage.sprite = cutscenes[currentIndex].cutsceneSprite;
            cutsceneText.text = cutscenes[currentIndex].cutsceneText;
        }
        
        private void LoadLevel1() 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            BGMusic.instance.ChangeClip();
        }
        
        private void EnableClick()
        {
            tutorialClickThrough = true;
        }
    }
}
