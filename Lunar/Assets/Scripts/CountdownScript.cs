using LunarJam;
using UnityEngine;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float startingTime = 10f;
    private float currentTime;

    private void Awake()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (currentTime - Time.deltaTime < 0) // Hit Zero
        {
            if (GameManager.instance.GetState() == GameState.Arcade)
                currentTime = startingTime;
            else
                return;
        }

        currentTime -= Time.deltaTime;
        text.text = currentTime.ToString("0.00");
    }
}
