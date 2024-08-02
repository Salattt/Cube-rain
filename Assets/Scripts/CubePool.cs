using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _quantity;
    [SerializeField] private float _minReleaseCountdown;
    [SerializeField] private float _maxReleaseCountdown;

    private List<Cube> _cubes = new List<Cube>();

    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
        FillCubeList();
    }

    public bool TryGetCube(out Cube cube)
    {
        cube = null;

        if(_cubes.Count > 0)
        {
            cube = _cubes[0];

            cube.Destroyed += OnCubeDestroyed;

            _cubes.Remove(cube);
            cube.GameObject.SetActive(true);

            return true;
        }
         
        return false;
    }

    private void OnCubeDestroyed(Cube cube)
    {
        StartCoroutine(ReleaseCountdown(cube));
    }

    private void FillCubeList()
    {
        Cube newCube;

        for (int i = 0; i < _quantity; i++)
        {
            newCube = Instantiate(_prefab, _position, Quaternion.identity);

            _cubes.Add(newCube);
            newCube.GameObject.SetActive(false);
        }
    }

    private IEnumerator ReleaseCountdown(Cube cube)
    {
        yield return new WaitForSeconds(Random.Range(_minReleaseCountdown, _maxReleaseCountdown));

        ReleaseCube(cube);
    }

    private void ReleaseCube(Cube cube)
    {
        cube.Destroyed -= OnCubeDestroyed;

        cube.Transform.position = _position;

        _cubes.Add(cube);
        cube.ReturnToDefault();
        cube.gameObject.SetActive(false);
    }
}
