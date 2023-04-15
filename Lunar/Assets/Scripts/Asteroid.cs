using UnityEngine;

namespace LunarJam
{
    public class Asteroid : Obstacle
    {
        [SerializeField] private float amplitude = 1f;
        [SerializeField] private float frequency = 1f;
        [SerializeField] private float sineSpeed = 25f;

        protected override void Awake()
        {
            base.Awake();
            //sineSpeed = Random.Range(sineSpeed - 2f, sineSpeed + 3f);
        }
        
        private void Update()
        {
            var newY = transform.position.y + amplitude * Mathf.Sin(Time.time * frequency);
            var newVel = new Vector2(rb.velocity.x, (newY - transform.position.y) * sineSpeed);
            rb.velocity = newVel;
        }
    }
}
