using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : MonoBehaviour
{
    [SerializeField] float enemyBulletSpeed = 5f;
    int attack = 2;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up *-1* enemyBulletSpeed;
       
        Destroy(gameObject, 6f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hp hp = collision.gameObject.GetComponent<Hp>();
        if (hp != null)
        {
            hp.TakeDamage(attack);
        }

        Destroy(gameObject);
    }

}
