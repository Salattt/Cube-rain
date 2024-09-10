using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private SpawnebleObject _prefab;
    [SerializeField] private int _quantity;
    [SerializeField] private float _minReleaseCountdown;
    [SerializeField] private float _maxReleaseCountdown;

    private List<SpawnebleObject> _objects = new List<SpawnebleObject>();

    private Vector3 _position;

    public event Action ObjectReleased;
    public event Action ObjectInstantiate;

    private void Awake()
    {
        _position = transform.position;
        FillList();
    }

    public SpawnebleObject Get()
    {
        SpawnebleObject spawnebleObject;

        if (_objects.Count > 0)
        {
            spawnebleObject = _objects[0];

            _objects.Remove(spawnebleObject);
            spawnebleObject.GameObject.SetActive(true);
        }
        else
        {
            spawnebleObject = Instantiate(_prefab, _position, Quaternion.identity);
            ObjectInstantiate?.Invoke();
        }

        spawnebleObject.Destroyed += OnObjectDestroyed;

        spawnebleObject.Construct(Random.Range(_minReleaseCountdown,_maxReleaseCountdown));

        return spawnebleObject;
    }

    private void FillList()
    {
        SpawnebleObject spawnebleObject;

        for (int i = 0; i < _quantity; i++)
        {
            spawnebleObject = Instantiate(_prefab, _position, Quaternion.identity);

            _objects.Add(spawnebleObject);
            spawnebleObject.GameObject.SetActive(false);
            ObjectInstantiate?.Invoke();
        }
    }

    private void OnObjectDestroyed(SpawnebleObject spawnebleObject)
    {
        spawnebleObject.Destroyed -= OnObjectDestroyed;


        spawnebleObject.Transform.position = _position;

        _objects.Add(spawnebleObject);
        spawnebleObject.ReturnToDefault();
        spawnebleObject.gameObject.SetActive(false);

        ObjectReleased?.Invoke();
    }
}
