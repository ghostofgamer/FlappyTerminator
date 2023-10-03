using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected ShootPoint ShootPoint;

    public void Init(ShootPoint shootPoint)
    {
        ShootPoint = shootPoint;
    }

    protected abstract void Move();
}