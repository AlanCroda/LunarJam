using UnityEngine;

namespace LunarJam
{
    public class SpawnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Obstacle"))
            {
                ObstacleSpawner.instance.SpawnNextArea();
            }
        }
    }
}
