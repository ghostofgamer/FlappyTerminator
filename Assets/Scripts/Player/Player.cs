using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private float _score;
    private int _enemiesKilledCount;

    public event UnityAction<int> KilledCountChanged;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void Reset()
    {
        _score = 0f;
        _enemiesKilledCount = 0;
        _playerMover.ResetPosition();
        Time.timeScale = 1f;
    }

    public void AddKilledCount()
    {
        _enemiesKilledCount++;
        KilledCountChanged?.Invoke(_enemiesKilledCount);
    }

    public void Die()
    {
        Time.timeScale = 0f;
    }
}
