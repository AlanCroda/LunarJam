using UnityEngine;

namespace LunarJam
{
    public class HomingMissile : Obstacle
    {
        [SerializeField] private float homingStrength;
        private Transform target;

        private void Start()
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
        
        private void FixedUpdate()
        {
            Vector3 distance = target.position - transform.position;
            float forceMagnitude = homingStrength/(distance.magnitude * distance.magnitude);
            rb.AddForce(distance * forceMagnitude);
        }
    }
}
