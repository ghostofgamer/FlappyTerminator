using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected ShootPoint _shootPoint;

    protected abstract void Move();
}
