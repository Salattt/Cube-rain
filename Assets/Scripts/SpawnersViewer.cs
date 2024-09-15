using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnersViewer : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private ObjectPool _cubePool;
    [SerializeField] private ObjectPool _bombPool;
    [SerializeField] private TextMeshProUGUI _cubeSpawnedInfo;
    [SerializeField] private TextMeshProUGUI _cubeActiveInfo;
    [SerializeField] private TextMeshProUGUI _cubeInstantiateInfo;
    [SerializeField] private TextMeshProUGUI _bombSpawnedInfo;
    [SerializeField] private TextMeshProUGUI _bombActiveInfo;
    [SerializeField] private TextMeshProUGUI _bombInstantiateInfo;

    private void OnEnable()
    {
        _cubeSpawner.ObjectSpawned += UpdateCubeActiveInfo;
        _cubeSpawner.ObjectSpawned += UpdateCubeSpawnedInfo;
        _cubePool.ObjectInstantiate += UpdateCubeInstantiateInfo;
        _cubePool.ObjectReleased += UpdateCubeActiveInfo;
        _bombSpawner.ObjectSpawned += UpdateBombActiveInfo;
        _bombSpawner.ObjectSpawned += UpdateBombSpawnedInfo;
        _bombPool.ObjectInstantiate += UpdateBombInstantiateInfo;
        _bombPool.ObjectReleased += UpdateBombActiveInfo;
    }

    private void OnDisable()
    {
        _cubeSpawner.ObjectSpawned -= UpdateCubeActiveInfo;
        _cubeSpawner.ObjectSpawned -= UpdateCubeSpawnedInfo;
        _cubePool.ObjectInstantiate -= UpdateCubeInstantiateInfo;
        _cubePool.ObjectReleased -= UpdateCubeActiveInfo;
        _bombSpawner.ObjectSpawned -= UpdateBombActiveInfo;
        _bombSpawner.ObjectSpawned -= UpdateBombSpawnedInfo;
        _bombPool.ObjectInstantiate -= UpdateBombInstantiateInfo;
        _bombPool.ObjectReleased -= UpdateBombActiveInfo;
    }

    private void UpdateCubeSpawnedInfo()
    {
        _cubeSpawnedInfo.text = _cubeSpawner.SpawnQuantity.ToString();
    }

    private void UpdateCubeInstantiateInfo()
    {
        _cubeInstantiateInfo.text = _cubePool.InitiatedObjects.ToString();
    }

    private void UpdateCubeActiveInfo()
    {
        _cubeActiveInfo.text = (_cubeSpawner.SpawnQuantity - _cubePool.ReleasedObjects).ToString();
    }

    private void UpdateBombSpawnedInfo()
    {
        _bombSpawnedInfo.text = _bombSpawner.SpawnQuantity.ToString();
    }

    private void UpdateBombInstantiateInfo()
    {
        _bombInstantiateInfo.text = _bombPool.InitiatedObjects.ToString();
    }

    private void UpdateBombActiveInfo()
    {
        _bombActiveInfo.text = (_bombSpawner.SpawnQuantity - _bombPool.ReleasedObjects).ToString();
    }
}
