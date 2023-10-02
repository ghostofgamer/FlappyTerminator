using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private float _score;
    private float _enemiesKilledCount;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void Reset()
    {
        _score = 0f;
        _enemiesKilledCount = 0f;
        _playerMover.ResetPosition();
        Time.timeScale = 1f;
    }

    public void Die()
    {
        Time.timeScale = 0f;
    }
}
