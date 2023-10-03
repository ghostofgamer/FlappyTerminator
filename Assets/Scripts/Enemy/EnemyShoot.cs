using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private readonly float _timeToNextShoot = 1f;
    private float _currentTime = 0f;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeToNextShoot)
        {
            _weapon.Shoot();
            _currentTime = 0f;
        }
    }
}
