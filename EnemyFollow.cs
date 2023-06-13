using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    [SerializeField] Transform player;
    public bool follow = false;
    public Transform startingPoint;
    public Vector3 offset;
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        if(player!=null)
        {
            if (follow == true)
            {
                Follow();
            }
            else
            {
                ReturnPoint();
            }
        }
        else
        {
            return;
        }
    }
    private void Follow()
    {
        Vector3 desiredPos = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
    }
    private void ReturnPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.fixedDeltaTime);
    }
}
