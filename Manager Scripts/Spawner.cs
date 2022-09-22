using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public float timeToSpawn;
    private float currentSpawnTime;

    void Start()
    {
    }

    void Update()
    {
        if (currentSpawnTime > 0)
        {
            currentSpawnTime -= Time.deltaTime;
        }
        else
        {
            SpawnPrefab();
            currentSpawnTime = timeToSpawn;
        }
    }

    public void SpawnPrefab()
    {
        Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);
    }
}
