using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float enemyBulletSpeed = 5f;
    [SerializeField] float bulletDestroyTime = 3f;
    int attack = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * -1 * enemyBulletSpeed;
        Destroy(gameObject, bulletDestroyTime);
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
