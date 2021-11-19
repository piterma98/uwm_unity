using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float Speed = 2f;
    public float x = 2;
    private bool withPlayer = false;
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private Transform oldParent;

    void Start()
    {
        StartPosition = transform.position;
        EndPosition = StartPosition - new Vector3(x, 0, 0);

    }

    void Update()
    {
        if (withPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPosition, Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPosition, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withPlayer = false;
        }
    }
}
