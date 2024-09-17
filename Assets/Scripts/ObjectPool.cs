using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float _minReleaseCountdown;
    [SerializeField] private float _maxReleaseCountdown;
    [SerializeField] private SpawnebleObjectFabrick _fabric;

    private List<SpawnebleObject> _objects = new List<SpawnebleObject>();

    private Vector3 _position;

    public event Action ObjectReleased;
    public event Action ObjectInstantiate;

    public int InitiatedObjects { get; private set; } = 0;
    public int ReleasedObjects { get; private set; } = 0;

    private void Awake()
    {
        _position = transform.position;
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
            spawnebleObject = _fabric.Instantiate();

            InitiatedObjects++;

            ObjectInstantiate?.Invoke();
        }

        spawnebleObject.Construct(Random.Range(_minReleaseCountdown,_maxReleaseCountdown));

        return spawnebleObject;
    }

    public void Return(SpawnebleObject spawnebleObject)
    {
        spawnebleObject.Transform.position = _position;

        _objects.Add(spawnebleObject);
        spawnebleObject.ReturnToDefault();
        spawnebleObject.gameObject.SetActive(false);

        ReleasedObjects++;

        ObjectReleased?.Invoke();
    }
}
