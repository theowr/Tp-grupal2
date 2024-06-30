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
            Vector3 spawnPosition = transform.position; 
            GameObject spawnedObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity);

            spawnedObject.transform.localScale *= 100f;
        }
    }
}