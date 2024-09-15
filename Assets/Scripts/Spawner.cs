using System;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] protected ObjectPool _pool;

    public event Action ObjectSpawned;

    public int SpawnQuantity { get; private set; } = 0;

    protected  void Spawn(Vector3 position)
    {
        T spawnebleObject = (T)_pool.Get();

        spawnebleObject.Transform.position = position;

        OnSpawn(spawnebleObject);

        SpawnQuantity++;

        ObjectSpawned?.Invoke();
    }

    protected virtual void OnSpawn(T spawnedObject)
    {

    }
}
