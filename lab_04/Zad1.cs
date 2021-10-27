using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    private int objectCounter = 0;
    [SerializeField]
    public int objectNumber = 5;
    // obiekt do generowania
    public GameObject block;
    public Material[] materials = new Material[5];

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        var gameobjectsize = meshRenderer.bounds;
        while (positions.Count <= objectNumber)
        {
            Vector3 randomposition = new Vector3(Random.Range(gameobjectsize.min.x, gameobjectsize.max.x), 1, Random.Range(gameobjectsize.min.z, gameobjectsize.max.z));
            if (!positions.Contains(randomposition)) {
                this.positions.Add(randomposition);
            }
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            var gameobject = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            gameobject.GetComponent<MeshRenderer>().material = this.materials[Random.Range(0, this.materials.Length)];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
