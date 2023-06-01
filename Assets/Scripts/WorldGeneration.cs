using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] private int initialSpawnCount = 10;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float spawnIntervall = 3f;
    [SerializeField] private int maxWorldObjects = 20;

    [SerializeField] private List<GameObject> worldObjects = new List<GameObject>();

    private float elapsedTimeSinceLastSpawn = 0;

    private void Start()
    {
        InitializeWorld();
    }

    private void Update()
    {
        HandleWorldObjectSpawn();
    }

    private void InitializeWorld()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnRandomPrefab();
        }
    }

    private void HandleWorldObjectSpawn()
    {
        elapsedTimeSinceLastSpawn += Time.deltaTime;
        if (elapsedTimeSinceLastSpawn >= spawnIntervall)
        {
            SpawnRandomPrefab();
            elapsedTimeSinceLastSpawn = 0f;
        }
    }

    private void SpawnRandomPrefab()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[prefabIndex];

        Vector3 spawnPoint = Vector3.zero;
        spawnPoint.z = worldObjects.Last().transform.position.z + (prefab.transform.localScale.z * 10) / 2 + (worldObjects.Last().transform.localScale.z * 10) / 2;

        GameObject createdObject = Instantiate( 
            prefab,
            spawnPoint,
            new Quaternion(0, 0, 0, 0),
            transform
            );
        worldObjects.Add(createdObject);
        
        CleanupWorldObjects();
    }

    private void CleanupWorldObjects()
    {
        while (worldObjects.Count > maxWorldObjects)
        {
            Destroy(worldObjects.First());
            worldObjects.RemoveAt(0);
        }
    }
}
