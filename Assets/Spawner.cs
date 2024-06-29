using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Objetos;

    void Start()
    {
        SpawnRandomObject();
    }

    void SpawnRandomObject()
    {
        if (Objetos.Length > 0)
        {
            int randomIndex = Random.Range(0, Objetos.Length);
            GameObject selectedObject = Objetos[randomIndex];

            GameObject spawnedObject = Instantiate(selectedObject, transform.position, Quaternion.identity);

            // Scale the spawned object to 4 times its original size
            spawnedObject.transform.localScale *= 20f;
        }
        else
        {
            Debug.LogWarning("No objects in the array to spawn.");
        }
    }
}