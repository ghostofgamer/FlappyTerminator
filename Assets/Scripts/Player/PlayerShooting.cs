using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _weapon.Shoot();
        }
    }
}
