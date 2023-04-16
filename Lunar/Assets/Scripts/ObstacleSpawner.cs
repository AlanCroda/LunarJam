using System.Collections.Generic;
using LunarJam;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    [SerializeField] private List<GameObject> levelPresets;
    [SerializeField] private int maxAreas = 5;

    private List<GameObject> spawnedAreas = new List<GameObject>();
    private Vector2 screenBounds;

    private void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(DeathUI.instance.IsDead())
            return;
        instance = this;
    }

    public void SpawnNextArea()
    {
        var pos = new Vector3(25f, 0f, 0);
        if (spawnedAreas.Count > 0)
            pos = new Vector3(spawnedAreas[spawnedAreas.Count - 1].transform.position.x + 15f, 0f, 0f);
        var rand = Random.Range(0, levelPresets.Count);
        var obj = Instantiate(levelPresets[rand], pos, Quaternion.identity);
        spawnedAreas.Add(obj);
    }
}
