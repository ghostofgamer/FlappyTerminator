using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private Coroutine _coroutine;

    private readonly float _timeToNextShoot = 1f;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(DoShoot());
    }

    private IEnumerator DoShoot()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeToNextShoot);

        while (true)
        {
            yield return waitForSeconds;
            _weapon.Shoot();
        }
    }
}
