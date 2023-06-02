using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _minSpawnIntervalRange = 2f;
    [SerializeField] private float _maxSpawnIntervalRange = 8f;


    private float _timeElapsedSinceLastSpawn;
    private float _spawnInterval;

    private void Start()
    {
        _spawnInterval = GetRandomSpawnInterval();
        SpawnCar();
    }

    private void Update()
    {
        _timeElapsedSinceLastSpawn += Time.deltaTime;
        if (_timeElapsedSinceLastSpawn >= _spawnInterval)
        {
            SpawnCar();
            _timeElapsedSinceLastSpawn = 0;
            _spawnInterval = GetRandomSpawnInterval();
        }
    }

    private void SpawnCar()
    {
        int prefabIndex = Random.Range(0, _prefabs.Length);
        GameObject prefab = _prefabs[prefabIndex];
        
        Instantiate(prefab, transform.position + new Vector3(0, prefab.transform.localScale.y /2, 0), transform.rotation, transform.parent);
    }

    private float GetRandomSpawnInterval()
    {
        return Random.Range(_minSpawnIntervalRange, _maxSpawnIntervalRange + 1);
    }
}
