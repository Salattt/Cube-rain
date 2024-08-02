using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private float _spawnTime;

    private Transform _transform;
    private BoxCollider _collider;
    private float _timer = 0f;

    private void Awake()
    {
        _transform = transform;
        _collider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _spawnTime)
        {
            _timer = 0f;

            Spawn();
        }
    }

    private void Spawn()
    {
        if(_pool.TryGetCube(out Cube cube))
        {
            cube.Transform.position = GetRandomSpawnPosition();
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(_transform.position.x - _collider.size.x /2, _transform.position.x + _collider.size.x / 2), Random.Range(_transform.position.y - _collider.size.y / 2, _transform.position.y + _collider.size.y / 2),
            Random.Range(_transform.position.z - _collider.size.z / 2, _transform.position.z + _collider.size.z / 2));
    }
}
