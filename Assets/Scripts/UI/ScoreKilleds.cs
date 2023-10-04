using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKilleds : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _player.KilledCountChanged += ChangeMurders;
    }

    private void OnDisable()
    {
        _player.KilledCountChanged -= ChangeMurders;
    }

    private void ChangeMurders(int countKilleds)
    {
        _score.text = countKilleds.ToString();
    }
}
