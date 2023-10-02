using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected ShootPoint ShootPoint;

    protected abstract void Move();
}
