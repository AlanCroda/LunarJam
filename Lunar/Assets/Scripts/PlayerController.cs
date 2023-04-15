using LunarJam;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject deathParticles;
    
    internal float speed;
    internal float acceleration;
    internal float deceleration;
    private Vector2 movementInput;
    private Vector2 screenBounds;
    private float objectSize;
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
        CountdownScript.instance.OnTimerEnd += () =>
        {
            GetComponent<PlanetData>().SwitchNextMoon();
        };
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        objectSize = transform.GetComponent<CircleCollider2D>().radius;
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

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectSize, screenBounds.x - objectSize);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectSize, screenBounds.y - objectSize);
        transform.position = viewPos;
    }
}