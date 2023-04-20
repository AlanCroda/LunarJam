using DG.Tweening;
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
    private bool canMove = true;
    private int lives = 1;

    private void Start()
    {
        controls = new Controls();
        controls.Player.Enable();
        rb = GetComponent<Rigidbody2D>();
        DeathUI.instance.OnPlayerDied += () =>
        {
            if (GameManager.instance.GetState() == GameState.Arcade)
            {
                GetComponent<PlanetData>().SwitchPreviousMoon();
                lives--;
                if (lives <= 0)
                {
                    Instantiate(deathParticles, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            else
            {
                Instantiate(deathParticles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        };
        CountdownScript.instance.OnTimerEnd += () =>
        {
            if (GameManager.instance.GetState() == GameState.Arcade)
            {
                if (lives <= 4)
                {
                    GetComponent<PlanetData>().SwitchNextMoon();
                    lives++;
                    DeathUI.instance.AddLives();
                }
            }
            else
            {
                canMove = false;
                rb.velocity = Vector2.zero;
                transform.DOMove(new Vector3(3f, 0f, 0f), 1.5f);
            }
        };
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        objectSize = transform.GetComponent<CircleCollider2D>().radius;
    }

    private void FixedUpdate()
    {
        if(!canMove)
            return;
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
        if(!canMove)
            return;
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectSize, screenBounds.x - objectSize);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectSize, screenBounds.y - objectSize);
        transform.position = viewPos;
    }
}