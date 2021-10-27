using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    public float minAngle = -90.0f;
    public float maxAngle = 90.0f;

    private float mouseXMove = 0.0f;
    private float mouseYMove = 0.0f;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseXMove += sensitivity * Time.deltaTime * Input.GetAxis("Mouse X");
        mouseYMove -= sensitivity * Time.deltaTime * Input.GetAxis("Mouse Y");

        mouseYMove = Mathf.Clamp(mouseYMove, minAngle, maxAngle);

        transform.eulerAngles = new Vector3(mouseYMove, mouseXMove, 0.0f);
    }
}