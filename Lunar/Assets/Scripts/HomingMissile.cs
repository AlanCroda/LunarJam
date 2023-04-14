using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class HomingMissile : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] private float speed;
        [SerializeField] private float homingStrength;
        private Transform target;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = -Vector3.right * speed;
            target = GameObject.FindObjectOfType<PlayerController>().transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 distance = target.position - transform.position;
            float forceMagnitude = homingStrength/(distance.magnitude * distance.magnitude);
            rb.AddForce(distance * forceMagnitude);
        }
    }
}
