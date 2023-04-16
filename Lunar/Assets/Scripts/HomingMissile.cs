using DG.Tweening;
using UnityEngine;

namespace LunarJam
{
    public class HomingMissile : Obstacle
    {
        [SerializeField] private float homingStrength;
        private Transform target;

        private void Start()
        {
            target = FindObjectOfType<PlayerController>()?.transform;
        }
        
        private void FixedUpdate()
        {
            if(target != null)
            {
                if(target.position.x < transform.position.x)
                {
                    Vector3 distance = target.position - transform.position;
                    float forceMagnitude = homingStrength / (distance.magnitude * distance.magnitude);
                    rb.AddForce(distance * forceMagnitude);
                }
                transform.rotation = Quaternion.LookRotation(Vector3.forward * 500, rb.velocity);
            }
        }
    }
}
