using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Transform _container;
    private Camera _camera;
    private T _prefab;
    private T[] _prefabs;

    private List<T> _poolGeneric;

    public bool AutoExpand { get; private set; }

    public ObjectPool(T prefab, int count, Transform container)
    {
        _prefab = prefab;
        _container = container;
        Initialization(count, prefab);
    }

    public ObjectPool(T[] prefab, int count, Transform container)
    {
        _prefabs = prefab;
        _container = container;
        Initialization(count, prefab);
    }

    private void Initialization(int count, T prefabs)
    {
        _camera = Camera.main;
        _poolGeneric = new List<T>();

        for (int i = 0; i < count; i++)
        {
            var spawned = Object.Instantiate(prefabs, _container.transform);
            spawned.gameObject.SetActive(false);
            _poolGeneric.Add(spawned);
        }
    }
    private void Initialization(int count, T[] prefabs)
    {
        _camera = Camera.main;
        _poolGeneric = new List<T>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            var spawned = Object.Instantiate<T>(prefabs[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);
            _poolGeneric.Add(spawned);
        }
    }

    public bool TryGetObject(out T spawned, T prefabs)
    {
        var filter = _poolGeneric.Where(p => p.gameObject.activeSelf == false);
        var index = Random.Range(0, filter.Count());

        if (filter.Count() == 0 && AutoExpand)
        {
            spawned = CreateObject(prefabs);
            return spawned != null;
        }

        spawned = filter.ElementAt(index);
        spawned.gameObject.SetActive(true);
        return spawned != null;
    }

    private T CreateObject(T prefabs)
    {
        var spawned = Object.Instantiate<T>(prefabs, _container.transform);
        spawned.gameObject.SetActive(true);
        _poolGeneric.Add(spawned);
        return spawned;
    }

    public void GetAutoExpand(bool flag)
    {
        AutoExpand = flag;
    }

    public void DisableObjectAbroadScreen()
    {
        foreach (var item in _poolGeneric)
        {
            if (item.gameObject.activeSelf == true)
            {
                Vector3 point = _camera.WorldToViewportPoint(item.transform.position);

                if (point.x < 0)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _poolGeneric)
            item.gameObject.SetActive(false);
    }
}
