using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private float currentTime;
    private float startingTime = 9.9f;

    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {
        currentTime -= Time.deltaTime;
        text.text = currentTime.ToString("0.0");
    }
}
