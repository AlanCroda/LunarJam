using System.Collections;
using UnityEngine;

namespace LunarJam
{
    public class SpawnTrigger : MonoBehaviour
    {
        [SerializeField] private float spawnDelay;
        private float spawnTime;

        private void Awake()
        {
            spawnTime = 0;
        }

        private void Update()
        {
            spawnTime -= Time.deltaTime;
            if(spawnTime < 0)
            {
                spawnTime = spawnDelay;
                SpawnPreset();
            }
        }

        private void SpawnPreset()
        {
            ObstacleSpawner.instance.SpawnNextArea();
        }
    }
}
