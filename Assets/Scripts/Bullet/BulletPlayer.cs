using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    private readonly float _speed = 15f;

    private void Start()
    {
        ShootPoint = FindObjectOfType<ShootPoint>();
        transform.rotation = ShootPoint.transform.rotation;
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }

    public void Init(ShootPoint shootPoint)
    {
        ShootPoint = shootPoint;
    }
}
