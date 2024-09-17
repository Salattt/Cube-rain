using System;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] protected ObjectPool Pool;

    public event Action ObjectSpawned;

    public int SpawnQuantity { get; private set; } = 0;

    public void OnObjectDestroyed(SpawnebleObject spawnebleObject)
    {
        spawnebleObject.Destroyed -= OnObjectDestroyed;
        
        Pool.Return(spawnebleObject);
    }

    protected void Spawn(Vector3 position)
    {
        T spawnebleObject = (T)Pool.Get();

        spawnebleObject.Destroyed += OnObjectDestroyed;

        spawnebleObject.Transform.position = position;

        OnSpawn(spawnebleObject);

        SpawnQuantity++;

        ObjectSpawned?.Invoke();
    }

    protected virtual void OnSpawn(T spawnedObject)
    {

    }
}
