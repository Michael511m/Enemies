using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaff : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform aim;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] ParticleSystem eps;


    void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, aim.position, Quaternion.identity);
        eps.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("StartShooting", 0.5f, shootDelay);

            EnemyPatrol enemyPatrol = GetComponentInParent<EnemyPatrol>();

            if(enemyPatrol != null)
            {
                enemyPatrol.SetVelocityToZero();
            }

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
