using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> KilledChanged;

    public void Die()
    {
        gameObject.SetActive(false);
        KilledChanged?.Invoke(this);
    }
}
