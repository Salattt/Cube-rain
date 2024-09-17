public class BombSpawner : Spawner<Bomb>
{
    public void OnObjectAlmostDestroyed(Cube cube)
    {
        cube.AlmostDestroyed -= OnObjectAlmostDestroyed;

        Spawn(cube.Transform.position);
    }
}
