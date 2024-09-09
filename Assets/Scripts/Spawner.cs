using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected ObjectPool _pool;

    protected void Spawn(Vector3 position)
    {
        if (_pool.TryGet(out SpawnebleObject spawnebleObject))
        {
            spawnebleObject.Transform.position = position;
        }
    }
}
