using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _countBullets;

    private BulletContainer _container;

    private ObjectPool<Bullet> _bullets;

    private void Start()
    {
        _container = FindObjectOfType<BulletContainer>();
        _bullets = new ObjectPool<Bullet>(_bullet, _countBullets, _container.transform);
        _bullets.GetAutoExpand(_autoExpand);
    }

    public void Shoot()
    {
        if (_bullets.TryGetObject(out Bullet _bullet, this._bullet))
        {
            _bullet.Init(_shootPosition);
        }
    }

    public void ResetBullet()
    {
        _bullets.ResetPool();
    }
}
