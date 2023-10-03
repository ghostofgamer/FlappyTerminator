using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private ShootPoint _shootPositions;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _bulletContainer;
    [SerializeField] private Spawner _spawner;

    public void Shoot()
    {
        var bullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity, _bulletContainer.transform);
        bullet.Init(_shootPositions);
    }
}
