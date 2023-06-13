using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTriggerScript : MonoBehaviour
{
    public EnemyFollow[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(EnemyFollow enemy in enemyArray)
            {
                enemy.follow = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (EnemyFollow enemy in enemyArray)
            {
                enemy.follow = false;
            }
        }
    }
}
