using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private readonly float _speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.right * -_speed * Time.deltaTime);
    }
}
