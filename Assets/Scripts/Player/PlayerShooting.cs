using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _weapon.Shoot();
        }
    }
}
