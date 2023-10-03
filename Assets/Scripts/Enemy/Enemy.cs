using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private EnemyContainer _container;

    private void Start()
    {
        _container = GetComponent<EnemyContainer>();
    }

    public void Die()
    {
        _container.ResetBullet();
        gameObject.SetActive(false);
    }
}
