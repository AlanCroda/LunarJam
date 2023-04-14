using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector2 minRange;
    [SerializeField] private Vector2 maxRange;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float amountToSpawn;
    private float spawnTimer;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            for (var i = 0; i < amountToSpawn; i++)
                Spawn();
            spawnTimer = timeBetweenSpawns;
        }
    }

    private void Spawn()
    {
        var randX = Random.Range(minRange.x, maxRange.x);
        var randY = Random.Range(minRange.y, maxRange.y);
        var obj = Instantiate(obstacle, new Vector3(randX, randY, 0f), Quaternion.identity);
    }
}
