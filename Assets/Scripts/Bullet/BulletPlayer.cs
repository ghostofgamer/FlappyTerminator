using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    private readonly float _speed = 15f;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }
}
