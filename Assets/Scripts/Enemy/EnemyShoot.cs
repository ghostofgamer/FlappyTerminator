using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private float _currentTime = 0f;

    private readonly float _timeToNextShoot = 1f;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeToNextShoot)
        {
            _currentTime = 0f;
            _weapon.Shoot();
        }
    }
}
