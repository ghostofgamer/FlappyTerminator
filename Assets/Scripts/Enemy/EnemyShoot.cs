using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private Coroutine _coroutine;

    private readonly float _timeToNextShoot = 1f;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DoShoot());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
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
