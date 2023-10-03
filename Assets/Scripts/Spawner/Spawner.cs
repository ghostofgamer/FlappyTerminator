using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private float _timeToNextSpawn = 3f;
    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialization(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeToNextSpawn)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                _elapsedTime = 0f;
                float positionY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 spawnPosition = new Vector3(transform.position.x, positionY, transform.position.z);
                enemy.SetActive(true);
                enemy.transform.position = spawnPosition;
                DisableObjectAbroadScreen();
            }
        }
    }
}
