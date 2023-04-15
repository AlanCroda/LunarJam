using LunarJam;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject deathParticles;
    
    internal float speed;
    internal float acceleration;
    internal float deceleration;
    private Vector2 movementInput;

    private Controls controls;
    internal Rigidbody2D rb;

    private void Start()
    {
        controls = new Controls();
        controls.Player.Enable();
        rb = GetComponent<Rigidbody2D>();
        DeathUI.instance.OnPlayerDied += () =>
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        };
    }

    private void FixedUpdate()
    {
        movementInput = controls.Player.Move.ReadValue<Vector2>();
        movementInput.Normalize();
        if (movementInput.magnitude > 0)
        {
            rb.velocity += movementInput * acceleration;
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), Mathf.Clamp(rb.velocity.y, -speed, speed));
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * deceleration);
        }
    }
}