using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Transform[] _bullets;

    private void Start()
    {
        _bullets = new Transform[_container.childCount];

        for (int i = 0; i < _bullets.Length; i++)
        {
            _bullets[i] = _container.GetChild(i);
        }
    }

    public void ResetBullet()
    {
        foreach (var bullet in _bullets)
        {
            Debug.Log("выкл");
            bullet.gameObject.SetActive(false);
        }
    }
}
