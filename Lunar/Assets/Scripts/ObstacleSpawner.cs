using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector2 minRange;
    [SerializeField] private Vector2 maxRange;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float amountToSpawn;
    [SerializeField] private float distancePerObstacle = 1;
    private float spawnTimer;
    private float lastY = 0f;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Spawn(amountToSpawn);
            spawnTimer = timeBetweenSpawns;
        }
    }

    private void Spawn(float amount)
    {
        var lastY = -999f;
        for (int i = 0; i < amount; i++)
        {
            var randY = 0f;
            if (lastY != -999f)
            {
                var rand = Random.Range(0, 2);
                if(rand == 0)
                    randY = Random.Range(minRange.y, lastY + distancePerObstacle);
                else
                    randY = Random.Range(minRange.y, lastY - distancePerObstacle);
            }
            else
                randY = Random.Range(minRange.y, maxRange.y);
            var randX = Random.Range(minRange.x, maxRange.x);
            lastY = randY;
            var pos = new Vector3(randX, randY, 0);
            var obj = Instantiate(obstacle, pos, Quaternion.identity);
        }
    }
}
