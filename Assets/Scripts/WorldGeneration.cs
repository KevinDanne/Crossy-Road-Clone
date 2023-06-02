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
    [SerializeField] private int _initialSpawnCount = 10;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnIntervall = 1f;
    [SerializeField] private int _maxWorldObjects = 20;

    [SerializeField] private List<GameObject> _worldObjects = new List<GameObject>();

    private float _elapsedTimeSinceLastSpawn = 0;

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
        for (int i = 0; i < _initialSpawnCount; i++)
        {
            SpawnRandomPrefab();
        }
    }

    private void HandleWorldObjectSpawn()
    {
        _elapsedTimeSinceLastSpawn += Time.deltaTime;
        if (_elapsedTimeSinceLastSpawn >= _spawnIntervall)
        {
            SpawnRandomPrefab();
            _elapsedTimeSinceLastSpawn = 0f;
        }
    }

    private void SpawnRandomPrefab()
    {
        int prefabIndex = UnityEngine.Random.Range(0, _prefabs.Length);
        GameObject prefab = _prefabs[prefabIndex];

        Vector3 spawnPoint = Vector3.zero;
        spawnPoint.z = _worldObjects.Last().transform.position.z + (prefab.transform.localScale.z * 10) / 2 + (_worldObjects.Last().transform.localScale.z * 10) / 2;

        GameObject createdObject = Instantiate( 
            prefab,
            spawnPoint,
            new Quaternion(0, 0, 0, 0),
            transform
            );
        _worldObjects.Add(createdObject);
        
        CleanupWorldObjects();
    }

    private void CleanupWorldObjects()
    {
        while (_worldObjects.Count > _maxWorldObjects)
        {
            Destroy(_worldObjects.First());
            _worldObjects.RemoveAt(0);
        }
    }
}
