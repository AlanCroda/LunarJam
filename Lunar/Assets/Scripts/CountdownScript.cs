using System;
using LunarJam;
using UnityEngine;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    public static CountdownScript instance;

    [SerializeField] private TMP_Text text;
    [SerializeField] private float startingTime = 10f;
    private float currentTime;

    public Action OnTimerEnd;
    
    private void Awake()
    {
        currentTime = startingTime;
        instance = this;
    }

    private void Update()
    {
        if(DeathUI.instance.IsDead())
            return;
        if (currentTime - Time.deltaTime < 0) // Hit Zero
        {
            OnTimerEnd?.Invoke();
            currentTime = startingTime;
        }

        currentTime -= Time.deltaTime;
        text.text = currentTime.ToString("0.00");
    }
}
