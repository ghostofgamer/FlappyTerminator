using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _containerEnemy;
    [SerializeField] private Transform _containerBullet;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private int _count;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Player _player;

    private float _timeToNextSpawn = 3f;
    private float _elapsedTime = 0f;

    private ObjectPool<Enemy> _pool;

    private void Start()
    {
        _pool = new ObjectPool<Enemy>(_enemyPrefabs, _count, _containerEnemy);
        _pool.GetAutoExpand(_autoExpand);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeToNextSpawn)
        {
            var randomIndex = Random.Range(0, _enemyPrefabs.Length);

            if (_pool.TryGetObject(out Enemy enemy, _enemyPrefabs[randomIndex]))
            {
                _elapsedTime = 0f;
                float positionY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 spawnPosition = new Vector3(transform.position.x, positionY, transform.position.z);
                enemy.Dying += OnEnemyDiyng;
                enemy.GetComponent<Weapon>().Init(_containerBullet);
                enemy.transform.position = spawnPosition;
                _pool.DisableObjectAbroadScreen();
            }
        }
    }

    public void ResetGame()
    {
        _pool.Reset();
    }

    private void OnEnemyDiyng(Enemy enemy)
    {
        _player.AddKilledCount();
        enemy.Dying -= OnEnemyDiyng;
        enemy.GetComponent<Weapon>().ResetBullet();
    }
}
