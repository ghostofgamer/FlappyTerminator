using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;

    private readonly float _xOffset = -10f;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _xOffset, transform.position.y, transform.position.z);
    }
}
