using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_2 : MonoBehaviour
{
    public Vector3 targetPos1;
    public Vector3 targetPos2;
    [SerializeField]
    public float speed = 1f;
    public bool firstMove;

    void Start()
    {
        firstMove = true;
        targetPos1 = transform.position;
        targetPos2 = transform.position;
        targetPos2.x += 10;
    }

    void Update()
    {
        if (transform.position == targetPos1)
        {
            firstMove = false;
        }
        if (transform.position == targetPos2)
        {
            firstMove = true;
        }
        if (firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed * Time.deltaTime);
        }
    }
}
