using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    private readonly float _speed = 10f;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(transform.right * -_speed * Time.deltaTime);
    }
}
