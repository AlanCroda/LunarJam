using System;
using LunarJam;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CountdownScript : MonoBehaviour
{
    public static CountdownScript instance;

    [SerializeField] private TMP_Text text;
    [SerializeField] private float startingDelay = 1.25f;
    [SerializeField] private float startingTime = 10f;
    private float currentTime;

    public Action OnTimerEnd;
    private bool hasStarted = false;
    
    private void Awake()
    {
        currentTime = startingTime;
        instance = this;
        Invoke(nameof(StartTimer), startingDelay);

        if (GameManager.instance.GetState() == GameState.Story)
        {
            GameObject title = GameObject.FindWithTag("Title");
            title.GetComponent<CanvasGroup>().DOFade(0, startingDelay);
        }
    }

    private void StartTimer()
    {
        hasStarted = true;
    }
    
    private void Update()
    {
        if(DeathUI.instance.IsDead() || !hasStarted)
            return;
        if (currentTime - Time.deltaTime < 0) // Hit Zero
        {
            OnTimerEnd?.Invoke();
            if(GameManager.instance.GetState() == GameState.Arcade)
                currentTime = startingTime;
            else
            {
                hasStarted = false;
                return;
            }
        }

        currentTime -= Time.deltaTime;
        text.text = currentTime.ToString("0.00");
    }
}
