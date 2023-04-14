using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using LunarJam;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float size = 1.0f;
    
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -Vector3.right * speed;
        transform.DOScale(transform.localScale * size, 0);
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            DeathUI.instance.ShowDeathUI();
            Destroy(gameObject);
            OnPlayerCollision(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            OnPlayerCollision(other.gameObject);
    }

    protected virtual void OnPlayerCollision(GameObject player)
    {

    }
}
