using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public void Init(Transform shootPoint)
    {
        transform.position = shootPoint.transform.position;
        transform.rotation = shootPoint.transform.rotation;
    }

    protected abstract void Move();
}