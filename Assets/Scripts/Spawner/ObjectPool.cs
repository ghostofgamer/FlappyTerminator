using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private int _capacity = 30;
    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialization(GameObject[] prefabs)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialization(GameObject prefabs)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefabs, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out GameObject enemy)
    {
        var filter = _pool.Where(p => p.activeSelf == false);
        var index = Random.Range(0, filter.Count());
        enemy = filter.ElementAt(index);
        return enemy != null;
    }

    public bool TryGetBullet(out GameObject bullet, bool playerBullet)
    {
        if (playerBullet)
        {
            var filter = _pool.Where(p => p.activeSelf == false && p.GetComponent<BulletPlayer>());
            bullet = filter.FirstOrDefault();
            return bullet != null;
        }
        else
        {
            var filter = _pool.Where(p => p.activeSelf == false && p.GetComponent<BulletEnemy>());
            bullet = filter.FirstOrDefault();
            return bullet != null;
        }
    }

    protected void DisableObjectAbroadScreen()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 point = _camera.WorldToViewportPoint(item.transform.position);

                if (point.x < 0)
                    item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }
}
