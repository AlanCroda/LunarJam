using DG.Tweening;
using LunarJam;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float size = 1.0f;
    [SerializeField] private arrow temporaryArrow;
    private arrow cloneArrow;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -Vector3.right * speed;
        transform.DOScale(transform.localScale * size, 0);
    }

    private void Update()
    {
        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CameraShake.instance.Shake();
            DeathUI.instance.ShowDeathUI();
            OnPlayerCollision(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("ArrowTrigger") && this is HomingMissile)
        {
            cloneArrow = Instantiate(temporaryArrow, new Vector3(8.25f, gameObject.transform.position.y), Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            OnPlayerCollision(other.gameObject);
        if (other.gameObject.CompareTag("ArrowTrigger"))
        {
            temporaryArrow.transform.position = new Vector3(temporaryArrow.transform.position.x, transform.position.y, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ArrowTrigger") && cloneArrow != null)
        {
            Destroy(cloneArrow.gameObject);
        }
    }

    protected virtual void OnPlayerCollision(GameObject player)
    {

    }
}
