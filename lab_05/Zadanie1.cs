using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{
    public float Speed = 2f;
    private bool isForward = false;
    private bool withPlayer = false;
    private Vector3 StartPosition;
    public Vector3 EndPosition;
    private Transform oldParent;

    void Start()
    {
        StartPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (withPlayer)
        {
            if (isForward)
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPosition, Speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, StartPosition, Speed * Time.deltaTime);
            }
            GetDirection();
        }
    }

    private void GetDirection()
    {
        if (transform.position == EndPosition)
        {
            isForward = false;
        }
        else if (transform.position == StartPosition)
        {
            isForward = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            withPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withPlayer = false;
            other.gameObject.transform.parent = oldParent;
        }
    }
}
