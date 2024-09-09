using System.Collections;
using UnityEngine;

public class BombSpawner : Spawner
{
    public void OnObjectDestroyed(SpawnebleObject spawnebleObject)
    {
        spawnebleObject.Destroyed -= OnObjectDestroyed;
        Spawn(spawnebleObject.Transform.position);
    }
}
