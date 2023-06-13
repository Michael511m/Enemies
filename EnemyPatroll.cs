using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] float movespeed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(-1f, 0f) * movespeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PatrollPoint"))
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -1f, 1f) * -1f, 0f) * movespeed;
            transform.localScale = new Vector3(Mathf.Clamp(rb.velocity.x, -1f, 1f) * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Hp hp = collision.gameObject.GetComponent<Hp>();
            if (hp != null)
            {
                hp.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }

    public void SetVelocityToZero()
    {
        rb.velocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        
    }
}
