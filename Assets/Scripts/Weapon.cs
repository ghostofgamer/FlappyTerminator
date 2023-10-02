using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;

    public void Shoot(/*bool playerShoot*/)
    {
        var bullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity);
        //bullet.CheckWhoFired(playerShoot);
    }
}
