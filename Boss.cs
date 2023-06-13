using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject flamePrefab;
    Vector2 throwDir;
    void Start()
    {
        ChoseNextAttack();
    }



    void ChoseNextAttack()
    {
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            StartCoroutine(Wait());
        }
        else
        {
            StartCoroutine(Throw());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        ChoseNextAttack();
    }

    IEnumerator Throw()
    {
        GameObject flame = Instantiate(flamePrefab, transform.position, Quaternion.identity);
        throwDir = new Vector2(Random.Range(-30f, -16f), Random.Range(7f, 15f));
        flame.GetComponent<Rigidbody2D>().AddForce(throwDir, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        ChoseNextAttack();
    }

}
