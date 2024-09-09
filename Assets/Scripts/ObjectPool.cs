using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private SpawnebleObject _prefab;
    [SerializeField] private int _quantity;
    [SerializeField] private float _minReleaseCountdown;
    [SerializeField] private float _maxReleaseCountdown;
    [SerializeField] private BombSpawner _additionalSubscriber;

    private List<SpawnebleObject> _objects = new List<SpawnebleObject>();

    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
        FillList();
    }

    public bool TryGet(out SpawnebleObject spawnebleObject)
    {
        spawnebleObject = null;

        if(_objects.Count > 0)
        {
            spawnebleObject = _objects[0];

            if (_additionalSubscriber != null)
            {
                spawnebleObject.Destroyed += _additionalSubscriber.OnObjectDestroyed;
            }

            spawnebleObject.Destroyed += OnObjectDestroyed;

            _objects.Remove(spawnebleObject);
            spawnebleObject.GameObject.SetActive(true);
            spawnebleObject.Construct(Random.Range(_minReleaseCountdown,_maxReleaseCountdown));

            return true;
        }
         
        return false;
    }

    private void FillList()
    {
        SpawnebleObject spawnebleObject;

        for (int i = 0; i < _quantity; i++)
        {
            spawnebleObject = Instantiate(_prefab, _position, Quaternion.identity);

            _objects.Add(spawnebleObject);
            spawnebleObject.GameObject.SetActive(false);
        }
    }

    private void OnObjectDestroyed(SpawnebleObject spawnebleObject)
    {
        spawnebleObject.Destroyed -= OnObjectDestroyed;


        spawnebleObject.Transform.position = _position;

        _objects.Add(spawnebleObject);
        spawnebleObject.ReturnToDefault();
        spawnebleObject.gameObject.SetActive(false);
    }
}
