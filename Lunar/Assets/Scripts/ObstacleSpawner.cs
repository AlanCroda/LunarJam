using System.Collections.Generic;
using LunarJam;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    [SerializeField] private WeightedGameObjectList levelPresets;
    [SerializeField] private int maxAreas = 5;

    private List<GameObject> spawnedAreas = new List<GameObject>();
    private Vector2 screenBounds;

    private void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        SpawnNextArea();
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
        var obj = Instantiate(levelPresets.GetRandomObject(), pos, Quaternion.identity);
        spawnedAreas.Add(obj);
    }
}
