using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class ArrowTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Obstacle"))
            {

            }
        }
    }
}
