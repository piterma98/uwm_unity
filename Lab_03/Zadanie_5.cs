using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_5 : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        List <(float, float)> coordinates_list = new List<(float, float)>();
        (float, float) coordinates_pair;
        while (coordinates_list.Count < 10)
        {
            coordinates_pair.Item1= Random.Range(-10.0f, 10.0f);
            coordinates_pair.Item2= Random.Range(-10.0f, 10.0f);
            if (!coordinates_list.Contains(coordinates_pair))
            {
                coordinates_list.Add(coordinates_pair);
                Instantiate(myPrefab, new Vector3(coordinates_pair.Item1, 1, coordinates_pair.Item2), Quaternion.identity);
            }
        }
    }
}
