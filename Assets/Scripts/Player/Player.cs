using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;

    public int EnemiesKilledCount { get; private set; }

    public event UnityAction<int> KilledCountChanged;
    public event UnityAction ResetScore;
    public event UnityAction GameOver;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void Reset()
    {
        ResetScore?.Invoke();
        EnemiesKilledCount = 0;
        KilledCountChanged?.Invoke(EnemiesKilledCount);
        _playerMover.ResetPosition();
    }

    public void AddKilledCount()
    {
        EnemiesKilledCount++;
        KilledCountChanged?.Invoke(EnemiesKilledCount);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
