using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plansza : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunningRight = false;
    private bool isRunningLeft = false;
    private int index = 0;
    private Vector3 leftPosition;
    public List<Vector3> rightPosition;


    void Start()
    {
        leftPosition = transform.position;
    }

    void FixedUpdate()
    {

        if (isRunningRight)
        {
            float maxDistanceDelta = elevatorSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, rightPosition[index], maxDistanceDelta);
            if (transform.position == rightPosition[index])
            {
                if (transform.position == rightPosition[rightPosition.Count - 1])
                {
                    isRunningLeft = true;
                    isRunningRight = false;
                }
                else
                {
                    index += 1;
                }
            }
        }
        if (isRunningLeft)
        {
            float maxDistanceDelta = elevatorSpeed * Time.deltaTime;
            if (index >= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, rightPosition[index], maxDistanceDelta);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, leftPosition, maxDistanceDelta);
            }
            if (transform.position == rightPosition[index])
            {
                index -= 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunningRight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunningRight = false;
            isRunningLeft = false;
        }
    }


}