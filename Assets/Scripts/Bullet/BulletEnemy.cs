using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    private readonly float _speed = 10f;
    private Coroutine _changer;

    private void OnEnable()
    {
        _changer = StartCoroutine(BulletsActive());
    }

    private void OnDisable()
    {
        if (_changer != null)
            StopCoroutine(_changer);
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(transform.right * -_speed * Time.deltaTime);
    }

    private IEnumerator BulletsActive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
