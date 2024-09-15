using System.Collections;
using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    public void OnObjectDestroyed(Cube Cube)
    {
        Cube.AlmostDestroyed -= OnObjectDestroyed;
        Spawn(Cube.Transform.position);
    }
}
