using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected ObjectPool _pool;
    [SerializeField] protected PointSpawner _spawner;

    public event Action ObjectSpawned;

    protected void Spawn(Vector3 position)
    {
        SpawnebleObject spawnebleObject = _pool.Get();

        if(_spawner != null)
            spawnebleObject.AlmostDestroyed += _spawner.OnObjectDestroyed;

        spawnebleObject.Transform.position = position;

        ObjectSpawned?.Invoke();
    }
}
