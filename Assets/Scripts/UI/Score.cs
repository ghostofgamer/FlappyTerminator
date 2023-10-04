using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreTxt;

    private float _score;
    private readonly float _speed = 16f;

    private void OnEnable()
    {
        _player.ResetScore += Reset;
    }

    private void OnDisable()
    {
        _player.ResetScore -= Reset;
    }

    private void Update()
    {
        _score += _speed * Time.deltaTime;
        _scoreTxt.text = _score.ToString("0");
    }

    private void Reset()
    {
        _score = 0f;
    }
}
