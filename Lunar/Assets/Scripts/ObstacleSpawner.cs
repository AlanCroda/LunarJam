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
    private List<GameObject> obstacles = new List<GameObject>();

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
        for (int i = 0; i < amount; i++)
        {
            var randX = Random.Range(minRange.x, maxRange.x);
            var randY = Random.Range(minRange.y, maxRange.y);
            var pos = new Vector3(randX, randY, 0);
            var obj = Instantiate(obstacle, pos, Quaternion.identity);
            obstacles.Add(obj);
            obj.GetComponent<obstacle>().SetSpawner(this);
        }
    }

    public void DestroyObstacle(GameObject obs)
    {
        obstacles.Remove(obs);
        Destroy(obs);
    }
}
