using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LunarJam
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private List<CutsceneData> cutscenes;
        [SerializeField] private Image cutsceneImage;
        [SerializeField] private TMP_Text cutsceneText;
        private int currentIndex = -1;

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
                TransitionManager.instance.Fade(0.5f, () =>
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    BGMusic.instance.ChangeClip();
                });
                return;
            }

            currentIndex++;
            cutsceneImage.sprite = cutscenes[currentIndex].cutsceneSprite;
            cutsceneText.text = cutscenes[currentIndex].cutsceneText;
        }
    }
}
