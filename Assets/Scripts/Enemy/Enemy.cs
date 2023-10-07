using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> Dying;

    public void Die()
    {
        gameObject.SetActive(false);
        Dying?.Invoke(this);
    }
}
