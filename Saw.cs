using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] int sawAttack = 9;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hp hp = collision.gameObject.GetComponent<Hp>();
        if(hp!=null)
        {
            hp.TakeDamage(sawAttack);
        }
    }
}
