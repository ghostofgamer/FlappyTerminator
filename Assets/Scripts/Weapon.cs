using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _countBullets;
    [SerializeField]private Transform _container;

    private ObjectPool<Bullet> _bullets;

    private void Start()
    {
        _bullets = new ObjectPool<Bullet>(_bullet, _countBullets, _container.transform);
        _bullets.GetAutoExpand(_autoExpand);
    }

    public void Init(Transform container)
    {
        _container = container;
    }

    public void Shoot()
    {
        if (_bullets.TryGetObject(out Bullet _bullet, this._bullet))
            _bullet.Init(_shootPosition);
    }

    public void ResetBullet()
    {
        _bullets.Reset();
    }
}
